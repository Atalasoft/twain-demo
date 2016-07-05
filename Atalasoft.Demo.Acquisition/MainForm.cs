// ------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Atalasoft.Twain;

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes the main form.
    /// </summary>
    public class MainForm : Form
    {
        private readonly List<ComboBox> _disabledControls = new List<ComboBox>();

        #region UI Controls

        private TabControl tabImages;
        private Panel panel1;
        private Label label1;
        private MenuStrip menuMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem acquireToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ComboBox cboPixelType;
        private Label label3;
        private ComboBox cboTransferMethod;
        private Label label2;
        private ComboBox cboDevice;
        private ComboBox cboResolution;
        private Label label5;
        private ComboBox cboBitDepth;
        private Label label4;
        private CheckBox chkHideProgress;
        private CheckBox chkHideInterface;
        private CheckBox chkKeepInterfaceOpen;
        private CheckBox chkModalAcquire;
        private ToolStripMenuItem acquireCustomInterfaceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ComboBox cboFrameSize;
        private Label label6;
        private ToolStripMenuItem capabilityInformationToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;

        #endregion

        private bool _keepUIOpen;
        private InfoDialog _infoDialog;
        private string _fileDialogFilter = string.Empty;
        private Twain.Acquisition acquisition;
        private Device device = null;
        private ToolStripMenuItem saveAcquireParametersToolStripMenuItem;
        private ToolStripMenuItem acquireFromParametersToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private int _scanCount;
        private bool _updatingValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">The value indicating whether disposing is in progress.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.device != null) this.device.Close();
                if (this.acquisition != null) this.acquisition.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\nStack Trace:\r\n" + ex.StackTrace, "Exception");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.acquisition = new Twain.Acquisition();

            this.acquisition.AsynchronousException += this.On_acquisition_AsynchronousException;
            this.acquisition.AcquireCanceled += On_acquisition_AcquireCanceled;
            this.acquisition.AcquireFinished += On_;
            this.acquisition.DeviceEvent += On_acquisition_DeviceEvent;
            this.acquisition.FileTransfer += On_acquisition_FileTransfer;
            this.acquisition.ImageAcquired += On_acquisition_ImageAcquired;

            ShowInfoDialog("Loading devices...");
            LoadDeviceNames();
            HideInfoDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.device != null && this.device.State > TwainState.Loaded)
                this.device.Close();

            if (this.acquisition != null)
                this.acquisition.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (MainForm));
            this.tabImages = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFrameSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkKeepInterfaceOpen = new System.Windows.Forms.CheckBox();
            this.chkModalAcquire = new System.Windows.Forms.CheckBox();
            this.chkHideProgress = new System.Windows.Forms.CheckBox();
            this.chkHideInterface = new System.Windows.Forms.CheckBox();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBitDepth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPixelType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTransferMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquireCustomInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAcquireParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquireFromParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.capabilityInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabImages
            // 
            this.tabImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImages.Location = new System.Drawing.Point(174, 24);
            this.tabImages.Name = "tabImages";
            this.tabImages.SelectedIndex = 0;
            this.tabImages.Size = new System.Drawing.Size(516, 431);
            this.tabImages.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cboFrameSize);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkKeepInterfaceOpen);
            this.panel1.Controls.Add(this.chkModalAcquire);
            this.panel1.Controls.Add(this.chkHideProgress);
            this.panel1.Controls.Add(this.chkHideInterface);
            this.panel1.Controls.Add(this.cboResolution);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboBitDepth);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboPixelType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTransferMethod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboDevice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 431);
            this.panel1.TabIndex = 1;
            // 
            // cboFrameSize
            // 
            this.cboFrameSize.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFrameSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrameSize.FormattingEnabled = true;
            this.cboFrameSize.Location = new System.Drawing.Point(15, 292);
            this.cboFrameSize.Name = "cboFrameSize";
            this.cboFrameSize.Size = new System.Drawing.Size(142, 21);
            this.cboFrameSize.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Frame Size:";
            // 
            // chkKeepInterfaceOpen
            // 
            this.chkKeepInterfaceOpen.AutoSize = true;
            this.chkKeepInterfaceOpen.Location = new System.Drawing.Point(15, 402);
            this.chkKeepInterfaceOpen.Name = "chkKeepInterfaceOpen";
            this.chkKeepInterfaceOpen.Size = new System.Drawing.Size(125, 17);
            this.chkKeepInterfaceOpen.TabIndex = 16;
            this.chkKeepInterfaceOpen.Text = "Keep Interface Open";
            this.chkKeepInterfaceOpen.UseVisualStyleBackColor = true;
            this.chkKeepInterfaceOpen.CheckedChanged += new System.EventHandler(this.On_chkKeepInterfaceOpen_CheckedChanged);
            // 
            // chkModalAcquire
            // 
            this.chkModalAcquire.AutoSize = true;
            this.chkModalAcquire.Location = new System.Drawing.Point(15, 379);
            this.chkModalAcquire.Name = "chkModalAcquire";
            this.chkModalAcquire.Size = new System.Drawing.Size(94, 17);
            this.chkModalAcquire.TabIndex = 15;
            this.chkModalAcquire.Text = "Modal Acquire";
            this.chkModalAcquire.UseVisualStyleBackColor = true;
            // 
            // chkHideProgress
            // 
            this.chkHideProgress.AutoSize = true;
            this.chkHideProgress.Location = new System.Drawing.Point(15, 356);
            this.chkHideProgress.Name = "chkHideProgress";
            this.chkHideProgress.Size = new System.Drawing.Size(125, 17);
            this.chkHideProgress.TabIndex = 14;
            this.chkHideProgress.Text = "Hide Progress Dialog";
            this.chkHideProgress.UseVisualStyleBackColor = true;
            // 
            // chkHideInterface
            // 
            this.chkHideInterface.AutoSize = true;
            this.chkHideInterface.Location = new System.Drawing.Point(15, 333);
            this.chkHideInterface.Name = "chkHideInterface";
            this.chkHideInterface.Size = new System.Drawing.Size(130, 17);
            this.chkHideInterface.TabIndex = 13;
            this.chkHideInterface.Text = "Hide Device Interface";
            this.chkHideInterface.UseVisualStyleBackColor = true;
            this.chkHideInterface.CheckedChanged += new System.EventHandler(this.On_chkHideInterface_CheckedChanged);
            // 
            // cboResolution
            // 
            this.cboResolution.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Location = new System.Drawing.Point(15, 241);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(142, 21);
            this.cboResolution.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Resolution:";
            // 
            // cboBitDepth
            // 
            this.cboBitDepth.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBitDepth.FormattingEnabled = true;
            this.cboBitDepth.Location = new System.Drawing.Point(15, 186);
            this.cboBitDepth.Name = "cboBitDepth";
            this.cboBitDepth.Size = new System.Drawing.Size(142, 21);
            this.cboBitDepth.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bit Depth:";
            // 
            // cboPixelType
            // 
            this.cboPixelType.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPixelType.FormattingEnabled = true;
            this.cboPixelType.Location = new System.Drawing.Point(15, 131);
            this.cboPixelType.Name = "cboPixelType";
            this.cboPixelType.Size = new System.Drawing.Size(142, 21);
            this.cboPixelType.TabIndex = 8;
            this.cboPixelType.SelectedIndexChanged += new System.EventHandler(this.On_cboPixelType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pixel Type:";
            // 
            // cboTransferMethod
            // 
            this.cboTransferMethod.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTransferMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransferMethod.FormattingEnabled = true;
            this.cboTransferMethod.Location = new System.Drawing.Point(15, 79);
            this.cboTransferMethod.Name = "cboTransferMethod";
            this.cboTransferMethod.Size = new System.Drawing.Size(142, 21);
            this.cboTransferMethod.TabIndex = 6;
            this.cboTransferMethod.SelectedIndexChanged +=
                new System.EventHandler(this.On_cboTransferMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Transfer Method:";
            // 
            // cboDevice
            // 
            this.cboDevice.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Items.AddRange(new object[]
            {
                "Select Source..."
            });
            this.cboDevice.Location = new System.Drawing.Point(15, 29);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(142, 21);
            this.cboDevice.TabIndex = 4;
            this.cboDevice.SelectedIndexChanged += new System.EventHandler(this.On_cboDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device:";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.fileToolStripMenuItem,
                this.helpToolStripMenuItem
            });
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(690, 24);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.acquireToolStripMenuItem,
                this.acquireCustomInterfaceToolStripMenuItem,
                this.toolStripMenuItem1,
                this.saveAcquireParametersToolStripMenuItem,
                this.acquireFromParametersToolStripMenuItem,
                this.toolStripMenuItem2,
                this.capabilityInformationToolStripMenuItem,
                this.toolStripMenuItem3,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // acquireToolStripMenuItem
            // 
            this.acquireToolStripMenuItem.Name = "acquireToolStripMenuItem";
            this.acquireToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.acquireToolStripMenuItem.Text = "&Acquire";
            this.acquireToolStripMenuItem.Click += new System.EventHandler(this.On_acquireToolStripMenuItem_Click);
            // 
            // acquireCustomInterfaceToolStripMenuItem
            // 
            this.acquireCustomInterfaceToolStripMenuItem.Name = "acquireCustomInterfaceToolStripMenuItem";
            this.acquireCustomInterfaceToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.acquireCustomInterfaceToolStripMenuItem.Text = "Acquire (Custom Interface)";
            this.acquireCustomInterfaceToolStripMenuItem.Click +=
                new System.EventHandler(this.On_acquireCustomInterfaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // saveAcquireParametersToolStripMenuItem
            // 
            this.saveAcquireParametersToolStripMenuItem.Name = "saveAcquireParametersToolStripMenuItem";
            this.saveAcquireParametersToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveAcquireParametersToolStripMenuItem.Text = "Save Acquire Parameters";
            this.saveAcquireParametersToolStripMenuItem.Click +=
                new System.EventHandler(this.On_saveAcquireParametersToolStripMenuItem_Click);
            // 
            // acquireFromParametersToolStripMenuItem
            // 
            this.acquireFromParametersToolStripMenuItem.Name = "acquireFromParametersToolStripMenuItem";
            this.acquireFromParametersToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.acquireFromParametersToolStripMenuItem.Text = "Acquire From Parameters";
            this.acquireFromParametersToolStripMenuItem.Click +=
                new System.EventHandler(this.On_acquireFromParametersToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // capabilityInformationToolStripMenuItem
            // 
            this.capabilityInformationToolStripMenuItem.Name = "capabilityInformationToolStripMenuItem";
            this.capabilityInformationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.capabilityInformationToolStripMenuItem.Text = "Capability Information...";
            this.capabilityInformationToolStripMenuItem.Click +=
                new System.EventHandler(this.On_capabilityInformationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.On_exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.On_aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(690, 455);
            this.Controls.Add(this.tabImages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Acquisition Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Acquisition Events

        private void On_acquisition_AcquireCanceled(object sender, System.EventArgs e)
        {
            // If we are keeping the interface open between scans,
            // the user will have to click 'Cancel' to close it.
            if (this._keepUIOpen)
                this.device.Disable();

            this.device.Close();
            EnableDisableMenus(true);
        }

        private void On_(object sender, System.EventArgs e)
        {
            // This is the only event where you should call the Close method.
            // AcquireFinished fires after all images have been acquired.
            // Note that you can call Close anytime if you need to cancel
            // any pending transfers and do a quick shutdown of your application.
            if (this._keepUIOpen == false)
            {
                this.device.Close();
                EnableDisableMenus(true);
            }
        }

        private void On_acquisition_ImageAcquired(object sender, Atalasoft.Twain.AcquireEventArgs e)
        {
            _scanCount++;

            // Add a new tab for the image.
            TabPage tab = new TabPage();
            tab.AutoScroll = true;
            PictureBox pic = new PictureBox();
            tab.Controls.Add(pic);
            this.tabImages.TabPages.Add(tab);

            if (e.Image != null)
            {
                tab.Text = "Scan " + _scanCount.ToString();
                pic.Image = e.Image;
            }
            else if (e.FileName != null && File.Exists(e.FileName))
            {
                tab.Text = Path.GetFileName(e.FileName);

                using (FileStream fs = new FileStream(e.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    pic.Image = new Bitmap(fs);
                }
            }

            pic.Width = pic.Image.Width;
            pic.Height = pic.Image.Height;
        }

        private void On_acquisition_FileTransfer(object sender, Atalasoft.Twain.FileTransferEventArgs e)
        {
            // This will fire before a file transfer takes place to
            // allow you to set the filename and format of this image.
            // Once the file is acquired and saved, the ImageAcquired
            // event fires with the filename of the image just saved.
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = this._fileDialogFilter;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // Delete the existing file.
                try
                {
                    if (File.Exists(dlg.FileName))
                        File.Delete(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error trying to delete the file.\r\n\r\n" + ex.Message,
                        "Delete File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.CancelPending = true;
                    return;
                }

                e.FileName = dlg.FileName;
                string[] filters = dlg.Filter.Split('|');
                switch (filters[(dlg.FilterIndex - 1) * 2])
                {
                    case "TIFF (*.tif)":
                        e.FileFormat = SourceImageFormat.Tiff;
                        break;
                    case "JPEG (*.jpg)":
                        e.FileFormat = SourceImageFormat.Jfif;
                        break;
                    case "PNG (*.png)":
                        e.FileFormat = SourceImageFormat.Png;
                        break;
                    case "Multipage TIFF (*.tif)":
                        e.FileFormat = SourceImageFormat.TiffMulti;
                        break;
                    case "XBM (*.xbm)":
                        e.FileFormat = SourceImageFormat.Xbm;
                        break;
                    case "PDF (*.pdf)":
                        e.FileFormat = SourceImageFormat.Pdf;
                        break;
                    case "JPEG 2000 (*.jp2)":
                        e.FileFormat = SourceImageFormat.Jpeg2000;
                        break;
                    default:
                        e.FileFormat = SourceImageFormat.Bmp;
                        break;
                }
            }
            else
                e.CancelPending = true;

            dlg.Dispose();
        }

        private void On_acquisition_DeviceEvent(object sender, Atalasoft.Twain.DeviceEventArgs e)
        {
            // One of the many device events has fired.
            // You will only receive the events you have set using
            // the Device.DeviceEvents property.
            if (e.Event == DeviceEventFlags.PaperJam)
                MessageBox.Show(this, "Paper jam!!!");
            else
                MessageBox.Show(this, "Device Event:  " + e.Event.ToString());
        }

        private void On_acquisition_AsynchronousException(object sender, Atalasoft.Twain.AsynchronousExceptionEventArgs e)
        {
            // Make sure you close the connection when there is an error during a scan.
            this.device.Close();
            MessageBox.Show(this, e.Exception.Message, "Asynchronous Exception");
        }

        #endregion

        #region Private Methods

        private void EnableDisableMenus(bool enabled)
        {
            this.fileToolStripMenuItem.Enabled = enabled;

            this.cboDevice.Enabled = enabled;
            this.cboTransferMethod.Enabled = enabled;

            // We do this so controls that are disabled 
            if (enabled)
            {
                int len = _disabledControls.Count;
                for (int i = 0; i < len; i++)
                {
                    ComboBox box = _disabledControls[i];
                    box.Enabled = true;
                }
            }
            else
            {
                if (this.cboPixelType.Enabled)
                {
                    this.cboPixelType.Enabled = false;
                    _disabledControls.Add(this.cboPixelType);
                }

                if (this.cboBitDepth.Enabled)
                {
                    this.cboBitDepth.Enabled = false;
                    _disabledControls.Add(this.cboBitDepth);
                }

                if (this.cboResolution.Enabled)
                {
                    this.cboResolution.Enabled = false;
                    _disabledControls.Add(this.cboResolution);
                }

                if (this.cboFrameSize.Enabled)
                {
                    this.cboFrameSize.Enabled = false;
                    _disabledControls.Add(this.cboFrameSize);
                }
            }
        }

        private void ClearTabs()
        {
            // Calling TabPages.Clear will not release the memory
            // used by the images, so we have to dispose them manually.
            foreach (TabPage page in this.tabImages.TabPages)
            {
                PictureBox pic = page.Controls[0] as PictureBox;
                if (pic != null)
                {
                    page.Controls.Remove(pic);
                    if (pic.Image != null) pic.Image.Dispose();
                    pic.Dispose();
                }
            }

            this.tabImages.TabPages.Clear();
        }

        private void ShowInfoDialog(string message)
        {
            this._infoDialog = new InfoDialog("Loading devices...");
            Rectangle rc = Screen.PrimaryScreen.WorkingArea;
            this._infoDialog.Show();
            Application.DoEvents();
        }

        private void HideInfoDialog()
        {
            this._infoDialog.Close();
            this._infoDialog.Dispose();
            this._infoDialog = null;
        }

        private void LoadDeviceNames()
        {
            // Never assume that a system has any acquisition devices.
            if (!this.acquisition.SystemHasTwain || this.acquisition.Devices.Count == 0)
                return;

            string defaultDevice = this.acquisition.Devices.Default.Identity.ProductName;

            // Add a menu item for each device.
            foreach (Device dev in this.acquisition.Devices)
            {
                this.cboDevice.Items.Add(dev.Identity.ProductName);
            }

            int index = this.cboDevice.Items.IndexOf(defaultDevice);
            if (index > -1) this.cboDevice.SelectedIndex = index;
        }

        private void FillDeviceInformation()
        {
            if (this.device == null) return;

            this.Cursor = Cursors.WaitCursor;
            if (this.device.TryOpen())
            {
                try
                {
                    _updatingValues = true;
                    UpdateTransferMethodValues();
                    UpdatePixelTypeValues();
                    UpdateBitDepthValues();
                    UpdateResolutionValues();
                    UpdateFrameSizeValues();
                }
                finally
                {
                    _updatingValues = false;
                    this.device.Close();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void UpdateTransferMethodValues()
        {
            this.cboTransferMethod.Items.Clear();
            if (this.device.QueryCapability(DeviceCapability.ICAP_XFERMECH, true))
            {
                this.cboTransferMethod.Enabled = true;

                TwainTransferMethod[] methods = this.device.GetSupportedTransferMethods();
                foreach (TwainTransferMethod method in methods)
                    this.cboTransferMethod.Items.Add(method);

                int index = this.cboTransferMethod.Items.IndexOf(this.device.TransferMethod);
                if (index > -1) this.cboTransferMethod.SelectedIndex = index;
            }
            else
                this.cboTransferMethod.Enabled = false;
        }

        private void UpdatePixelTypeValues()
        {
            this.cboPixelType.Items.Clear();
            if (this.device.QueryCapability(DeviceCapability.ICAP_PIXELTYPE, true))
            {
                this.cboPixelType.Enabled = true;

                ImagePixelType[] pixelTypes = this.device.GetSupportedPixelTypes();
                foreach (ImagePixelType pt in pixelTypes)
                    this.cboPixelType.Items.Add(pt);

                int index = this.cboPixelType.Items.IndexOf(this.device.PixelType);
                if (index > -1) this.cboPixelType.SelectedIndex = index;
            }
            else
                this.cboPixelType.Enabled = false;
        }

        private void UpdateBitDepthValues()
        {
            this.cboBitDepth.Items.Clear();
            if (this.device.QueryCapability(DeviceCapability.ICAP_BITDEPTH, true))
            {
                this.cboBitDepth.Enabled = true;

                int[] bitDepths = this.device.GetSupportedBitDepths();
                foreach (int bd in bitDepths)
                    this.cboBitDepth.Items.Add(bd);

                int index = this.cboBitDepth.Items.IndexOf(this.device.BitDepth);
                if (index > -1) this.cboBitDepth.SelectedIndex = index;
            }
            else
                this.cboBitDepth.Enabled = false;
        }

        private void UpdateResolutionValues()
        {
            this.cboResolution.Items.Clear();
            if (this.device.QueryCapability(DeviceCapability.ICAP_XRESOLUTION, true))
            {
                this.cboResolution.Enabled = true;

                TwainResolution[] resolutions = this.device.GetSupportedResolutions();
                foreach (TwainResolution res in resolutions)
                    this.cboResolution.Items.Add(res.X.ToString() + ", " + res.Y.ToString());

                TwainResolution resolution = this.device.Resolution;
                int index = this.cboResolution.Items.IndexOf(resolution.X.ToString() + ", " + resolution.Y.ToString());
                if (index > -1) this.cboResolution.SelectedIndex = index;
            }
            else
                this.cboResolution.Enabled = false;
        }

        private void UpdateFrameSizeValues()
        {
            this.cboFrameSize.Items.Clear();
            if (this.device.QueryCapability(DeviceCapability.ICAP_SUPPORTEDSIZES, true))
            {
                this.cboFrameSize.Enabled = true;

                StaticFrameSizeType[] frameSizes = this.device.GetSupportedFrameSizes();
                foreach (StaticFrameSizeType fs in frameSizes)
                    this.cboFrameSize.Items.Add(fs);

                int index = this.cboFrameSize.Items.IndexOf(this.device.FrameSize);
                if (index > -1) this.cboFrameSize.SelectedIndex = index;
            }
            else
                this.cboFrameSize.Enabled = false;
        }

        private void SetResolutionValue()
        {
            if (this.cboResolution.Enabled == false)
                return;

            string[] val = this.cboResolution.Text.Split(',');
            float x, y;
            if (float.TryParse(val[0].Trim(), out x) && float.TryParse(val[1].Trim(), out y))
                this.device.Resolution = new TwainResolution(x, y);
        }

        #endregion

        #region Menu Events

        private void On_acquireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Perform a normal acquire.
            ClearTabs();

            if (this.device == null)
                this.device = this.acquisition.Devices.Default;

            if (this.device.TryOpen())
            {
                if (this.cboTransferMethod.Enabled && this.cboTransferMethod.SelectedIndex != -1)
                    this.device.TransferMethod = (TwainTransferMethod)this.cboTransferMethod.SelectedItem;
                if (this.cboPixelType.Enabled && this.cboPixelType.SelectedIndex != -1)
                    this.device.PixelType = (ImagePixelType)this.cboPixelType.SelectedItem;
                if (this.cboBitDepth.Enabled && this.cboBitDepth.SelectedIndex != -1)
                    this.device.BitDepth = (int)this.cboBitDepth.SelectedItem;

                SetResolutionValue();

                if (this.cboFrameSize.Enabled && this.cboFrameSize.SelectedIndex != -1)
                    this.device.FrameSize = (StaticFrameSizeType)this.cboFrameSize.SelectedItem;

                this.device.HideInterface = this.chkHideInterface.Checked;
                this.device.ModalAcquire = this.chkModalAcquire.Checked;
                this.device.DisplayProgressIndicator = !this.chkHideProgress.Checked;

                EnableDisableMenus(false);

                // If the transfer method is FILE, get a list of supported file types.
                TwainTransferMethod tm = this.device.TransferMethod;
                if (tm == TwainTransferMethod.TWSX_FILE || tm == TwainTransferMethod.TWSX_FILE2)
                {
                    _fileDialogFilter = string.Empty;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    SourceImageFormat[] formats = this.device.GetSupportedImageFormats();
                    foreach (SourceImageFormat format in formats)
                    {
                        switch (format)
                        {
                            case SourceImageFormat.Bmp:
                                sb.Append("Bitmap (*.bmp)|*.bmp|");
                                break;
                            case SourceImageFormat.Jfif:
                                sb.Append("JPEG (*.jpg)|*.jpg|");
                                break;
                            case SourceImageFormat.Jpeg2000:
                                sb.Append("JPEG 2000 (*.jp2)|*.jp2|");
                                break;
                            case SourceImageFormat.Pdf:
                                sb.Append("PDF (*.pdf)|*.pdf|");
                                break;
                            case SourceImageFormat.Png:
                                sb.Append("PNG (*.png)|*.png|");
                                break;
                            case SourceImageFormat.Tiff:
                                sb.Append("TIFF (*.tif)|*.tif|");
                                break;
                            case SourceImageFormat.TiffMulti:
                                sb.Append("Multipage TIFF (*.tif)|*.tif|");
                                break;
                            case SourceImageFormat.Xbm:
                                sb.Append("XBM (*.xbm)|*.xbm|");
                                break;
                        }
                    }

                    _fileDialogFilter = sb.ToString(0, sb.Length - 1);
                }

                // If you want to keep the interface open between scans, 
                // use Enable instead of Acquire and call Disable in AcquireCanceled.
                if (this._keepUIOpen)
                    this.device.Enable();
                else
                    this.device.Acquire();
            }
            else
                MessageBox.Show("We were unable to open a connection to the device.", "Connection Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void On_acquireCustomInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();

            // Use our custom interface instead of the driver interface.
            // Note that the driver always has the option to show its own interface
            // even when asked to hide it.
            if (this.device == null)
                this.device = this.acquisition.Devices.Default;

            CustomInterface ci = null;

            try
            {
                if (this.device.TryOpen())
                {
                    this.device.HideInterface = true;
                    this.device.DisplayProgressIndicator = false;

                    ci = new CustomInterface(this.device);
                    if (ci.ShowDialog(this) == DialogResult.OK)
                    {
                        EnableDisableMenus(false);
                        this.device.Acquire();
                    }
                    else
                        this.device.Close();
                }
                else
                    MessageBox.Show("We were unable to open a connection to the device.", "Connection Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                this.device.Close();
            }
            finally
            {
                if (ci != null)
                    ci.Dispose();
            }
        }

        private void On_saveAcquireParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will show the scanner interface without scanning to
            // allow users to select the settings they want to use in
            // a future scan.  It will then save those settings to file.
            if (this.device == null) return;

            if (this.device.TryOpen())
            {
                try
                {
                    if (this.device.EnableInterfaceOnly && this.device.ShowUserInterface())
                    {
                        using (SaveFileDialog dlg = new SaveFileDialog())
                        {
                            bool customData = this.device.QueryCapability(DeviceCapability.CAP_CUSTOMDSDATA, false);

                            dlg.Filter = "Twain Parameters|*." + (customData ? "ini" : "xml");
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                            {
                                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    // CAP_CUSTOMDSDATA is read only, so make sure to pass 'false' for 'canSet'.
                                    if (customData)
                                        this.device.SaveParameters(fs);
                                    else
                                        this.device.SaveXmlParameters(fs);
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("The device does not support this feature.", "Not Supported",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    this.device.Close();
                }
            }
            else
                MessageBox.Show("We were unable to connect to the device.", "Connection Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void On_acquireFromParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will load a previously saved setting file and hide
            // the scanner interface when scanning.
            if (this.device.TryOpen())
            {
                try
                {
                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        bool customData = this.device.QueryCapability(DeviceCapability.CAP_CUSTOMDSDATA, false);

                        dlg.Filter = "Twain Parameters|*." + (customData ? "ini" : "xml");
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                if (customData)
                                    this.device.LoadParameters(fs);
                                else
                                    this.device.LoadXmlParameters(fs);
                            }

                            EnableDisableMenus(false);

                            this.device.HideInterface = true;
                            this.device.DisplayProgressIndicator = false;
                            this.device.Acquire();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.device.Close();
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void On_capabilityInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.device == null) return;

            if (this.device.TryOpen())
            {
                try
                {
                    DeviceCapabilityInformation info = new DeviceCapabilityInformation(this.device);
                    info.ShowDialog(this);
                    info.Dispose();
                }
                finally
                {
                    this.device.Close();
                }
            }
        }

        private void On_exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        #endregion

        #region ComboBox Events

        private void On_cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboDevice.Text == "Select Source...")
            {
                // Display the select source dialog.
                // If the user cancels the dialog the return value is the default device.
                Device dev = this.acquisition.ShowSelectSource();
                if (dev == null)
                    return;

                this.device = dev;
            }
            else
                this.device = this.acquisition.Devices.GetDevice(this.cboDevice.Text);

            FillDeviceInformation();
        }

        private void On_cboTransferMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingValues) return;

            this.Cursor = Cursors.WaitCursor;
            if (this.device.TryOpen())
            {
                try
                {
                    this.device.TransferMethod = (TwainTransferMethod)this.cboTransferMethod.SelectedItem;

                    _updatingValues = true;
                    UpdatePixelTypeValues();
                    UpdateBitDepthValues();
                }
                finally
                {
                    _updatingValues = false;
                    this.device.Close();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void On_cboPixelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingValues) return;

            this.Cursor = Cursors.WaitCursor;
            if (this.device.TryOpen())
            {
                try
                {
                    this.device.PixelType = (ImagePixelType)this.cboPixelType.SelectedItem;

                    _updatingValues = true;
                    UpdateBitDepthValues();
                }
                finally
                {
                    _updatingValues = false;
                    this.device.Close();
                }
            }

            this.Cursor = Cursors.Default;
        }

        #endregion

        // You can't have both Keep Interface Open and Hide Interface enabled.
        private void On_chkKeepInterfaceOpen_CheckedChanged(object sender, EventArgs e)
        {
            this._keepUIOpen = this.chkKeepInterfaceOpen.Checked;
            if (_keepUIOpen) this.chkHideInterface.Checked = false;
            this.chkHideInterface.Enabled = !_keepUIOpen;
        }

        private void On_chkHideInterface_CheckedChanged(object sender, EventArgs e)
        {
            bool disable = !this.chkHideInterface.Checked;
            if (disable) this.chkKeepInterfaceOpen.Checked = false;
            this.chkKeepInterfaceOpen.Enabled = disable;
        }
    }
}
