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
internal class PnlFailAwakePatch
{
    static MethodInfo TargetMethod()
    {
        var method = AccessTools.Method("PnlFail:Awake");
        return method;
    }

    private static void Postfix(PnlBattle __instance)
    {
        float progress = AudioManager.instance.bgm.time;
        float length = AudioManager.instance.bgm.clip.length;

        Console.WriteLine("HERE " + progress + " " + length);

        // we have listened to more than half the song, so should scrobble
        if ((progress / length) > 0.49f) {
            Scrobbler.setShouldScrobble(true);
        }
    }
}