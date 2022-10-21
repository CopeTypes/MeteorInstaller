using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.ui.shop.addon;
using MeteorInstaller.util;


//UI for installing an addon
namespace MeteorInstaller.ui.shop
{
    public partial class AddonInstallPanel : Form
    {

        private MeteorAddon _addon;
        private readonly string _installFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\mods");
        
        public AddonInstallPanel(MeteorAddon addon)
        {
            InitializeComponent();
            _addon = addon;
        }




        private void log(string s)
        {
            logBox.Text += s + "\n";
            logBox.SelectionStart = logBox.Text.Length + 1;
            logBox.ScrollToCaret();
            Update();
        }

        private void AddonInstallPanel_Shown(object sender, EventArgs e)
        {
            var outf = Path.Combine(_installFolder, _addon.fileName);
            if (File.Exists(outf))
            {
                MessageBox.Show(_addon.name + " is already installed & up to date!");
                return;
            }
            
            var ii = Utils.getIncompatibles();
            if (ii.Count > 0)
            {
                var m = "The following incompatible mods will be removed upon installation\n" +
                        ii.Aggregate("", (current, i) => current + i + "\n");
                MessageBox.Show(m, "Incompatible mods installed!");
                Utils.deleteFiles(ii);
            }
            
            removeOld();
            log("Installing " + _addon.name);
            
            if (string.IsNullOrEmpty(_addon.downloadUrl))
            {
                MessageBox.Show("This entry doesn't have a valid download link!\nTry updating the shop.");
                return;
            }

            log("Downloading from " + _addon.downloadUrl);
            //log("Installing to " + _installFolder);
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;
            client.DownloadFileAsync(new Uri(_addon.downloadUrl), outf);
            
        }

        private void removeOld()
        {
            var old = Directory.GetFiles(_installFolder, _addon.name.ToLower() + "*", SearchOption.TopDirectoryOnly);
            foreach (var s in old)
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



        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Install complete!");
        }
    }
}