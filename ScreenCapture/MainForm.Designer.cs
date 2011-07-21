namespace ScreenCapture
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFullScrn = new System.Windows.Forms.Button();
            this.btnRegionScrn = new System.Windows.Forms.Button();
            this.btnPathScrn = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFullScrn
            // 
            this.btnFullScrn.Location = new System.Drawing.Point(12, 12);
            this.btnFullScrn.Name = "btnFullScrn";
            this.btnFullScrn.Size = new System.Drawing.Size(100, 23);
            this.btnFullScrn.TabIndex = 0;
            this.btnFullScrn.Text = "全屏截图";
            this.btnFullScrn.UseVisualStyleBackColor = true;
            this.btnFullScrn.Click += new System.EventHandler(this.btnFullScrn_Click);
            // 
            // btnRegionScrn
            // 
            this.btnRegionScrn.Location = new System.Drawing.Point(127, 12);
            this.btnRegionScrn.Name = "btnRegionScrn";
            this.btnRegionScrn.Size = new System.Drawing.Size(100, 23);
            this.btnRegionScrn.TabIndex = 1;
            this.btnRegionScrn.Text = "区域截图";
            this.btnRegionScrn.UseVisualStyleBackColor = true;
            this.btnRegionScrn.Click += new System.EventHandler(this.btnRegionScrn_Click);
            // 
            // btnPathScrn
            // 
            this.btnPathScrn.Location = new System.Drawing.Point(12, 50);
            this.btnPathScrn.Name = "btnPathScrn";
            this.btnPathScrn.Size = new System.Drawing.Size(100, 23);
            this.btnPathScrn.TabIndex = 2;
            this.btnPathScrn.Text = "路径截图";
            this.btnPathScrn.UseVisualStyleBackColor = true;
            this.btnPathScrn.Click += new System.EventHandler(this.btnPathScrn_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(127, 50);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 23);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.Text = "打开目录";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 86);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnPathScrn);
            this.Controls.Add(this.btnRegionScrn);
            this.Controls.Add(this.btnFullScrn);
            this.Name = "MainForm";
            this.Text = "屏幕截图";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFullScrn;
        private System.Windows.Forms.Button btnRegionScrn;
        private System.Windows.Forms.Button btnPathScrn;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}

