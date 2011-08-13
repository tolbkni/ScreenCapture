using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenCapture
{
    public partial class MainForm : Form
    {
        #region 构造方法

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 按钮事件处理

        private void btnFullScrn_Click(object sender, EventArgs e)
        {
            CommandFullScrn();
        }

        private void btnRegionScrn_Click(object sender, EventArgs e)
        {
            CommandRegionScrn();
        }

        private void btnPathScrn_Click(object sender, EventArgs e)
        {
            CommandPathScrn();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            CommandOpenFolder();
        }

        #endregion


        #region 按钮调用的方法

        /// <summary>
        /// 全屏截图
        /// </summary>
        private void CommandFullScrn()
        {
            // 获取屏幕快照
            FullScrn.Capture();
        }

        /// <summary>
        /// 区域截图
        /// </summary>
        private void CommandRegionScrn()
        {
            // 获取屏幕大小
            Size size = Screen.PrimaryScreen.Bounds.Size;
            // 保存屏幕快照
            Image image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(0, 0, 0, 0, size);

            g.Dispose();

            // 显示区域截图窗体
            RegionForm frm = new RegionForm();
            frm.Size = size;
            frm.Initialize();

            // 设置默认工具
            frm.ActiveTool = RegionForm.RegionToolType.Rectangle;
            frm.DrawRectangle = new DrawRectangle(); 
            frm.BackgroundImage = image;
            frm.Show();
        }

        /// <summary>
        /// 路径截图
        /// </summary>
        private void CommandPathScrn()
        {
            // 获取屏幕大小
            Size size = Screen.PrimaryScreen.Bounds.Size;
            // 保存屏幕快照
            Image image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(0, 0, 0, 0, size);

            g.Dispose();

            // 显示区域截图窗体
            RegionForm frm = new RegionForm();
            frm.Size = size;
            frm.Initialize();

            // 设置默认工具
            frm.ActiveTool = RegionForm.RegionToolType.Path;
            frm.DrawRectangle = new DrawPath();
            frm.BackgroundImage = image;
            frm.Show();
        }

        /// <summary>
        /// 打开截图保存目录（暂定为程序运行目录）
        /// </summary>
        private void CommandOpenFolder()
        {
            Process.Start(
                Environment.GetEnvironmentVariable("WINDIR") + "\\explorer.exe", 
                Application.StartupPath);
        }

        #endregion
    }
}