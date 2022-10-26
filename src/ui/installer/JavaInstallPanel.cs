using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteorInstaller.util;
using Octokit;

namespace MeteorInstaller.ui.installer
{
    public partial class JavaInstallPanel : Form
    {
        
        public JavaInstallPanel()
        {
            InitializeComponent();
        }
        
        private void log(string s)
        {
            logBox.Text += s + "\n";
            logBox.SelectionStart = logBox.Text.Length + 1;
            logBox.ScrollToCaret();
            Update();
        }


        private async void JavaInstallPanel_Shown(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;
            if (string.IsNullOrEmpty(Config._config.javaDLUrl))
            {// todo this should be 'refreshed' every so often if it's not null, put a timestamp or something
                log("Searching for the latest Java17 installer...");
                setJavaVer();
                while (string.IsNullOrEmpty(Config._config.javaDLUrl)) await Task.Delay(50);
                log("Got it! (" + Config._config.javaDLUrl + ")");
            }
            log("Downloading installer...");
            var outf = Path.Combine(Utils.appdata, "java_installer.msi");
            client.DownloadFileAsync(new Uri(Config._config.javaDLUrl), outf);
        }
        
        
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            log("Installing java...");
            var msiPath = Path.Combine(Utils.appdata, "java_installer.msi");
            var logPath = Path.Combine(Utils.appdata, "java_install.log");
            var installCmd = "msiexec.exe /i " + msiPath + " /QN /L*V " + logPath;
            var installP = Utils.startProcess(installCmd);
            installP.WaitForExit();
            var javav = Utils.getJavaVer();
            if (string.IsNullOrEmpty(javav))
            {
                MessageBox.Show(
                    "Failed to automatically install, the installer will be shown\nafter closing this message.");
                Utils.startProcess(msiPath);
            }
            else
            {
                MessageBox.Show("Java has been installed!");
            }
        }


        private static async void setJavaVer()
        {
            await Task.Run(() =>
            {
                var s = new Stopwatch();
                s.Start();
                Utils.sysLog("Checking for the latest java version...");
                var latestJava = getLatestJava();
                Config._config.javaDLUrl = string.IsNullOrEmpty(latestJava)
                    ? "https://github.com/adoptium/temurin17-binaries/releases/download/jdk-17.0.4.1%2B1/OpenJDK17U-jre_x64_windows_hotspot_17.0.4.1_1.msi"
                    : latestJava;
                Utils.sysLog("Checked in " + s.ElapsedMilliseconds + "ms");
                Config.save();
            });
        }
        
        private static string getLatestJava()
        {
            try
            {
                ApiOptions apiOptions = new ApiOptions()
                {
                    PageCount = 1,
                    PageSize = 2
                };
                IReadOnlyList<Release> releases = GithubUtils.ghClient.Repository.Release.GetAll("adoptium", "temurin17-binaries", apiOptions).GetAwaiter().GetResult();
                ReleaseAsset goodAsset = null;
                foreach (var rel in releases)
                {
                    foreach (var asset in rel.Assets)
                    {
                        if (!asset.Name.EndsWith(".msi")) continue;
                        if (!asset.Name.Contains("jre_x64")) continue;
                        goodAsset = asset;
                        break;
                    }

                    if (goodAsset != null) break;
                }

                return goodAsset == null ? string.Empty : goodAsset.BrowserDownloadUrl;
            }
            catch (ApiException apiException)
            {
                Utils.sysLog("Github API error for getLatestJava()");
                Utils.sysLog(apiException.StackTrace);
                return string.Empty;
            }
        }
        
    }
}