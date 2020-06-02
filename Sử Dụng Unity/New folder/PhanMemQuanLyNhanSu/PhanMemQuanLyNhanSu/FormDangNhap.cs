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
using PhanMemQuanLyNhanSu.BS_player;
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
            BLDangNhap DN = new BLDangNhap();
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                if(DN.KtraTaiKhoan(txtUser.Text, txtPass.Text, ref err) == true)
                {
                    FormMain frmMain = new FormMain();
                    frmMain.Show();
                }
                else
                    MessageBox.Show("Bạn nhập sai Tên Tài Khoản hoặc Mật Khấu. Vui lòng thử lại!!!");
            }
            else
                MessageBox.Show("Dữ liệu đăng nhập chưa được nhập. Vui lòng nhập lại!!!");
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
    }
}
