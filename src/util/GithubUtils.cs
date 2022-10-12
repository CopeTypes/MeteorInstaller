using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using MeteorInstaller.ui.shop.addon;
using Newtonsoft.Json;
using Octokit;

namespace MeteorInstaller.util
{

    
    
    
    
    public class GithubUtils
    {

        public static GitHubClient ghClient = new GitHubClient(new ProductHeaderValue("MeteorInstaller"));





        public static Release getLatestRelease(string repoUrl)
        {
            var c = new WebClient();
            c.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            var ghJson = c.DownloadString(repoUrl.Replace("https://github.com/", "https://api.github.com/repos/"));
            if (string.IsNullOrEmpty(ghJson)) return null;

            var json = JsonConvert.DeserializeObject<dynamic>(ghJson);
            if (json == null) return null;

            try
            {
                string repoName = json.name.ToString();
                string authorName = json.owner.login.ToString();
                string defBranch = json.default_branch.ToString();
                if (string.IsNullOrEmpty(repoName) || string.IsNullOrEmpty(authorName) ||
                    string.IsNullOrEmpty(defBranch)) return null;

                var lRelease = ghClient.Repository.Release.GetAll(authorName, repoName).GetAwaiter().GetResult()[0];
                return lRelease;
            }
            catch (Exception )
            {
                return null;
            }
        }

    
        public enum DLMODE
        {
            ZIP,JAR,EXE
        }
        
        /*public static string getDownload(Release release, DLMODE dlmode)
        {
            
        }*/
    }
}