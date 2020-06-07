using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Composite : Shape
    {
        public List<Shape> listChild = new List<Shape>();
        public Composite(string name, Point point, int witdh, int height): base(name,point,witdh,height)
        {
         
        }

        public override bool Area()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            Rectangle _rect = new Rectangle(base.Point.X,base.Point.Y,base.Witdh,base.Height);
            graphics.DrawRectangle(pen, _rect);
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}