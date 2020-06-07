using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composite
{
    public abstract class Shape
    {
        public string Name;

        public Point Point;

        public int Witdh;

        public int Height;

        

        protected Shape(string name, Point point, int witdh, int height)
        {
            Name = name;
            Point = point;
            Witdh = witdh;
            Height = height;
        }

        public abstract bool Area();
        public abstract void Draw(Graphics graphics, Pen pen);
        public abstract void FillShape();


    }
}