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

        public bool isSelect = false;

        public int Level;

        public Pen pen { get; set; }
        

        protected Shape(string name, Point point, int witdh, int height)
        {
            Name = name;
            Point = point;
            Witdh = witdh;
            Height = height;
        }

        public abstract bool CheckSelect(Point point);
        public abstract bool Area();
        public abstract void Draw(Graphics graphics, Pen penDraw);
        public abstract void FillShape();


    }
}