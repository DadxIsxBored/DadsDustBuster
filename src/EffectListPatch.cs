using HarmonyLib;
using UnityEngine;

namespace DadsDustBuster;

[HarmonyPatch(typeof(EffectList), nameof(EffectList.Create))]
internal static class EffectListCreatePatch
{
    private static void Postfix(GameObject[] __result)
    {
        if (!DadsDustBusterPlugin.ModEnabled.Value || __result == null) return;
        DustSuppressor.Suppress(__result);
    }
}
