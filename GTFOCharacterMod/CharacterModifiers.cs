using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace GTFOCharacterMod;

[BepInPlugin("GTFOCharacterMod", "CharacterModifiers", "1.0.0")]
public class CharacterModifiers : BasePlugin
{
    public static ManualLogSource Logger { get; private set; }
    
    public override void Load()
    {
        Logger = Log;
        var harmony = new Harmony("GiginssCharacterMod");
        harmony.PatchAll(typeof(ModifierPatch));
        Log.LogInfo($"Character Modifiers Plugin is loaded!");
    }
}