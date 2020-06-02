using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PhanMemQuanLyNhanSu.BS;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        string err;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            bool check =dn.KtraTaiKhoan(this.txtUser.Text, this.txtPass.Text, ref err);
            if(check==true)
            {
                FormMain.isDangNhap = true;
                MessageBox.Show("Đăng nhập thành công!");
                Form main = new FormMain();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, vui lòng thử lại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //Khai báo biến trả lời
            DialogResult traloi;
            //Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //Kiểm tra có nhấp chọn nút ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
