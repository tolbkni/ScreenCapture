using System;
using System.Windows.Forms;

namespace ScreenCapture
{
    /// <summary>
    /// Â·¾¶¹¤¾ß
    /// </summary>
    class ToolPath : ToolRectangle
    {
        public ToolPath()
        {
            Cursor = Cursors.Default;
        }

        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            ChangeObject(regionForm, new DrawRectangle(e.X, e.Y, 1, 1));
        }
    }
}
