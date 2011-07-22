using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// 所有绘制工具的基类
    /// </summary>
    abstract class Tool
    {
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// 按下左键或者未按任何键时移动鼠标
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// 释放鼠标左键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// 双击鼠标左键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDoubleClick(RegionForm regionForm, MouseEventArgs e)
        {
        }
    }
}
