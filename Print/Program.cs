using CCWin;
using common;
using common.tool;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Print
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bCreatedNew;
            Mutex mutex = new Mutex(false, Application.ProductName, out bCreatedNew);
            if (bCreatedNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (CheckUpdateLoad())
                {
                    Application.Exit();
                    return;
                }
                //清掉excel打印文件夹
                //StaticUtil.DeleteDir(Application.StartupPath + Path.DirectorySeparatorChar + "resource" + Path.DirectorySeparatorChar + "export");
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
            else
            {
                MessageBoxEx.Show("程序正在运行，请勿重复运行程序", "提示");
            }
        }

        public static bool CheckUpdateLoad()
        {
            bool result = false;
            try
            {
                AutoVersionInfo app = AutoVersionInfo.CheckIsUpdate(StaticUtil.VERSION);
                //Console.WriteLine("Application.StartupPath=>" + Application.StartupPath);
                if (app.IsUpdate && MessageBoxEx.Show("检查到新版本，是否更新？", "版本检查", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string path = Application.StartupPath.Replace(Path.DirectorySeparatorChar + "Print" + Path.DirectorySeparatorChar + "Print" + Path.DirectorySeparatorChar, Path.DirectorySeparatorChar + "Print" + Path.DirectorySeparatorChar + "AutoUpdate" + Path.DirectorySeparatorChar);
                    Ini ini = new Ini(path + Path.DirectorySeparatorChar + "version.ini");
                    ini.Write("version", "name", app.SoftName);
                    ini.Write("version", "version", app.Version);
                    ini.Write("version", "description", app.Description);
                    ini.Write("version", "forced", app.Forced.ToString());
                    ini.Write("version", "url", app.Url);
                    ini.Write("version", "md5", app.Md5);
                    ini.Write("version", "size", app.Size.ToString());

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WorkingDirectory = path;
                    process.StartInfo.FileName = "AutoUpdate.exe";
                    //process.StartInfo.Arguments = JsonConvert.SerializeObject(app);
                    process.Start();

                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                result = false;
            }
            return result;
        }
    }
}
