﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Rectangles:Shape
    {
        public Rectangles(string name, Point point, int witdh, int height) : base(name, point, witdh, height)
        {

        }
        public override bool Area()
        {
            throw new NotImplementedException();
        }

        public override bool CheckSelect(Point point)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics, Pen penDraw)
        {
            base.pen = penDraw;
            Rectangle _rect = new Rectangle(base.Point.X, base.Point.Y, base.Witdh, base.Height);
            graphics.DrawRectangle(base.pen, _rect);
        }
        public override void FillShape()
        {
            throw new NotImplementedException();
        }
    }
}