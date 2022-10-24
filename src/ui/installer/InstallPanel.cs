using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.util;

namespace MeteorInstaller.ui.installer
{
    public partial class InstallPanel : Form
    {

        private string downloadUrl;
        private string installFolder;
        private bool devBuild;
        
        public InstallPanel(bool devBuild, string installFolder)
        {
            this.devBuild = devBuild;
            this.installFolder = installFolder;
            InitializeComponent();
            downloadUrl = "https://meteorclient.com/download";
            if (devBuild) downloadUrl = "https://meteorclient.com/download?devBuild=latest";
        }
        
        private void InstallPanel_Shown(object sender, EventArgs e)
        {
            
            log("Preparing to install...");

            var ii = Utils.getIncompatibles();
            if (ii.Count > 0)
            {
                var m = "The following incompatible mods will be removed upon installation\n" +
                    ii.Aggregate("", (current, i) => current + i + "\n");
                MessageBox.Show(m, "Incompatible mods installed!");
                Utils.deleteFiles(ii, installFolder);
            }
            
            removeOld();
            
            if (devBuild) log("Downloading Meteor dev build " + Utils.devVer + " for Minecraft " + Utils.devMc);
            else log("Downloading Meteor release " + Utils.releaseVer + " for Minecraft " + Utils.releaseMc);
            log("Changelog:\n" + Utils.changelog);

            var client = new WebClient();
            var mname = "meteor_client-" + Utils.releaseVer + ".jar";
            if (devBuild) mname = "meteor_client_dev-" + Utils.devVer + ".jar";
            var outf = Path.Combine(installFolder, mname);

            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;
            
            //log("Saving to " + outf);
            client.DownloadFileAsync(new Uri(downloadUrl), outf);
        }
        
        private void removeOld()
        {
            var old = Directory.GetFiles(installFolder, "meteor*", SearchOption.TopDirectoryOnly);
            Utils.deleteFiles(old);
        }
        
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress_bar.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Install complete!");
        }
        
        private void log(string s)
        {
            textbox.Text += s + "\n";
            textbox.SelectionStart = textbox.TextLength;
            textbox.ScrollToCaret();
        }
    }
}