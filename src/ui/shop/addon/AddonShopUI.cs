﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteorInstaller.util;
using Newtonsoft.Json;
using Octokit;


//Main UI for the addon shop, code for updating addon db, etc
namespace MeteorInstaller.ui.shop.addon
{
    
    public partial class AddonShopUI : Form
    {
        public AddonShopUI()
        {
            InitializeComponent();

        }


        private void log(string s)
        {
            logBox.Text += s + "\n";
            logBox.SelectionStart = logBox.Text.Length + 1;
            logBox.ScrollToCaret();
            Update();
        }


        private void addList(List<MeteorAddon> addons)
        {
            foreach (var meteorAddon in addons)
            {
                addAddon(meteorAddon);
            }
        }
        
        private void addAddon(MeteorAddon addon)
        {
            addonList.Items.Add(new AddonListViewItem(addon));
            //Update();
        }


        private void addonList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            var a = (AddonListViewItem)e.Item;
            a.clicked(); // show the SummaryUI
            a.Selected = false;
        }

        private void AddonShopUI_Shown(object sender, EventArgs e)
        {
            log("Loading addons...");
            bool loaded = false;
            if (ShopCache.loadFromDisk())
            {
                //MessageBox.Show("loadFromDisk complete.");
                log("Loaded " + ShopCache.addonCache.Count + " addons from disk.");
                loaded = true;
            }
            if (loaded) reloadShop();
            else MessageBox.Show("Unable to load the shop! Please try refreshing.");

        }

        private void reloadShop()
        {
            addonList.Items.Clear();
            addList(ShopCache.addonCache);
            Task.Run(ShopCache.cacheAllIcons);
        }
        
        private async void AddonShopUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            await Task.Run(() =>
            {
                ShopCache.saveToDisk();
                ShopCache.cacheAllIcons();
            });
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                log("Saving database...");
                ShopCache.saveToDisk();
                if (scrapeGithub.Checked)
                {
                    log("Scraping from github...");
                    if (updateFromGithub()) log("Success!");
                }
                if (scrapeAntiCope.Checked)
                {
                    log("Scraping from anticope...");
                    if (updateFromAntiCope()) log("Success!");
                }
                log("Saving updated database...");
                ShopCache.saveToDisk();
                reloadShop();
                log("Complete!");
            });
        }






        private bool updateFromAntiCope()
        {
            try
            {
                var addons = new List<MeteorAddon>();
                var client = new WebClient();
                client.Headers.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");

                // scrape verified
                log("Scraping anticope verified addons...");
                var verified =
                    client.DownloadString(
                        "https://raw.githubusercontent.com/AntiCope/anticope.ml/data/addons-ver.json");
                if (string.IsNullOrEmpty(verified))
                {
                    log("Github error, skipping");
                    return false;
                }

                dynamic dJson = JsonConvert.DeserializeObject<dynamic>(verified);
                if (dJson == null)
                {
                    log("Json parse error, skipping");
                    return false;
                }

                //MessageBox.Show("calling getAddonLfromAC");
                List<MeteorAddon> temp = getAddonLfromAC(dJson);
                if (temp != null)
                {
                    log("Found " + temp.Count + " new addons");
                    addons.AddRange(temp);
                }

                // scrape unverified
                log("Scraping anticope unverified addons...");
                var unverif =
                    client.DownloadString(
                        "https://raw.githubusercontent.com/AntiCope/anticope.ml/data/addons-unver.json");
                if (string.IsNullOrEmpty(unverif))
                {
                    log("Github error, skipping");
                    return false;
                }

                dynamic dJson1 = JsonConvert.DeserializeObject<dynamic>(unverif);
                if (dJson1 == null)
                {
                    log("Json parse error, skipping");
                    return false;
                }

                List<MeteorAddon> temp1 = getAddonLfromAC(dJson1);
                if (temp1 != null)
                {
                    log("Found " + temp1.Count + " new addons.");
                    addons.AddRange(temp1);
                }

                if (addons.Count <= 0) return false;
                log("Found " + addons.Count + " new addons from anticope!");
                ShopCache.addList(addons);
                reloadShop();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private List<MeteorAddon> getAddonLfromAC(dynamic dJson)
        {
            List<MeteorAddon> _addons = new List<MeteorAddon>();
            foreach (dynamic addon in dJson)
            { // required data to add
                try
                {
                    var id = addon.id;
                    var authors = addon.authors;
                    var icon = addon.icon;
                    var links = addon.links;
                    var mcVer = addon.mc_version;
                    var dlCount = addon.downloads;
                    var name = addon.name;
                    var summary = addon.summary;

                    if (authors == null || icon == null || links == null || mcVer == null || dlCount == null ||
                        name == null || summary == null || id == null) continue; // skip 

                    //MessageBox.Show(id.ToString());
                    log("Checking " + name.ToString());

                    if (name.ToString().Equals("Addon Template")
                        || name.ToString().Equals("Addon Template by seasnail")
                        || name.ToString().Equals("AddonTemplate by seasnail8169"))
                    {
                        log("Skipping addon template paste...");
                        continue;
                    }

                    if (ShopCache.isCached(id.ToString()))
                    {
                        log("Already in database, skipping.");
                        continue;
                    }

                    MeteorAddon _addon = new MeteorAddon()
                    {
                        // init with known data
                        name = name.ToString(),
                        mcVer = mcVer.ToString(),
                        downloads = Int32.Parse(dlCount.ToString()),
                        description = summary.ToString(),
                        iconUrl = icon.ToString()
                    };

                    //MessageBox.Show("addon init OK.");
                    // check for the rest

                    List<string> _authors = new List<string>();
                    foreach (var author in authors) _authors.Add(author.ToString()); // set authors
                    _addon.authors = _authors;
                    //MessageBox.Show("authors OK.");
                    
                    if (_authors.Count > 2)
                    { // addon template check
                        if (_authors[0].Equals("seasnail") || _authors[0].Equals("seasnail8169"))
                        {
                            log("Skipping addon template paste...");
                            continue;
                        }
                    }

                    var discord = links.discord; // check for discord link
                    if (discord != null) _addon.discordLink = discord.ToString();

                    //MessageBox.Show("discord check OK.");

                    var download = links.download; // set download link
                    if (download == null)
                    {
                        log("No valid download link, skipping.");
                        continue;
                    }

                    var github = links.github; // set github link
                    if (github == null)
                    {
                        log("No valid github link? Skipping.");
                        continue;
                    }

                    _addon.repoUrl = github.ToString();
                    _addon.downloadUrl = download.ToString();

                    //MessageBox.Show("download link OK.");

                    _addons.Add(_addon);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to parse anticope addon entry", e.Message);
                }
            }

            return _addons;
        }
        
        
        
        private bool updateFromGithub()
        {
            log("Updating the shop...");
            var addons = new List<MeteorAddon>();
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
            
            // rather parse this myself rather than use octo thingy
            var baseJson = client.DownloadString("https://api.github.com/search/repositories?q=meteor-addon");
            if (string.IsNullOrEmpty(baseJson))
            {
                log("Unable to update the shop (invalid reply from Github api)");
                return false;
            }

            var json = JsonConvert.DeserializeObject<dynamic>(baseJson);
            if (json == null)
            {
                log("Unable to update the shop (json parse error)");
                return false;
            }

            
            foreach (var ad in json.items)
            {
                try
                {
                    string name = ad.name.ToString(); // get the basics
                    string authorName = ad.owner.login.ToString();
                    string repoUrl = ad.html_url.ToString();

                    //MessageBox.Show(name + " " + repoUrl + " " + authorName);
                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(repoUrl) ||
                        string.IsNullOrEmpty(authorName)) continue;

                    if (name.EndsWith("-template")) continue;
                    
                    log("Checking " + name + " (" + repoUrl + ")");

                    var release = GithubUtils.ghClient.Repository.Release.GetAll(authorName, name).GetAwaiter().GetResult()[0];
                    var downloadU = release.Url; // get the latest release
                    
                    if (string.IsNullOrEmpty(downloadU))
                    {
                        log("Unable to find a release, skipping.");
                        //MessageBox.Show("cant get download url");
                        continue;
                    }

                    string defaultBranch = ad.default_branch;
                    if (string.IsNullOrEmpty(defaultBranch))
                    { // check default branch
                        log("Unable to get the default branch, skipping.");
                        continue;
                    }
                    
                    var addon = new MeteorAddon
                    {
                        name = name,
                        authorName = authorName,
                        repoUrl = repoUrl,
                        downloads = -1
                    };
                    
                    foreach (var asset in release.Assets)
                    { // find the download url
                        log("Checking release asset (" + asset.Name + ")");
                        if (asset.Name.Contains("-dev") || asset.Name.Contains("-sources")) continue;
                        addon.downloads = asset.DownloadCount;
                        addon.downloadUrl = asset.BrowserDownloadUrl;
                        addon.fileName = asset.Name;
                        log("Found valid download (" + asset.Name + ") with " + asset.DownloadCount + " downloads.");
                        //log("Got download count (" + asset.DownloadCount + ")");
                        break;
                    }

                    if (addon.downloads == -1) log("Unable to get download count.");
                    if (string.IsNullOrEmpty(addon.downloadUrl))
                    {
                        log("Unable to find a valid download (release asset), skipping.");
                        continue;
                    }
                    
                    if (!getExtraInfo(authorName, name, defaultBranch, client, addon)) continue;

                    addons.Add(addon);
                }
                catch (ApiException e) when (e.GetBaseException() is RateLimitExceededException)
                {
                    log("Github ratelimit, turn on a vpn and try again or wait a while.");
                    if (addons.Count > 1)
                    {
                        ShopCache.addonCache = addons;
                        Task.Run(ShopCache.saveToDisk);
                    }
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    log("Unable to find a release, skipping.");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to parse github addon entry",e.ToString());
                }
            }

            ShopCache.addList(addons);
            //ShopCache.addonCache = addons;
            Task.Run(ShopCache.saveToDisk);
            return true;
        }


        private bool getExtraInfo(string repoAuthor, string repoName, string defaultBranch, WebClient client, MeteorAddon addon)
        {
            var propUrl = "https://raw.githubusercontent.com/" + repoAuthor + "/" + repoName + "/" + defaultBranch + "/gradle.properties";
            var fabricUrl = "https://raw.githubusercontent.com/" + repoAuthor + "/" + repoName + "/" + defaultBranch + "/src/main/resources/fabric.mod.json";

            try
            {
                string props = client.DownloadString(propUrl);
                string fabric = client.DownloadString(fabricUrl);
                
                var fabricJson = JsonConvert.DeserializeObject<dynamic>(fabric); // get description
                if (fabricJson == null)
                {
                    log("No fabric.mod.json data, skipping...");
                    return false;
                }
                string desc = fabricJson.description;
                if (string.IsNullOrEmpty(desc))
                {
                    log("No description set, using default.");
                    desc = "No description";
                }
                addon.description = desc;

                string icon = fabricJson.icon; // get icon
                if (!string.IsNullOrEmpty(icon)) addon.iconUrl = "https://raw.githubusercontent.com/" + repoAuthor + "/" + repoName + "/" + defaultBranch + "/src/main/resources/" + icon;
                
                var authors = new List<string>(); // get authors
                foreach (var author in fabricJson.authors) authors.Add(author.ToString());

                if (authors.Count < 1)
                {
                    log("Unable to retrieve authors, using repo owner.");
                    addon.authors = new List<string>{ addon.authorName };
                }
                else
                {
                    addon.authors = authors;
                }

                var contact = fabricJson.contact;
                if (contact != null)
                {
                    var discordI = fabricJson.contact.discord;// get discord link (todo regex repo main page)
                    if (discordI == null)
                    {
                        log("No discord link in fabric.mod.json.");
                    }
                    else
                    {
                        string discordLink = discordI.ToString();
                        if (!string.IsNullOrEmpty(discordLink) && discordLink.Contains(".gg/"))
                        {
                            log("Got discord link " + "(" + discordLink + ")");
                            addon.discordLink = discordLink;
                        }
                    }
                }
                
                string[] propd = props.Split(new []{'\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in propd) // get mc + meteor version
                {
                    if (s.StartsWith("minecraft_version")) addon.mcVer = s.Replace(" ", "").Replace("minecraft_version=", "");
                    if (s.StartsWith("meteor_version")) addon.meteorVer = s.Replace(" ", "").Replace("meteor_version=", "");
                }

                if (string.IsNullOrEmpty(addon.mcVer))
                {
                    log("Unable to detect Minecraft version...");
                    addon.mcVer = "???";
                }

                if (string.IsNullOrEmpty(addon.meteorVer))
                {
                    log("Unable to detect Meteor version...");
                    addon.meteorVer = "???";
                }
                
            }
            catch (WebException e) when (e.Response is HttpWebResponse r)
            { // skip if it doesn't have a gradle.properties or fabric.mod.json
                //MessageBox.Show("not found " + addon.name);
                if (r.StatusCode == HttpStatusCode.NotFound)
                {
                    log("Missing essential file (probably not an addon), skipping...");
                    return false;
                }
            }

            return true;
        }

        /*private void addonList_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }*/
    }
}