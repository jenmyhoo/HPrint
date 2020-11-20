namespace Print
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lb_login_name = new CCWin.SkinControl.SkinLabel();
            this.txt_login_name = new CCWin.SkinControl.SkinTextBox();
            this.txt_login_password = new CCWin.SkinControl.SkinTextBox();
            this.lb_login_password = new CCWin.SkinControl.SkinLabel();
            this.txt_print_address = new CCWin.SkinControl.SkinTextBox();
            this.lb_address = new CCWin.SkinControl.SkinLabel();
            this.lb_model = new CCWin.SkinControl.SkinLabel();
            this.btn_login = new CCWin.SkinControl.SkinButton();
            this.combo_print_environment = new CCWin.SkinControl.SkinComboBox();
            this.txt_company_code_port = new CCWin.SkinControl.SkinTextBox();
            this.lb_company_code_port = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // lb_login_name
            // 
            this.lb_login_name.AutoSize = true;
            this.lb_login_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_login_name.BorderColor = System.Drawing.Color.White;
            this.lb_login_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_login_name.Location = new System.Drawing.Point(50, 170);
            this.lb_login_name.Margin = new System.Windows.Forms.Padding(0);
            this.lb_login_name.Name = "lb_login_name";
            this.lb_login_name.Padding = new System.Windows.Forms.Padding(5);
            this.lb_login_name.Size = new System.Drawing.Size(82, 26);
            this.lb_login_name.TabIndex = 0;
            this.lb_login_name.Text = "登录账号";
            // 
            // txt_login_name
            // 
            this.txt_login_name.BackColor = System.Drawing.Color.Transparent;
            this.txt_login_name.DownBack = null;
            this.txt_login_name.Icon = null;
            this.txt_login_name.IconIsButton = false;
            this.txt_login_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_login_name.IsPasswordChat = '\0';
            this.txt_login_name.IsSystemPasswordChar = false;
            this.txt_login_name.Lines = new string[0];
            this.txt_login_name.Location = new System.Drawing.Point(132, 167);
            this.txt_login_name.Margin = new System.Windows.Forms.Padding(0);
            this.txt_login_name.MaxLength = 60;
            this.txt_login_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.txt_login_name.MouseBack = null;
            this.txt_login_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_login_name.Multiline = true;
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.NormlBack = null;
            this.txt_login_name.Padding = new System.Windows.Forms.Padding(5);
            this.txt_login_name.ReadOnly = false;
            this.txt_login_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_login_name.Size = new System.Drawing.Size(185, 32);
            // 
            // 
            // 
            this.txt_login_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_login_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_login_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_login_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txt_login_name.SkinTxt.MaxLength = 60;
            this.txt_login_name.SkinTxt.Multiline = true;
            this.txt_login_name.SkinTxt.Name = "BaseText";
            this.txt_login_name.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.txt_login_name.SkinTxt.TabIndex = 0;
            this.txt_login_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_login_name.SkinTxt.WaterText = "请输入登录账号";
            this.txt_login_name.SkinTxt.WordWrap = false;
            this.txt_login_name.TabIndex = 4;
            this.txt_login_name.TabStop = true;
            this.txt_login_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_login_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_login_name.WaterText = "请输入登录账号";
            this.txt_login_name.WordWrap = false;
            // 
            // txt_login_password
            // 
            this.txt_login_password.BackColor = System.Drawing.Color.Transparent;
            this.txt_login_password.DownBack = null;
            this.txt_login_password.Icon = null;
            this.txt_login_password.IconIsButton = false;
            this.txt_login_password.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_login_password.IsPasswordChat = '*';
            this.txt_login_password.IsSystemPasswordChar = false;
            this.txt_login_password.Lines = new string[0];
            this.txt_login_password.Location = new System.Drawing.Point(132, 212);
            this.txt_login_password.Margin = new System.Windows.Forms.Padding(0);
            this.txt_login_password.MaxLength = 60;
            this.txt_login_password.MinimumSize = new System.Drawing.Size(28, 28);
            this.txt_login_password.MouseBack = null;
            this.txt_login_password.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_login_password.Multiline = true;
            this.txt_login_password.Name = "txt_login_password";
            this.txt_login_password.NormlBack = null;
            this.txt_login_password.Padding = new System.Windows.Forms.Padding(5);
            this.txt_login_password.ReadOnly = false;
            this.txt_login_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_login_password.Size = new System.Drawing.Size(185, 32);
            // 
            // 
            // 
            this.txt_login_password.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_login_password.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_login_password.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_login_password.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txt_login_password.SkinTxt.MaxLength = 60;
            this.txt_login_password.SkinTxt.Multiline = true;
            this.txt_login_password.SkinTxt.Name = "BaseText";
            this.txt_login_password.SkinTxt.PasswordChar = '*';
            this.txt_login_password.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.txt_login_password.SkinTxt.TabIndex = 0;
            this.txt_login_password.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_login_password.SkinTxt.WaterText = "请输入账号密码";
            this.txt_login_password.SkinTxt.WordWrap = false;
            this.txt_login_password.TabIndex = 5;
            this.txt_login_password.TabStop = true;
            this.txt_login_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_login_password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_login_password.WaterText = "请输入账号密码";
            this.txt_login_password.WordWrap = false;
            // 
            // lb_login_password
            // 
            this.lb_login_password.AutoSize = true;
            this.lb_login_password.BackColor = System.Drawing.Color.Transparent;
            this.lb_login_password.BorderColor = System.Drawing.Color.White;
            this.lb_login_password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_login_password.Location = new System.Drawing.Point(50, 215);
            this.lb_login_password.Margin = new System.Windows.Forms.Padding(0);
            this.lb_login_password.Name = "lb_login_password";
            this.lb_login_password.Padding = new System.Windows.Forms.Padding(5);
            this.lb_login_password.Size = new System.Drawing.Size(82, 26);
            this.lb_login_password.TabIndex = 2;
            this.lb_login_password.Text = "登录密码";
            // 
            // txt_print_address
            // 
            this.txt_print_address.BackColor = System.Drawing.Color.Transparent;
            this.txt_print_address.DownBack = null;
            this.txt_print_address.Icon = null;
            this.txt_print_address.IconIsButton = false;
            this.txt_print_address.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_print_address.IsPasswordChat = '\0';
            this.txt_print_address.IsSystemPasswordChar = false;
            this.txt_print_address.Lines = new string[] {
        "http://127.0.0.1:9999/finance"};
            this.txt_print_address.Location = new System.Drawing.Point(132, 77);
            this.txt_print_address.Margin = new System.Windows.Forms.Padding(0);
            this.txt_print_address.MaxLength = 60;
            this.txt_print_address.MinimumSize = new System.Drawing.Size(28, 28);
            this.txt_print_address.MouseBack = null;
            this.txt_print_address.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_print_address.Multiline = true;
            this.txt_print_address.Name = "txt_print_address";
            this.txt_print_address.NormlBack = null;
            this.txt_print_address.Padding = new System.Windows.Forms.Padding(5);
            this.txt_print_address.ReadOnly = false;
            this.txt_print_address.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_print_address.Size = new System.Drawing.Size(185, 32);
            // 
            // 
            // 
            this.txt_print_address.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_print_address.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_print_address.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_print_address.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txt_print_address.SkinTxt.MaxLength = 60;
            this.txt_print_address.SkinTxt.Multiline = true;
            this.txt_print_address.SkinTxt.Name = "BaseText";
            this.txt_print_address.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.txt_print_address.SkinTxt.TabIndex = 0;
            this.txt_print_address.SkinTxt.Text = "http://127.0.0.1:9999/finance";
            this.txt_print_address.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_print_address.SkinTxt.WaterText = "";
            this.txt_print_address.SkinTxt.WordWrap = false;
            this.txt_print_address.TabIndex = 2;
            this.txt_print_address.TabStop = true;
            this.txt_print_address.Text = "http://127.0.0.1:9999/finance";
            this.txt_print_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_print_address.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_print_address.WaterText = "";
            this.txt_print_address.WordWrap = false;
            // 
            // lb_address
            // 
            this.lb_address.AutoSize = true;
            this.lb_address.BackColor = System.Drawing.Color.Transparent;
            this.lb_address.BorderColor = System.Drawing.Color.White;
            this.lb_address.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_address.Location = new System.Drawing.Point(50, 80);
            this.lb_address.Margin = new System.Windows.Forms.Padding(0);
            this.lb_address.Name = "lb_address";
            this.lb_address.Padding = new System.Windows.Forms.Padding(5);
            this.lb_address.Size = new System.Drawing.Size(82, 26);
            this.lb_address.TabIndex = 4;
            this.lb_address.Text = "服务地址";
            // 
            // lb_model
            // 
            this.lb_model.AutoSize = true;
            this.lb_model.BackColor = System.Drawing.Color.Transparent;
            this.lb_model.BorderColor = System.Drawing.Color.White;
            this.lb_model.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_model.Location = new System.Drawing.Point(50, 35);
            this.lb_model.Margin = new System.Windows.Forms.Padding(0);
            this.lb_model.Name = "lb_model";
            this.lb_model.Padding = new System.Windows.Forms.Padding(5);
            this.lb_model.Size = new System.Drawing.Size(82, 26);
            this.lb_model.TabIndex = 8;
            this.lb_model.Text = "打印模式";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_login.DownBack = null;
            this.btn_login.Location = new System.Drawing.Point(134, 260);
            this.btn_login.MouseBack = null;
            this.btn_login.Name = "btn_login";
            this.btn_login.NormlBack = null;
            this.btn_login.Size = new System.Drawing.Size(185, 30);
            this.btn_login.TabIndex = 6;
            this.btn_login.TabStop = false;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // combo_print_environment
            // 
            this.combo_print_environment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_print_environment.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combo_print_environment.FormattingEnabled = true;
            this.combo_print_environment.ItemBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.combo_print_environment.ItemHeight = 24;
            this.combo_print_environment.Items.AddRange(new object[] {
            "远程HTTP服务",
            "远程TCP服务",
            "本地HTTP服务",
            "本地TCP服务"});
            this.combo_print_environment.Location = new System.Drawing.Point(132, 33);
            this.combo_print_environment.Margin = new System.Windows.Forms.Padding(0);
            this.combo_print_environment.Name = "combo_print_environment";
            this.combo_print_environment.Size = new System.Drawing.Size(185, 30);
            this.combo_print_environment.TabIndex = 1;
            this.combo_print_environment.WaterText = "";
            this.combo_print_environment.SelectedIndexChanged += new System.EventHandler(this.combo_print_environment_SelectedIndexChanged);
            // 
            // txt_company_code_port
            // 
            this.txt_company_code_port.BackColor = System.Drawing.Color.Transparent;
            this.txt_company_code_port.DownBack = null;
            this.txt_company_code_port.Icon = null;
            this.txt_company_code_port.IconIsButton = false;
            this.txt_company_code_port.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_company_code_port.IsPasswordChat = '\0';
            this.txt_company_code_port.IsSystemPasswordChar = false;
            this.txt_company_code_port.Lines = new string[0];
            this.txt_company_code_port.Location = new System.Drawing.Point(132, 122);
            this.txt_company_code_port.Margin = new System.Windows.Forms.Padding(0);
            this.txt_company_code_port.MaxLength = 60;
            this.txt_company_code_port.MinimumSize = new System.Drawing.Size(28, 28);
            this.txt_company_code_port.MouseBack = null;
            this.txt_company_code_port.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_company_code_port.Multiline = true;
            this.txt_company_code_port.Name = "txt_company_code_port";
            this.txt_company_code_port.NormlBack = null;
            this.txt_company_code_port.Padding = new System.Windows.Forms.Padding(5);
            this.txt_company_code_port.ReadOnly = false;
            this.txt_company_code_port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_company_code_port.Size = new System.Drawing.Size(185, 32);
            // 
            // 
            // 
            this.txt_company_code_port.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_company_code_port.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_company_code_port.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_company_code_port.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txt_company_code_port.SkinTxt.MaxLength = 60;
            this.txt_company_code_port.SkinTxt.Multiline = true;
            this.txt_company_code_port.SkinTxt.Name = "BaseText";
            this.txt_company_code_port.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.txt_company_code_port.SkinTxt.TabIndex = 0;
            this.txt_company_code_port.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_company_code_port.SkinTxt.WaterText = "请输入公司代码";
            this.txt_company_code_port.SkinTxt.WordWrap = false;
            this.txt_company_code_port.TabIndex = 3;
            this.txt_company_code_port.TabStop = true;
            this.txt_company_code_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_company_code_port.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_company_code_port.WaterText = "请输入公司代码";
            this.txt_company_code_port.WordWrap = false;
            // 
            // lb_company_code_port
            // 
            this.lb_company_code_port.AutoSize = true;
            this.lb_company_code_port.BackColor = System.Drawing.Color.Transparent;
            this.lb_company_code_port.BorderColor = System.Drawing.Color.White;
            this.lb_company_code_port.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_company_code_port.Location = new System.Drawing.Point(50, 125);
            this.lb_company_code_port.Margin = new System.Windows.Forms.Padding(0);
            this.lb_company_code_port.Name = "lb_company_code_port";
            this.lb_company_code_port.Padding = new System.Windows.Forms.Padding(5);
            this.lb_company_code_port.Size = new System.Drawing.Size(82, 26);
            this.lb_company_code_port.TabIndex = 11;
            this.lb_company_code_port.Text = "公司代码";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 320);
            this.Controls.Add(this.txt_company_code_port);
            this.Controls.Add(this.lb_company_code_port);
            this.Controls.Add(this.combo_print_environment);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lb_model);
            this.Controls.Add(this.txt_print_address);
            this.Controls.Add(this.lb_address);
            this.Controls.Add(this.txt_login_password);
            this.Controls.Add(this.lb_login_password);
            this.Controls.Add(this.txt_login_name);
            this.Controls.Add(this.lb_login_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel lb_login_name;
        private CCWin.SkinControl.SkinTextBox txt_login_name;
        private CCWin.SkinControl.SkinTextBox txt_login_password;
        private CCWin.SkinControl.SkinLabel lb_login_password;
        private CCWin.SkinControl.SkinTextBox txt_print_address;
        private CCWin.SkinControl.SkinLabel lb_address;
        private CCWin.SkinControl.SkinLabel lb_model;
        private CCWin.SkinControl.SkinButton btn_login;
        private CCWin.SkinControl.SkinComboBox combo_print_environment;
        private CCWin.SkinControl.SkinTextBox txt_company_code_port;
        private CCWin.SkinControl.SkinLabel lb_company_code_port;
    }
}