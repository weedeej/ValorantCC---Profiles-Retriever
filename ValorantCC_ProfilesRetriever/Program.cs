using System;
using RestSharp;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ValorantCC_ProfilesRetriever
{
    class Program
    {
        static AuthResponse AuthResponse;
        static AuthObj AuthObj = new AuthObj();
        static RestClient client;
        static void Main(string[] args)
        {
            Login();
            if (AuthResponse.Success)
            {
                client = new RestClient("https://playerpreferences.riotgames.com");
                client.AddDefaultHeaders(ConstructHeaders(AuthResponse));
                AuthObj.Log(FetchProfiles());
                AuthObj.Log("Done! Please send this to a dev to reproduce the error.");
                Console.WriteLine("Press any \"Return\" (Enter) to continue.");
                Console.ReadLine();
            }
        }

        static AuthResponse Login()
        {
            AuthResponse = AuthObj.StartAuth(false);
            if (!AuthResponse.Success) return AuthResponse;
            AuthObj.Log("Auth Success");
            return AuthResponse;
        }

        private static string FetchProfiles()
        {
            AuthObj.Log("Obtaining User Settings");
            RestRequest request = new RestRequest("/playerPref/v3/getPreference/Ares.PlayerSettings");
            string responseContext = client.Get(request).Content;
            Dictionary<string, object> response = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContext);
            Data settings = AuthObj.Decompress(Convert.ToString(response["data"]));
            string ProfileData;
            if (CheckIfList(settings))
            {
                int SavedProfilesIndex = settings.stringSettings.ToList().FindIndex(setting => setting.settingEnum == "EAresStringSettingName::SavedCrosshairProfileData");
                ProfileData = settings.stringSettings.ToList().Find(setting => setting.settingEnum == "EAresStringSettingName::SavedCrosshairProfileData").value;
            }
            else
            {
                ProfileData = "Not a list.Fetch is unapplicable.";
            }
            
            return ProfileData;
        }

        private static bool CheckIfList(Data settings)
        {
            AuthObj.Log("Checking if User has multiple profiles");
            return settings.stringSettings.Any(setting => setting.settingEnum == "EAresStringSettingName::SavedCrosshairProfileData");
        }

        private static Dictionary<string, string> ConstructHeaders(AuthResponse auth)
        {
            AuthObj.Log("Constructing Headers");
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + auth.AuthTokens.AccessToken);
            headers.Add("X-Riot-Entitlements-JWT", auth.AuthTokens.Token);
            headers.Add("X-Riot-ClientVersion", auth.Version);
            headers.Add("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
            return headers;
        }
    }
}
