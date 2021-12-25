namespace IPModifer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbNetworkInterface = new System.Windows.Forms.ComboBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tbSave = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbLog = new System.Windows.Forms.ToolStripButton();
            this.toolCheckNet = new System.Windows.Forms.ToolStripButton();
            this.tsbTray = new System.Windows.Forms.ToolStripButton();
            this.toolAbout = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNetworkInterfaceID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DelFanAn = new System.Windows.Forms.Button();
            this.AddFanAn = new System.Windows.Forms.Button();
            this.cbFanAn = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNewDNS2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNewDNS1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNewGateway = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNewMask = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNewIp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "网卡名称";
            // 
            // cbNetworkInterface
            // 
            this.cbNetworkInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNetworkInterface.Location = new System.Drawing.Point(63, 31);
            this.cbNetworkInterface.Name = "cbNetworkInterface";
            this.cbNetworkInterface.Size = new System.Drawing.Size(292, 20);
            this.cbNetworkInterface.TabIndex = 1;
            this.cbNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.cbNetworkInterface_SelectedIndexChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(361, 30);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(47, 22);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "刷新";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tbSave
            // 
            this.tbSave.Location = new System.Drawing.Point(361, 57);
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(47, 48);
            this.tbSave.TabIndex = 3;
            this.tbSave.Text = "修改";
            this.tbSave.UseVisualStyleBackColor = true;
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLog,
            this.toolCheckNet,
            this.tsbTray,
            this.toolAbout});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(416, 25);
            this.toolStrip.TabIndex = 19;
            this.toolStrip.Text = "toolStrip";
            // 
            // tsbLog
            // 
            this.tsbLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbLog.Image")));
            this.tsbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLog.Name = "tsbLog";
            this.tsbLog.Size = new System.Drawing.Size(23, 22);
            this.tsbLog.Text = "toolStripButton3";
            this.tsbLog.ToolTipText = "显示日志";
            this.tsbLog.Click += new System.EventHandler(this.tsbLog_Click);
            // 
            // toolCheckNet
            // 
            this.toolCheckNet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCheckNet.Image = ((System.Drawing.Image)(resources.GetObject("toolCheckNet.Image")));
            this.toolCheckNet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckNet.Name = "toolCheckNet";
            this.toolCheckNet.Size = new System.Drawing.Size(23, 22);
            this.toolCheckNet.Text = "测试互联网";
            this.toolCheckNet.Click += new System.EventHandler(this.toolCheckNet_Click);
            // 
            // tsbTray
            // 
            this.tsbTray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTray.Image = ((System.Drawing.Image)(resources.GetObject("tsbTray.Image")));
            this.tsbTray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTray.Name = "tsbTray";
            this.tsbTray.Size = new System.Drawing.Size(23, 22);
            this.tsbTray.Text = "缩至托盘";
            this.tsbTray.Click += new System.EventHandler(this.tsbTray_Click);
            // 
            // toolAbout
            // 
            this.toolAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolAbout.Image")));
            this.toolAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(23, 22);
            this.toolAbout.Text = "关于程序";
            this.toolAbout.Click += new System.EventHandler(this.toolAbout_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "网卡编号";
            // 
            // tbNetworkInterfaceID
            // 
            this.tbNetworkInterfaceID.Location = new System.Drawing.Point(63, 57);
            this.tbNetworkInterfaceID.Name = "tbNetworkInterfaceID";
            this.tbNetworkInterfaceID.ReadOnly = true;
            this.tbNetworkInterfaceID.Size = new System.Drawing.Size(292, 21);
            this.tbNetworkInterfaceID.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.DelFanAn);
            this.groupBox2.Controls.Add(this.AddFanAn);
            this.groupBox2.Controls.Add(this.cbFanAn);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbNewDNS2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbNewDNS1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbNewGateway);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbNewMask);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbNewIp);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(8, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 116);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改设置";
            // 
            // DelFanAn
            // 
            this.DelFanAn.Location = new System.Drawing.Point(172, 24);
            this.DelFanAn.Name = "DelFanAn";
            this.DelFanAn.Size = new System.Drawing.Size(20, 20);
            this.DelFanAn.TabIndex = 6;
            this.DelFanAn.Text = "-";
            this.DelFanAn.UseVisualStyleBackColor = true;
            this.DelFanAn.Click += new System.EventHandler(this.DelFanAn_Click);
            // 
            // AddFanAn
            // 
            this.AddFanAn.Location = new System.Drawing.Point(153, 24);
            this.AddFanAn.Name = "AddFanAn";
            this.AddFanAn.Size = new System.Drawing.Size(20, 20);
            this.AddFanAn.TabIndex = 5;
            this.AddFanAn.Text = "+";
            this.AddFanAn.UseVisualStyleBackColor = true;
            this.AddFanAn.Click += new System.EventHandler(this.AddFanAn_Click);
            // 
            // cbFanAn
            // 
            this.cbFanAn.FormattingEnabled = true;
            this.cbFanAn.Items.AddRange(new object[] {
            "自动获取",
            "当前设置"});
            this.cbFanAn.Location = new System.Drawing.Point(69, 24);
            this.cbFanAn.Name = "cbFanAn";
            this.cbFanAn.Size = new System.Drawing.Size(83, 20);
            this.cbFanAn.TabIndex = 4;
            this.cbFanAn.SelectedIndexChanged += new System.EventHandler(this.cbFanAn_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "方案";
            // 
            // tbNewDNS2
            // 
            this.tbNewDNS2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNewDNS2.Location = new System.Drawing.Point(262, 80);
            this.tbNewDNS2.Name = "tbNewDNS2";
            this.tbNewDNS2.Size = new System.Drawing.Size(123, 21);
            this.tbNewDNS2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "备用DNS";
            // 
            // tbNewDNS1
            // 
            this.tbNewDNS1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNewDNS1.Location = new System.Drawing.Point(69, 79);
            this.tbNewDNS1.Name = "tbNewDNS1";
            this.tbNewDNS1.Size = new System.Drawing.Size(123, 21);
            this.tbNewDNS1.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "首选DNS";
            // 
            // tbNewGateway
            // 
            this.tbNewGateway.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNewGateway.Location = new System.Drawing.Point(262, 52);
            this.tbNewGateway.Name = "tbNewGateway";
            this.tbNewGateway.Size = new System.Drawing.Size(123, 21);
            this.tbNewGateway.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(206, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 38;
            this.label12.Text = "默认网关";
            // 
            // tbNewMask
            // 
            this.tbNewMask.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNewMask.Location = new System.Drawing.Point(69, 52);
            this.tbNewMask.Name = "tbNewMask";
            this.tbNewMask.Size = new System.Drawing.Size(123, 21);
            this.tbNewMask.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 36;
            this.label13.Text = "子网掩码";
            // 
            // tbNewIp
            // 
            this.tbNewIp.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNewIp.Location = new System.Drawing.Point(262, 25);
            this.tbNewIp.Name = "tbNewIp";
            this.tbNewIp.Size = new System.Drawing.Size(123, 21);
            this.tbNewIp.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(206, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "IP 地址";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(8, 243);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(399, 78);
            this.tbLog.TabIndex = 37;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "托盘";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(63, 84);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(292, 21);
            this.tbName.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "网卡名称";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 241);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tbNetworkInterfaceID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tbSave);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.cbNetworkInterface);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPModifer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNetworkInterface;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button tbSave;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbLog;
        private System.Windows.Forms.ToolStripButton toolAbout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNetworkInterfaceID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ToolStripButton tsbTray;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFanAn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNewDNS2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNewDNS1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNewGateway;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNewMask;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNewIp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button AddFanAn;
        private System.Windows.Forms.Button DelFanAn;
        private System.Windows.Forms.ToolStripButton toolCheckNet;
    }
}

