using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite
{
    public partial class Form1 : Form
    {
        int typeShape = -1;
        bool isDraw = false;

        Bitmap bitmap;
        Graphics graphics;
        Graphics graphics2;
        SolidBrush solidBrush;
        Pen pen;

        Composite root;
        public Form1()
        {
            InitializeComponent();

            graphics2 = ptbBoard.CreateGraphics();
            

            bitmap = new Bitmap(ptbBoard.Width, ptbBoard.Height);
            graphics = Graphics.FromImage(bitmap);

            solidBrush = new SolidBrush(Color.Blue);
            pen = new Pen(Color.Green);
            pen.DashStyle = DashStyle.Solid;
            pen.Width = 2;
            root = new Composite("Composite", new Point(0, 0), 656, 436);
           
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


        }

        private void btline_Click(object sender, EventArgs e)
        {
            isDraw = true;

            btline.BackColor = Color.Green;

            typeShape = 1;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            isDraw = true;

            btnCircle.BackColor = Color.Green;

            typeShape = 2;

        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            isDraw = true;

            btnSquare.BackColor = Color.Green;

            typeShape = 3;
            
        }

       
        public void DrawShape(Shape shape)
        {
            shape.Draw(graphics, pen);
            if(shape.Name=="Composite")
            {
                DrawComposite((Composite)shape);
            }
        }
        public void DrawComposite(Composite composite)
        {
            composite.Draw(graphics, pen);
            foreach( Shape shape in composite.listChild)
            {
                DrawShape(shape);
            }
        }
        private void ptbBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDraw == true)
            {
                Shape shape;
                if (typeShape == 1)
                {
                    shape = new Lines("Line", e.Location, 40, 40);
                    root.listChild.Add(shape);

                    isDraw = false;
                }
                else if (typeShape==2)
                {
                    shape = new Ellipse("Ellipse", e.Location, 40, 40);
                    root.listChild.Add(shape);

                    isDraw = false;
                }
            }

            DrawShape(root);
            graphics2.DrawImage(bitmap, 0, 0);
        }

        private void btnComposite_Click(object sender, EventArgs e)
        {

        }
    }
}
