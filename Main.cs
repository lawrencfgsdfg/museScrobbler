using IF.Lastfm.Core.Api;
using MelonLoader;

using System.Reflection;

namespace museScrobbler
{
    public class Main : MelonMod
    {
        static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData", "lastfmConfig.ini");

        //private LastfmClient lastfmClient;

        public override void OnInitializeMelon()
        {
            // i had an entire method here before i learned about the Plugins folder
            // ts took me forever for no reason bruh  
            // i think having it there is cleaner than dynamically loading it ? maybe
            //AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

            if (!File.Exists(configPath)) {
                File.WriteAllLines(configPath, new[] {
                    "apiKey=",
                    "apiSecret=",
                    "username=", // ts plaintext  broken heart emoji
                    "password="
                });
                LoggerInstance.Msg("lastfm config file did not exist, so it has been created");
            } else {
                string apiKey, apiSecret, username, password;
                apiKey = apiSecret = username = password = "";

                foreach (var line in File.ReadAllLines(configPath)) // thanks gpt
                {
                    var trimmed = line.Trim();
                    if (string.IsNullOrEmpty(trimmed) || !trimmed.Contains("=")) continue;

                    var parts = trimmed.Split('=', 2);
                    string key = parts[0].Trim(), value = parts[1].Trim();

                    switch (key)
                    {
                        case "apiKey": apiKey = value; break;
                        case "apiSecret": apiSecret = value; break;
                        case "username": username = value; break;
                        case "password": password = value; break;
                    }
                }
                Scrobbler scrobbler = new Scrobbler(apiKey, apiSecret, username, password);
            }

            LoggerInstance.Msg("museScrobbler initialized!");

            base.OnInitializeMelon();
        }

        /*
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            LoggerInstance.Msg("HERE HAI :3  " + buildIndex+" "+sceneName);
            base.OnSceneWasLoaded(buildIndex, sceneName);
        }
        */

    }
}
