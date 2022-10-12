using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MeteorInstaller.util;
using Newtonsoft.Json;


// handle loading addons into the shop on start
namespace MeteorInstaller.ui.shop.addon
{
    public class ShopCache
    {

        public static List<MeteorAddon> addonCache = new List<MeteorAddon>();

        
        public static bool loadFromDisk()
        { // populate the cache from the database on file
            try
            {
                if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addon_database.json")))
                    return false;
                var addonDB =
                    File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addon_database.json"));
                if (string.IsNullOrEmpty(addonDB)) return false;
                var addons = JsonConvert.DeserializeObject<List<MeteorAddon>>(addonDB);
                if (addons == null || addons.Count < 1) return false;
                addonCache = addons;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to parse addon_database.json", e.Message);
                return false;
            }
        }

        public static bool shouldDiscard(MeteorAddon addon)
        {
            if (string.IsNullOrEmpty(addon.name) || string.IsNullOrEmpty(addon.downloadUrl)) return true;
            if (addon.name.Equals("Addon Template")
                || addon.name.Equals("Addon Template by seasnail")
                || addon.name.Equals("AddonTemplate by seasnail8169"))
            {
                return true;
            }

            List<string> authors = addon.authors;
            if (authors == null || authors.Count < 1) return true;
            return authors[0] == "seasnail" || authors[0] == "seasnail8169";
        }
        

        public static bool saveToDisk()
        { // save the cache to file
            if (addonCache.Count < 1) return false;
            using (var file = File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addon_database.json")))
            {
                using (var writer = new JsonTextWriter(file)) {writer.WriteRaw(JsonConvert.SerializeObject(addonCache));}
            }
            return true;
        }

        public static void addList(List<MeteorAddon> addons)
        {
            foreach (var addon in addons) addonCache.Add(addon);
        }
        
        
        public static bool isCached(string id)
        {
            return addonCache.Where(addon => !string.IsNullOrEmpty(addon.getId())).Any(addon => id.Equals(addon.getId()));
        }
        
    }
}