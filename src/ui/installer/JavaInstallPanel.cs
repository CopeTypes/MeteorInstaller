using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.util;

namespace MeteorInstaller.ui.installer
{
    public partial class JavaInstallPanel : Form
    {

        //todo not hardcode?
        private readonly string _dlUrl =
            "https://github.com/adoptium/temurin17-binaries/releases/download/jdk-17.0.4.1%2B1/OpenJDK17U-jre_x64_windows_hotspot_17.0.4.1_1.msi";
        
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


        private void JavaInstallPanel_Shown(object sender, EventArgs e)
        {
            log("Downloading installer...");
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;

            var outf = Path.Combine(Utils.appdata, "java_installer.msi");
            client.DownloadFileAsync(new Uri(_dlUrl), outf);
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
    }
}