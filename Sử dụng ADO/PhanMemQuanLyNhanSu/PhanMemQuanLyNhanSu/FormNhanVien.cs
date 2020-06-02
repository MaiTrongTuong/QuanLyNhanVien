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
using System.IO;
using System.Drawing.Imaging;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormNhanVien : Form  
    {
        clsResize _form_resize;
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
        DataTable dtTK = new DataTable();
        int dem = 0;
        DataTable dtNhanVien = null;
        string error;
        bool isThem = true;
        NhanVien dbNhanVien = new NhanVien();

        void Loaddata()
        {
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();

                DataSet ds = dbNhanVien.LayNhanVien();
                dtNhanVien = ds.Tables[0];

                dgvNhanVien.DataSource = dtNhanVien;
                dgvNhanVien.AutoResizeColumns();

                DataTable dtPhong = new DataTable();
                PhongBan dbPhongBan = new PhongBan();
                DataSet datap = dbPhongBan.LayPhongBan();
                dtPhong = datap.Tables[0];

                this.cbbPhongBan.DataSource = dtPhong;
                this.cbbPhongBan.DisplayMember = "TenPB";
                this.cbbPhongBan.ValueMember = "MaPB";

                (dgvNhanVien.Columns["Phong"] as DataGridViewComboBoxColumn).DataSource = dtPhong;
                (dgvNhanVien.Columns["Phong"] as DataGridViewComboBoxColumn).DisplayMember = "TenPB";
                (dgvNhanVien.Columns["Phong"] as DataGridViewComboBoxColumn).ValueMember = "MaPB";
                (dgvNhanVien.Columns["Phong"] as DataGridViewComboBoxColumn).ReadOnly = true;

                DataTable dtLuong = new DataTable();
                Luong dbLuong = new Luong();
                DataSet datal = dbLuong.LayLuong();
                dtLuong = datal.Tables[0];

                this.cbbLuong.DataSource = dtLuong;
                this.cbbLuong.DisplayMember = "MaLuong";
                this.cbbLuong.ValueMember = "MaLuong";

                (dgvNhanVien.Columns["Luong"] as DataGridViewComboBoxColumn).DataSource = dtLuong;
                (dgvNhanVien.Columns["Luong"] as DataGridViewComboBoxColumn).DisplayMember = "MaLuong";
                (dgvNhanVien.Columns["Luong"] as DataGridViewComboBoxColumn).ValueMember = "MaLuong";
                (dgvNhanVien.Columns["Luong"] as DataGridViewComboBoxColumn).ReadOnly = true;

                dgvNhanVien_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table NhanVien!");
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            Loaddata();
            gBInfo.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gioitinh;
            int r = dgvNhanVien.CurrentCell.RowIndex;
            if (!dgvNhanVien.Rows[r].Cells[0].Value.ToString().Equals(""))
            {
                txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
                dtbNgaySinh.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
                gioitinh = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
                if (gioitinh == "Nam")
                {
                    rBNam.Checked = true;
                }
                else rbNu.Checked = true;
                txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
                cbbPhongBan.SelectedValue = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
                txtCMND.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
                txtCongViec.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
                cbbLuong.SelectedValue = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
                txtGhiChu.Text = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            gBInfo.Enabled = true;
            btnSua.Enabled = false;
            txtCMND.Clear();
            txtCongViec.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            txtMaNV.Clear();
            txtSearch.Clear();
            txtTenNV.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem==true)
            {
                try
                {
                    NhanVien nv = new NhanVien();
                    bool check = nv.KiemTraTonTai(txtMaNV.Text, ref error);
                    if(check==true)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại, không thể thêm!");
                        return;
                    }
                    string gt;
                    if (rBNam.Checked == true)
                    {
                        gt = "Nam";
                    }
                    else gt = "Nữ";
                    nv.ThemNhanVien(this.txtMaNV.Text, this.txtTenNV.Text, this.dtbNgaySinh.Text, gt, this.txtDiaChi.Text, this.cbbPhongBan.SelectedValue.ToString(), 
                        this.txtCMND.Text, this.txtCongViec.Text, this.cbbLuong.SelectedValue.ToString(), this.txtGhiChu.Text, ref error);

                    ChamCong cc = new ChamCong();
                    string LuongCB = "";
                    string HeSoLuong = "";
                    cc.GetLuongString(this.cbbLuong.SelectedValue.ToString(), ref LuongCB, ref HeSoLuong);
                    int TongLuong = Int32.Parse(LuongCB) * Int32.Parse(HeSoLuong);
                    cc.ThemChamCong(this.txtMaNV.Text, this.txtTenNV.Text, this.cbbLuong.SelectedValue.ToString(), TongLuong.ToString(), "", "", "", "", "", "", ref error);

                    Loaddata();

                    MessageBox.Show("Đã thêm");

                    txtCMND.Clear();
                    txtCongViec.Clear();
                    txtDiaChi.Clear();
                    txtGhiChu.Clear();
                    txtMaNV.Clear();
                    txtSearch.Clear();
                    txtTenNV.Clear();
                } 
                catch(SqlException)
                {
                    MessageBox.Show("Lỗi thêm");
                }
            }
            else
            {
                try
                {
                    string gt;
                    if (rBNam.Checked == true)
                    {
                        gt = "Nam";
                    }
                    else gt = "Nữ";
                    NhanVien nv = new NhanVien();
                    nv.CapNhatNhanVien(this.txtMaNV.Text, this.txtTenNV.Text, this.dtbNgaySinh.Text, gt, this.txtDiaChi.Text, this.cbbPhongBan.SelectedValue.ToString(), this.txtCMND.Text, this.txtCongViec.Text, this.cbbLuong.SelectedValue.ToString(), this.txtGhiChu.Text, ref error);

                    ChamCong cc = new ChamCong();
                    string LuongCB = "";
                    string HeSoLuong = "";
                    cc.GetLuongString(this.cbbLuong.SelectedValue.ToString(), ref LuongCB, ref HeSoLuong);
                    int TongLuong = Int32.Parse(LuongCB) * Int32.Parse(HeSoLuong);
                    cc.CapNhatChamCong(this.txtMaNV.Text,this.cbbLuong.SelectedValue.ToString(), TongLuong.ToString(),ref error);

                    Loaddata();
                    Loaddata();
                    MessageBox.Show("Đã sửa xong!");
                } 
                catch(SqlException)
                {
                    MessageBox.Show("Lỗi khi sửa");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnDoiHinh_Click(object sender, EventArgs e)
        {
            //openFileDialogPicture.ShowDialog();
            //string filePic = openFileDialogPicture.FileName;
            //if (string.IsNullOrEmpty(filePic))
            //    return;
            //Image myImage = Image.FromFile(filePic);
            //pictureBox.Image = myImage;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ChamCong cc = new ChamCong();
                cc.XoaChamCong(txtMaNV.Text, ref error);

                PhanCong pc = new PhanCong();
                pc.XoaPhanCong(txtMaNV.Text, ref error);

                NhanVien nv = new NhanVien();
                nv.XoaNhanVien(txtMaNV.Text, ref error);

                Loaddata();
                MessageBox.Show("Đã xóa xong!");
            }
            catch(SqlException)
            {
                MessageBox.Show("Xảy ra lỗi trong khi xóa!");
            }
        }

        private void dgvNhanVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form main = new FormMain();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Loaddata();
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
            for (int i = 0; i < dgvNhanVien.Rows.Count - 1; i++)
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
                if (dgvNhanVien.Rows[i].Cells[1].Value.ToString().Contains(txtSearch.Text) != false)
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(isThem==true)
            {
                btnSua.Enabled = true;
            }
            else
            {
                btnThem.Enabled = true;
            }
            btnLuu.Enabled = false;
        }
    }
}
