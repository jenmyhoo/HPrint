using System.Text;

namespace common.tool
{
    public class Ini
    {
        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string file);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string value, StringBuilder retVal, int size, string file);

        private string file = null;


        public Ini(string file)
        {
            this.file = file;
        }


        public void Write(string section, string key, string value)
        {
            // section=配置节，key=键名，value=键值，file=路径
            WritePrivateProfileString(section, key, value, file);
        }


        public string Read(string section, string key, int size)
        {
            // 每次从ini中读取多少字节
            StringBuilder sb = new StringBuilder(size);
            // section=配置节，key=键名，temp=上面，path=路径
            GetPrivateProfileString(section, key, "", sb, size, file);
            return sb.ToString();
        }
    }
}
