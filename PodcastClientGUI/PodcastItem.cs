using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PodcastClientGUI
{
    public class PodcastItem
    {
        public string ItemUrl { get; set; }
        public string ItemLink { get; set; }
        public string ItemTitle { get; set; }
        public string ItemPubDate { get; set; }
        public string ItemDescription { get; set; }
        public bool Listened { get; set; }
        public bool Downloaded { get; set; }
        public string DownloadedLocation { get; set; }

        public PodcastItem(XElement xItem)
        {
            ItemUrl = xItem.Element("enclosure").Attribute("url").Value;
            ItemLink = xItem.Element("link").Value;
            ItemTitle = xItem.Element("title").Value;
            ItemPubDate = xItem.Element("pubDate").Value;
            ItemDescription = xItem.Element("description").Value;
            
            var parent = xItem.Parent.Element("title").Value;
            Uri uri = new Uri(ItemUrl);
            if (Directory.Exists(Form1.Manager.DownloadDirectory + parent))
            {
                if (
                    File.Exists(Form1.Manager.DownloadDirectory + parent + "\\" +
                                Path.GetFileName(uri.LocalPath)))
                {
                    Downloaded = true;
                    DownloadedLocation = Form1.Manager.DownloadDirectory + parent + "\\" +
                                         Path.GetFileName(uri.LocalPath);
                }
                else
                {
                    Downloaded = false;
                }
            }
        }
    }
}
