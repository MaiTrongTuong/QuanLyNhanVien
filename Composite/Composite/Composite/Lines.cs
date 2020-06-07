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
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, base.Point.X, base.Point.Y, base.Point.X + 40, base.Point.Y + 40);
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}