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
    public partial class Form1 : Form
    {
        //Phan Graphic
        Color myColor;
        Pen myPen;
        Bitmap bm;
        Graphics g,gp1;
        SolidBrush myBrush;
        //-------
        int type; //loại nét vẽ
        int draw; //loại vật thể (1 là line, 2 là rect, 3 là sqr, 4 là cir, 5 là polygon, 6 là curve,7 là Elip)
        int mySize; //kích thước nét vẽ
        //
        clsDrawObj myObj;
        List<clsDrawObj> lstObj = new List<clsDrawObj>(); //danh sach vat the
       
       
        bool isPress = false;
        bool select = false;
        bool del = false;
        bool move = false;
        Color temp; // lưu màu gốc của hình được chọn
        public Form1()
        {
            InitializeComponent();
            g = pictureBox2.CreateGraphics();
            bm = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gp1 = Graphics.FromImage(bm);
            myColor = Color.Black;
            myPen = new Pen(myColor);
            myBrush = new SolidBrush(myColor);
            gp1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        #region selectShape
        private void btline_Click(object sender, EventArgs e)
        {
            draw = 1; 
            myObj = new clsLine();
            isPress = true;
        }

        private void btrect_Click(object sender, EventArgs e)
        {
            draw = 2;
            myObj = new clsRect(); 
            isPress = true;
        }

        private void btsqr_Click(object sender, EventArgs e)
        {
            draw = 3;
            myObj = new clsSqr();
            isPress = true;
        }

        private void btcir_Click(object sender, EventArgs e)
        {
            draw = 4;
            myObj = new clsCir();
            isPress = true;
        }

        private void btel_Click(object sender, EventArgs e)
        {
            draw = 7;
            isPress = true; 
            myObj = new clsElips();
        }

        private void btselec_Click(object sender, EventArgs e)
        {

            if (select == true)
            {
                select = false;
                btselec.BackColor = Color.Gray;
                move = false;
                btmove.BackColor = Color.Gray;
                btZoom.BackColor = Color.Gray;
            }
            else {
                select = true; 
                btselec.BackColor = Color.Red; del = false; btdel.BackColor = Color.Gray; 
            }


        }
        #endregion

        private void btdel_Click(object sender, EventArgs e)
        {
            //xoa vat the dang duoc chon
            for (int i = 0; i < lstObj.Count; i++)
            {
                if (lstObj[i].isSelect == true)
                {
                    lstObj.Remove(lstObj[i]);
                }
            }
            gp1.Clear(Color.White);
            for (int i = 0; i < lstObj.Count; i++)
            {
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }

            g.DrawImage(bm, 0, 0);

            //doi mau 
            if (del == true)
            {
                del = false;
                btdel.BackColor = Color.Gray;
            }
            else {

                del = true; btdel.BackColor = Color.Red; select = false; btselec.BackColor = Color.Gray;
            }
        }
        private void btmove_Click(object sender, EventArgs e)
        {
            if (move==true)
            {
                btmove.BackColor = Color.Gray;
                move = false;
            }
            else if (select == true && move ==false)
            {
                btZoom.BackColor = Color.Gray;
                btmove.BackColor = Color.Red;
                move = true;
            }
        }
        private void btZoom_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lstObj.Count; i++)
            {
                if (lstObj[i].isSelect == true)
                {
                    lstObj[i].p2.X += 100;
                    lstObj[i].p2.Y += 100;
                }
            }
            gp1.Clear(Color.White);
            for (int i = 0; i < lstObj.Count; i++)
            {
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }

            g.DrawImage(bm, 0, 0);
        }
        private void btzom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstObj.Count; i++)
            {
                if (lstObj[i].isSelect == true)
                {
                    lstObj[i].p2.X -= 100;
                    lstObj[i].p2.Y -= 100;
                }
            }
            gp1.Clear(Color.White);
            for (int i = 0; i < lstObj.Count; i++)
            {
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }

            g.DrawImage(bm, 0, 0);
        }
        private void btFill_Click(object sender, EventArgs e)
        {

            
            for (int i = 0; i < lstObj.Count; i++)
            {
                // nếu có 1 vật thể đang được chọn và trạng thái tô màu = false thì tô màu cho nó và gán biến fill thành true, (đã tô màu chưa)
                if (lstObj[i].isSelect == true)
                {
                    if (lstObj[i].fill == false)
                    {
                        lstObj[i].fill = true;
                        if (colorDialog1.ShowDialog() == DialogResult.OK)
                        {
                            myColor = colorDialog1.Color;
                            myObj.myBrush.Color = colorDialog1.Color;
                            pictureBox1.BackColor = colorDialog1.Color;
                        }
                    }
                    else lstObj[i].fill = false;
                }
            }
            gp1.Clear(Color.White);
            for (int i = 0; i < lstObj.Count; i++)
            {
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }

            g.DrawImage(bm, 0, 0);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            //Nếu button move đang bật và có vật thể đang được chọn
            if (move == true)
            {
                for (int i = 0; i < lstObj.Count; i++)
                {
                    if (lstObj[i].isSelect == true)
                    {
                        int width = Math.Abs(lstObj[i].p1.X - lstObj[i].p2.X);
                        int height = Math.Abs(lstObj[i].p1.Y - lstObj[i].p2.Y);
                        lstObj[i].p1 = e.Location;
                        lstObj[i].p2.X = lstObj[i].p1.X + width;
                        lstObj[i].p2.Y = lstObj[i].p1.Y + height;
                    }
                }
            }
            //Xác định vật thể mới
            if (isPress)
            {
                    myObj.p1 = e.Location;
                    myObj.myColor = myColor;
                    myObj.mySize =  Convert.ToInt32(numericUpDown1.Value);
                    myObj.type = this.type;
                    myObj.myPen = myPen;
                    myObj.myBrush = myBrush;
                    this.lstObj.Add(myObj);
            }
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            //Di chuyển nếu có hình đang chọn và nút Move đang kích hoạt
            if (move == true)
            {
                for (int i = 0; i < lstObj.Count; i++)
                {
                    if (lstObj[i].isSelect == true)
                    {
                        int width = Math.Abs(lstObj[i].p1.X - lstObj[i].p2.X);
                        int height = Math.Abs(lstObj[i].p1.Y - lstObj[i].p2.Y);
                        lstObj[i].p1 = e.Location;
                        lstObj[i].p2.X = lstObj[i].p1.X + width;
                        lstObj[i].p2.Y = lstObj[i].p1.Y + height;
                    }
                }
            }
            if (isPress == true)
            {
                    myObj.p2 = e.Location;
            }
            gp1.Clear(Color.White);
            // Vẽ các vật thể
            for (int i = 0; i < lstObj.Count; i++)
            {
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }
            g.DrawImage(bm, 0, 0);
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            //neu vat the di chuyen 
            if (move == true)
            {
                for (int i = 0; i < lstObj.Count; i++)
                {
                    if (lstObj[i].isSelect == true)
                    {
                        int width = Math.Abs(lstObj[i].p1.X - lstObj[i].p2.X);
                        int height = Math.Abs(lstObj[i].p1.Y - lstObj[i].p2.Y);
                        lstObj[i].p1 = e.Location;
                        lstObj[i].p2.X = lstObj[i].p1.X + width;
                        lstObj[i].p2.Y = lstObj[i].p1.Y + height;
                        move = false;
                    }
                }
            }
            //nếu có một button vẽ nào đang được nhấn
            if (isPress)
            {
                myObj.p2 = e.Location;
                for (int i = 0; i < lstObj.Count; i++)
                {
                    lstObj[i].tao();
                    lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
                }
                g.DrawImage(bm, 0, 0);
                isPress = false;
            }
        }
        //Ô màu
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myColor = colorDialog1.Color;
                myObj.myPen.Color = colorDialog1.Color;
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }
        //chọn Kiểu vẽ
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = comboBox1.SelectedItem.ToString();
            if (select == "Solid") type = 0;
            else if (select == "Dot") type = 1;
            else if (select == "Dash") type = 2;
            else if (select == "DashDot") type = 3;
            else if (select == "DashDotDot") type = 4;
        }
        //Tìm 1 điểm có thuộc trong một vât thể hay không
        public bool tim (clsDrawObj obj, Point p)
        {
            if (obj.loai == 1)
            {
                // diem click thuoc duong thang
                int a = Convert.ToInt32( Math.Sqrt((obj.p1.X-p.X)* (obj.p1.X - p.X)+(obj.p1.Y-p.Y)* (obj.p1.Y - p.Y)));
                int b = Convert.ToInt32(Math.Sqrt((obj.p2.X - p.X) * (obj.p2.X - p.X) + (obj.p2.Y - p.Y) * (obj.p2.Y - p.Y)));
                int c = Convert.ToInt32(Math.Sqrt((obj.p1.X - obj.p2.X) * (obj.p1.X - obj.p2.X) + (obj.p1.Y - obj.p2.Y) * (obj.p1.Y - obj.p2.Y)));

                if (a+b==c) return true;
            }
            if (obj.loai==2)
                //diem click thuoc hinh chu nhat
              if (obj.p1.X < p.X && obj.p2.X > p.X && obj.p1.Y < p.Y && obj.p2.Y > p.Y || obj.p1.X > p.X && obj.p2.X < p.X && obj.p1.Y > p.Y && obj.p2.Y < p.Y) return true;
            if (obj.loai==3)
            {
                if (obj.p1.X < p.X && obj.p2.X > p.X && obj.p1.Y < p.Y && obj.p2.Y > p.Y || obj.p1.X > p.X && obj.p2.X < p.X && obj.p1.Y > p.Y && obj.p2.Y < p.Y) return true;
            }
            if (obj.loai == 4)
            {
                //khoang cach tu diem den ban kinh
                //Để tính tâm thì bạn lấy x1 = (chiều dài / 2) +x, y1 = (chiều rộng / 2) +y. => O(x1, y1).
                double r = Math.Abs((obj.p1.X - obj.p2.X) / 2);
                //toa do tam
                double x1 = r + obj.p1.X;
                double x2 =  r + obj.p1.Y;
                //do dai tu diem a den ban kinh
                double a = Math.Abs(Math.Sqrt((x1-p.X) * (x1-p.X) + (x2-p.Y) * (x2-p.Y)));

                if (a < r) return true;
            }
            if (obj.loai ==7)
            {
                //ban kinh lon nho
                double r1 = Math.Abs(obj.p1.X - obj.p2.X);
                double r2 = Math.Abs(obj.p1.Y - obj.p2.Y);
                if (p.X >= obj.p1.X && p.Y >= obj.p1.Y && p.X <= obj.p1.X + r1 && p.Y <= obj.p1.Y + r2) return true;

            }
            return false;
        }
        //select and del
        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (del == true )
            {
                for (int i = 0; i < lstObj.Count; i++)
                {
                    //nếu điểm click thuộc vật thể
                    if (tim(lstObj[i], e.Location) == true) lstObj.RemoveAt(i);
                }
            }
            if (select==true )
            {
                for (int i = 0; i < lstObj.Count; i++)
                {
                    //nếu điểm click thuộc vật thể
                    if (tim(lstObj[i], e.Location) == true)
                    {
                        if (lstObj[i].isSelect == true)
                        {
                            lstObj[i].myColor = temp;
                            lstObj[i].isSelect = false;
                        }
                        else
                        {
                            lstObj[i].isSelect = true;
                            temp = lstObj[i].myColor;

                        }
                    }
                }
            }
            gp1.Clear(Color.White);

            //Vẽ các hình vào picturebox
            for (int i = 0; i < lstObj.Count; i++)
            {
                if (lstObj[i].isSelect == true) lstObj[i].myColor = Color.Red;
                lstObj[i].tao();
                lstObj[i].Draw(this.gp1, this.lstObj[i].myPen, this.lstObj[i].myColor);
            }
            g.DrawImage(bm, 0, 0);          
        }
        //reset lại Form
        private void btClear_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }
}
