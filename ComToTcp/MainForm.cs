using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComToTcp
{
    public partial class MainForm : Form
    {
        public MainFormViewModel ViewModel = new MainFormViewModel();

        public MainForm()
        {
            InitializeComponent();

            UpdateUI();
            AttachEvents();
        }

        private void UpdateUI()
        {
            var oldText = cboComPort.Text;
            cboComPort.DataSource = ViewModel.ComPorts;
            cboComPort.Text = oldText;
            txtTcpPort.Text = ViewModel.SelectedTcpPort.ToString(CultureInfo.CurrentUICulture);
            btnGo.Enabled = grpInput.Enabled = !ViewModel.IsListening;
            btnStop.Enabled = ViewModel.IsListening;
            lblConnectionsCount.Text = ViewModel.TotalConnections.ToString(CultureInfo.CurrentUICulture);
        }

        private void AttachEvents()
        {
            ViewModel.ComPortsChanged += ViewModel_ComPortsChanged;
            ViewModel.IsListeningChanged += ViewModel_IsListeningChanged;
            ViewModel.TotalConnectionsChanged += ViewModel_TotalConnectionsChanged;
        }

        private void ViewModel_TotalConnectionsChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void ViewModel_IsListeningChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void ViewModel_ComPortsChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void cboComPort_SelectedValueChanged(object sender, EventArgs e)
        {
            ViewModel.SelectedComPort = cboComPort.Text;
        }

        private void txtTcpPort_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !int.TryParse(txtTcpPort.Text, NumberStyles.Integer, CultureInfo.CurrentUICulture, out Var<int>.Out);
        }

        private void txtTcpPort_Validated(object sender, EventArgs e)
        {
            ViewModel.SelectedTcpPort = int.Parse(txtTcpPort.Text, NumberStyles.Integer, CultureInfo.CurrentUICulture);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!ViewModel.IsListening) ViewModel.Listen();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ViewModel.IsListening) ViewModel.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ComToTcp.Properties.Settings.Default.Save();
            }
        }
    }
}
