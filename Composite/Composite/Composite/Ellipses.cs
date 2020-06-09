using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Ellipse :Shape
    {

        public Ellipse(string name, Point point, int witdh, int height) : base(name, point, witdh, height)
        {

        }
        public override bool Area()
        {
            throw new NotImplementedException();
        }

        public override bool CheckSelect(Point point)
        {
            //Để tính tâm thì bạn lấy x1 = (chiều dài / 2) +x, y1 = (chiều rộng / 2) +y. => O(x1, y1).
            double r = Witdh / 2;
            //toa do tam
            double x1 = r + base.Point.X;
            double x2 = r + base.Point.Y;
            //do dai tu diem a den ban kinh
            double a = Math.Abs(Math.Sqrt((x1 - point.X) * (x1 - point.X) + (x2 - point.Y) * (x2 - point.Y)));

            if (a < r) return true;
            return false;
        }

        public override void Draw(Graphics graphics, Pen penDraw)
        {
            base.pen = penDraw;
            graphics.DrawEllipse(base.pen, base.Point.X, base.Point.Y, base.Witdh, base.Height );
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}