using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeSimulatorUI
{
    class MyPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            base.OnPaint(pe);
        }
    }
}
