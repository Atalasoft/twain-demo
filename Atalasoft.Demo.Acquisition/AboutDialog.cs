// ------------------------------------------------------------------------------------
// <copyright file="AboutDialog.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

using System.Reflection;
using System.Windows.Forms;

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes About dialog.
    /// </summary>
    public partial class AboutDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutDialog"/> class.
        /// </summary>
        public AboutDialog()
        {
            InitializeComponent();

            Assembly asm = Assembly.Load("Atalasoft.DotTwain");
            this.lblVersion.Text = "Version: " + asm.GetName().Version.ToString();
        }

        private void On_linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.atalasoft.com");
        }

        private void On_downloadHelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.atalasoft.com/support/dotimage/help/install");
        }

        private void On_demoGalleryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.atalasoft.com/support/dotimage/demos/acquisition-demo");
        }

        private void On_downloadDotImageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.atalasoft.com/products/download/dotimage");
        }
    }
}