using CCWin;
using common;
using common.tool;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AutoUpdate
{
    public partial class UpdateForm : CCSkinMain
    {
        private AutoVersionInfo app = null;
        public UpdateForm()
        {
            InitializeComponent();
            this.progress_file.Minimum = 0;
            this.progress_file.Maximum = 100;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            string file = Application.StartupPath + Path.DirectorySeparatorChar + "version.ini";
            if (File.Exists(file))
            {
                Ini ini = new Ini(file);
                app = new AutoVersionInfo();

                app.SoftName = ini.Read("version", "name", 256);
                app.Version = ini.Read("version", "version", 256);
                app.Description = ini.Read("version", "description", 256);
                app.Forced = StaticUtil.ToInt(ini.Read("version", "forced", 256));
                app.Url = ini.Read("version", "url", 256);
                app.Md5 = ini.Read("version", "md5", 256);
                app.Size = StaticUtil.ToInt(ini.Read("version", "size", 256));
                if (!CheckTools.isPoint(StaticUtil.VERSION))
                {
                    throw new Exception("系统版本号设置有误！");
                }
                if (!CheckTools.isPoint(app.Version))
                {
                    throw new Exception("远程版本号设置有误！");
                }
                if (float.Parse(app.Version) > float.Parse(StaticUtil.VERSION))
                {
                    app.IsUpdate = true;
                }
            }
            else
            {
                this.progress_file.Text = "正在检测版本号...";
                app = AutoVersionInfo.CheckIsUpdate(StaticUtil.VERSION);
            }
            UpdateApp();
        }

        public void UpdateApp()
        {
            if (app == null || !app.IsUpdate)
            {
                this.progress_file.Value = 100;
                this.progress_file.Text = "100%";
                if (MessageBoxEx.Show("已是最新版本！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
            WebClient client = null;
            try
            {
                //Console.WriteLine("Application.ExecutablePath=>"+ Application.StartupPath);
                client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(app.Url), Application.StartupPath + Path.DirectorySeparatorChar + app.SoftName);
            }
            catch
            {
                if (client != null)
                {
                    client.Dispose();
                }
                throw new Exception("更新出现错误，网络连接失败！");
            }
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("TotalBytesToReceive=>" + e.TotalBytesToReceive);
            //this.progress_file.Step = e.ProgressPercentage;
            this.progress_file.Maximum = (int)e.TotalBytesToReceive;
            this.progress_file.Value = (int)e.BytesReceived;
            this.progress_file.Text = e.ProgressPercentage + "%";
        }

        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            (sender as WebClient).Dispose();
            if (e.Error != null)
            {
                MessageBoxEx.Show(e.Error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((e.Cancelled == true))
            {
                MessageBoxEx.Show("更新包下载被取消！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBoxEx.Show("点击确定启动安装程序！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string path = Application.StartupPath;
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WorkingDirectory = path;
                    process.StartInfo.FileName = app.SoftName;
                    process.Start();
                    Application.Exit();
                }
            }
        }
    }
}
