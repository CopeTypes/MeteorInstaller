using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

//UI for installing a launcher
namespace MeteorInstaller.ui.installer
{
    public partial class LauncherInstallPanel : Form
    {

        private Launcher _launcher;
        private readonly string _dlFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MeteorInstaller\\downloads");

        public LauncherInstallPanel(Launcher launcher)
        {
            InitializeComponent();
            _launcher = launcher;
        }
        
        private void log(string s)
        {
            logBox.Text += s + "\n";
            logBox.SelectionStart = logBox.Text.Length + 1;
            logBox.ScrollToCaret();
            Update();
        }

        private void LauncherInstallPanel_Shown(object sender, EventArgs e)
        {
            if (!Directory.Exists(_dlFolder)) Directory.CreateDirectory(_dlFolder);
            log("Installing launcher: " + _launcher.name);

            if (string.IsNullOrEmpty(_launcher.downloadUrl))
            {
                log("Unable to download the specified launcher. Please try again later.");
                return;
            }
            
            log("Downloading installer from " + _launcher.downloadUrl);

            var client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            client.DownloadFileCompleted += DownloadComplete;
            client.DownloadProgressChanged += ProgressChanged;
            client.DownloadFileAsync(new Uri(_launcher.downloadUrl), Path.Combine(_dlFolder, _launcher.name.Equals("MultiMC") ? "temp.zip" : "installer.exe"));
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (_launcher.name.Equals("MultiMC"))
            { // extract to desktop
                ZipFile.ExtractToDirectory(Path.Combine(_dlFolder, "temp.zip"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MultiMC"));
                MessageBox.Show("MultiMC installed!\nLook for the MultiMC folder on your desktop.");
            }
            else
            {
                var p = Process.Start(Path.Combine(_dlFolder, "installer.exe"));
                if (p == null)
                {
                    MessageBox.Show("Failed to start the install process.");
                    return;
                }
                var t = Process.GetProcessById(p.Id); // cope about it 
                Visible = false; // hide this until the launcher install process finishes
                t.WaitForExit();
                Visible = true;
                MessageBox.Show("Install complete!");
            }
        }
    }
}