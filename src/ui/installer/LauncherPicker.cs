using System.Collections.Generic;
using System.Windows.Forms;

//in case the user doesn't have a launcher installed yet
//could double as an updater after other stuff is done

namespace MeteorInstaller.ui.installer
{
    public partial class LauncherPicker : Form
    {
        
        private List<Launcher> _launchers = new List<Launcher>
        {
            new Launcher
            {
                name = "Microsoft",
                info = "The default Minecraft Launcher",
                downloadUrl = "https://launcher.mojang.com/download/MinecraftInstaller.exe"
            },
            new Launcher
            {
                name = "MultiMC",
                info = "A popular replacement to the default launcher.",
                downloadUrl = "https://files.multimc.org/downloads/mmc-stable-win32.zip"
            },
            new Launcher
            {
                name = "Prism",
                info = "An improved version of MultiMC",
                downloadUrl = "https://github.com/PrismLauncher/PrismLauncher/releases/download/5.0/PrismLauncher-Windows-Setup-5.0.exe"
            }
        };
        
        public LauncherPicker(string mainText = "You don't have a Minecraft launcher installed!", string subText = "Pick one of these trusted launchers to install")
        {
            InitializeComponent();
            noLauncherMain.Text = mainText;
            noLauncherSub.Text = subText;
            foreach (var launcher in _launchers) launcherChoices.Items.Add(new LauncherListViewItem(launcher));
        }

        private void launcherChoices_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            var a = (LauncherListViewItem)e.Item;
            a.clicked(); // show LauncherInstallPanel for whatever launcher
            a.Selected = false;
        }
    }
}