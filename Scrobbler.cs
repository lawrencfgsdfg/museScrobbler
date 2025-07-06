using System;
using IF.Lastfm.Core;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using IF.Lastfm.Core.Scrobblers;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MelonLoader;
using UnityEngine.Assertions;

public class Scrobbler {
    static LastfmClient lastfm;

    public Scrobbler(LastfmClient lastfmClient) {
        lastfm = lastfmClient;
    }

    static String songName = "";
    static String artistName = "";

    static DateTime startTime;

    static bool shouldScrobble = false;

    public static void scrobble() {
        if (shouldScrobble) {
            lastfm.Scrobbler.ScrobbleAsync(new Scrobble(artistName, null, songName, startTime));
            MelonLogger.Msg("scrobbled: " + artistName + " - " + songName); ;
        }
        shouldScrobble = false;
    }

    public static void setListening(){
        lastfm.Track.UpdateNowPlayingAsync(new Scrobble(artistName, null, songName, startTime));
        MelonLogger.Msg("marked as now playing: " + artistName + " - " + songName); ;
    }

    // welp. i guess this is just not possible bruh
    //public static void setNotListening() {
    //}

    // setters
    public static void setMetadata(string song, string artist) {
        songName = song; artistName = artist;
    }
    public static void setStartTime(DateTime dateTime) {
        startTime = dateTime;
    }
    public static void setShouldScrobble(bool shouldScrobble_) {
        shouldScrobble = shouldScrobble_;
    }


}
