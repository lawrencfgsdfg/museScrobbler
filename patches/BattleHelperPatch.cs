using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using MelonLoader;

namespace museScrobbler.patches;

[HarmonyPatch(typeof(BattleHelper), nameof(BattleHelper.BattleStart))]
// called on game exit
[HarmonyPatch(typeof(BattleHelper), nameof(BattleHelper.GameFinish))]
internal class BattleHelperGameFinishPatch
{
    private static void Postfix(PnlVictory __instance)
    {
        Scrobbler.scrobble();
        //Scrobbler.setNotListening();
    }
}

// called on restart
[HarmonyPatch(typeof(BattleHelper), nameof(BattleHelper.GameRestart))]
internal class BattleHelperGameRestartPatch
{
    private static void Postfix(PnlVictory __instance)
    {
        Scrobbler.scrobble();
    }
}