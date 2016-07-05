// ------------------------------------------------------------------------------------
// <copyright file="InfoDialog.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes progress info dialog.
    /// </summary>
    public class InfoDialog : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container components = null;

        private Label lblInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoDialog"/> class.
        /// </summary>
        /// <param name="message">Progress text.</param>
        public InfoDialog(string message)
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            this.lblInfo.Text = message;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">The value indicating whether disposing is in progress.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(11, 7);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(270, 94);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Working... Please wait.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.TextChanged += new System.EventHandler(this.On_lblInfo_TextChanged);
            // 
            // InfoDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 109);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ResumeLayout(false);
        }
        #endregion

        private void On_lblInfo_TextChanged(object sender, System.EventArgs e)
        {
            this.Refresh();
            Application.DoEvents();
        }
    }
}
