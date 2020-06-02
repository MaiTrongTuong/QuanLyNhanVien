using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using PhanMemQuanLyNhanSu.BS_player;
namespace PhanMemQuanLyNhanSu
{
    public partial class FormLuong : Form
    {
        public FormLuong()
        {
            InitializeComponent();
        }

        private void FormLuong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        bool Them;
        string err;
        BLLuong dbLuong = new BLLuong();
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView
                dgvLuong.DataSource = dbLuong.LayLuong();
                // Thay đổi độ rộng cột
                dgvLuong.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                txtMaLuong.ResetText();
                txtTenLuong.ResetText();
                txtLươngCoban.ResetText();
                txtHeSoLuong.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                gBInfo.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
                //
                dgvLuong_CellClick(null, null);
            }

            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien. Lỗi rồi!!!");
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int r = dgvLuong.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                txtMaLuong.Text = dgvLuong.Rows[r].Cells[0].Value.ToString();
                txtTenLuong.Text = dgvLuong.Rows[r].Cells[1].Value.ToString();
                txtLươngCoban.Text = dgvLuong.Rows[r].Cells[2].Value.ToString();
                txtHeSoLuong.Text = dgvLuong.Rows[r].Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Bạn đã nhấp chuột ra khỏi vùng chữa dữ liệu!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = true;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            txtMaLuong.ResetText();
            txtTenLuong.ResetText();
            txtLươngCoban.ResetText();
            txtHeSoLuong.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            txtMaLuong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = false;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            txtMaLuong.ResetText();
            txtTenLuong.ResetText();
            txtLươngCoban.ResetText();
            txtHeSoLuong.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            txtMaLuong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh
            //Lấy thứ tự record hiện hành
            int r = dgvLuong.CurrentCell.RowIndex;
            //Lấy MaKH của record hiện hành
            string strLuong =
                dgvLuong.Rows[r].Cells[0].Value.ToString();
            // Khai báo biến trả lời
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                try
                {
                    dbLuong.XoaLuong(ref err, strLuong);
                    //Cập nhật lại DataGiridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                catch
                {

                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLLuong blLuong = new BLLuong();
                    blLuong.ThemLuong(this.txtMaLuong.Text,
                     this.txtTenLuong.Text, float.Parse(txtLươngCoban.Text),
                     float.Parse(txtHeSoLuong.Text), ref err);
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");

                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Đã có lỗi!");
                }
            }

            else // sửa đổi
            {
                try
                {
                    BLLuong blLuong = new BLLuong();
                    blLuong.CapNhatLuong(this.txtMaLuong.Text,
                     this.txtTenLuong.Text, float.Parse(txtLươngCoban.Text),
                     float.Parse(txtHeSoLuong.Text), ref err);
                    //load lại dữ liệu
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được đã có lỗi!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            txtMaLuong.ResetText();
            txtTenLuong.ResetText();
            txtLươngCoban.ResetText();
            txtHeSoLuong.ResetText();
            // Cho thao tác trên các nút Thêm/Sửa/Xóa/Thoát
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu/Hủy/Panel
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            gBInfo.Enabled = false;
        }
    }
}
