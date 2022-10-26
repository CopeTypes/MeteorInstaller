namespace MeteorInstaller.util
{
    public class Settings
    {
        
        public bool customModDir { get; set; }
        public bool skipLauncherCheck { get; set; }
        public string modFolderPath { get; set; }
        
        public bool scrapeGithub { get; set; }
        public bool scrapeAnticope { get; set; }
        
        
        public string javaDLUrl { get; set; }
    }
}