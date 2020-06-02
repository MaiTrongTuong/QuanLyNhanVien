using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyNhanSu.BS;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormChamCong : Form
    {
        clsResize _form_resize;
        public FormChamCong()
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
        DataTable dtChamCong = null;
        string error;

        ChamCong dbChamCong = new ChamCong();

        void Loaddata()
        {
            try
            {
                dtChamCong = new DataTable();
                dtChamCong.Clear();

                DataSet ds = dbChamCong.LayChamCong();
                dtChamCong = ds.Tables[0];

                dgvChamCong.DataSource = dtChamCong;
                dgvChamCong.AutoResizeColumns();

                ChamCong();

                dgvChamCong_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table ChamCong!");
            }
        }

        void ChamCong()
        {
            for (int i = 0; i < dgvChamCong.Rows.Count - 1; i++)
            {
                float Total = float.Parse(dgvChamCong.Rows[i].Cells[4].Value.ToString()) * float.Parse(dgvChamCong.Rows[i].Cells[6].Value.ToString()) + 
                    float.Parse(dgvChamCong.Rows[i].Cells[7].Value.ToString()) + float.Parse(dgvChamCong.Rows[i].Cells[8].Value.ToString())
               - float.Parse(dgvChamCong.Rows[i].Cells[9].Value.ToString());
                ChamCong cc = new ChamCong();
                cc.CapNhatChamCong(dgvChamCong.Rows[i].Cells[1].Value.ToString(), dgvChamCong.Rows[i].Cells[5].Value.ToString(), dgvChamCong.Rows[i].Cells[6].Value.ToString(), dgvChamCong.Rows[i].Cells[7].Value.ToString(), dgvChamCong.Rows[i].Cells[8].Value.ToString(), dgvChamCong.Rows[i].Cells[9].Value.ToString(), Total.ToString(), ref error);

            }
        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dgvChamCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChamCong.CurrentCell.RowIndex;
            if (!dgvChamCong.Rows[r].Cells[0].Value.ToString().Equals(""))
            {
                txtMaNV.Text = dgvChamCong.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dgvChamCong.Rows[r].Cells[1].Value.ToString();
                txtMaLuong.Text = dgvChamCong.Rows[r].Cells[2].Value.ToString();
                txtLuongChinh.Text = dgvChamCong.Rows[r].Cells[3].Value.ToString();
                txtSoNgayNghi.Text = dgvChamCong.Rows[r].Cells[4].Value.ToString();
                txtSoNgayDiLam.Text = dgvChamCong.Rows[r].Cells[5].Value.ToString();
                txtPhuCap.Text = dgvChamCong.Rows[r].Cells[6].Value.ToString();
                txtTienThuong.Text = dgvChamCong.Rows[r].Cells[7].Value.ToString();
                txtTienPhat.Text = dgvChamCong.Rows[r].Cells[8].Value.ToString();
                txtTongLuong.Text = dgvChamCong.Rows[r].Cells[9].Value.ToString();
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        { 
            float Total = float.Parse(txtLuongChinh.Text) * float.Parse(txtSoNgayDiLam.Text) + float.Parse(txtPhuCap.Text) + 
                float.Parse(txtTienThuong.Text)
                - float.Parse(txtTienPhat.Text);
            txtTongLuong.Text = Total.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ChamCong cc = new ChamCong();
            cc.CapNhatChamCong(this.txtMaNV.Text, this.txtSoNgayNghi.Text, this.txtSoNgayDiLam.Text, this.txtPhuCap.Text, this.txtTienThuong.Text, this.txtTienPhat.Text, this.txtTongLuong.Text, ref error);

            Loaddata();
            MessageBox.Show("Đã cập nhật!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form main = new Form();
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
                dtTK.Columns.Add("TenNV");
                dtTK.Columns.Add("MaLuong");
                dtTK.Columns.Add("LuongChinh");
                dtTK.Columns.Add("SoNgayNghi");
                dtTK.Columns.Add("SoNgayDiLam");
                dtTK.Columns.Add("PhuCap");
                dtTK.Columns.Add("TienThuong");
                dtTK.Columns.Add("TienPhat");
                dtTK.Columns.Add("TONGTIEN");
            }
            for (int i = 0; i < dgvChamCong.Rows.Count-1; i++)
            {
                if (dgvChamCong.Rows[i].Cells[1].Value.ToString().Contains(txtSearch.Text) != false)
                {
                    DataRow rows = dtTK.NewRow();
                    rows["MaNV"] = dgvChamCong.Rows[i].Cells[1].Value.ToString();
                    rows["TenNV"] = dgvChamCong.Rows[i].Cells[2].Value.ToString();
                    rows["MaLuong"] = dgvChamCong.Rows[i].Cells[3].Value.ToString();
                    rows["LuongChinh"] = dgvChamCong.Rows[i].Cells[4].Value.ToString();
                    rows["SoNgayNghi"] = dgvChamCong.Rows[i].Cells[5].Value.ToString();
                    rows["SoNgayDiLam"] = dgvChamCong.Rows[i].Cells[6].Value.ToString();
                    rows["PhuCap"] = dgvChamCong.Rows[i].Cells[7].Value.ToString();
                    rows["TienThuong"] = dgvChamCong.Rows[i].Cells[8].Value.ToString();
                    rows["TienPhat"] = dgvChamCong.Rows[i].Cells[9].Value.ToString();
                    rows["TongTien"] = dgvChamCong.Rows[i].Cells[10].Value.ToString();
                    dtTK.Rows.Add(rows);
                }
                if (dgvChamCong.Rows[i].Cells[2].Value.ToString().Contains(txtSearch.Text) != false)
                {
                    DataRow rows = dtTK.NewRow();
                    rows["MaNV"] = dgvChamCong.Rows[i].Cells[1].Value.ToString();
                    rows["TenNV"] = dgvChamCong.Rows[i].Cells[2].Value.ToString();
                    rows["MaLuong"] = dgvChamCong.Rows[i].Cells[3].Value.ToString();
                    rows["LuongChinh"] = dgvChamCong.Rows[i].Cells[4].Value.ToString();
                    rows["SoNgayNghi"] = dgvChamCong.Rows[i].Cells[5].Value.ToString();
                    rows["SoNgayDiLam"] = dgvChamCong.Rows[i].Cells[6].Value.ToString();
                    rows["PhuCap"] = dgvChamCong.Rows[i].Cells[7].Value.ToString();
                    rows["TienThuong"] = dgvChamCong.Rows[i].Cells[8].Value.ToString();
                    rows["TienPhat"] = dgvChamCong.Rows[i].Cells[9].Value.ToString();
                    rows["TongTien"] = dgvChamCong.Rows[i].Cells[10].Value.ToString();
                    dtTK.Rows.Add(rows);
                }
            }
            dem++;
            dgvChamCong.DataSource = dtTK;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel excel = new ExportToExcel();
                // Lấy về nguồn dữ liệu cần Export là 1 DataTable
                // DataTable này mỗi bạn lấy mỗi khác. 
                // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
                // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
                // DataGridView nhé 
                DataTable dt = (DataTable)dgvChamCong.DataSource;
                excel.Export(dt, "Danh sach", "BẢNG CHẤM CÔNG");

            }
            catch
            {
                MessageBox.Show("Không xuất được file exel!");

            }
        }
    }
}
