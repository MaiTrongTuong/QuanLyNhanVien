using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormMain : Form
    {
        public static bool isDangNhap = false;
        clsResize _form_resize;
        public FormMain()
        {
            InitializeComponent();
            _form_resize = new clsResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dangnhap = new FormDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(isDangNhap==false)
            {
                đăngNhậpToolStripMenuItem.Enabled = true;
                đăngXuấtToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Enabled = false;
                traCứuToolStripMenuItem.Enabled = false;
                trợGiúpToolStripMenuItem.Enabled = false;
                btnChamCong.Enabled = false;
                btnNhanVien.Enabled = false;
                btnPhanCong.Enabled = false;
                btnDuAn.Enabled = false;
                btnLuong.Enabled = false;
                btnPhongBan.Enabled = false;
            }
            else
            {
                đăngXuấtToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Enabled = true;
                traCứuToolStripMenuItem.Enabled = true;
                trợGiúpToolStripMenuItem.Enabled = true;
                btnChamCong.Enabled = true;
                btnNhanVien.Enabled = true;
                btnPhanCong.Enabled = true;
                btnDuAn.Enabled = true;
                btnLuong.Enabled = true;
                btnPhongBan.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nv = new FormNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pb = new FormPhongBan();
            this.Hide();
            pb.ShowDialog();
            this.Close();
        }

        private void dựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form da = new FormDuAn();
            this.Hide();
            da.ShowDialog();
            this.Close();
        }

        private void phânCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pc = new FormPhanCong();
            this.Hide();
            pc.ShowDialog();
            this.Close();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form l = new FormLuong();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cc = new FormChamCong();
            this.Hide();
            cc.ShowDialog();
            this.Close();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Form nv = new FormNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Close();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            Form pb = new FormPhongBan();
            this.Hide();
            pb.ShowDialog();
            this.Close();
        }

        private void btnDuAn_Click(object sender, EventArgs e)
        {
            Form da = new FormDuAn();
            this.Hide();
            da.ShowDialog();
            this.Close();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            Form cc = new FormChamCong();
            this.Hide();
            cc.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form l = new FormLuong();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            Form cc = new FormChamCong();
            this.Hide();
            cc.ShowDialog();
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            //Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //Kiểm tra có nhấp chọn nút ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDangNhap = false;
            FormMain_Load(sender,e);
        }   
    }
}
