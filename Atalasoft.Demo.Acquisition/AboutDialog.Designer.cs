// ------------------------------------------------------------------------------------
// <copyright file="AboutDialog.Designer.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes About dialog.
    /// </summary>
    public partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel downloadDotImageLinkLabel;
        private System.Windows.Forms.LinkLabel downloadHelpLinkLabel;
        private System.Windows.Forms.LinkLabel demoGalleryLinkLabel;

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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.downloadDotImageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.downloadHelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.demoGalleryLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(204, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atalasoft DotTwain";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(206, 167);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(128, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.atalasoft.com";
            this.linkLabel1.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.On_linkLabel1_LinkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Location = new System.Drawing.Point(261, 78);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(148, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version 8.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(261, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // downloadDotImageLinkLabel
            // 
            this.downloadDotImageLinkLabel.AutoSize = true;
            this.downloadDotImageLinkLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.downloadDotImageLinkLabel.Location = new System.Drawing.Point(206, 117);
            this.downloadDotImageLinkLabel.Name = "downloadDotImageLinkLabel";
            this.downloadDotImageLinkLabel.Size = new System.Drawing.Size(154, 13);
            this.downloadDotImageLinkLabel.TabIndex = 5;
            this.downloadDotImageLinkLabel.TabStop = true;
            this.downloadDotImageLinkLabel.Text = "Download the Latest DotImage";
            this.downloadDotImageLinkLabel.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.On_downloadDotImageLinkLabel_LinkClicked);
            // 
            // downloadHelpLinkLabel
            // 
            this.downloadHelpLinkLabel.AutoSize = true;
            this.downloadHelpLinkLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.downloadHelpLinkLabel.Location = new System.Drawing.Point(206, 143);
            this.downloadHelpLinkLabel.Name = "downloadHelpLinkLabel";
            this.downloadHelpLinkLabel.Size = new System.Drawing.Size(168, 13);
            this.downloadHelpLinkLabel.TabIndex = 6;
            this.downloadHelpLinkLabel.TabStop = true;
            this.downloadHelpLinkLabel.Text = "Download DotImage Help Installer";
            this.downloadHelpLinkLabel.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.On_downloadHelpLinkLabel_LinkClicked);
            // 
            // demoGalleryLinkLabel
            // 
            this.demoGalleryLinkLabel.AutoSize = true;
            this.demoGalleryLinkLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.demoGalleryLinkLabel.Location = new System.Drawing.Point(206, 167);
            this.demoGalleryLinkLabel.Name = "demoGalleryLinkLabel";
            this.demoGalleryLinkLabel.Size = new System.Drawing.Size(120, 13);
            this.demoGalleryLinkLabel.TabIndex = 7;
            this.demoGalleryLinkLabel.TabStop = true;
            this.demoGalleryLinkLabel.Text = "Acquisition Demo Home";
            this.demoGalleryLinkLabel.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.On_demoGalleryLinkLabel_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Atalasoft.Demo.Acquisition.Properties.Resources.dlgbmp;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(421, 278);
            this.Controls.Add(this.demoGalleryLinkLabel);
            this.Controls.Add(this.downloadHelpLinkLabel);
            this.Controls.Add(this.downloadDotImageLinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}