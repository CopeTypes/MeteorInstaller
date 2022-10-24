using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteorInstaller.util;
using Newtonsoft.Json;


// handle loading addons into the shop on start
namespace MeteorInstaller.ui.shop.addon
{
    public class ShopCache
    {

        public static List<MeteorAddon> addonCache = new List<MeteorAddon>();


        private static void organize()
        {
            //todo rewrite
            List<MeteorAddon> latest = new List<MeteorAddon>();
            List<MeteorAddon> others = new List<MeteorAddon>();
            foreach (var addon in addonCache)
            {
                if (addon.mcVer == null) others.Add(addon);
                else if (addon.mcVer.Contains("1.19.2")) latest.Add(addon);
                if (addon.meteorVer == null) others.Add(addon);
                else if (addon.meteorVer.Contains("0.5.1")) latest.Add(addon);
            }
            
            List<MeteorAddon> organized = new List<MeteorAddon>();
            organized.AddRange(latest.OrderBy(addon => addon.downloads).Reverse().ToList());
            organized.AddRange(others.OrderBy(addon => addon.downloads).Reverse().ToList());
            addonCache.Clear();
            addonCache.AddRange(organized.Distinct());
        }
        
        
        
        public static void cacheAllIcons()
        {
            foreach (var addon in addonCache) cacheIcon(addon);
        }
        
        public static bool cacheIcon(MeteorAddon addon)
        {
            var iconF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon_cache");
            if (!Directory.Exists(iconF)) Directory.CreateDirectory(iconF);
            if (string.IsNullOrEmpty(addon.iconUrl)) return false;
            Image icon = addon.getIcon();
            var name = Path.Combine(iconF, addon.name + ".png");
            if (File.Exists(name)) return true;
            try
            {
                icon.Save(name, ImageFormat.Png);
                return true;
            }
            catch (ArgumentNullException)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
            catch (ExternalException)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
        }

        public static Image getCachedIcon(MeteorAddon addon)
        {
            var iconF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon_cache");
            if (!Directory.Exists(iconF)) return null;

            var iconPath = Path.Combine(iconF, addon.name + ".png");
            return !File.Exists(iconPath) ? null : Image.FromFile(iconPath);
        }
        
        
        
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
                organize();
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
            //Task.Run(() => { foreach (var addon in addonCache) cacheIcon(addon); }); // cache icons
            using (var file = File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addon_database.json")))
            {
                using (var writer = new JsonTextWriter(file)) {writer.WriteRaw(JsonConvert.SerializeObject(addonCache));}
            }
            return true;
        }

        public static void addList(List<MeteorAddon> addons)
        {
            foreach (var addon in addons) addonCache.Add(addon);
            organize();
        }
        
        
        public static bool isCached(string id)
        {
            return addonCache.Where(addon => !string.IsNullOrEmpty(addon.id)).Any(addon => id.Equals(addon.id));
        }
        
    }
}