using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CCWin;
using System.Net;
using common;
using common.tool;
using System.IO;
using Newtonsoft.Json;
using common.bean;
using System.Web;
using System.Text;

namespace Print
{
    public partial class LoginForm : CCSkinMain
    {
        private string key = "YI9nnvjr";
        private int windowMaxHeight = 320;
        private bool reqireLogin = true;
        public LoginForm()
        {
            InitializeComponent();
            windowMaxHeight = this.Height;
            combo_print_environment.SelectedIndex = 0;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (reqireLogin)
            {
                string print_address = txt_print_address.Text.Trim();
                if (!CheckTools.isUrl(print_address))
                {
                    MessageBoxEx.Show(this, "服务地址须为有效域名或IP", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (print_address.EndsWith("/"))
                {
                    print_address = print_address.Substring(0, print_address.Length - 1);
                }
                string company_code = txt_company_code_port.Text.Trim();
                if (company_code.Length < 3)
                {
                    MessageBoxEx.Show(this, "公司代码不允许为空", "提示", MessageBoxButtons.OK);
                    return;
                }
                string login_name = txt_login_name.Text.Trim();
                if (login_name.Length < 3)
                {
                    MessageBoxEx.Show(this, "登录账号不允许为空", "提示", MessageBoxButtons.OK);
                    return;
                }
                string login_password = txt_login_password.Text.Trim();
                if (login_password.Length < 3)
                {
                    MessageBoxEx.Show(this, "账号密码不允许为空", "提示", MessageBoxButtons.OK);
                    return;
                }
                StaticUtil.PRINT_ADDRESS = print_address;
                Dictionary<string, string> parameters = new Dictionary<string, string>(3);
                parameters.Add("companyCode", company_code);
                parameters.Add("loginName", login_name);
                parameters.Add("loginPassword", login_password);
                string result = null;
                result = HttpRequestClientUtil.doPost(StaticUtil.PRINT_ADDRESS + "/user/login", StaticUtil.DEFAULT_CHARSET, 60000, null, parameters, null);
                if (null == result)
                {
                    MessageBoxEx.Show(this, "登录超时，请检查网络", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    Result<UserCookieBean> data = JsonConvert.DeserializeObject<Result<UserCookieBean>>(result);
                    if (data.success && data.bizErrCode == 20000)
                    {
                        StaticUtil.USER_COOKIE_BEAN = data.data;
                        string domain = StaticUtil.getDomainByPrintAddress(StaticUtil.PRINT_ADDRESS);

                        Encoding encoding = Encoding.GetEncoding(StaticUtil.DEFAULT_CHARSET);
                        Cookie userIdCookie = new Cookie("user_id", HttpUtility.UrlEncode(StaticUtil.USER_COOKIE_BEAN.userId.ToString(), encoding), "/", domain);
                        StaticUtil.USER_COOKIE_BEAN.Cookies.Add(userIdCookie);

                        Cookie companyCodeCookie = new Cookie("company_code", HttpUtility.UrlEncode(StaticUtil.USER_COOKIE_BEAN.companyCode, encoding), "/", domain);
                        StaticUtil.USER_COOKIE_BEAN.Cookies.Add(companyCodeCookie);

                        Cookie loginNameCookie = new Cookie("login_name", HttpUtility.UrlEncode(StaticUtil.USER_COOKIE_BEAN.loginName, encoding), "/", domain);
                        StaticUtil.USER_COOKIE_BEAN.Cookies.Add(loginNameCookie);

                        Cookie userNameCookie = new Cookie("user_name", HttpUtility.UrlEncode(StaticUtil.USER_COOKIE_BEAN.userName, encoding), "/", domain);
                        StaticUtil.USER_COOKIE_BEAN.Cookies.Add(userNameCookie);

                        Cookie cookie_sessionCookie = new Cookie("cookie_session", HttpUtility.UrlEncode(StaticUtil.USER_COOKIE_BEAN.cookie_session, encoding), "/", domain);
                        StaticUtil.USER_COOKIE_BEAN.Cookies.Add(cookie_sessionCookie);

                        Ini ini = new Ini(Application.StartupPath + Path.DirectorySeparatorChar + "user.ini");
                        ini.Write("user", "address", StaticUtil.PRINT_ADDRESS);
                        ini.Write("user", "company", FingerUtil.Encrypt(company_code, key));
                        ini.Write("user", "name", FingerUtil.Encrypt(login_name, key));
                        ini.Write("user", "password", FingerUtil.Encrypt(login_password, key));

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBoxEx.Show(this, data.defaultRequestFailShow(), "提示", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                string address = txt_print_address.Text.Trim();
                if (!CheckTools.isIp(address))
                {
                    MessageBoxEx.Show(this, "请输入本地打印服务器地址且必须为IP格式", "提示", MessageBoxButtons.OK);
                    return;
                }
                string ports = txt_company_code_port.Text.Trim();
                if (!CheckTools.isPositiveNumber(ports))
                {
                    ports = "27027";
                }
                int port = int.Parse(ports);
                if (port <= 1024 || port > 65535)
                {
                    MessageBoxEx.Show(this, "请输入手机打印服务器端口号，有效范围1025～65535", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void combo_print_environment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.combo_print_environment.SelectedIndex;
            StaticUtil.ENVIRONMENT = index;
            StaticUtil.ENVIRONMENT_NAME = this.combo_print_environment.SelectedItem.ToString();
            switch (index)
            {
                //远程HTTP
                case 0:
                    {
                        setRemoteUI();
                        break;
                    }
                //远程TCP
                case 1:
                    {
                        setRemoteUI();
                        break;
                    }
                //本地HTTP
                case 2:
                    {
                        setLocalUI();

                        break;
                    }
                //本地TCP
                case 3:
                    {
                        setLocalUI();
                        break;
                    }
            }
        }

        private void setRemoteUI()
        {
            if (this.Height != windowMaxHeight)
            {
                reqireLogin = true;
                int twoHeight = (26 + 19) * 2;
                this.Height = windowMaxHeight;
                this.lb_company_code_port.Text = "公司代码";
                this.txt_company_code_port.WaterText = "请输入公司代码";
                int x = btn_login.Location.X;
                int y = btn_login.Location.Y + twoHeight;
                btn_login.Location = new System.Drawing.Point(x, y);
                this.lb_login_name.Visible = true;
                this.txt_login_name.Visible = true;
                this.lb_login_password.Visible = true;
                this.txt_login_password.Visible = true;
            }
            readIni();
        }

        private void setLocalUI()
        {
            if (this.Height == windowMaxHeight)
            {
                reqireLogin = false;
                this.lb_company_code_port.Text = "服务端口";
                this.txt_company_code_port.WaterText = "请输入服务端口";
                this.lb_login_name.Visible = false;
                this.txt_login_name.Visible = false;
                this.lb_login_password.Visible = false;
                this.txt_login_password.Visible = false;
                int twoHeight = (26 + 19) * 2;
                int x = btn_login.Location.X;
                int y = btn_login.Location.Y - twoHeight;
                btn_login.Location = new System.Drawing.Point(x, y);
                this.Height = windowMaxHeight - twoHeight;
                txt_print_address.Text = StaticUtil.getLocalHostLANAddress().ToString();
                txt_company_code_port.Text = "27027";
            }
        }

        private void readIni()
        {
            Ini ini = new Ini(Application.StartupPath + Path.DirectorySeparatorChar + "user.ini");
            string address = ini.Read("user", "address", 256);
            if (CheckTools.isUrl(address))
            {
                this.txt_print_address.Text = address;
            }
            string company = ini.Read("user", "company", 256);
            if (!CheckTools.isNull(company))
            {
                this.txt_company_code_port.Text = FingerUtil.Decrypt(company, key);
            }
            else
            {
                txt_company_code_port.Text = "";
            }
            string name = ini.Read("user", "name", 256);
            if (!CheckTools.isNull(name))
            {
                this.txt_login_name.Text = FingerUtil.Decrypt(name, key);
            }
            string password = ini.Read("user", "password", 256);
            if (!CheckTools.isNull(password))
            {
                this.txt_login_password.Text = FingerUtil.Decrypt(password, key);
            }
        }

        //protected override void WndProc(ref Message msg)
        //{
        //    const int WM_SYSCOMMAND = 0x0010;
        //    const int SC_CLOSE = 0x0000;
        //    if (msg.Msg == WM_SYSCOMMAND)
        //    {
        //        Console.WriteLine(msg.ToString());
        //    }
        //    if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
        //    {
        //        // 点击winform右上关闭按钮 
        //        this.Dispose();
        //        Application.Exit();
        //    }
        //    else
        //    {
        //        base.WndProc(ref msg);
        //    }
        //}
    }
}
