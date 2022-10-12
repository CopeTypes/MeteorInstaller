using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace MeteorInstaller.util
{
    public class Utils
    {
        public static readonly string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string localappdata =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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


        public static bool launcherCheck()
        {
            var t = Path.Combine(appdata, ".minecraft\\launcher_settings.json");
            if (File.Exists(t)) return true;
            //todo somehow check for other launchers?
    
            return false;
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