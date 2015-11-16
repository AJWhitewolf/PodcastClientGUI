using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using WMPLib;


namespace PodcastClientGUI
{
    public partial class Form1 : Form
    {
        public BackgroundWorker BW { get; set; }
        public static PodcastManager Manager { get; set; }
        static WindowsMediaPlayer WMP = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manager = new PodcastManager();
            List<PodcastSub> podList = Manager.SubList;
            RefreshSubscriptions();
            BW = new BackgroundWorker();
            BW.WorkerReportsProgress = true;
            BW.DoWork += new DoWorkEventHandler(bw_DoWork);
            BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        public void RefreshSubscriptions()
        {
            listBox1.Items.Clear();
            foreach (PodcastSub sub in Manager.SubList)
            {
                listBox1.Items.Add(sub.PodcastName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            labelStatus.Visible = true;
            int sli = listBox1.SelectedIndex;
            
            BW.RunWorkerAsync(sli);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> results = new List<string>();
            BackgroundWorker worker = sender as BackgroundWorker;
            int sli = (int) e.Argument;
            
            Manager.SelectedSub = Manager.SubList[sli];
            if (!Manager.SelectedSub.PodcastItemsLoaded)
            {
                Manager.SelectedSub.ReadAllItems();
            }
            foreach (PodcastItem item in Manager.SelectedSub.ListenedList)
            {
                results.Add(item.ItemTitle);
                int progPercent = (Manager.SelectedSub.ListenedList.IndexOf(item)/Manager.SelectedSub.ListenedList.Count)*100;
                worker.ReportProgress(progPercent);
            }
            e.Result = results;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {

            }
            else if (!(e.Error == null))
            {

            }
            else
            {
                List<string> result = (List<string>)e.Result;
                foreach (string line in result)
                {
                    listBox2.Items.Add(line);
                }
                labelStatus.Visible = false;
            }
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.Dispose();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager.SelectedItem = Manager.SelectedSub.ListenedList[listBox2.SelectedIndex];
            richTextBox1.Text = Manager.SelectedItem.ItemTitle;
            if (Manager.SelectedItem.Downloaded)
            {
                btnDownload.Enabled = false;
                btnStream.Text = "Stream";
            }
            else
            {
                btnDownload.Enabled = true;
                btnStream.Text = "Play";
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(Manager.SelectedItem.ItemUrl);
            if (!Directory.Exists(Manager.DownloadDirectory + Manager.SelectedSub.PodcastName))
            {
                Directory.CreateDirectory(Manager.DownloadDirectory + Manager.SelectedSub.PodcastName);
            }
            DownloadPodcast(Manager.SelectedItem.ItemUrl, Manager.DownloadDirectory + Manager.SelectedSub.PodcastName + "\\" + Path.GetFileName(uri.LocalPath));
        }

        public void DownloadPodcast(string url, string location)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += wc_DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(new Uri(url), location);
            }
            progBarDownload.Visible = true;
        }

        private void wc_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            btnDownload.Click -= this.btnDownload_Click;
            btnDownload.Enabled = false;
            Manager.SelectedItem.Downloaded = true;
            progBarDownload.Visible = false;
        }

        public void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != progBarDownload.Value)
            {
                progBarDownload.Value = e.ProgressPercentage;
            }
            //Console.Write("\r{0}Downloaded {1}kb of {2}kb. {3}% complete...", (string)e.UserState, e.BytesReceived / 1000, e.TotalBytesToReceive / 1000, e.ProgressPercentage);
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            if (Manager.SelectedItem.Downloaded)
            {
                axWindowsMediaPlayer1.URL = Manager.SelectedItem.DownloadedLocation;
            }
            else
            {
                axWindowsMediaPlayer1.URL = Manager.SelectedItem.ItemUrl;
            }
            //WMP.URL = Manager.SelectedItem.ItemUrl;
            //WMP.controls.play();
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddSubscription_Click(object sender, EventArgs e)
        {
            SubscriptionPopUp subWindow = new SubscriptionPopUp();
            if (subWindow.ShowDialog() == DialogResult.OK)
            {
                RefreshSubscriptions();
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
    }
}
