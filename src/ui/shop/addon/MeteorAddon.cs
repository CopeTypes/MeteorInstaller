using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using MeteorInstaller.util;


namespace MeteorInstaller.ui.shop.addon
{
    public class MeteorAddon
    {
        public string name { get; set; }
        public string fileName { get; set; }
        public string description { get; set; }
        
        public string authorName { get; set; }
        
        public string repoUrl { get; set; }
        public string downloadUrl { get; set; }
        
        public string iconUrl { get; set; }

        public string getId()
        {
            return authorName + "/" + name;
        }
        
        //public string icon { get; set; } // icon as base64 | todo impl
        
        //public Image icon { get; set; }
        
        public int downloads { get; set; }

        public string getDownloads()
        {
            if (downloads == -1) return "???";
            return "" + downloads;
        }
        
        public string discordLink { get; set; }
        
        public string mcVer { get; set; }
        
        public string meteorVer { get; set; }
        
        public List<string> authors { get; set; }

        
        public string getAuthors()
        {
            var c = authors.Count < 2 ? authors[0] : authors.Aggregate("", (current, a) => current + a + ", ");
            return c.TrimEnd(' ').TrimEnd(',');
        }

        public string getSummary()
        {
            return name + " by " + getAuthors();
        }


        private Image icon;
        public Image getIcon()
        {
            if (icon != null) return icon;
            var client = new WebClient();
            client.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            byte[] bytes = client.DownloadData(iconUrl);
            MemoryStream ms = new MemoryStream(bytes);
            Image temp = Image.FromStream(ms);
            ms.Close();
            Image properIcon = Utils.resizeImage(temp, new Size(64, 64));
            icon = properIcon;
            return icon;
        }
        
    }
}