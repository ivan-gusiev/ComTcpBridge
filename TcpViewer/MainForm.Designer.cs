namespace TcpViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHost = new System.Windows.Forms.ToolStripLabel();
            this.txtHost = new System.Windows.Forms.ToolStripTextBox();
            this.lblPort = new System.Windows.Forms.ToolStripLabel();
            this.txtPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.txtData = new System.Windows.Forms.RichTextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHost,
            this.txtHost,
            this.lblPort,
            this.txtPort,
            this.toolStripSeparator1,
            this.btnConnect,
            this.btnDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(570, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHost
            // 
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 22);
            this.lblHost.Text = "Host:";
            // 
            // txtHost
            // 
            this.txtHost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 25);
            this.txtHost.Text = global::TcpViewer.Properties.Settings.Default.DefaultHost;
            // 
            // lblPort
            // 
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 22);
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 25);
            this.txtPort.Text = global::TcpViewer.Properties.Settings.Default.DefaultPort;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 22);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtData.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::TcpViewer.Properties.Settings.Default, "DefaultSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.ForeColor = System.Drawing.Color.White;
            this.txtData.Location = new System.Drawing.Point(0, 25);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = global::TcpViewer.Properties.Settings.Default.DefaultSize;
            this.txtData.TabIndex = 1;
            this.txtData.Text = "";
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.Color.Blue;
            this.txtCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCommand.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.ForeColor = System.Drawing.Color.PapayaWhip;
            this.txtCommand.Location = new System.Drawing.Point(0, 363);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(570, 23);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            this.txtCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 386);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.toolStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::TcpViewer.Properties.Settings.Default, "DefaultLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::TcpViewer.Properties.Settings.Default.DefaultLocation;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TCP Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RichTextBox txtData;
        private System.Windows.Forms.ToolStripLabel lblHost;
        private System.Windows.Forms.ToolStripTextBox txtHost;
        private System.Windows.Forms.ToolStripLabel lblPort;
        private System.Windows.Forms.ToolStripTextBox txtPort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.TextBox txtCommand;
    }
}

