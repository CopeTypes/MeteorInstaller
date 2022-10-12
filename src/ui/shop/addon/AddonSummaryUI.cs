using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.util;


//UI for addon summary (description, installation, etc)
namespace MeteorInstaller.ui.shop.addon
{
    public partial class AddonSummaryUI : Form
    {

        private MeteorAddon _addon;
        
        
        public AddonSummaryUI(MeteorAddon addon)
        {
            InitializeComponent();
            _addon = addon;
            refresh();
        }



        private void refresh()
        {
            addonName.Text = _addon.name;
            addonDesc.Text = _addon.description;
            addonAuthors.Text += _addon.getAuthors();
            addonMcVer.Text += _addon.mcVer;
            addonDownloads.Text += _addon.getDownloads();
            if (string.IsNullOrEmpty(_addon.meteorVer)) addonMeteorVer.Text += "???";
            else addonMeteorVer.Text += _addon.meteorVer;
            if (!string.IsNullOrEmpty(_addon.iconUrl))
            {
                Image properIcon = _addon.getIcon();
                addonIcon.Image = properIcon;
                addonIcon.Visible = true;
            }
            Update();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            new AddonInstallPanel(_addon).Show();
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_addon.repoUrl)) Process.Start(new ProcessStartInfo(_addon.repoUrl));
        }

        private void discordButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_addon.discordLink)) Process.Start(new ProcessStartInfo(_addon.discordLink));
            else MessageBox.Show("No discord link available.");
        }
    }
}