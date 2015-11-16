using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PodcastClientGUI
{
    public class PodcastSubscriptions
    {
        public static XDocument SubsDoc { get; set; }
        public static List<PodcastSub> Subscriptions { get; set; }

        public PodcastSubscriptions(string subDocUrl)
        {
            Subscriptions = new List<PodcastSub>();
            if (File.Exists(subDocUrl))
            {
                SubsDoc = XDocument.Load(subDocUrl);
                //Console.WriteLine("Number of Subscriptions: {0}", SubsDoc.Element("root").Elements("sub").Count());
                foreach (XElement sub in SubsDoc.Element("root").Elements("sub"))
                {
                    //Console.WriteLine("Adding Subscription {0}", sub.Attribute("title").Value);
                    PodcastSub newSub = new PodcastSub(sub.Attribute("url").Value, sub.Attribute("title").Value);
                    //Subscriptions.Add(newSub);
                }
            }
            else
            {
                XDocument xdoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("root")
                    );
                xdoc.Save(subDocUrl);
                SubsDoc = XDocument.Load(subDocUrl);
            }
        }

        public static void AddNewSubscription(string url)
        {
            XDocument xdoc = XDocument.Load(url);
            string title = xdoc.Element("rss").Element("channel").Element("title").Value;
            //string link = xdoc.Element("rss").Element("channel").Element("link").Value;
            PodcastSub newSub = new PodcastSub(url, title);
            SubsDoc.Element("root").Add(new XElement("sub", new XAttribute("title", title), new XAttribute("url", url)));
            SubsDoc.Save("subs.xml");
        }

        public void CheckSubscriptions()
        {

        }

        public void CountSubscriptions()
        {
            Console.WriteLine("Displaying Item Counts");
            foreach (PodcastSub sub in Subscriptions)
            {
                Console.WriteLine("Title: {0}, Count: {1}", sub.PodcastName, sub.GetCount());
            }
        }

        public List<PodcastSub> GetSubscriptions()
        {
            return Subscriptions;
        }

        public XDocument GetSubsDoc()
        {
            return SubsDoc;
        }
    }
}
