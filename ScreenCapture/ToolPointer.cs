using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// 指针工具
    /// </summary>
    class ToolPointer : Tool
    {
        #region Members

        private static Image _image;

        #endregion

        #region Properties

        public static Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        #endregion

        private enum SelectionMode
        {
            None,
            Move,       // 移动对象
            Size        // 拖动对象
        }

        private SelectionMode selectMode = SelectionMode.None;

        // 当前要拖动的对象
        private DrawRectangle resizedObject;
        private int resizedObjectHandle;

        // 保留上一个和当前点的状态（用来移动和拖动对象）
        private Point lastPoint = new Point(0, 0);
        private Point startPoint = new Point(0, 0);

        bool wasMove;

        /// <summary>
        /// 按下鼠标左键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            wasMove = false;

            selectMode = SelectionMode.None;
            Point point = new Point(e.X, e.Y);

            int handleNumber = regionForm.DrawRectangle.HitTest(point);

            if (handleNumber > 0)
            {
                selectMode = SelectionMode.Size;


                resizedObject = regionForm.DrawRectangle;
                resizedObjectHandle = handleNumber;
            }

            if (selectMode == SelectionMode.None)
            {
                DrawRectangle o = null;

                if (regionForm.DrawRectangle.HitTest(point) == 0)
                {
                    o = regionForm.DrawRectangle;
                }

                if (o != null)
                {
                    selectMode = SelectionMode.Move;

                    regionForm.Cursor = Cursors.SizeAll;
                }
            }

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            startPoint.X = e.X;
            startPoint.Y = e.Y;

            regionForm.Capture = true;

            regionForm.Refresh();
        }

        /// <summary>
        /// 移动鼠标
        /// 未按下任何键或者按下左键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            Point oldPoint = lastPoint;

            wasMove = true;

            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = null;

                int n = regionForm.DrawRectangle.HitTest(point);

                if (n > 0)
                {
                    cursor = regionForm.DrawRectangle.GetHandleCursor(n);
                }

                if (cursor == null)
                {
                    cursor = Cursors.Default;
                }

                regionForm.Cursor = cursor;

                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            // 按下左键


            // 找出上一位置和当前位置的差异
            int dx = e.X - lastPoint.X;
            int dy = e.Y - lastPoint.Y;

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;

            // 拖动
            if (selectMode == SelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    resizedObject.MoveHandleTo(point, resizedObjectHandle);
                    regionForm.Refresh();
                }
            }

            // 移动
            if (selectMode == SelectionMode.Move)
            {
                regionForm.DrawRectangle.Move(dx, dy);

                regionForm.Cursor = Cursors.SizeAll;
                regionForm.Refresh();
            }
        }

        /// <summary>
        /// 释放鼠标右键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
            if (resizedObject != null)
            {
                // after resizing
                resizedObject.Normalize();
                resizedObject = null;
            }

            regionForm.Capture = false;
            regionForm.Refresh();
        }
    
        /// <summary>
        /// 双击鼠标左键
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseDoubleClick(RegionForm regionForm, MouseEventArgs e)
        {
            // 获取矩形区域
            Rectangle rect = ((DrawRectangle)regionForm.DrawRectangle).Rectangle;
            // 新建位图保存区域快照
            Image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(_image);

            // 把区域快照保存在位图中
            g.DrawImage(regionForm.BackgroundImage, 0, 0, rect, GraphicsUnit.Pixel);

            g.Dispose();

            // 暂存到剪贴板
            /* 
             * Clipboard.SetImage(FullScrn.Image);
             */
            // 保存图片
            Image.Save(Application.StartupPath + "\\RegionScrn.png");
        }
    }
}
