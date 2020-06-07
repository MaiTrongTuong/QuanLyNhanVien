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

        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, base.Point.X, base.Point.Y, base.Witdh, base.Height );
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}