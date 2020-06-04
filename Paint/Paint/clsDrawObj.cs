using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public abstract class clsDrawObj
    {
        public Point p1;
        public Point p2;

        public Color myColor; //màu sắc
        public int mySize; //kích thước
        public Pen myPen;
        public SolidBrush myBrush;
        public int loai=0;
        public System.Drawing.Drawing2D.DashStyle kieu;
        public int type; //kiểu nét vẽ

        public bool isSelect = false; //đã được chọn chưa
        public bool fill = false; //đã tô màu chưa

        public void tao()
        {
            myPen.Color = this.myColor;
            myPen.Width = this.mySize;
            
        }
        public abstract void Draw(Graphics myGp, Pen myPen, Color myColor);
    }
}
