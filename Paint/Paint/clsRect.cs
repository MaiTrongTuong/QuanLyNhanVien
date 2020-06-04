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
    class clsRect : clsDrawObj
    {
        public override void Draw(Graphics myGp, Pen myPen, Color myColor)
        {
            loai = 2;
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
            
            int x = Math.Min(this.p1.X, this.p2.X);
            int y = Math.Min(this.p1.Y, this.p2.Y);
            int width = Math.Abs(this.p1.X - this.p2.X);
            int height = Math.Abs(this.p1.Y - this.p2.Y);
            Rectangle _rect = new Rectangle(x, y, width, height);
            myGp.DrawRectangle(myPen, _rect);
            if (fill==true) myGp.FillRectangle(myBrush, _rect);

        }
    }
}
