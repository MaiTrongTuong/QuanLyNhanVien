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
    public partial class FormPhanCong : Form
    {
        clsResize _form_resize;
        public FormPhanCong()
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

        private void FormPhanCong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanSuDataSetPhanCong.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.quanLyNhanSuDataSetPhanCong.NhanVien);
            // TODO: This line of code loads data into the 'quanLyNhanSuDataSetPhanCong.DuAn' table. You can move, or remove it, as needed.
            this.duAnTableAdapter.Fill(this.quanLyNhanSuDataSetPhanCong.DuAn);
            LoadData();
        }
        bool Them;
        string err;
        BLPhanCong dbPC = new BLPhanCong();
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView
                dgvPhanCong.DataSource = dbPC.LayPhanCong();
                // Thay đổi độ rộng cột
                dgvPhanCong.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                cbbMaDA.ResetText();
                cbbMaNV.ResetText();
                dtpStart.ResetText();
                dtpEnd.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                gBInfo.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnThoat.Enabled = true;
                //
                dgvPhanCong_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Phan Cong. Lỗi rồi!!!");
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int rPc = dgvPhanCong.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                cbbMaDA.Text = dgvPhanCong.Rows[rPc].Cells[0].Value.ToString();
                cbbMaNV.Text = dgvPhanCong.Rows[rPc].Cells[1].Value.ToString();
                dtpStart.Text = dgvPhanCong.Rows[rPc].Cells[2].Value.ToString();
                dtpEnd.Text = dgvPhanCong.Rows[rPc].Cells[3].Value.ToString();

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
            cbbMaDA.ResetText();
            cbbMaNV.ResetText();
            dtpStart.ResetText();
            dtpEnd.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;

            // Đưa con trỏ đến TextField txtMaPhongBan
            cbbMaDA.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gBInfo.Enabled = true;
            // Kich hoạt biến Thêm
            Them = false;
            //txtMaKhachHang.Enabled = true;
            // Xóa trống các đối tượng trong Panel
            cbbMaDA.ResetText();
            cbbMaNV.ResetText();
            dtpStart.ResetText();
            dtpEnd.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;

            // Đưa con trỏ đến TextField txtMaPhongBan
            cbbMaDA.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLPhanCong blPc = new BLPhanCong();
                    blPc.ThemPhanCong(this.cbbMaDA.Text,
                     this.cbbMaNV.Text, this.dtpStart.Value,
                     this.dtpEnd.Value, ref err);
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
                    BLPhanCong blPb = new BLPhanCong();
                    blPb.CapNhatPhanCong(this.cbbMaDA.Text,
                     this.cbbMaNV.Text, this.dtpStart.Value,
                     this.dtpEnd.Value, ref err);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh
            //Lấy thứ tự record hiện hành
            int r = dgvPhanCong.CurrentCell.RowIndex;
            //Lấy MaDA của record hiện hành
            string strMaDA =
                dgvPhanCong.Rows[r].Cells[0].Value.ToString();
            string strMaNV =
                dgvPhanCong.Rows[r].Cells[1].Value.ToString();
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
                    dbPC.XoaPhanCong(ref err, strMaDA, strMaNV);
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
            cbbMaDA.ResetText();
            cbbMaNV.ResetText();
            dtpStart.ResetText();
            dtpEnd.ResetText();
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
