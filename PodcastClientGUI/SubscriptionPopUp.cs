using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PodcastClientGUI
{
    public partial class SubscriptionPopUp : Form
    {
        public SubscriptionPopUp()
        {
            InitializeComponent();
        }

        private void btnPopUpCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btnPopUpOk_Click(object sender, EventArgs e)
        {
            string url = textBoxPopUp.Text;
            if (url != "")
            {
                PodcastSubscriptions.AddNewSubscription(url);
                this.DialogResult = DialogResult.OK;
                //Close();
            }
        }
    }
}
