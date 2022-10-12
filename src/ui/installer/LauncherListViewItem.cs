using System.Windows.Forms;

namespace MeteorInstaller.ui.installer
{
    public class LauncherListViewItem : ListViewItem
    {

        private Launcher _launcher;


        public LauncherListViewItem(Launcher launcher)
        {
            _launcher = launcher;
            Text = _launcher.getSummary();
        }

        public void clicked()
        {
            new LauncherInstallPanel(_launcher).Show(); // open up da install panel
        }

    }
}