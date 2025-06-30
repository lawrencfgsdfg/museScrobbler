using System;
using IF.Lastfm.Core;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MelonLoader;
using UnityEngine.Assertions;

public class Scrobbler {

    static LastfmClient lastfm;
    public Scrobbler(string apiKey, string apiSecret, string username, string password) {
        lastfm = new LastfmClient(apiKey, apiSecret);
        try {
            lastfm.Auth.GetSessionTokenAsync(username, password);
            MelonLogger.Msg("lastfm verification successful!");
        } catch (Exception e) {
            MelonLogger.Error("lastfm verification failed!");
            MelonLogger.Error(e.Message);
        }
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


    // hangs the game xd
    //static readonly AudioManager audioManager = Il2CppAssets.Scripts.PeroTools.Commons.Singleton<AudioManager>.instance;


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
