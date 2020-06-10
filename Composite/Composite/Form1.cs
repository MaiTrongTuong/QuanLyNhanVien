using Composite.Composite;
using Microsoft.Win32.SafeHandles;
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

        public bool isSelect = false;

        Bitmap bitmap;
        Graphics graphics;
        Graphics graphics2;
        SolidBrush solidBrush;
        Pen pen = new Pen(Color.Blue);

        Composites root;

        TreeNode treeViewNode;
        TreeNode treeNode;
        List<int> listComposite;

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
            root = new Composites("Composite", new Point(0, 0), ptbBoard.Width- 2, ptbBoard.Height -2);
            root.Level = 0;

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


        }
        public bool AddShape(Composites composite, Shape shape)
        {
            composite.listChild.Add(shape);
            if (isParent(composite,shape) ==true )
            {
                if(composite.listChild.Count<=0)
                {
                    return true;
                }
                else
                {
                    foreach(var item in composite.listChild)
                    {
                        if(item.Name == "Composite" && isParent((Composites)item,shape)==true)
                        {
                            composite.listChild.Remove(shape);

                            if (AddShape((Composites)item, shape) == true)
                                return true;
                        }
                    }
                }
                return true;
            }
            else
            {
                composite.listChild.Remove(shape);
                return false;
            }
        }

        public bool isParent(Composites Parent, Shape Child)
        {
            if(Parent.CheckSelect(Child.Point)==true)
            {
                int X = Parent.Point.X + Parent.Witdh;
                int Y = Parent.Point.Y + Parent.Height;
                int x = Child.Point.X + Child.Witdh;
                int y = Child.Point.Y + Child.Height;

                if(X>x && Y>y)
                {
                    return true;
                }
            }
            return false;
        }
        public void ChooseShape(Composites composite,Point point, ref bool isSelect)
        {
            foreach(var shape in composite.listChild)
            {
                if(shape.CheckSelect(point)==true)
                {
                    shape.isSelect = true;
                    shape.pen.Color = Color.Red;

                    if (shape.Name=="Composite")
                    {
                        ChooseShape((Composites)shape, point, ref isSelect);
                        if(isSelect ==true)
                        {
                            shape.isSelect = false;
                            shape.pen.Color = Color.Green;
                            return;
                        }
                    }
                    else
                    {
                        isSelect = true;
                        return;
                    }
                }
            }
        }
        public void ShowTree(Composites composite, TreeNode tN)
        {
            int i = 0;
            
            if (composite.listChild.Count > 0)
            {
                listComposite = new List<int>();
                foreach (var shape in composite.listChild)
                {
                    treeNode = new TreeNode(shape.Name);
                    tN.Nodes.Add(treeNode);
                    if(shape.Name=="Composite")
                    {
                        listComposite.Add(i);
                    }
                    i++;
                }
                if(listComposite.Count>0)
                {
                    foreach(int k in listComposite)
                    {
                        ShowTree((Composites)composite.listChild[k], tN.Nodes[k]);
                    }
                }
            }
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


            typeShape = 3;

        }

       
        public void DrawShape(Shape shape)
        {
            shape.Draw(graphics, pen);
            if(shape.Name=="Composite")
            {
                DrawComposite((Composites)shape);
            }
        }
        public void DrawComposite(Composites composite)
        {
            composite.Draw(graphics, pen);
            foreach( var shape in composite.listChild)
            {
                DrawShape(shape);
            }
        }
        private void ptbBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDraw == true)
            {
                if (typeShape == 1)
                {
                    Lines shape = new Lines("Line", e.Location, DefineSize.Width, DefineSize.Height);
                    AddShape(root, shape);

                    isDraw = false;
                }
                else if (typeShape==2)
                {
                    Circles shape = new Circles("Circle", e.Location, DefineSize.Width, DefineSize.Width);
                    AddShape(root, shape);

                    isDraw = false;
                }
                else if (typeShape == 0)
                {
                    Composites shape = new Composites("Composite", e.Location, DefineSize.Width_Composite, DefineSize.Height_Composite);

                    AddShape(root, shape);

                    isDraw = false;


                }

                DrawShape(root);
                graphics2.DrawImage(bitmap, 0, 0);
            }
            else
            {
                ChooseShape(root, e.Location, ref isSelect);

                DrawShape(root);
                graphics2.DrawImage(bitmap, 0, 0);
              
            }

            treeViewInfo.Nodes.Clear();

            treeViewNode = new TreeNode("Root");

            ShowTree(root,treeViewNode);
            treeViewInfo.Nodes.Add(treeViewNode);
        }

        private void btnComposite_Click(object sender, EventArgs e)
        {
            isDraw = true;

            typeShape = 0;
        }
    }
}
