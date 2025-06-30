using HarmonyLib;
using Il2Cpp;
using MelonLoader;

using Object = Il2CppSystem.Object;


namespace museScrobbler.patches;

// yea it's kind of weird to subscribe to this method specifically but whatever
[HarmonyPatch(typeof(PnlVictory), nameof(PnlVictory.SetDetailInfo))]
internal class PnlVictorySetDetailInfoPatch
{
    private static void Postfix(PnlVictory __instance)
    {
        // we won the level , so scrobble
        Scrobbler.setShouldScrobble(true);
        Scrobbler.scrobble();

        // this is a hack because it will be called again on exit/restart
        // we don't want to scrobble twice

        // YES, in theory we could just setShouldScrobble(true) and avoid doing the scrobble above at all,
        // but i prefer immediate scrobbling and therefore , this hack
        Scrobbler.setShouldScrobble(false);


        //Scrobbler.setNotListening();
    }
}