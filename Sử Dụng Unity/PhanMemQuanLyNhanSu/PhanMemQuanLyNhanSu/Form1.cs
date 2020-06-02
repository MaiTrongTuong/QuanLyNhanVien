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

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frmNhanVien = new FormNhanVien();
            frmNhanVien.Show();
        }

        private void menuPhongBan_Click(object sender, EventArgs e)
        {
            FormPhongBan frmPhongBan = new FormPhongBan();
            frmPhongBan.Show();
        }

        private void menuDuAn_Click(object sender, EventArgs e)
        {
            FormDuAn frmDuAn = new FormDuAn();
            frmDuAn.Show();
        }

        private void menuPhanCong_Click(object sender, EventArgs e)
        {
            FormPhanCong frmPhanCong = new FormPhanCong();
            frmPhanCong.Show();
        }

        private void menuLuong_Click(object sender, EventArgs e)
        {
            FormLuong frmLuong = new FormLuong();
            frmLuong.Show();
        }

        private void menuChamCong_Click(object sender, EventArgs e)
        {
            FormChamCong frmChamCong = new FormChamCong();
            frmChamCong.Show();
        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap frmDangNhap = new FormDangNhap();
            frmDangNhap.Show();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            //Khai báo biến trả lời
            DialogResult traloi;
            //Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //Kiểm tra có nhấp chọn nút ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frmNhanVien = new FormNhanVien();
            frmNhanVien.Show();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            FormPhongBan frmPhongBan = new FormPhongBan();
            frmPhongBan.Show();
        }

        private void btnDuAn_Click(object sender, EventArgs e)
        {
            FormDuAn frmDuAn = new FormDuAn();
            frmDuAn.Show();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            FormPhanCong frmPhanCong = new FormPhanCong();
            frmPhanCong.Show();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            FormLuong frmLuong = new FormLuong();
            frmLuong.Show();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            FormChamCong frmChamCong = new FormChamCong();
            frmChamCong.Show();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.Show();
        }
    }
}
