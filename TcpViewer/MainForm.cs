using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TcpViewer
{
    public partial class MainForm : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _thread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Write(string text, MessageKind kind)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<string, MessageKind>)Write, new object[] { text, kind });
            }
            else
            {
                Cleanup();
                txtData.Select(txtData.TextLength, 0);
                SelectColor(kind);
                txtData.SelectedText = text;
                txtData.ScrollToCaret();
            }
        }

        private void Cleanup()
        {
            if (txtData.TextLength > 5000)
            {
                txtData.Text = txtData.Text.Substring(txtData.TextLength - 4000);
                txtData.Select(0, txtData.TextLength);
                SelectColor(MessageKind.Normal);
            }
        }

        private void SelectColor(MessageKind kind)
        {
            switch (kind)
            {
                case MessageKind.Normal:
                    txtData.SelectionColor = txtData.ForeColor;
                    break;
                case MessageKind.System:
                    txtData.SelectionColor = Color.Yellow;
                    break;
                case MessageKind.Error:
                    txtData.SelectionColor = Color.Coral;
                    break;
                case MessageKind.User:
                    txtData.SelectionColor = Color.LimeGreen;
                    break;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;
                _client = new TcpClient(txtHost.Text, int.Parse(txtPort.Text));
                _client.LingerState = new LingerOption(enable: false, seconds: 0);
                _stream = _client.GetStream();
                Write($"Connected to {_client.Client.RemoteEndPoint}.\r\n", MessageKind.System);
                _thread = new Thread(ReaderLoop) { IsBackground = true };
                _thread.Start();
                
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                Write(ex.GetType().FullName + Environment.NewLine, MessageKind.Error);
                Write(ex.Message + Environment.NewLine, MessageKind.Error);
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }
        
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Write("Disconnected manually.\r\n", MessageKind.System);
            CloseConnection();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void txtCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                var command = txtCommand.Text + Environment.NewLine;
                txtCommand.Text = "";
                SendCommand(command);
                Write(command, MessageKind.User);
            }
        }

        private void CloseConnection()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)CloseConnection);
            }
            else
            {
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;

                _stream.Close();
                _client.Close();
            }
        }

        private void ReaderLoop()
        {
            var reader = new StreamReader(_stream, Encoding.UTF8);
            while (true)
            {                
                try
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        Write("Transmission ended.\r\n", MessageKind.System);
                        break;
                    }
                    Write(line + Environment.NewLine, MessageKind.Normal);
                }
                catch (Exception e)
                {
                    Write(e.Message + Environment.NewLine, MessageKind.Error);
                    break;
                }
            }
            CloseConnection();
        }

        private void SendCommand(string message)
        {
            if (_stream?.CanWrite == true)
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                try
                {
                    _stream.Write(bytes, 0, bytes.Length);
                    _stream.Flush();
                }
                catch (IOException e)
                {
                    Write(e.Message + Environment.NewLine, MessageKind.Error);
                }
            }
        }

        enum MessageKind
        {
            Normal,
            System,
            User,
            Error
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                TcpViewer.Properties.Settings.Default.Save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = TcpViewer.Properties.Settings.Default.DefaultSize;
        }

    }
}
