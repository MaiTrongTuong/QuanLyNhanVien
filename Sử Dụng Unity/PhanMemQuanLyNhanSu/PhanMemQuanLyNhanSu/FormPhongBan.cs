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
    public partial class FormPhongBan : Form
    {
        clsResize _form_resize;
        public FormPhongBan()
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
        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        bool Them;
        string err;
        BLPhongBan dbPB = new BLPhongBan();
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView
                dgvPhongBan.DataSource = dbPB.LayPhongBan();
                // Thay đổi độ rộng cột
                dgvPhongBan.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                txtMaPhongBan.ResetText();
                txtTenPhongBan.ResetText();
                txtTruongPhong.ResetText();
                dtbNgayNhanChuc.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                gBInfo.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnThoat.Enabled = true;
                //
                dgvPhongBan_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Phong Ban. Lỗi rồi!!!");
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = true;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            txtMaPhongBan.ResetText();
            txtTenPhongBan.ResetText();
            txtTruongPhong.ResetText();
            dtbNgayNhanChuc.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
            
            // Đưa con trỏ đến TextField txtMaPhongBan
            txtMaPhongBan.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = false;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            txtMaPhongBan.ResetText();
            txtTenPhongBan.ResetText();
            txtTruongPhong.ResetText();
            dtbNgayNhanChuc.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;

            // Đưa con trỏ đến TextField txtMaPhongBan
            txtMaPhongBan.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {

                    BLPhongBan blPb = new BLPhongBan();
                    blPb.ThemPhongBan(this.txtMaPhongBan.Text,
                     this.txtTenPhongBan.Text, this.txtTruongPhong.Text,
                     this.dtbNgayNhanChuc.Value,ref err);
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
                    BLPhongBan blPb = new BLPhongBan();
                    blPb.CapNhatPhongBan(this.txtMaPhongBan.Text,
                     this.txtTenPhongBan.Text, this.txtTruongPhong.Text,
                     this.dtbNgayNhanChuc.Value, ref err);
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
            txtMaPhongBan.ResetText();
            txtTenPhongBan.ResetText();
            txtTruongPhong.ResetText();
            dtbNgayNhanChuc.ResetText();
            // Cho thao tác trên các nút Thêm/Sửa/Xóa/Thoát
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu/Hủy/Panel
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            gBInfo.Enabled = false;
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int rPb = dgvPhongBan.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                txtMaPhongBan.Text = dgvPhongBan.Rows[rPb].Cells[0].Value.ToString();
                txtTenPhongBan.Text = dgvPhongBan.Rows[rPb].Cells[1].Value.ToString();
                txtTruongPhong.Text = dgvPhongBan.Rows[rPb].Cells[2].Value.ToString();
                dtbNgayNhanChuc.Text = dgvPhongBan.Rows[rPb].Cells[3].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Bạn đã nhấp chuột ra khỏi vùng chữa dữ liệu!");
            }
        }
    }
}
