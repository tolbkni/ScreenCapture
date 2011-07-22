using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class RegionForm : Form
    {
        #region 构造方法

        public RegionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 枚举

        public enum RegionToolType
        {
            Pointer,
            Rectangle,
            NumberOfRegionTools
        };

        #endregion

        #region 成员

        private RegionObject regionObject;  // 绘制对象

        private RegionToolType activeTool;  // 当前绘制工具
        private Tool[] tools;               // 工具数组

        #endregion

        #region 属性

        /// <summary>
        /// 当前绘制工具
        /// </summary>
        public RegionToolType ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        /// <summary>
        /// 区域截图形状
        /// </summary>
        public RegionObject RegionObject
        {
            get { return regionObject; }
            set { regionObject = value; }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 绘制区域形状
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_Paint(object sender, PaintEventArgs e)
        {
            if (regionObject != null)
            {
                regionObject.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// 把释放鼠标左键事件传递给当前工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseUp(this, e);
            }
        }

        /// <summary>
        /// 把按住鼠标左键移动和不按键移动事件传递给当前工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                tools[(int)activeTool].OnMouseMove(this, e);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 按下鼠标左键事件传递给当前工具
        /// 按下鼠标右键事件直接关闭本窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// 保存绘制对象区域对应的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rect = ((RegionRectangle)RegionObject).Rectangle;
                if (rect.Contains(new Point(e.X, e.Y)))
                {
                    tools[(int)activeTool].OnMouseDoubleClick(this, e);
                    this.Close();
                    this.Dispose();
                }
            }
        }

        #endregion


        #region 其他方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, 
                true);

            // 创建绘制工具
            tools = new Tool[(int)RegionToolType.NumberOfRegionTools];
            tools[(int)RegionToolType.Pointer] = new ToolPointer();
            tools[(int)RegionToolType.Rectangle] = new ToolRectangle();
        }

        #endregion
    }
}