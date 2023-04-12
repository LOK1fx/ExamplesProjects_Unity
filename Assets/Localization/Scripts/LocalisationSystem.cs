using System.Collections.Generic;

namespace LOK1game
{
    public class LocalisationSystem
    {
        public enum ELanguage
        {
            English,
            Russian,
            Kazah
        }

        public static ELanguage Language = ELanguage.English;

        private static Dictionary<string, string> LocalisedEN;
        private static Dictionary<string, string> LocalisedRU;
        private static Dictionary<string, string> LocalisedKK;

        public static bool IsInit { get; private set; }

        public static void Init()
        {
            var csvLoader = new CSVLoader();
            csvLoader.LoadCSV();

            LocalisedEN = csvLoader.GetDictionaryValues("en");
            LocalisedRU = csvLoader.GetDictionaryValues("ru");
            LocalisedKK = csvLoader.GetDictionaryValues("kk");

            IsInit = true;
        }

        public static string GetLocalisedValue(string key)
        {
            if (!IsInit) { Init(); }

            var value = key;

            switch (Language)
            {
                case ELanguage.English:
                    LocalisedEN.TryGetValue(key, out value);
                    break;
                case ELanguage.Russian:
                    LocalisedRU.TryGetValue(key, out value);
                    break;
                case ELanguage.Kazah:
                    LocalisedKK.TryGetValue(key, out value);
                    break;
                default:
                    LocalisedEN.TryGetValue(key, out value);
                    break;
            }

            return value;
        }
    }
}