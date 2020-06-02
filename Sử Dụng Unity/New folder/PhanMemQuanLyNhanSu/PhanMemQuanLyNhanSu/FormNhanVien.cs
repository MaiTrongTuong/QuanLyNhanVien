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
using System.IO;
using PhanMemQuanLyNhanSu.BS_player;
namespace PhanMemQuanLyNhanSu
{
    public partial class FormNhanVien : Form
    {
        clsResize _form_resize;
        DataTable dtTK = new DataTable();
        int dem=0;
        public FormNhanVien()
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

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanSuDataSetPhanCong.Luong' table. You can move, or remove it, as needed.
            this.luongTableAdapter.Fill(this.quanLyNhanSuDataSetPhanCong.Luong);
            // TODO: This line of code loads data into the 'quanLyNhanSuDataSetPhanCong.PhongBan' table. You can move, or remove it, as needed.
            this.phongBanTableAdapter.Fill(this.quanLyNhanSuDataSetPhanCong.PhongBan);
            LoadData();
        }

        bool Them;
        string err;
        string GioiTinh;
        BLNhanVien dbNV = new BLNhanVien();
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = dbNV.LayNhanVien();
                // Thay đổi độ rộng cột
                dgvNhanVien.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                txtMaNV.ResetText();
                txtTenNV.ResetText();
                dtbNgaySinh.ResetText();
                rBNam.ResetText();
                rbNu.ResetText();
                txtDiaChi.ResetText();
                cbBPhong.ResetText();
                txtCMND.ResetText();
                txtCongViec.ResetText();
                cbBLuong.ResetText();
                txtGhiChu.ResetText();
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
                dgvNhanVien_CellClick(null, null);
            }

            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien. Lỗi rồi!!!");
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
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            dtbNgaySinh.ResetText();
            rBNam.ResetText();
            rbNu.ResetText();
            txtDiaChi.ResetText();
            cbBPhong.ResetText();
            txtCMND.ResetText();
            txtCongViec.ResetText();
            cbBLuong.ResetText();
            txtGhiChu.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            txtMaNV.Focus();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int r = dgvNhanVien.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
                dtbNgaySinh.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
                //if (rbNu.Checked) { GioiTinh = "nu"; }  //giới tính

                GioiTinh = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
                if (GioiTinh.Trim() == "nu")
                {
                    rbNu.Checked = true;
                }
                else rBNam.Checked = true;
                txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
                cbBPhong.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
                txtCMND.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
                txtCongViec.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
                cbBLuong.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
                txtGhiChu.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Bạn đã nhấp chuột ra khỏi vùng chữa dữ liệu!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    if (rbNu.Checked) { GioiTinh = "nữ"; }
                    else GioiTinh = "nam";
                    BLNhanVien blNv = new BLNhanVien();
                    blNv.ThemNhanVien(this.txtMaNV.Text,
                     this.txtTenNV.Text, this.dtbNgaySinh.Value,
                     GioiTinh, this.txtDiaChi.Text,
                     this.cbBPhong.Text, this.txtCMND.Text,
                     this.txtCongViec.Text, this.cbBLuong.Text,
                     this.txtGhiChu.Text,
                     ref err);
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
                    if (rbNu.Checked) { GioiTinh = "nữ"; }
                    else GioiTinh = "nam";

                    BLNhanVien blNv = new BLNhanVien();
                    blNv.CapNhatNhanVien(this.txtMaNV.Text,
                     this.txtTenNV.Text, this.dtbNgaySinh.Value,
                     GioiTinh, this.txtDiaChi.Text,
                     this.cbBPhong.Text, this.txtCMND.Text,
                     this.txtCongViec.Text, this.cbBLuong.Text,
                     this.txtGhiChu.Text,
                     ref err);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = false;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            dtbNgaySinh.ResetText();
            rBNam.ResetText();
            rbNu.ResetText();
            txtDiaChi.ResetText();
            cbBPhong.ResetText();
            txtCMND.ResetText();
            txtCongViec.ResetText();
            cbBLuong.ResetText();
            txtGhiChu.ResetText();


            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            txtMaNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh
            //Lấy thứ tự record hiện hành
            int r = dgvNhanVien.CurrentCell.RowIndex;
            //Lấy MaKH của record hiện hành
            string strNhanVien =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();
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
                    dbNV.XoaNhanVien(ref err, strNhanVien);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            dtbNgaySinh.ResetText();
            rBNam.ResetText();
            rbNu.ResetText();
            txtDiaChi.ResetText();
            cbBPhong.ResetText();
            txtCMND.ResetText();
            txtCongViec.ResetText();
            cbBLuong.ResetText();
            txtGhiChu.ResetText();
            // Cho thao tác trên các nút Thêm/Sửa/Xóa/Thoát
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu/Hủy/Panel
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            gBInfo.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {
                dtTK.Columns.Add("MaNV");
                dtTK.Columns.Add("HoTenNV");
                dtTK.Columns.Add("NgaySinh");
                dtTK.Columns.Add("GioiTinh");
                dtTK.Columns.Add("DiaChi");
                dtTK.Columns.Add("Phong");
                dtTK.Columns.Add("CMND");
                dtTK.Columns.Add("CongViec");
                dtTK.Columns.Add("GhiChu");
                dtTK.Columns.Add("Luong");

            }
            for (int i = 0; i < dgvNhanVien.Rows.Count-1; i++)
            {
                if (dgvNhanVien.Rows[i].Cells[0].Value.ToString().Contains(txtSearch.Text) != false)
                {
                    DataRow rows = dtTK.NewRow();
                    rows["MaNV"] = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                    rows["HoTenNV"] = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                    rows["NgaySinh"] = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
                    rows["GioiTinh"] = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                    rows["DiaChi"] = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
                    rows["Phong"] = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                    rows["CMND"] = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
                    rows["CongViec"] = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
                    rows["GhiChu"] = dgvNhanVien.Rows[i].Cells[8].Value.ToString();
                    rows["Luong"] = dgvNhanVien.Rows[i].Cells[9].Value.ToString();
                    dtTK.Rows.Add(rows);               
                }
            }
            dem++;
            dgvNhanVien.DataSource = dtTK;

        }
    }
}
