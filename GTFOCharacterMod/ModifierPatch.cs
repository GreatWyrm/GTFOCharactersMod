using Agents;
using HarmonyLib;
using Player;
using System.Collections.Generic;
using UnityEngine;

namespace GTFOCharacterMod;

public class ModifierPatch
{
    private record ModifierDetails(AgentModifier Modifier, float Amount, bool Adds);

    private static List<ModifierDetails> modifiers = new()
    {
        new ModifierDetails(AgentModifier.ProjectileResistance, 0.05f, false), // Woods
        new ModifierDetails(AgentModifier.HealSupport, 0.1f, true), // Dauda
        new ModifierDetails(AgentModifier.StandardWeaponDamage, 0.05f, true), // Hackett
        new ModifierDetails(AgentModifier.HackingProficiency, 0.1f, true) // Bishop
    };
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AgentModifierManager), nameof(AgentModifierManager.ApplyModifier))]
    public static void PatchModifiers(Agent agent, AgentModifier modifier, float value, ref float __result)
    {
        PlayerAgent playerAgent = agent.TryCast<PlayerAgent>();
        if (playerAgent != null)
        {
            ModifierDetails details = modifiers[playerAgent.CharacterID];
            if (details.Modifier == modifier)
            {
                // Stack Additively, calculate current percentage
                float currentPercent = __result / value; // Example: 30% bonus = 1.3f, 30% resistance = 0.7f
                float newPercentage = details.Adds ? currentPercent + details.Amount : currentPercent - details.Amount; // Add if we're providing a bonus, subtract if we're providing a resistance (e.g. Projectile resistance)
                // Ensure valid bounds
                newPercentage = Mathf.Max(newPercentage, 0f);
                CharacterModifiers.Logger.LogInfo($"Applied change to {modifier} for player {playerAgent.CharacterID}. Old modifier amount: {currentPercent}, new modifier amount: {newPercentage}.");
                __result = newPercentage * value;
            }
        }
    }
}