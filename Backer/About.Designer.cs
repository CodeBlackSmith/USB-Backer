namespace Backer
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.websiteUrl = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.websiteLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // websiteUrl
            // 
            this.websiteUrl.AutoSize = true;
            this.websiteUrl.Location = new System.Drawing.Point(204, 55);
            this.websiteUrl.Name = "websiteUrl";
            this.websiteUrl.Size = new System.Drawing.Size(178, 13);
            this.websiteUrl.TabIndex = 13;
            this.websiteUrl.TabStop = true;
            this.websiteUrl.Text = "https://github.com/CodeBlackSmith";
            this.websiteUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteUrl_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Copyright © CodeBlackSmith. All rights reserved.";
            // 
            // websiteLbl
            // 
            this.websiteLbl.AutoSize = true;
            this.websiteLbl.Location = new System.Drawing.Point(146, 55);
            this.websiteLbl.Name = "websiteLbl";
            this.websiteLbl.Size = new System.Drawing.Size(41, 13);
            this.websiteLbl.TabIndex = 11;
            this.websiteLbl.Text = "Github:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 155);
            this.Controls.Add(this.websiteUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.websiteLbl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel websiteUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label websiteLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}