namespace ComToTcp
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
            this.lblComPort = new System.Windows.Forms.Label();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.lblTcpPort = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnections = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnectionsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpInput.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(10, 23);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(57, 13);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "&COM Port:";
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(73, 20);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(141, 21);
            this.cboComPort.TabIndex = 1;
            this.cboComPort.SelectedValueChanged += new System.EventHandler(this.cboComPort_SelectedValueChanged);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtTcpPort);
            this.grpInput.Controls.Add(this.lblTcpPort);
            this.grpInput.Controls.Add(this.cboComPort);
            this.grpInput.Controls.Add(this.lblComPort);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInput.Location = new System.Drawing.Point(0, 0);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(226, 84);
            this.grpInput.TabIndex = 2;
            this.grpInput.TabStop = false;
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.Location = new System.Drawing.Point(73, 47);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(141, 21);
            this.txtTcpPort.TabIndex = 3;
            this.txtTcpPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtTcpPort_Validating);
            this.txtTcpPort.Validated += new System.EventHandler(this.txtTcpPort_Validated);
            // 
            // lblTcpPort
            // 
            this.lblTcpPort.AutoSize = true;
            this.lblTcpPort.Location = new System.Drawing.Point(10, 50);
            this.lblTcpPort.Name = "lblTcpPort";
            this.lblTcpPort.Size = new System.Drawing.Size(53, 13);
            this.lblTcpPort.TabIndex = 2;
            this.lblTcpPort.Text = "&TCP Port:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnections,
            this.lblConnectionsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 126);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(226, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnections
            // 
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(77, 17);
            this.lblConnections.Text = "Connections:";
            // 
            // lblConnectionsCount
            // 
            this.lblConnectionsCount.Name = "lblConnectionsCount";
            this.lblConnectionsCount.Size = new System.Drawing.Size(13, 17);
            this.lblConnectionsCount.Text = "0";
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGo.Location = new System.Drawing.Point(13, 90);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(90, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.Location = new System.Drawing.Point(124, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 148);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpInput);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ComToTcp.Properties.Settings.Default, "DefaultLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = global::ComToTcp.Properties.Settings.Default.DefaultLocation;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "COM → TCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cboComPort;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblTcpPort;
        private System.Windows.Forms.TextBox txtTcpPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnections;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionsCount;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnStop;
    }
}

