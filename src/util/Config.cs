using System;
using System.IO;
using Newtonsoft.Json;

namespace MeteorInstaller.util
{
    public class Config
    {

        public static Settings _config = new Settings();


        private static bool loaded = false;
        public static bool load()
        {
            if (loaded) return true;
            var configF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            if (!File.Exists(configF)) return false;

            var jsonS = File.ReadAllText(configF);
            var jsonV = JsonConvert.DeserializeObject<Settings>(jsonS);
            if (jsonV == null) return false;

            _config = jsonV;
            loaded = true;
            return true;
        }

        public static void save()
        {
            var configF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            using (var f = File.CreateText(configF))
            {
                using (var w = new JsonTextWriter(f)) w.WriteRaw(JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
        }


    }
}