using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IPModifer {
    /// <summary>
    /// INI文件读写类。
    /// </summary>
    public class INIFile {
        public string path;
        public INIFile(string INIPath) {
            path = INIPath;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);
       
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void IniWriteValue(string Section, string Key, string Value) {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key) {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }

        public byte[] IniReadValues(string Section, string key) {
            byte[] temp = new byte[255];
            GetPrivateProfileString(Section, key, "", temp, 255, this.path);
            return temp;
        }

        /// <summary>
        /// 读取section
        /// </summary>
        /// <returns></returns>
        public string[] GetSectionNames() {
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(null, "", "", buffer, 999, this.path);
            string[] rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries);
            return rs;
        }

        /// <summary>
        /// 删除ini文件下所有段落
        /// </summary>
        public void ClearAllSection() {
            IniWriteValue(null, null, null);
        }

        /// <summary>
        /// 删除ini文件下personal段落下的所有键
        /// </summary>
        /// <param name="Section"></param>
        public void ClearSection(string Section) {
            IniWriteValue(Section, null, null);
        }
    }
}