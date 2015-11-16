using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace PodcastClientGUI
{
    public class PodcastSub
    {
        internal string PodcastUrl { get; set; }
        internal string PodcastName { get; set; }
        internal string PodcastLink { get; set; }
        internal bool PodcastItemsLoaded { get; set; }

        internal XDocument SubXDoc { get; set; }
        internal List<PodcastItem> ListenedList { get; set; }

        public PodcastSub(string url, string title)
        {
            PodcastUrl = url;
            PodcastName = title;
            ListenedList = new List<PodcastItem>();
            PodcastSubscriptions.Subscriptions.Add(this);
        }

        public void LoadSubXML()
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17";
            var stream = client.OpenRead(PodcastUrl);
            XmlReader reader = XmlReader.Create(stream);
            SubXDoc = XDocument.Load(reader);
            reader.Close();
        }

        public int GetCount()
        {
            if (SubXDoc == null)
            {
                LoadSubXML();
            }
            return SubXDoc.Element("rss").Element("channel").Elements("item").Count();
            //Console.WriteLine("Title: {0}, Count: {1}", PodcastName, SubXDoc.Element("rss").Element("channel").Elements("item").Count());
        }

        public void UpdateSub()
        {
            if (SubXDoc == null)
            {
                LoadSubXML();
            }
            string mostRecentPubDate = SubXDoc.Element("root").Element("channel").Element("item").Element("pubDate").Value;
            if (ListenedList.Count > 0)
            {
                if (mostRecentPubDate != ListenedList[0].ItemPubDate)
                {
                    var newItem2 = (
                        from item in SubXDoc.Descendants("item")
                        where DateTime.Compare(convertDateTime(item.Element("pubDate").Value), convertDateTime(ListenedList[0].ItemPubDate)) > 0
                        orderby (DateTime)convertDateTime(item.Element("pubDate").Value)
                        select item
                        );
                    foreach (XElement pitem in newItem2)
                    {
                        PodcastItem newItem = new PodcastItem(pitem);
                        ListenedList.Insert(0, newItem);
                    }
                }
            }
        }

        public void ReadAllItems()
        {
            if (SubXDoc == null)
            {
                LoadSubXML();
            }
            ListenedList.Clear();
            var items = from item in SubXDoc.Descendants("item")
                        select item;
            foreach (XElement item in items)
            {
                PodcastItem newItem = new PodcastItem(item);
                XDocument xdoc = Form1.Manager.GetSubsDocument();
                var listened = from ii in xdoc.Descendants("item")
                               where ii.Parent.Attribute("title").Value == PodcastName &&
                               ii.Attribute("title").Value == newItem.ItemTitle &&
                               ii.Attribute("url").Value == newItem.ItemUrl
                               select ii;
                if (listened.Any())
                {
                    newItem.Listened = true;
                }
                ListenedList.Add(newItem);
            }
            PodcastItemsLoaded = true;
        }

        internal DateTime convertDateTime(string pubDate)
        {
            string bit = pubDate.Split("+".ToCharArray())[0];
            string RFC822 = "ddd, dd MM yyyy HH:mm:ss";
            DateTime dt = DateTime.ParseExact(bit, RFC822, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            return dt;
        }

        public void MarkItemListened(PodcastItem pItem)
        {
            var xdoc = Form1.Manager.GetSubsDocument();
            var pNode = (from sub in xdoc.Descendants("sub")
                         where sub.Attribute("title").Value == PodcastName
                         select sub).FirstOrDefault();
            var check = (from item in pNode.Descendants("item")
                         where item.Attribute("title").Value == pItem.ItemTitle
                         select item).Count();
            if (check < 1)
            {
                XElement node = new XElement("item", new XAttribute("title", pItem.ItemTitle), new XAttribute("url", pItem.ItemUrl), new XAttribute("pubDate", pItem.ItemPubDate));
                pNode.Add(node);
            }
            pItem.Listened = true;
            xdoc.Save("subs.xml");
        }
    }
}
