using System;
using UnityEngine;

namespace DadsDustBuster;

internal static class DustSuppressor
{
    private static readonly string[] NamedDustMarkers =
    {
        "sawdust",
        "dust"
    };

    private static readonly string[] PhysicalEffectMarkers =
    {
        "destroy",
        "tree",
        "log",
        "bush",
        "shrub",
        "beehive",
        "wood",
        "stone",
        "rock",
        "_cut",
        "_pick"
    };

    internal static void Suppress(GameObject[] effects)
    {
        foreach (GameObject effect in effects)
        {
            if (effect == null) continue;

            ParticleSystem[] particleSystems = effect.GetComponentsInChildren<ParticleSystem>(true);
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                if (!IsDustParticle(particleSystem, effect)) continue;

                ParticleSystem.EmissionModule emission = particleSystem.emission;
                emission.enabled = false;
                particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                particleSystem.Clear(true);

                ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
                if (renderer != null) renderer.enabled = false;
            }
        }
    }

    private static bool IsDustParticle(ParticleSystem particleSystem, GameObject effect)
    {
        Transform? current = particleSystem.transform;
        while (current != null)
        {
            if (ContainsAny(current.name, NamedDustMarkers)) return true;
            if (current == effect.transform) break;
            current = current.parent;
        }

        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        if (renderer == null) return false;

        foreach (Material material in renderer.sharedMaterials)
        {
            if (material == null) continue;
            if (IsDedicatedDustMaterial(material.name)) return true;
            if (IsPhysicalDustEffect(effect.name, material.name)) return true;
        }

        Material trailMaterial = renderer.trailMaterial;
        return trailMaterial != null && IsDedicatedDustMaterial(trailMaterial.name);
    }

    private static bool IsDedicatedDustMaterial(string materialName)
    {
        return materialName.IndexOf("build_fog", StringComparison.OrdinalIgnoreCase) >= 0 ||
               materialName.IndexOf("sawdust", StringComparison.OrdinalIgnoreCase) >= 0 ||
               materialName.IndexOf("dust_footstep", StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private static bool IsPhysicalDustEffect(string effectName, string materialName)
    {
        bool isGenericDustMaterial = materialName.IndexOf("dust_particle", StringComparison.OrdinalIgnoreCase) >= 0;
        return isGenericDustMaterial && ContainsAny(effectName, PhysicalEffectMarkers);
    }

    private static bool ContainsAny(string value, string[] markers)
    {
        foreach (string marker in markers)
        {
            if (value.IndexOf(marker, StringComparison.OrdinalIgnoreCase) >= 0) return true;
        }

        return false;
    }
}
