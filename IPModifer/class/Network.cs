using System;

namespace IPModifer {
    public class Network {
        private String nic;//网卡
        private String name;//网络名称
        private String id;//网卡编号
        //ipv4
        private String ip;//ip地址
        private String mask;//子网掩码
        private String gateway;//网关
        private String dns1;//首选DNS
        private String dns2;//备选DNS
        //IPv6
        private String ipv6;//ipv6地址
        private String prefixlength;//子网前缀长度



        public string Nic {
            get {
                return nic;
            }

            set {
                nic = value;
            }
        }

        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }

        public string Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        public string Ip {
            get {
                return ip;
            }

            set {
                ip = value;
            }
        }

        public string Mask {
            get {
                return mask;
            }

            set {
                mask = value;
            }
        }

        public string Gateway {
            get {
                return gateway;
            }

            set {
                gateway = value;
            }
        }

        public string Dns1 {
            get {
                return dns1;
            }

            set {
                dns1 = value;
            }
        }

        public string Dns2 {
            get {
                return dns2;
            }

            set {
                dns2 = value;
            }
        }

        public string Ipv6 {
            get {
                return ipv6;
            }

            set {
                ipv6 = value;
            }
        }
        public string PrefixLength {
            get {
                return prefixlength;
            }

            set {
                prefixlength = value;
            }
        }

    }
}
