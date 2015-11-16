namespace PodcastClientGUI
{
    partial class SubscriptionPopUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPopUp = new System.Windows.Forms.TextBox();
            this.btnPopUpOk = new System.Windows.Forms.Button();
            this.btnPopUpCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a new Subscription URL: ";
            // 
            // textBoxPopUp
            // 
            this.textBoxPopUp.Location = new System.Drawing.Point(12, 34);
            this.textBoxPopUp.Name = "textBoxPopUp";
            this.textBoxPopUp.Size = new System.Drawing.Size(568, 20);
            this.textBoxPopUp.TabIndex = 1;
            // 
            // btnPopUpOk
            // 
            this.btnPopUpOk.Location = new System.Drawing.Point(495, 65);
            this.btnPopUpOk.Name = "btnPopUpOk";
            this.btnPopUpOk.Size = new System.Drawing.Size(89, 29);
            this.btnPopUpOk.TabIndex = 2;
            this.btnPopUpOk.Text = "OK";
            this.btnPopUpOk.UseVisualStyleBackColor = true;
            this.btnPopUpOk.Click += new System.EventHandler(this.btnPopUpOk_Click);
            // 
            // btnPopUpCancel
            // 
            this.btnPopUpCancel.Location = new System.Drawing.Point(400, 65);
            this.btnPopUpCancel.Name = "btnPopUpCancel";
            this.btnPopUpCancel.Size = new System.Drawing.Size(89, 29);
            this.btnPopUpCancel.TabIndex = 3;
            this.btnPopUpCancel.Text = "Cancel";
            this.btnPopUpCancel.UseVisualStyleBackColor = true;
            this.btnPopUpCancel.Click += new System.EventHandler(this.btnPopUpCancel_Click);
            // 
            // SubscriptionPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 100);
            this.Controls.Add(this.btnPopUpCancel);
            this.Controls.Add(this.btnPopUpOk);
            this.Controls.Add(this.textBoxPopUp);
            this.Controls.Add(this.label1);
            this.Name = "SubscriptionPopUp";
            this.Text = "SubscriptionPopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPopUp;
        private System.Windows.Forms.Button btnPopUpOk;
        private System.Windows.Forms.Button btnPopUpCancel;
    }
}