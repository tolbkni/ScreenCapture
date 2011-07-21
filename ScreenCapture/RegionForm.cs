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

        private void RegionForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegionForm_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void RegionForm_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void RegionForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void RegionForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        #region 初始化

        public void Initialize()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, 
                true);
        }

        #endregion
    }
}