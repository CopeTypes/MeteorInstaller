using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteorInstaller.ui.installer;
using MeteorInstaller.ui.shop.addon;
using MeteorInstaller.util;

namespace MeteorInstaller.ui.main
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            customFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft\\mods");
        }

        private void install_release_Click(object sender, EventArgs e)
        {
            if (!preFlight()) return;
            new InstallPanel(false, customFolder.Text).Show();
        }

        private void install_dev_Click(object sender, EventArgs e)
        {
            if (!preFlight()) return;
            new InstallPanel(true, customFolder.Text).Show();
        }


        private bool preFlight()
        {
            if (!Utils.javaCheck()) // make sure they have java
            {
                MessageBox.Show("You don't have java installed, or the current version is too old.\n" + "Java 17 will be installed after pressing ok");
                new JavaInstallPanel().Show();
                return false;
            }

            if (skipLauncherCheck.Checked) return true; // make sure they have a launcher
            if (Utils.launcherCheck()) return true;
            new LauncherPicker().Show();
            return false;
        }


        private void customDir_CheckedChanged(object sender, EventArgs e)
        {
            customFolder.Visible = customDir.Checked;
            customFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft\\mods");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!Config.load()) return;
            customFolder.Visible = Config._config.customModDir;
            customFolder.Text = Config._config.modFolderPath;
            skipLauncherCheck.Checked = Config._config.skipLauncherCheck;
        }

        private void addonShop_Click(object sender, EventArgs e)
        {
            new AddonShopUI().Show();
        }

        private void launcherPick_Click(object sender, EventArgs e)
        {
            new LauncherPicker("Install a launcher").Show();
        }

        private async void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await Task.Run(() =>
            {
                Utils.sysLog("Shutting down...");
                Config._config.customModDir = customDir.Checked;
                Config._config.modFolderPath = customFolder.Text;
                Config._config.skipLauncherCheck = skipLauncherCheck.Checked;
                Config.save();
                Utils.sysLog("Config saved! Goodbye.");
            });
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Utils.setVers();
            install_release.Text += " (" + Utils.releaseMc + ")";
            install_dev.Text += " (" + Utils.devMc + ")";
        }
    }
}