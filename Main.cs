using System.Diagnostics;
using System.Net;
using System.Text.Json;
using HarmonyLib.Tools;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using MelonLoader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using File = System.IO.File;
using Path = System.IO.Path;

namespace museScrobbler
{
    class Config {
        public string apiKey { get; set; } = "";
        public string apiSecret { get; set; } = "";
    }

    public class Main : MelonMod
    {
        static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData", "lastfmConfig.json");
        static string sessionFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData", "lastfm.session");

        public override async void OnInitializeMelon()
        {
            Scrobbler scrobbler = new Scrobbler(await CreateScrobbler());
            LoggerInstance.Msg("museScrobbler initialized!");

            base.OnInitializeMelon();
        }

        // this is a chonker of a function
        public static async Task<LastfmClient> CreateScrobbler()
        {
            LastAuth auth;
            Config config;

            // read and get apiKey and apiSecret
            if (File.Exists(configPath)) {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
                MelonLogger.Msg("read lastfm config file");
            } else {
                config = new Config();
                File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
                MelonLogger.Msg("lastfm config file did not exist - it has been created");

                return null;
            }

            var apiKey = config.apiKey;
            var apiSecret = config.apiSecret;

            // if the session file exists
            if (File.Exists(sessionFile)) {
                // create auth from session
                auth = new LastAuth(apiKey, apiSecret);
                LastUserSession session = JsonConvert.DeserializeObject<LastUserSession>(File.ReadAllText(sessionFile));
                auth.LoadSession(session);

                MelonLogger.Msg("lastfm session file found");

                if(auth.Authenticated) {
                    MelonLogger.Msg("authenticated from lastfm session file successfully!");
                    return (new LastfmClient(auth));
                }
                else MelonLogger.Msg("authentication from session file unsuccessful!"); // continue
            }

            // if session file does not exist , we do all this stuff below ...

            int port = 54321;
            string doneUrl = $"http://localhost:{port}";

            // create http listener
            var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/");
            listener.Start();

            // url that user must open to authenticate
            string url = $"http://www.last.fm/api/auth/?api_key={apiKey}&cb={doneUrl}/";
            MelonLogger.Msg("user must authenticate - if not automatically opened, please open: \n" + url + "\n");

            // open in browser
            Process.Start(new ProcessStartInfo{ FileName = url, UseShellExecute = true });

            // wait for the page to open
            var context = await listener.GetContextAsync();

            // obtain token, which is appended at the end of the localhost URL
            // <callback_url>/?token=xxxxxxx
            var request = context.Request;
            string token = request.QueryString["token"];

            // wrap up localhost stuff
            var r = context.Response;
            var buffer = System.Text.Encoding.UTF8.GetBytes("you can close this tab now :3");
            r.ContentLength64 = buffer.Length;
            r.OutputStream.Write(buffer);
            r.OutputStream.Close();

            listener.Stop();

            // create auth
            auth = new LastAuth(apiKey, apiSecret);
            var resp = await auth.GetSessionTokenAsync(token);
            MelonLogger.Msg("lastfm auth success? " + auth.Authenticated);

            var lastfm = new LastfmClient(auth);

            // save the session to file, this will not need to be done again until session expires
            var json = JsonConvert.SerializeObject(auth.UserSession, Formatting.Indented);
            File.WriteAllText(sessionFile, json);

            return lastfm;
        }

    }
}
