using System.Reflection;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppSystem.Runtime.Remoting.Lifetime;
using MelonLoader;

using Object = Il2CppSystem.Object;


namespace museScrobbler.patches;

[HarmonyPatch()]
internal class PnlBattleOnPauseClickedPatch
{
    static MethodInfo TargetMethod()
    {
        var method = AccessTools.Method("PnlBattle:OnPauseClicked");
        return method;
    }

    // TODO: mods to directly restart/exit may skip this entirely
    private static void Postfix(PnlBattle __instance)
    {
        float progress = AudioManager.instance.bgm.time;
        float length = AudioManager.instance.bgm.clip.length;

        if (length > 29.9f){ // song is over 30s long
            if ((progress / length) > 0.49f || progress > 240) { // 50% scrobbled or more than 4 min passed
                Scrobbler.setShouldScrobble(true);
            }
        }
    }
}