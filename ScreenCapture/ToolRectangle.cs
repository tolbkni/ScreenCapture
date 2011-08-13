using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// 矩形工具，创建绘图对象工具的基类
    /// </summary>
    class ToolRectangle : Tool
    {
        private Cursor cursor;

        #region 属性

        /// <summary>
        /// 工具的光标
        /// </summary>
        protected Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }

        #endregion

        #region 构造方法

        public ToolRectangle()
        {
            Cursor = Cursors.Default;
        }

        #endregion

        #region 鼠标事件处理

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

        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            ChangeObject(regionForm, new DrawRectangle(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
            regionForm.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                regionForm.DrawRectangle.MoveHandleTo(point, 5);
                regionForm.Refresh();
            }
        }
        
        #endregion

        #region 辅助方法

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

        #endregion
    }
}
