using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class clsCir : clsDrawObj
    {
        public override void Draw(Graphics myGp, Pen myPen, Color myColor)
        {
            loai = 4;
            if (type == 0)
            {
                myPen.DashStyle = DashStyle.Solid;
            }
            else if (type == 1)
            {
                myPen.DashStyle = DashStyle.Dot;
            }
            else if (type == 2)
            {
                myPen.DashStyle = DashStyle.Dash;
            }
            else if (type == 3)
            {
                myPen.DashStyle = DashStyle.DashDot;
            }
            else if (type == 4)
            {
                myPen.DashStyle = DashStyle.DashDotDot;
            }
            myGp.DrawEllipse(myPen, this.p1.X, this.p1.Y, this.p2.X - this.p1.X, this.p2.X - this.p1.X);
            if (fill==true) myGp.FillEllipse(myBrush, this.p1.X, this.p1.Y, this.p2.X - this.p1.X, this.p2.X - this.p1.X);
        }
    }
}
