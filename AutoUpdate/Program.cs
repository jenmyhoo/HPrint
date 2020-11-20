using CCWin;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AutoUpdate
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
                Application.Run(new UpdateForm());
            }
            else
            {
                MessageBoxEx.Show("程序正在运行，请勿重复运行程序", "提示");
            }
        }
    }
}
