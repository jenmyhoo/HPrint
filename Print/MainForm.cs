using System;

using CCWin;
using Print.bridge;
using System.Windows.Forms;
using System.Drawing.Printing;
using common;
using common.tool;
using Print.tool;
using System.IO;
using Newtonsoft.Json;
using Print.bean.printer;
using common.bean;
using System.Collections.Generic;

namespace Print
{
    public partial class MainForm : CCSkinMain
    {
        private System.Threading.Timer remoteHttpTimer = null;
        private HttpServer localHttpServer = null;
        private TcpSocketServer localTcpSocketServer = null;
        //先定义一个委托事件方法
        protected delegate void DelegateShowUIMessage(string message);

        //定义一个更新控件的方法
        protected void updateMsg(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new DelegateShowUIMessage(delegate (string msg)
                {
                    if (msg != null)
                    {
                        this.txt_print_log.AppendText(msg);
                    }
                }), message);
            }
            else
            {
                this.txt_print_log.AppendText(message);
            }
        }
        public MainForm()
        {
            InitializeComponent();
            //显示服务信息
            InitServiceInfo();
            //初始化打印机下拉列表选项
            InitPrinterComboBox();
            //初始化打印模板列表
            InitPrintTemplate();
        }

        //获取本机默认打印机名称
        public String GetDefaultPrinter()
        {
            return this.print_document.PrinterSettings.PrinterName;
        }

        public void InitPrinterComboBox()
        {
            this.combo_printer.Items.Add(GetDefaultPrinter());
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!this.combo_printer.Items.Contains(fPrinterName))
                {
                    this.combo_printer.Items.Add(fPrinterName);
                }
            }
            this.combo_printer.SelectedIndex = 0;
        }

        public void InitServiceInfo()
        {
            //int height = this.grid_service_info.Height;
            //int rowHeight = height/7;
            //this.grid_service_info.Columns.Add("name", "项目名称");
            //this.grid_service_info.Columns.Add("value", "项目值");
            //this.grid_service_info.ColumnHeadersHeight = height - rowHeight * 6;

            int index = this.grid_service_info.Rows.Add();
            //this.grid_service_info.Rows[index].Height = rowHeight;
            this.grid_service_info.Rows[index].Cells[0].Value = "操作系统";
            this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.GetOSVersion();

            index = this.grid_service_info.Rows.Add();
            //this.grid_service_info.Rows[index].Height = rowHeight;
            this.grid_service_info.Rows[index].Cells[0].Value = "系统版本";
            this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.VERSION;

            index = this.grid_service_info.Rows.Add();
            //this.grid_service_info.Rows[index].Height = rowHeight;
            this.grid_service_info.Rows[index].Cells[0].Value = "打印模式";
            this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.ENVIRONMENT_NAME;

            index = this.grid_service_info.Rows.Add();
            //this.grid_service_info.Rows[index].Height = rowHeight;
            this.grid_service_info.Rows[index].Cells[0].Value = "服务地址";
            this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.PRINT_ADDRESS;

            if (StaticUtil.USER_COOKIE_BEAN == null)
            {
                index = this.grid_service_info.Rows.Add();
                //this.grid_service_info.Rows[index].Height = rowHeight;
                this.grid_service_info.Rows[index].Cells[0].Value = "服务端口";
                this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.LOCAL_PORT.ToString();
            }
            else
            {
                index = this.grid_service_info.Rows.Add();
                //this.grid_service_info.Rows[index].Height = rowHeight;
                this.grid_service_info.Rows[index].Cells[0].Value = "公司代码";
                this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.USER_COOKIE_BEAN.companyCode;

                index = this.grid_service_info.Rows.Add();
                //this.grid_service_info.Rows[index].Height = rowHeight;
                this.grid_service_info.Rows[index].Cells[0].Value = "打印账号";
                this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.USER_COOKIE_BEAN.loginName;

                index = this.grid_service_info.Rows.Add();
                //this.grid_service_info.Rows[index].Height = rowHeight;
                this.grid_service_info.Rows[index].Cells[0].Value = "打印机名";
                this.grid_service_info.Rows[index].Cells[1].Value = StaticUtil.USER_COOKIE_BEAN.userName;
            }
        }

        public void InitPrintTemplate()
        {
            string fileTemplateDir = Application.StartupPath + Path.DirectorySeparatorChar + "resource" + Path.DirectorySeparatorChar + "template";
            DirectoryInfo folder = new DirectoryInfo(fileTemplateDir);
            foreach (FileInfo fileInfo in folder.GetFiles())
            {
                this.combo_print_template.Items.Add(fileInfo.Name);
            }
            if (this.combo_print_template.Items.Count > 0)
            {
                this.combo_print_template.SelectedIndex = 0;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.combo_theme.SelectedIndex = 0;
            this.txt_print_log.AppendText("打印服务正在初始化...\r\n");
            switch (StaticUtil.ENVIRONMENT)
            {
                //远程HTTP
                case 0:
                    {
                        //Timer构造函数参数说明：
                        //Callback：一个　TimerCallback 委托，表示要执行的方法。
                        //State：一个包含回调方法要使用的信息的对象，或者为空引用（Visual　Basic 中为 Nothing）。
                        //dueTime：调用callback之前延迟的时间量（以毫秒为单位）。指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。
                        //Period：调用callback的时间间隔（以毫秒为单位）。指定 Timeout.Infinite 可以禁用定期终止。
                        /**立即执行一次*/
                        remoteHttpTimer = new System.Threading.Timer(remoteHttp, null, 0, System.Threading.Timeout.Infinite);
                        break;
                    }
                //远程TCP
                case 1:
                    {
                        remoteTcp();
                        break;
                    }
                //本地HTTP
                case 2:
                    {
                        localHttp();
                        break;
                    }
                //本地TCP
                case 3:
                    {
                        localTcp();
                        break;
                    }
            }
        }

        //声明委托
        private delegate void RemoteHttpDelegate();
        private void remoteHttp(object state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RemoteHttpDelegate(remoteHttpRequest));
            }
            else
            {
                remoteHttpRequest();
            }
        }

        private void remoteHttpRequest()
        {
            string result = null;
            result = HttpRequestClientUtil.doPost(StaticUtil.PRINT_ADDRESS + "/printer/getPrinterList", StaticUtil.DEFAULT_CHARSET, 60000, null, null, StaticUtil.USER_COOKIE_BEAN.Cookies);
            if (null == result)
            {
                //停止定时器
                remoteHttpTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                MessageBoxEx.Show(this, "请求超时,请检查网络!", "提示", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    Result<List<PrinterList>> data = JsonConvert.DeserializeObject<Result<List<PrinterList>>>(result);
                    if (data.success && data.bizErrCode == 20000)
                    {
                        SyncPrint(data.data);
                    }
                    else
                    {
                        this.txt_print_log.AppendText("远程HTTP打印服务异常提示:" + data.defaultRequestFailShow() + "\r\n");
                        //启动下次定时任务
                        changeRemoteHttpTimer();
                    }
                }
                catch (Exception e)
                {
                    //停止定时器
                    remoteHttpTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    Console.WriteLine("MainForm.remoteHttpRequest序列化异常：" + e.Message);
                }
            }
            
        }

        private void changeRemoteHttpTimer()
        {
            DateTime nowTime = DateTime.Now;
            DateTime nextTime = nowTime.AddSeconds(5);
            int dueTime = (int)nextTime.Subtract(nowTime).TotalMilliseconds;
            //执行完后,重新设置定时器下次执行时间.
            remoteHttpTimer.Change(dueTime, System.Threading.Timeout.Infinite);
            //Console.WriteLine("{0} 执行一次,下次执行时间 {1}", DateTime.Now, nextTime);
            this.txt_print_log.AppendText(string.Format("远程HTTP打印服务下次执行时间:{0}\r\n", nextTime.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        //声明委托
        //private delegate void UpdatePrintResultDelegate(PrinterList printer);

        private void SyncPrint(List<PrinterList> printerList)
        {
            if (printerList != null)
            {
                CallServiceThread callService = new CallServiceThread();
                //foreach (PrinterList printer in printerList)
                //{
                //    Task<PrinterList> task = Task.Factory.StartNew<PrinterList>(() => callService.print(true, printer));//异步执行
                //    //PrinterList result = task.Result;
                //    task.ContinueWith(t =>
                //    {
                //        PrinterList result = t.Result;
                //        if (this.InvokeRequired)
                //        {
                //            this.Invoke(new UpdatePrintResultDelegate(UpdatePrintResult), result);
                //        }
                //        else
                //        {
                //            UpdatePrintResult(result);
                //        }
                //    });
                //}
                foreach (PrinterList printer in printerList)
                {
                    callService.print(true, printer);
                    UpdatePrintResult(printer);
                }
            }
            changeRemoteHttpTimer();
        }

        private void UpdatePrintResult(PrinterList printer)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>(3);
            parameters.Add("listId", printer.listId.ToString());
            parameters.Add("printResult", printer.printResult.ToString());
            parameters.Add("errorMsg", printer.errorMsg);
            string result = null;
            result = HttpRequestClientUtil.doPost(StaticUtil.PRINT_ADDRESS + "/printer/updatePrinterListResult", StaticUtil.DEFAULT_CHARSET, 60000, null, parameters, StaticUtil.USER_COOKIE_BEAN.Cookies);
            if (null == result)
            {
                MessageBoxEx.Show(this, "请求超时,请检查网络!", "提示", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    Result<int?> data = JsonConvert.DeserializeObject<Result<int?>>(result);
                    if (data.success && data.bizErrCode == 20000 && data.data > 0)
                    {

                    }
                    else
                    {
                        this.txt_print_log.AppendText("远程HTTP打印服务异常提示:" + data.defaultRequestFailShow() + "\r\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("MainForm.UpdatePrintResult序列化异常：" + e.Message);
                }

            }
        }

        private void remoteTcp()
        {

        }

        private void localHttp()
        {
            localHttpServer = new HttpServer(StaticUtil.PRINT_ADDRESS, StaticUtil.LOCAL_PORT, StaticUtil.DEFAULT_CHARSET);
            //Thread thread = new Thread(new ThreadStart(httpServer.listen));
            //thread.Start();
            localHttpServer.UIDelegateUIMessage += updateMsg;
            localHttpServer.listen();
        }

        private void localTcp()
        {
            SocketParameter socketParameter = new SocketParameter(StaticUtil.PRINT_ADDRESS, StaticUtil.LOCAL_PORT);
            localTcpSocketServer = TcpSocketServer.getInstance();
            localTcpSocketServer.UIDelegateUIMessage += updateMsg;
            string result = localTcpSocketServer.start(socketParameter);
            if ("SUCCESS".Equals(result))
            {
                this.txt_print_log.AppendText("本地TCP打印服务已启动...\r\n");
            }
            else
            {
                this.txt_print_log.AppendText("本地TCP打印服务启动异常:" + result + "\r\n");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (remoteHttpTimer != null)
            {
                remoteHttpTimer.Dispose();
            }
            if (localTcpSocketServer != null)
            {
                localTcpSocketServer.terminate();
            }
            if (localHttpServer != null)
            {
                localHttpServer.IsActive = false;
            }
            notify_form.Dispose();
            Environment.Exit(0);
        }

        private void combo_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string theme = this.combo_theme.SelectedItem.ToString();
            switch (theme)
            {
                case "None":
                    this.XTheme = new CCSkinMain() { Shadow = false };
                    break;
                case "Mac":
                    this.XTheme = new Skin_Mac() { };
                    break;
                case "Dev":
                    this.XTheme = new Skin_DevExpress() { };
                    break;
                case "VS":
                    this.XTheme = new Skin_VS() { };
                    break;
                case "Win8":
                    this.XTheme = new Skin_Metro() { };
                    break;
                case "Color":
                    this.XTheme = new Skin_Color() { };
                    break;
            }
        }

        private void combo_printer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Externs.SetDefaultPrinter(this.combo_printer.SelectedItem.ToString());
        }

        private void notify_form_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notify_form.Visible = false;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notify_form.Visible = true;
            }
        }

        private void btn_view_template_Click(object sender, EventArgs e)
        {
            if (this.combo_print_template.SelectedIndex == -1)
            {
                return;
            }
            string fileTemplateDir = Application.StartupPath + Path.DirectorySeparatorChar + "resource" + Path.DirectorySeparatorChar + "template";
            string filename = this.combo_print_template.SelectedItem.ToString();
            System.Diagnostics.Process.Start(fileTemplateDir + Path.DirectorySeparatorChar + filename);
        }

        private void btn_delete_cache_Click(object sender, EventArgs e)
        {
            string cacheDir = Application.StartupPath + Path.DirectorySeparatorChar + "resource" + Path.DirectorySeparatorChar + "export";
            System.Diagnostics.Process.Start(cacheDir);
            //StaticUtil.DeleteDir(cacheDir);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (remoteHttpTimer == null)
            {
                MessageBoxEx.Show(this, "手工打印只支持远程打印模式", "出错了", MessageBoxButtons.OK);
            }
            else
            {
                DateTime nowTime = DateTime.Now;
                //执行完后,重新设置定时器下次执行时间.
                remoteHttpTimer.Change(0, System.Threading.Timeout.Infinite);
                //Console.WriteLine("{0} 执行一次,下次执行时间 {1}", DateTime.Now, nextTime);
                this.txt_print_log.AppendText(string.Format("远程HTTP打印服务手动执行时间:{0}\r\n", nowTime.ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
    }
}
