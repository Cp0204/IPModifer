using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace IPModifer {
    public class NetworkAdapterMannager {
        private Dictionary<string, string> AllNIC = new Dictionary<string, string>();
        private List<NetworkAdapter> ntks = new List<NetworkAdapter>();

        public NetworkAdapterMannager() {
            this.initNICItem();
            this.initNICInfo();
        }

        public Dictionary<string, string> AllNIC1 {
            get {
                return AllNIC;
            }

            set {
                AllNIC = value;
            }
        }

        //刷新
        public void Refresh() {
            this.initNICItem();
            this.initNICInfo();
        }

        //获取网卡条目
        private void initNICItem() {
            this.AllNIC.Clear();
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach(ManagementObject mo in moc) {
                if((bool)mo["IPEnabled"])
                    this.AllNIC.Add(mo["Caption"].ToString(), mo["SettingID"].ToString());
            }
        }

        /// <summary>
        ///  获取网卡信息
        /// </summary>
        private void initNICInfo() {
            ntks.Clear();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface adapter in nics) {
                NetworkAdapter ntk = new NetworkAdapter();
                ntk.Id = adapter.Id;
                ntk.Name = adapter.Name;
                Console.WriteLine("网卡ID:" + ntk.Id);
                Console.WriteLine("网卡NAME:" + ntk.Name);

                //获取以太网卡网络接口信息
                IPInterfaceProperties ip = adapter.GetIPProperties();

                //获取单播地址集
                UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                foreach(UnicastIPAddressInformation ipadd in ipCollection) {
                    //InterNetwork    IPV4地址      InterNetworkV6        IPV6地址
                    if(ipadd.Address.AddressFamily == AddressFamily.InterNetwork) {
                        //判断是否为ipv4
                        ntk.Ip = ipadd.Address.ToString();//获取ip
                        ntk.Mask = ipadd.IPv4Mask.ToString();
                        Console.WriteLine("v4-IP地址:" + ntk.Ip);
                        Console.WriteLine("v4-子网掩码:" + ntk.Mask);
                    }
                    if(ipadd.Address.AddressFamily == AddressFamily.InterNetworkV6) {
                        //判断是否为ipv6
                        ntk.Ipv6 = ipadd.Address.ToString();//获取ip
                        ntk.PrefixLength = ipadd.PrefixLength.ToString();
                        Console.WriteLine("v6-IP地址:" + ntk.Ipv6);
                        Console.WriteLine("v6-子网前缀长度:" + ntk.PrefixLength);
                    }
                }
                //获取默认网关
                int GatewayCount = ip.GatewayAddresses.Count;
                Console.WriteLine("网关地址：");
                if(GatewayCount > 0) {
                    for(int i = 0; i < GatewayCount; i++) {
                        //判断ipv4|v6
                        if(ip.GatewayAddresses[i].Address.AddressFamily == AddressFamily.InterNetwork) {
                            Console.WriteLine("  v4-网关:" + ip.GatewayAddresses[i].Address.ToString());
                            ntk.Gateway = ip.GatewayAddresses[i].Address.ToString();
                        } else if(ip.GatewayAddresses[i].Address.AddressFamily == AddressFamily.InterNetworkV6) {
                            Console.WriteLine("  v6-网关:" + ip.GatewayAddresses[i].Address.ToString());
                            ntk.Gatewayv6 = ip.GatewayAddresses[i].Address.ToString();
                        }
                    }
                }
                //首选DNS与备用DNS
                int DnsCount = ip.DnsAddresses.Count;
                Console.WriteLine("DNS服务器地址：");
                if(DnsCount > 0) {
                    //其中第一个为首选DNS，第二个为备用的，余下的为所有DNS为DNS备用，按使用顺序排列
                    for(int i = 0; i < DnsCount; i++) {
                        //判断ipv4|v6
                        if(ip.DnsAddresses[i].AddressFamily == AddressFamily.InterNetwork) {
                            Console.WriteLine("  v4-DNS:" + ip.DnsAddresses[i].ToString());
                            if(ntk.Dns1 == null) {
                                ntk.Dns1 = ip.DnsAddresses[i].ToString();
                            } else {
                                ntk.Dns2 = ip.DnsAddresses[i].ToString();
                            }
                        } else if(ip.DnsAddresses[i].AddressFamily == AddressFamily.InterNetworkV6) {
                            Console.WriteLine("  v6-DNS:" + ip.DnsAddresses[i].ToString());
                            if(ntk.Dns1v6 == null) {
                                ntk.Dns1v6 = ip.DnsAddresses[i].ToString();
                            } else {
                                ntk.Dns2v6 = ip.DnsAddresses[i].ToString();
                            }
                        }
                    }

                }
                ntks.Add(ntk);
                Console.WriteLine("=========\n");
            }
        }

        /// <summary>
        /// 将Caption转换为ID
        /// </summary>
        /// <param name="caption">网卡Caption</param>
        /// <returns>网卡ID</returns>
        private string Caption2Id(string caption) {
            string id = AllNIC1[caption];
            return id;
        }

        /// <summary>
        /// 通过网卡Caption获取网卡信息
        /// </summary>
        /// <param name="caption">网卡Caption</param>
        /// <returns>Network对象</returns>
        public NetworkAdapter getNICInfoByCaption(string caption) {
            string id = Caption2Id(caption);
            NetworkAdapter nk = new NetworkAdapter();
            foreach(NetworkAdapter ntk in ntks) {
                if(ntk.Id == id) {
                    nk = ntk;
                }
            }
            return nk;
        }

        /// <summary>
        /// 设置网卡信息
        /// </summary>
        /// <param name="SettingID"></param>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="gateway"></param>
        /// <param name="dns"></param>
        public void setNetwork(string SettingID, string[] ip, string[] submask, string[] gateway, string[] dns) {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            foreach(ManagementObject mo in moc) {
                //如果没有启用IP设置的网络设备则跳过
                if(!(bool)mo["IPEnabled"])
                    continue;
                if(mo["SettingID"].ToString() != SettingID)
                    continue;

                //设置IP地址和掩码
                if(ip != null && submask != null) {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                }

                //设置网关地址
                if(gateway != null) {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = gateway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                }

                //设置DNS地址
                if(dns != null) {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
            }
        }

        /// <summary>
        /// 设置网卡自动获取IP
        /// </summary>
        public void setAutoNetwork(string SettingID) {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach(ManagementObject mo in moc) {

                //如果没有启用IP设置的网络设备则跳过
                if(!(bool)mo["IPEnabled"])
                    continue;
                if(mo["SettingID"].ToString() != SettingID)
                    continue;

                mo.InvokeMethod("SetDNSServerSearchOrder", null);
                mo.InvokeMethod("EnableStatic", null);
                mo.InvokeMethod("SetGateways", null);
                mo.InvokeMethod("EnableDHCP", null);
                break;
            }
        }
    }
}
