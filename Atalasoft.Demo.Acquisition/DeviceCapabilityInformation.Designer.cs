// ------------------------------------------------------------------------------------
// <copyright file="DeviceCapabilityInformation.Designer.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes Device Capability Information dialog.
    /// </summary>
    public partial class DeviceCapabilityInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listCapabilities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCapType;
        private System.Windows.Forms.Label lblGetCurrentContainer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGetContainer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listValues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox listOperations;

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
            this.listCapabilities = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCapType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGetContainer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGetCurrentContainer = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listValues = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listOperations = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capabilities:";
            // 
            // listCapabilities
            // 
            this.listCapabilities.FormattingEnabled = true;
            this.listCapabilities.Location = new System.Drawing.Point(12, 35);
            this.listCapabilities.Name = "listCapabilities";
            this.listCapabilities.Size = new System.Drawing.Size(171, 342);
            this.listCapabilities.Sorted = true;
            this.listCapabilities.TabIndex = 1;
            this.listCapabilities.SelectedIndexChanged += new System.EventHandler(this.On_listCapabilities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Capability Information:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGetCurrentContainer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblGetContainer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCapType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(210, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // lblCapType
            // 
            this.lblCapType.AutoSize = true;
            this.lblCapType.Location = new System.Drawing.Point(134, 22);
            this.lblCapType.Name = "lblCapType";
            this.lblCapType.Size = new System.Drawing.Size(53, 13);
            this.lblCapType.TabIndex = 2;
            this.lblCapType.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Get Container:";
            // 
            // lblGetContainer
            // 
            this.lblGetContainer.AutoSize = true;
            this.lblGetContainer.Location = new System.Drawing.Point(134, 42);
            this.lblGetContainer.Name = "lblGetContainer";
            this.lblGetContainer.Size = new System.Drawing.Size(76, 13);
            this.lblGetContainer.TabIndex = 5;
            this.lblGetContainer.Text = "Not Supported";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Get Current Container:";
            // 
            // lblGetCurrentContainer
            // 
            this.lblGetCurrentContainer.AutoSize = true;
            this.lblGetCurrentContainer.Location = new System.Drawing.Point(134, 63);
            this.lblGetCurrentContainer.Name = "lblGetCurrentContainer";
            this.lblGetCurrentContainer.Size = new System.Drawing.Size(76, 13);
            this.lblGetCurrentContainer.TabIndex = 7;
            this.lblGetCurrentContainer.Text = "Not Supported";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Supported Values:";
            // 
            // listValues
            // 
            this.listValues.FormattingEnabled = true;
            this.listValues.IntegralHeight = false;
            this.listValues.Location = new System.Drawing.Point(210, 274);
            this.listValues.Name = "listValues";
            this.listValues.Size = new System.Drawing.Size(271, 103);
            this.listValues.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Capability Operations:";
            // 
            // listOperations
            // 
            this.listOperations.FormattingEnabled = true;
            this.listOperations.Items.AddRange(new object[] {
            "TWQC_NONE",
            "TWQC_GET",
            "TWQC_SET",
            "TWQC_GETDEFAULT",
            "TWQC_GETCURRENT",
            "TWQC_RESET"});
            this.listOperations.Location = new System.Drawing.Point(210, 149);
            this.listOperations.Name = "listOperations";
            this.listOperations.Size = new System.Drawing.Size(271, 94);
            this.listOperations.TabIndex = 7;
            // 
            // DeviceCapabilityInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 392);
            this.Controls.Add(this.listOperations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listValues);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listCapabilities);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceCapabilityInformation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device Capability Information";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}