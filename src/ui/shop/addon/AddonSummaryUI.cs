using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

            addonModules.Text += _addon.moduleCount;
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

        private void viewModulesButton_Click(object sender, EventArgs e)
        {
            if (_addon.modules == null)
            {
                MessageBox.Show("No modules found for this addon. Try updating the shop or checking the Github repo.");
                return;
            }
            var m = _addon.modules.Aggregate("", (current, module) => current + module + "\n");
            MessageBox.Show(m, "Modules for " + _addon.name);
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            if (_addon.verified) MessageBox.Show("This addon is safe to use!");
            else if (Utils.shouldVerify(_addon))
                MessageBox.Show("This addon hasn't been verified, but passed the automatic inspection.");
            else
                MessageBox.Show(
                    "This addon hasn't been verified and failed the automatic inspection.\nProceed with caution.");
        }
    }
}