using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using WMPLib;

namespace PodcastClientGUI
{
    public class PodcastManager
    {
        static string SubsFilePath { get; set; }
        public List<PodcastSub> SubList { get; set; }
        static ConsoleKeyInfo cki { get; set; }
        public PodcastSub SelectedSub { get; set; }
        public PodcastItem SelectedItem { get; set; }
        static XDocument SubsDocument { get; set; }
        public string DownloadDirectory { get; set; }
        static PodcastSubscriptions Subs { get; set; }
        //static Thread WMPThread = new Thread(PlayPodcast);

        public PodcastManager()
        {
            SubsFilePath = "subs.xml";
            Subs = new PodcastSubscriptions(SubsFilePath);
            SubList = Subs.GetSubscriptions();
            SubsDocument = Subs.GetSubsDoc();
            DownloadDirectory = @"C:\Users\DunigA01\Downloads\Podcasts";
        }
        public XDocument GetSubsDocument()
        {
            return SubsDocument;
        }

    }
}
