using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace IPModifer {
    public partial class MainForm:Form {
        public static string apppath = Path.GetDirectoryName(Application.ExecutablePath);
        public static string iniPath = apppath + "\\config.ini";
        INIFile ini = new INIFile(iniPath);
        public List<Network> AllFanAn = new List<Network>();

        NetworkAdapterMannager nmg;

        public MainForm() {
            nmg = new NetworkAdapterMannager();
            InitializeComponent();
            fullcbFanAn();
            fullcbNetworkInterface();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = false;
            Text = Text + " v" + Application.ProductVersion.ToString();
            if(IsAdministrator()) {
                tbLog.AppendText(System.DateTime.Now + " 当前：管理员权限。\r\n");
            } else {
                tbLog.AppendText(System.DateTime.Now + " 当前：非管理员权限。\r\n");
            }
        }

        private void cbNetworkInterface_SelectedIndexChanged(object sender, EventArgs e) {
            Network ntk = nmg.getNICInfoByCaption(cbNetworkInterface.Text);
            tbNetworkInterfaceID.Text = ntk.Id;
            tbName.Text = ntk.Name;
            // 切换到当前设置
            cbFanAn.SelectedIndex = 1;
        }

        private void btRefresh_Click(object sender, EventArgs e) {
            fullcbFanAn();
            fullcbNetworkInterface();
            tbLog.AppendText(System.DateTime.Now + " 刷新完成...\r\n");
        }

        private void tbSave_Click(object sender, EventArgs e) {
            string id = nmg.AllNIC1[cbNetworkInterface.Text];
            string[] ip = new string[] { tbNewIp.Text };
            string[] mask = new string[] { tbNewMask.Text };
            string[] gateway = new string[] { tbNewGateway.Text };
            string[] dns = new string[] { tbNewDNS1.Text, tbNewDNS2.Text };

            if(ip[0] == "") {
                tbLog.AppendText(System.DateTime.Now + " 设置为自动获取IP...\r\n");
                nmg.setAutoNetwork(id);
            } else {
                //设置ip
                tbLog.AppendText(System.DateTime.Now + " 设置为方案[" + cbFanAn.Text + "]...\r\n");
                nmg.setNetwork(id, ip, mask, gateway, dns);
            }
        }

        private void cbFanAn_SelectedIndexChanged(object sender, EventArgs e) {
            string name = cbFanAn.Text;

            if(name == "*自动获取") {
                tbNewIp.Text = tbNewGateway.Text = tbNewMask.Text = tbNewDNS1.Text = tbNewDNS2.Text = "";
                tbNewIp.Enabled = tbNewGateway.Enabled = tbNewMask.Enabled = tbNewDNS1.Enabled = tbNewDNS2.Enabled = false;

            } else if(name == "*当前设置") {
                tbNewIp.Enabled = tbNewGateway.Enabled = tbNewMask.Enabled = tbNewDNS1.Enabled = tbNewDNS2.Enabled = true;
                // 显示Network信息到界面
                fullcbNetworkInterface();
                Network ntk = nmg.getNICInfoByCaption(cbNetworkInterface.Text);
                tbNewIp.Text = ntk.Ip;
                tbNewGateway.Text = ntk.Gateway;
                tbNewMask.Text = ntk.Mask;
                tbNewDNS1.Text = ntk.Dns1;
                tbNewDNS2.Text = ntk.Dns2;

            } else {
                tbNewIp.Enabled = tbNewGateway.Enabled = tbNewMask.Enabled = tbNewDNS1.Enabled = tbNewDNS2.Enabled = true;
                // 读取方案填入
                foreach(Network info in AllFanAn) {
                    if(info.Name.ToString() == name) {
                        tbNewIp.Text = info.Ip.ToString();
                        tbNewGateway.Text = info.Gateway.ToString();
                        tbNewMask.Text = info.Mask.ToString();
                        tbNewDNS1.Text = info.Dns1.ToString();
                        tbNewDNS2.Text = info.Dns2.ToString();
                    }
                }
            }

        }

        private void AddFanAn_Click(object sender, EventArgs e) {
            if(cbFanAn.Text == "" || cbFanAn.Text == "*当前设置" || cbFanAn.Text == "*自动获取") {
                MessageBox.Show("方案名非法！", "方案管理");
                return;
            }
            Network info = new Network {
                Name = cbFanAn.Text,
                Ip = tbNewIp.Text,
                Mask = tbNewMask.Text,
                Gateway = tbNewGateway.Text,
                Dns1 = tbNewDNS1.Text,
                Dns2 = tbNewDNS2.Text
            };
            for(int i = 0; i < AllFanAn.Count; i++) {
                if(AllFanAn[i].Name == cbFanAn.Text) {
                    if(MessageBox.Show("[" + cbFanAn.Text + "]方案已存在，是否覆盖？", "方案管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        AllFanAn[i] = info;
                    }
                    return;
                }
            }
            AllFanAn.Add(info);
            cbFanAn.Items.Add(cbFanAn.Text);
            cbFanAn.SelectedIndex = cbFanAn.Items.Count-1;
            SaveConfig();
        }

        private void DelFanAn_Click(object sender, EventArgs e) {
            if(cbFanAn.Text == "" || cbFanAn.Text == "*当前设置" || cbFanAn.Text == "*自动获取") {
                return;
            }
            if(MessageBox.Show("是否删除方案[" + cbFanAn.Text + "]？", "方案管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                foreach(var info in AllFanAn) {
                    if(info.Name == cbFanAn.Text) {
                        AllFanAn.Remove(info);
                        ini.ClearSection(cbFanAn.Text);
                        cbFanAn.Items.RemoveAt(cbFanAn.SelectedIndex);
                        cbFanAn.SelectedIndex = 0;
                        break;
                    }
                }
            }
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        /// 工具栏按钮响应
        /// //////////////////////////////////////////////////////////////////////////////////////////////

        private void toolAbout_Click(object sender, EventArgs e) {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void tsbLog_Click(object sender, EventArgs e) {
            if(this.Height == 370) {
                this.Height = 280;
            } else {
                this.Height = 370;
            }

        }

        private void toolCheckNet_Click(object sender, EventArgs e) {
            if(checkNetConnect()) {
                MessageBox.Show("互联网已联通", "测试互联网");
                tbLog.AppendText(System.DateTime.Now + " 测试互联网：已联通\r\n");
            } else {
                MessageBox.Show("互联网未联通", "测试互联网");
                tbLog.AppendText(System.DateTime.Now + " 测试互联网：未联通\r\n");
            }
        }

        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        /// 托盘
        /// //////////////////////////////////////////////////////////////////////////////////////////////

        private void tsbTray_Click(object sender, EventArgs e) {
            this.Visible = false;
            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;
            this.notifyIcon.ShowBalloonTip(3, "提示", "软件在后台运行！如要打开，请双击图标。", ToolTipIcon.Info);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Visible = true;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        public void SaveConfig() {
            //写各个项
            foreach(var info in AllFanAn) {
                ini.IniWriteValue(info.Name, "ip", info.Ip);
                ini.IniWriteValue(info.Name, "mask", info.Mask);
                ini.IniWriteValue(info.Name, "gateway", info.Gateway);
                ini.IniWriteValue(info.Name, "dns1", info.Dns1);
                ini.IniWriteValue(info.Name, "dns2", info.Dns2);
            }
        }

        private void fullcbFanAn() {
            cbFanAn.Items.Clear();
            cbFanAn.Items.Add("*自动获取");
            cbFanAn.Items.Add("*当前设置");
            string[] AllFanAnName = ini.GetSectionNames();
            foreach(string name in AllFanAnName) {
                cbFanAn.Items.Add(name.ToString());
                Network info = new Network {
                    Name = name,
                    Ip = ini.IniReadValue(name, "ip"),
                    Mask = ini.IniReadValue(name, "mask"),
                    Gateway = ini.IniReadValue(name, "gateway"),
                    Dns1 = ini.IniReadValue(name, "dns1"),
                    Dns2 = ini.IniReadValue(name, "dns2")
                };
                AllFanAn.Add(info);
            }
        }

        public void fullcbNetworkInterface() {
            cbNetworkInterface.Items.Clear();
            nmg.Refresh();
            foreach(var item in nmg.AllNIC1) {
                Console.WriteLine(item.Key + ':' + item.Value);
                cbNetworkInterface.Items.Add(item.Key);
            }
            cbNetworkInterface.SelectedIndex = 0;
        }

        public static bool IsAdministrator() {
            bool result;
            try {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                result = principal.IsInRole(WindowsBuiltInRole.Administrator);
            } catch {
                result = false;
            }
            return result;
        }

        public bool checkNetConnect(string host = "www.baidu.com") {
            try {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pr = ping.Send(host, 12000);
                return pr.Status == System.Net.NetworkInformation.IPStatus.Success;
            } catch(Exception) {
                return false;
            }
        }


    }
}
