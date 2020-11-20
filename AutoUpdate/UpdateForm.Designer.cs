namespace AutoUpdate
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.progress_file = new CCWin.SkinControl.SkinProgressBar();
            this.SuspendLayout();
            // 
            // progress_file
            // 
            this.progress_file.Back = null;
            this.progress_file.BackColor = System.Drawing.Color.Transparent;
            this.progress_file.BarBack = null;
            this.progress_file.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progress_file.ForeColor = System.Drawing.Color.Red;
            this.progress_file.Location = new System.Drawing.Point(43, 48);
            this.progress_file.Name = "progress_file";
            this.progress_file.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.progress_file.Size = new System.Drawing.Size(320, 23);
            this.progress_file.TabIndex = 0;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 113);
            this.Controls.Add(this.progress_file);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件下载中";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinProgressBar progress_file;
    }
}