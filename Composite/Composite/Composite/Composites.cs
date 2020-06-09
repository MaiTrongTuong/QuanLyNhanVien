using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Composites : Shape
    {
        public List<Shape> listChild = new List<Shape>();
        public Composites(string name, Point point, int witdh, int height): base(name,point,witdh,height)
        {
         
        }

        public override bool Area()
        {
            throw new NotImplementedException();
        }

        public override bool CheckSelect(Point point)
        {
            if (base.Point.X < point.X && base.Point.X + base.Witdh > point.X &&
                base.Point.Y < point.Y && base.Point.Y + base.Height > point.Y)
            {
                base.isSelect = true;
                return true;
            }
            return false;
        }

        public override void Draw(Graphics graphics, Pen penDraw)
        {
            base.pen = penDraw;
            Rectangle _rect = new Rectangle(base.Point.X,base.Point.Y,base.Witdh,base.Height);
            graphics.DrawRectangle(base.pen, _rect);
        }

        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}