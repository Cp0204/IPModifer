namespace IPModifer {
    public class NetworkAdapter:Network
    {
        string name; //网络名称
        string nicId; //网卡ID

        public string Name1
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string NicId
        {
            get
            {
                return nicId;
            }

            set
            {
                nicId = value;
            }
        }
    }
}
