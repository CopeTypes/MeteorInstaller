namespace MeteorInstaller.ui.installer
{
    public class Launcher
    {
        
        public string name { get; set; }
        public string info { get; set; }
        public string downloadUrl { get; set; }

        public string installType { get; set; }

        public string getSummary()
        {
            return name + " (" + info + ")";
        }
        
        //todo what else is needed?
    }
}