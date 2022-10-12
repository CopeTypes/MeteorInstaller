using System.Windows.Forms;

namespace MeteorInstaller.ui.shop.addon
{
    public class AddonListViewItem : ListViewItem
    {

        private MeteorAddon _addon;

        public AddonListViewItem(MeteorAddon addon)
        {
            _addon = addon;
            Text = _addon.getSummary();
        }

        public void clicked()
        {
            new AddonSummaryUI(_addon).Show();
        }

    }
}