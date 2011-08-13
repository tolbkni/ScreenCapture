using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// 创建绘图对象工具的基类
    /// </summary>
    abstract class ToolObject : Tool
    {
        private Cursor cursor;

        /// <summary>
        /// 工具的光标
        /// </summary>
        protected Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }

        /// <summary>
        /// 释放鼠标左键
        /// 改变绘制对象的大小
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
            regionForm.DrawRectangle.Normalize();
            // 切换成拖动模式
            regionForm.ActiveTool = RegionForm.RegionToolType.Pointer;

            regionForm.Capture = false;
            regionForm.Refresh();
        }

        /// <summary>
        /// 左键点击绘制区时调用
        /// 激活指定绘图对象
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="o"></param>
        protected void ChangeObject(RegionForm regionForm, DrawRectangle o)
        {
            regionForm.DrawRectangle = o;

            regionForm.Capture = true;
            regionForm.Refresh();
        }
    }
}
