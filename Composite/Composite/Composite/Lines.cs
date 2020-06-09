using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Lines:Shape
    {
        public Lines(string name, Point point, int witdh, int height) : base(name, point, witdh, height)
        {

        }
        public override bool Area()
        {
            throw new NotImplementedException();
        }

        public override bool CheckSelect(Point point)
        {
            int a = Convert.ToInt32(Math.Sqrt((base.Point.X - point.X) * (base.Point.X - point.X) + (base.Point.Y - point.Y) * (base.Point.Y - point.Y)));
            int b = Convert.ToInt32(Math.Sqrt(( base.Point.X + base.Witdh  - point.X) * ( base.Point.X + base.Witdh  - point.X) + (base.Point.Y + base.Height - point.Y) * (base.Point.Y + base.Height - point.Y)));
            int c = Convert.ToInt32(Math.Sqrt(base.Witdh  *  base.Witdh  + base.Height*base.Height));

            if (a + b == c) return true;
            return false;
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            base.pen = pen;
            graphics.DrawLine(base.pen, base.Point.X, base.Point.Y, base.Point.X + 40, base.Point.Y + 40);
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}