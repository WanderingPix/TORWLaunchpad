using AmongUs.Data;
using AmongUs.Data.Player;
using Assets.InnerNet;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using LibCpp2IL;
using System;
using System.Collections;
using HarmonyLib;
using System.IO;
using System.Text.Json;
using UnityEngine;
using UnityEngine.Networking;

[HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.Init))]
public class ModNewsPatch
{
    static bool downloaded = false;
    static string ModNewsURL = "https://raw.githubusercontent.com/EnhancedNetwork/TownofHost-Enhanced/refs/heads/main/Resources/Announcements/modNews-";
    
    // This method runs after the original method
    [HarmonyPostfix]
    public static void Postfix(ref Il2CppSystem.Collections.IEnumerator __result)
    {
        static IEnumerator FetchBlacklist()
        {
            if (downloaded)
                yield break;

            downloaded = true;

            // Determine the language for the news
            ModNewsURL += TranslationController.Instance.currentLanguage.languageID switch
            {
                SupportedLangs.German => "de_DE.json",
                SupportedLangs.Latam => "es_419.json",
                SupportedLangs.Spanish => "es_ES.json",
                SupportedLangs.French => "fr_FR.json",
                SupportedLangs.Italian => "it_IT.json",
                _ => "en_US.json", // Default to English
            };

            // Fetch the news from the URL
            var request = UnityWebRequest.Get(ModNewsURL);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Logger.Error("Failed to load mod news, falling back to local news.", "ModNews");
                LoadModNewsFromResources();
                yield break;
            }

            try
            {
                using var jsonDocument = JsonDocument.Parse(request.downloadHandler.text);
                var newsArray = jsonDocument.RootElement.GetProperty("News");

                foreach (var newsElement in newsArray.EnumerateArray())
                {
                    var number = int.Parse(newsElement.GetProperty("Number").GetString());
                    var title = newsElement.GetProperty("Title").GetString();
                    var subtitle = newsElement.GetProperty("Subtitle").GetString();
                    var shortTitle = newsElement.GetProperty("Short").GetString();
                    var body = newsElement.GetProperty("Body").EnumerateArray().ToStringEnumerable().ToString();
                    var dateString = newsElement.GetProperty("Date").GetString();

                    // Add the news to the mod news list
                    new ModNews(number, title, subtitle, shortTitle, body, dateString);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "ModNews");
                Logger.Error("Failed to parse mod news, loading from local resources.", "ModNews");
                LoadModNewsFromResources();
            }
        }

        __result = Effects.Sequence(FetchBlacklist().WrapToIl2Cpp(), __result);
    }
}
