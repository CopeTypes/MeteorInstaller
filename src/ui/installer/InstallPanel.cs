using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.util;
using Newtonsoft.Json;

//todo cleanup and match to other install panels (AddonInstall, JavaInstall, etc)
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
            log("Preparing to install...");
        }


        private void removeOld()
        {
            var old = Directory.GetFiles(installFolder, "meteor*", SearchOption.TopDirectoryOnly);
            foreach (var s in old)
            {
                try
                {
                    File.Delete(s);
                }
                catch (IOException)
                {
                    log("Couldn't remove old meteor " + s);
                }
                catch (UnauthorizedAccessException)
                {
                    log("Couldn't remove old meteor " + s);
                }
            }
        }
        
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress_bar.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Install complete!");
        }


        /*private bool checkJava()
        {
            var javaVer = Utils.getJavaVer();
            return !string.IsNullOrEmpty(javaVer);
        }*/
        
        private void log(string s)
        {
            textbox.Text += s + "\n";
            textbox.SelectionStart = textbox.TextLength;
            textbox.ScrollToCaret();
        }

        private void InstallPanel_Shown(object sender, EventArgs e)
        {

            /*if (!checkJava())
            {
                log("Java is not installed.. preparing to install");
                return;
            }*/
            //log("Detected java " + Utils.getJavaVer());
            
            removeOld();
            
            var api = new WebClient().DownloadString("https://meteorclient.com/api/stats");
            var json = JsonConvert.DeserializeObject<dynamic>(api);

            var meteorVer = json.version;
            var mcVer = json.mc_version;
            var devBuildVer = json.devBuild;
            var devMcVer = json.dev_build_mc_version;



            if (devBuild) log("Downloading Meteor dev build " + devBuildVer + " for Minecraft " + devMcVer);
            else log("Downloading Meteor release " + meteorVer + " for Minecraft " + mcVer);
            
            var changelog = json.changelog;
            log("Changelog:");
            foreach (var change in changelog) log(change.ToString());
            
            var client = new WebClient();
            var mname = "meteor_client-" + meteorVer + ".jar";
            if (devBuild) mname = "meteor_client_dev-" + devBuildVer + ".jar";
            var outf = Path.Combine(installFolder, mname);

            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;
            
            //log("Saving to " + outf);
            client.DownloadFileAsync(new Uri(downloadUrl), outf);
        }
    }
}