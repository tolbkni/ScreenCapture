using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// 所有绘制对象的基类
    /// </summary>
    public abstract class RegionObject
    {
        #region 属性

        /// <summary>
        /// 拖柄的数量
        /// </summary>
        public virtual int HandleCount
        {
            get { return 0; }
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 绘制对象
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// 通过拖柄编号得到对应拖柄
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// 通过拖柄编号得到对应拖柄区域
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// 绘制拖柄
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);

            for ( int i = 1; i <= HandleCount; i++ )
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }

            brush.Dispose();
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }

        /// <summary>
        /// 判断点是否在对象内部
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }

        /// <summary>
        /// 获取拖柄的光标
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// 移动对象
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// 移动拖柄到指定点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Normalize object.
        /// 在对象改变大小的之后调用
        /// </summary>
        public virtual void Normalize()
        {
        }

        #endregion
    }
}
