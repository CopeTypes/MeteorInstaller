using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using MeteorInstaller.ui.shop.addon;
using Newtonsoft.Json;

namespace MeteorInstaller.util
{
    public class Utils
    {
        public static readonly string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string logpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "latest.log");
        
        
        public static string releaseMc;
        public static string releaseVer;
        public static string devMc;
        public static string devVer;

        public static string changelog;


        public static async void sysLog(string s)
        {
            if (!File.Exists(logpath)) using (StreamWriter w = File.CreateText(logpath)) await w.WriteLineAsync("MeteorInstaller log");
            else using (StreamWriter w2 = File.AppendText(logpath)) await w2.WriteLineAsync(s);
        }
        
        
        public static void setVers()
        {
            var api = new WebClient().DownloadString("https://meteorclient.com/api/stats");
            var json = JsonConvert.DeserializeObject<dynamic>(api);
            if (json == null) return;
            releaseMc = json.mc_version.ToString();
            releaseVer = json.version.ToString();
            devMc = json.dev_build_mc_version.ToString();
            devVer = json.devBuild.ToString();
            
            var cl = json.changelog;
            changelog = "";
            foreach (var change in cl) changelog += change + "\n";
        }
        
        
        public static Process startProcess(string cmd)
        {
            
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/c " + cmd,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            p.Start();
            return p;
        }


        public static bool javaCheck()
        {
            string ver = getJavaVer();
            if (string.IsNullOrEmpty(ver)) return false;
            return ver.Contains("17") || ver.Contains("18") || ver.Contains("19");
        }
        
        
        public static string getJavaVer()
        {
            var p = startProcess("java -version");
            string l;
            StreamReader r = p.StandardError;
            while ((l = r.ReadLine()) != null)
            {
                if (!l.Contains("version")) continue;
                var sa = l.Split('"').Where((item, index) => index % 2 != 0);
                return sa.First();
            }

            return null;
        }

        public static void deleteFiles(IEnumerable<string> files)
        {
            foreach (var s in files)
            {
                try
                {
                    File.Delete(s);
                }
                catch (IOException)
                { }
                catch (UnauthorizedAccessException)
                { }
            }
        }

        public static void deleteFiles(IEnumerable<string> files, string root)
        {
            foreach (var s in files)
            {
                try
                {
                    File.Delete(Path.Combine(root, s));
                }
                catch (IOException)
                { }
                catch (UnauthorizedAccessException)
                { }
            }
        }
        
        
        public static bool launcherCheck()
        {
            var t = Path.Combine(appdata, ".minecraft\\launcher_settings.json"); //unreliable, todo find a better way
            if (File.Exists(t)) return true;
            //todo somehow check for other launchers?
    
            return false;
        }

        public static string fcu(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));
        }
        
        
        public static List<string> getIncompatibles()
        {
            var modDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft\\mods");
            if (Config._config.customModDir) modDir = Config._config.modFolderPath;
            var incompatibles = new List<string>();
            
            
            foreach (var i in incompatible)
            { // i feel like this can be simplified, but it's good enough. 
                var old1 = Directory.GetFiles(modDir, fcu(i) + "*", SearchOption.TopDirectoryOnly);
                var old2 = Directory.GetFiles(modDir, i + "*", SearchOption.TopDirectoryOnly);
                incompatibles.AddRange(old1);
                incompatibles.AddRange(old2);
            }
            
            return incompatibles.Distinct().ToList().Select(copE => copE.Split('\\').Last()).ToList(); //pog

            //return incompatibles.Distinct().ToList();
        }
        
        private static List<string> incompatible = new List<string>
        {
            "inertia",
            "wurst",
            "aristois",
            "feather",
            "optifine",
            "optifabric",
            "origins",
            "better mount hud",
            "armor chroma"
        };
        
        
        private static List<string> skids = new List<string> { "RedCarlos26", "Ethius", "RickyTheRacc" };
        private static List<string> dontTrust = new List<string> { "Necropho", "Bennoo", "Kiriyaga" };
        private static List<string> verifiedAuthors = new List<string>
            { "AntiCope", "Cloudburst", "GhostTypes", "StormyBytes", "Declipsonator", "Wide_Cat" };
        
        public static bool shouldVerify(MeteorAddon addon)
        {
            return !addon.authors.Any(author => dontTrust.Contains(author)) && addon.authors.Any(author => verifiedAuthors.Contains(author));
        }
        
        
        
        // Image Utils

        
        public static Image resizeImage(Image imgToResize, Size size)  
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;  
            float nPercent = 0;  
            float nPercentW = 0;  
            float nPercentH = 0;
            nPercentW = size.Width / (float)sourceWidth;
            nPercentH = size.Height / (float)sourceHeight;  
            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);  
            Bitmap b = new Bitmap(destWidth, destHeight);  
            Graphics g = Graphics.FromImage(b);  
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);  
            g.Dispose();  
            return b;  
        }
    }
}