using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    class FullScrn
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

        public static void Capture()
        {
            // 获取屏幕大小
            Size size = Screen.PrimaryScreen.Bounds.Size;

            // 新建位图保存屏幕
            _image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(_image);

            // 把屏幕快照保存在位图中
            g.CopyFromScreen(0, 0, 0, 0, size);
            g.Dispose();

            // 暂存到剪贴板
            /* 
             * Clipboard.SetImage(FullScrn.Image);
             */
            // 保存图片
            Image.Save(Application.StartupPath + "\\FullScrn.png");
        }
    }
}
