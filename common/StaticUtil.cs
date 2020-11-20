using common.bean;
using common.tool;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace common
{
    public class StaticUtil
    {
        public static string VERSION = "1.0.0";
        public static string DEFAULT_CHARSET = "utf-8";
        public static int ENVIRONMENT;
        public static string ENVIRONMENT_NAME;
        public static string PRINT_ADDRESS;
        public static int LOCAL_PORT = 0;
        public static UserCookieBean USER_COOKIE_BEAN = null;

        public static string getDomainByPrintAddress(string printAddress)
        {
            Uri uri = new Uri(printAddress);
            //StringBuilder sb = new StringBuilder();
            //cookie 头不允许带端口号
            //string host = sb.Append(uri.Host).Append(uri.IsDefaultPort ? "" : (":" + uri.Port)).ToString();
            string host = uri.Host;
            return host;
        }

        public static IPAddress getLocalHostLANAddress()
        {
            IPAddress candidateAddress = null;
            //本机名
            string hostName = Dns.GetHostName();
            //输出主机名
            //Console.WriteLine("主机名：" + hostName);
            //会返回所有地址，包括IPv4和IPv6
            IPAddress[] ipHost = Dns.GetHostAddresses(hostName);
            for (int i = 0; i < ipHost.Length; i++)
            {
                candidateAddress = ipHost[i];
                //从IP地址列表中筛选出IPv4类型的IP地址
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                if (candidateAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    break;
                }

            }
            return candidateAddress;
        }

        public static bool Print(string file)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = file;
                //指定执行的动作，是打印，即print，打开是open
                process.StartInfo.Verb = "print";
                return process.Start();
            }
            catch
            {
                return false;
            }
        }

        public static Rectangle GetRealPageBounds(bool preview, PrintPageEventArgs e)
        {
            if (preview)
            {
                return e.MarginBounds;
            }
            float cx = e.PageSettings.HardMarginX;
            float cy = e.PageSettings.HardMarginY;
            float dpix = e.Graphics.DpiX;
            float dpiy = e.Graphics.DpiY;
            Rectangle marginBounds = e.MarginBounds;
            marginBounds.Offset((int)(-cx * 100 / dpix), (int)(-cy * 100 / dpiy));
            return marginBounds;
        }

        /**
         * 递归删除目录下的所有文件及子目录下所有文件
         *
         * @param dir 将要删除的文件目录
         * @return
         */
        public static void DeleteDir(string dir)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                FileSystemInfo[] fileinfo = info.GetFileSystemInfos();//返回目录中所有文件和子目录
                foreach (FileSystemInfo file in fileinfo)
                {
                    if (file is DirectoryInfo)//判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(file.FullName);
                        subdir.Delete(true); //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(file.FullName);//删除指定文件
                    }
                }
            }
            catch
            {

            }
        }

        public static string GetOSVersion()
        {
            try
            {
                string operatingSystem = "";
                string osArchitecture = "";
                using (ManagementObjectSearcher win32OperatingSystem = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in win32OperatingSystem.Get())
                    {
                        operatingSystem = obj["Caption"].ToString();
                        osArchitecture = obj["OSArchitecture"].ToString();
                    }
                }
                return operatingSystem + " " + osArchitecture;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 将DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeToTimestamp(DateTime datetime)
        {
            if (datetime == null)
            {
                datetime = DateTime.Now;
            }
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (datetime.Ticks - startTime.Ticks) / 10000;//除10000调整为13位   
            return t;
        }

        /// <summary>
        /// 将yyyy-MM-dd hh:mm:ss时间格式字符串转换为Unix时间戳格式
        /// </summary>
        /// <param name="datetimeString">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeToTimestamp(string datetimeString)
        {
            DateTime datetime = datetimeString == null ? DateTime.Now : Convert.ToDateTime(datetimeString);
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (datetime.Ticks - startTime.Ticks) / 10000;//除10000调整为13位   
            return t;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private DateTime ConvertStringToDateTime(string timestamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timestamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        public static int? ToInt(object obj)
        {
            if (obj == null || obj == DBNull.Value || !CheckTools.isNumber(obj.ToString()))
            {
                return null;
            }
            int result = default(int);
            int.TryParse(obj.ToString(), out result);
            return result;
        }
    }
}
