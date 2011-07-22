using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ¾ØÐÎ¹¤¾ß
    /// </summary>
    class ToolRectangle : ToolObject
    {
        public ToolRectangle()
        {
            Cursor = Cursors.Default;
        }

        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            ChangeObject(regionForm, new RegionRectangle(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
            regionForm.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                regionForm.RegionObject.MoveHandleTo(point, 5);
                regionForm.Refresh();
            }
        }
    }
}
