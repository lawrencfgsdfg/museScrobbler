using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.GameMain;
using Il2CppFormulaBase;
using MelonLoader;

using Object = Il2CppSystem.Object;


namespace museScrobbler.patches;

[HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.GameStart))]
internal class StageBattleComponentGameStartPatch
{
    // called on game start , after countdown
    private static void Postfix(StageBattleComponent __instance)
    {
        Scrobbler.setMetadata(MusicUtils.MusicName, MusicUtils.MusicAuthor);
        Scrobbler.setStartTime(DateTime.Now);
        Scrobbler.setListening();
    }
}