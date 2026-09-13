using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace DadsDustBuster;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInProcess("valheim.exe")]
public sealed class DadsDustBusterPlugin : BaseUnityPlugin
{
    public const string PluginGuid = "com.dadisbored.dadsdustbuster";
    public const string PluginName = "DadsDustBuster";
    public const string PluginVersion = "1.0.0";

    private Harmony? _harmony;
    internal static ConfigEntry<bool> ModEnabled { get; private set; } = null!;

    private void Awake()
    {
        ModEnabled = Config.Bind(
            "General",
            "Enabled",
            true,
            "Remove transient dust plumes created by building, dismantling, terrain tools, and other actions.");

        _harmony = new Harmony(PluginGuid);
        _harmony.PatchAll();
        Logger.LogInfo($"{PluginName} {PluginVersion} loaded.");
    }

    private void OnDestroy()
    {
        _harmony?.UnpatchSelf();
    }
}
