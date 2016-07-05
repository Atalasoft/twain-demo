// ------------------------------------------------------------------------------------
// <copyright file="DeviceCapabilityInformation.cs" company="Atalasoft">
//     (c) 2000-2015 Atalasoft, a Kofax Company. All rights reserved. Use is subject to license terms.
// </copyright>
// ------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using Atalasoft.Twain;

namespace Atalasoft.Demo.Acquisition
{
    /// <summary>
    /// Describes DEvice Capability Information dialog.
    /// </summary>
    public partial class DeviceCapabilityInformation : Form
    {
        private readonly Device _device;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCapabilityInformation"/> class.
        /// </summary>
        /// <param name="device">Object that describes TWAIN device.</param>
        public DeviceCapabilityInformation(Device device)
        {
            _device = device;
            InitializeComponent();
            LoadCapabilities();
        }

        private void On_listCapabilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listCapabilities.SelectedIndex == -1) return;
            DeviceCapability cap = (DeviceCapability)this.listCapabilities.SelectedItem;

            this.listValues.Items.Clear();

            this.lblCapType.Text = _device.Controller.GetCapabilityTwainType(cap).ToString();

            QueryOperation operations = _device.GetQueryOperations(cap);
            FillOperationList(operations);

            if ((operations & QueryOperation.TWQC_GET) == QueryOperation.TWQC_GET)
            {
                TwainCapability capability = new TwainCapability(cap, TwainContainer.TWON_DONTCARE16, IntPtr.Zero);
                if (_device.Controller.SendCommand(TwainTriplet.CapabilityGet, _device.Identity, capability) == TwainReturnCode.TWRC_SUCCESS)
                {
                    this.lblGetContainer.Text = capability.ContainerType.ToString();

                    // Always use a TwainMemory object when working with memory returned from a driver.
                    TwainMemory memory = _device.Controller.CreateTwainMemory(capability.Data);
                    try
                    {
                        object vals = _device.Controller.ReadTwainContainerData(capability.ContainerType, memory);

                        FillValueList(vals, cap);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ReadTwainContainerData failed for " + cap.ToString() + "\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                    }
                    finally
                    {
                        memory.Dispose();
                    }
                }
                else
                    this.lblGetContainer.Text = "Unknown";
            }
            else
                this.lblGetContainer.Text = "Not Supported";

            if ((operations & QueryOperation.TWQC_GETCURRENT) == QueryOperation.TWQC_GETCURRENT)
            {
                TwainCapability capability = new TwainCapability(cap, TwainContainer.TWON_DONTCARE16, IntPtr.Zero);
                if (_device.Controller.SendCommand(TwainTriplet.CapabilityGet, _device.Identity, capability) == TwainReturnCode.TWRC_SUCCESS)
                {
                    this.lblGetCurrentContainer.Text = capability.ContainerType.ToString();

                    // Don't forget to free the memory allocated by the driver.
                    _device.Controller.FreeTwainMemory(capability.Data);
                }
                else
                    this.lblGetContainer.Text = "Unknown";
            }
            else
                this.lblGetCurrentContainer.Text = "Not Supported";
        }

        private void LoadCapabilities()
        {
            DeviceCapability[] caps = _device.GetSupportedCapabilities();
            foreach (DeviceCapability cap in caps)
                this.listCapabilities.Items.Add(cap);
        }

        private void FillOperationList(QueryOperation operations)
        {
            this.listOperations.SetItemCheckState(0, ((operations & QueryOperation.TWQC_NONE) == QueryOperation.TWQC_NONE) ? CheckState.Checked : CheckState.Unchecked);
            this.listOperations.SetItemCheckState(1, ((operations & QueryOperation.TWQC_GET) == QueryOperation.TWQC_GET) ? CheckState.Checked : CheckState.Unchecked);
            this.listOperations.SetItemCheckState(2, ((operations & QueryOperation.TWQC_SET) == QueryOperation.TWQC_SET) ? CheckState.Checked : CheckState.Unchecked);
            this.listOperations.SetItemCheckState(3, ((operations & QueryOperation.TWQC_GETDEFAULT) == QueryOperation.TWQC_GETDEFAULT) ? CheckState.Checked : CheckState.Unchecked);
            this.listOperations.SetItemCheckState(4, ((operations & QueryOperation.TWQC_GETCURRENT) == QueryOperation.TWQC_GETCURRENT) ? CheckState.Checked : CheckState.Unchecked);
            this.listOperations.SetItemCheckState(5, ((operations & QueryOperation.TWQC_RESET) == QueryOperation.TWQC_RESET) ? CheckState.Checked : CheckState.Unchecked);
        }

        private void FillValueList(object values, DeviceCapability capability)
        {
            if (values == null) return;

            object[] vals = values as object[];
            if (vals == null)
                this.listValues.Items.Add(values);
            else if (vals.Length > 0)
                this.listValues.Items.AddRange(vals);
        }
    }
}
