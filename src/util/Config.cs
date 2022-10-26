using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Octokit;

namespace MeteorInstaller.util
{
    public class Config
    {

        public static Settings _config = new Settings();


        private static bool loaded = false;
        public static void load()
        {
            if (loaded) return;
            var configF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            if (!File.Exists(configF))
            {
                setDefaultConf();
                save();
                return;
            }

            var jsonS = File.ReadAllText(configF);
            var jsonV = JsonConvert.DeserializeObject<Settings>(jsonS);
            if (jsonV == null)
            {
                setDefaultConf();
                return;
            }
            _config = jsonV;
            loaded = true;
        }

        public static async void save()
        {
            try
            {
                var configF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                using (var f = File.CreateText(configF))
                {
                    using (var w = new JsonTextWriter(f))
                        await w.WriteRawAsync(JsonConvert.SerializeObject(_config, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                Utils.sysLog(ex.StackTrace);
            }
        }

        private static void setDefaultConf()
        {
            _config.customModDir = false;
            _config.skipLauncherCheck = false;
            _config.modFolderPath = string.Empty;
            _config.scrapeGithub = false;
            _config.scrapeAnticope = true;
            _config.javaDLUrl = string.Empty;
        }
        
    }
}