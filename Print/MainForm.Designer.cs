namespace Print
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.txt_print_log = new CCWin.SkinControl.SkinWaterTextBox();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.btn_print = new CCWin.SkinControl.SkinButton();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.combo_print_template = new CCWin.SkinControl.SkinComboBox();
            this.btn_delete_cache = new CCWin.SkinControl.SkinButton();
            this.btn_view_template = new CCWin.SkinControl.SkinButton();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.combo_printer = new CCWin.SkinControl.SkinComboBox();
            this.combo_theme = new CCWin.SkinControl.SkinComboBox();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.grid_service_info = new CCWin.SkinControl.SkinDataGridView();
            this.notify_form = new System.Windows.Forms.NotifyIcon(this.components);
            this.print_document = new System.Drawing.Printing.PrintDocument();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinGroupBox2.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_service_info)).BeginInit();
            this.SuspendLayout();
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox2.Controls.Add(this.txt_print_log);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Location = new System.Drawing.Point(2, 33);
            this.skinGroupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(587, 404);
            this.skinGroupBox2.TabIndex = 1;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "请求日志";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // txt_print_log
            // 
            this.txt_print_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_print_log.Location = new System.Drawing.Point(3, 17);
            this.txt_print_log.Multiline = true;
            this.txt_print_log.Name = "txt_print_log";
            this.txt_print_log.ReadOnly = true;
            this.txt_print_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_print_log.Size = new System.Drawing.Size(581, 384);
            this.txt_print_log.TabIndex = 0;
            this.txt_print_log.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_print_log.WaterText = "";
            // 
            // skinPanel1
            // 
            this.skinPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.btn_print);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.combo_print_template);
            this.skinPanel1.Controls.Add(this.btn_delete_cache);
            this.skinPanel1.Controls.Add(this.btn_view_template);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.combo_printer);
            this.skinPanel1.Controls.Add(this.combo_theme);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(2, 438);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(892, 45);
            this.skinPanel1.TabIndex = 2;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.Transparent;
            this.btn_print.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_print.DownBack = null;
            this.btn_print.Location = new System.Drawing.Point(724, 13);
            this.btn_print.MouseBack = null;
            this.btn_print.Name = "btn_print";
            this.btn_print.NormlBack = null;
            this.btn_print.Size = new System.Drawing.Size(75, 21);
            this.btn_print.TabIndex = 6;
            this.btn_print.Text = "手工打印";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(434, 17);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(63, 14);
            this.skinLabel3.TabIndex = 8;
            this.skinLabel3.Text = "打印模板";
            this.skinLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_print_template
            // 
            this.combo_print_template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_print_template.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combo_print_template.FormattingEnabled = true;
            this.combo_print_template.ItemHeight = 16;
            this.combo_print_template.Location = new System.Drawing.Point(502, 13);
            this.combo_print_template.Name = "combo_print_template";
            this.combo_print_template.Size = new System.Drawing.Size(135, 22);
            this.combo_print_template.TabIndex = 3;
            this.combo_print_template.WaterText = "";
            // 
            // btn_delete_cache
            // 
            this.btn_delete_cache.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete_cache.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_delete_cache.DownBack = null;
            this.btn_delete_cache.Location = new System.Drawing.Point(805, 13);
            this.btn_delete_cache.MouseBack = null;
            this.btn_delete_cache.Name = "btn_delete_cache";
            this.btn_delete_cache.NormlBack = null;
            this.btn_delete_cache.Size = new System.Drawing.Size(75, 21);
            this.btn_delete_cache.TabIndex = 7;
            this.btn_delete_cache.Text = "清理缓存";
            this.btn_delete_cache.UseVisualStyleBackColor = false;
            this.btn_delete_cache.Click += new System.EventHandler(this.btn_delete_cache_Click);
            // 
            // btn_view_template
            // 
            this.btn_view_template.BackColor = System.Drawing.Color.Transparent;
            this.btn_view_template.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_view_template.DownBack = null;
            this.btn_view_template.Location = new System.Drawing.Point(643, 13);
            this.btn_view_template.MouseBack = null;
            this.btn_view_template.Name = "btn_view_template";
            this.btn_view_template.NormlBack = null;
            this.btn_view_template.Size = new System.Drawing.Size(75, 21);
            this.btn_view_template.TabIndex = 5;
            this.btn_view_template.Text = "查看模板";
            this.btn_view_template.UseVisualStyleBackColor = false;
            this.btn_view_template.Click += new System.EventHandler(this.btn_view_template_Click);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(141, 17);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(105, 14);
            this.skinLabel2.TabIndex = 4;
            this.skinLabel2.Text = "设定默认打印机";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(6, 17);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(63, 14);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "界面风格";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_printer
            // 
            this.combo_printer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_printer.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combo_printer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.combo_printer.FormattingEnabled = true;
            this.combo_printer.ItemHeight = 16;
            this.combo_printer.Location = new System.Drawing.Point(253, 13);
            this.combo_printer.Name = "combo_printer";
            this.combo_printer.Size = new System.Drawing.Size(173, 22);
            this.combo_printer.TabIndex = 2;
            this.combo_printer.WaterText = "";
            this.combo_printer.SelectedIndexChanged += new System.EventHandler(this.combo_printer_SelectedIndexChanged);
            // 
            // combo_theme
            // 
            this.combo_theme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_theme.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combo_theme.FormattingEnabled = true;
            this.combo_theme.ItemHeight = 16;
            this.combo_theme.Items.AddRange(new object[] {
            "None",
            "Mac",
            "Dev",
            "VS",
            "Win8",
            "Color"});
            this.combo_theme.Location = new System.Drawing.Point(71, 13);
            this.combo_theme.Name = "combo_theme";
            this.combo_theme.Size = new System.Drawing.Size(66, 22);
            this.combo_theme.TabIndex = 1;
            this.combo_theme.WaterText = "";
            this.combo_theme.SelectedIndexChanged += new System.EventHandler(this.combo_theme_SelectedIndexChanged);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox1.Controls.Add(this.grid_service_info);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(594, 33);
            this.skinGroupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(300, 404);
            this.skinGroupBox1.TabIndex = 2;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "系统信息";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // grid_service_info
            // 
            this.grid_service_info.AllowUserToAddRows = false;
            this.grid_service_info.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.grid_service_info.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_service_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_service_info.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_service_info.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid_service_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_service_info.ColumnFont = null;
            this.grid_service_info.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_service_info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_service_info.ColumnHeadersHeight = 26;
            this.grid_service_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_service_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.column_value});
            this.grid_service_info.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_service_info.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_service_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_service_info.EnableHeadersVisualStyles = false;
            this.grid_service_info.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grid_service_info.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid_service_info.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid_service_info.Location = new System.Drawing.Point(3, 17);
            this.grid_service_info.Name = "grid_service_info";
            this.grid_service_info.ReadOnly = true;
            this.grid_service_info.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_service_info.RowHeadersVisible = false;
            this.grid_service_info.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid_service_info.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_service_info.RowTemplate.Height = 23;
            this.grid_service_info.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grid_service_info.Size = new System.Drawing.Size(294, 384);
            this.grid_service_info.TabIndex = 0;
            this.grid_service_info.TitleBack = null;
            this.grid_service_info.TitleBackColorBegin = System.Drawing.Color.White;
            this.grid_service_info.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // notify_form
            // 
            this.notify_form.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_form.Icon")));
            this.notify_form.Text = "远程打印服务器";
            this.notify_form.Visible = true;
            this.notify_form.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_form_MouseDoubleClick);
            // 
            // column_name
            // 
            this.column_name.HeaderText = "项目名称";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            // 
            // column_value
            // 
            this.column_value.HeaderText = "项目值";
            this.column_value.Name = "column_value";
            this.column_value.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 490);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.skinGroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "修车仔远程打印服务器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_service_info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinWaterTextBox txt_print_log;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinComboBox combo_theme;
        private CCWin.SkinControl.SkinComboBox combo_printer;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton btn_view_template;
        private CCWin.SkinControl.SkinButton btn_delete_cache;
        private System.Windows.Forms.NotifyIcon notify_form;
        private System.Drawing.Printing.PrintDocument print_document;
        private CCWin.SkinControl.SkinButton btn_print;
        private CCWin.SkinControl.SkinDataGridView grid_service_info;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinComboBox combo_print_template;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_value;
    }
}

