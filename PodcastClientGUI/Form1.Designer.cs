namespace PodcastClientGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnStream = new System.Windows.Forms.Button();
            this.progBarDownload = new System.Windows.Forms.ProgressBar();
            this.btnCheckSubs = new System.Windows.Forms.Button();
            this.btnAddSubscription = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1333, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 68);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(263, 624);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(281, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(1040, 364);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(281, 398);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1039, 294);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1183, 706);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(138, 31);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnStream
            // 
            this.btnStream.Location = new System.Drawing.Point(1059, 707);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(118, 31);
            this.btnStream.TabIndex = 6;
            this.btnStream.Text = "Stream";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // progBarDownload
            // 
            this.progBarDownload.Location = new System.Drawing.Point(814, 708);
            this.progBarDownload.Name = "progBarDownload";
            this.progBarDownload.Size = new System.Drawing.Size(239, 30);
            this.progBarDownload.Step = 1;
            this.progBarDownload.TabIndex = 7;
            this.progBarDownload.Visible = false;
            // 
            // btnCheckSubs
            // 
            this.btnCheckSubs.Location = new System.Drawing.Point(12, 706);
            this.btnCheckSubs.Name = "btnCheckSubs";
            this.btnCheckSubs.Size = new System.Drawing.Size(262, 32);
            this.btnCheckSubs.TabIndex = 8;
            this.btnCheckSubs.Text = "Update Subscriptions";
            this.btnCheckSubs.UseVisualStyleBackColor = true;
            // 
            // btnAddSubscription
            // 
            this.btnAddSubscription.Location = new System.Drawing.Point(12, 28);
            this.btnAddSubscription.Name = "btnAddSubscription";
            this.btnAddSubscription.Size = new System.Drawing.Size(262, 34);
            this.btnAddSubscription.TabIndex = 9;
            this.btnAddSubscription.Text = "Add New Subscription";
            this.btnAddSubscription.UseVisualStyleBackColor = true;
            this.btnAddSubscription.Click += new System.EventHandler(this.btnAddSubscription_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(1236, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(83, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Fetching Data...";
            this.labelStatus.Visible = false;
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(281, 696);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(527, 42);
            this.axWindowsMediaPlayer1.TabIndex = 14;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 750);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnAddSubscription);
            this.Controls.Add(this.btnCheckSubs);
            this.Controls.Add(this.progBarDownload);
            this.Controls.Add(this.btnStream);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnStream;
        public System.Windows.Forms.ProgressBar progBarDownload;
        private System.Windows.Forms.Button btnCheckSubs;
        private System.Windows.Forms.Button btnAddSubscription;
        private System.Windows.Forms.Label labelStatus;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

