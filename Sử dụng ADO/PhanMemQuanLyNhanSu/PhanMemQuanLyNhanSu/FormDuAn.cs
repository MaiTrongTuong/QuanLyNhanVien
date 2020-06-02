using PhanMemQuanLyNhanSu.BS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormDuAn : Form
    {
        clsResize _form_resize;
        public FormDuAn()
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

        DataTable dtDuAn = null;
        string error;
        bool isThem = true;
        DuAn dbDuAn = new DuAn();

        void Loaddata()
        {
            try
            {
                dtDuAn = new DataTable();
                dtDuAn.Clear();

                DataSet ds = dbDuAn.LayDuAn();
                dtDuAn = ds.Tables[0];

                dgvDuAn.DataSource = dtDuAn;
                dgvDuAn.AutoResizeColumns();

                dgvDuAn_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table NhanVien!");
            }
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDuAn.CurrentCell.RowIndex;
            if (!dgvDuAn.Rows[r].Cells[0].Value.ToString().Equals(""))
            {
                txtMaDuAn.Text = dgvDuAn.Rows[r].Cells[0].Value.ToString();
                txtTenDuAn.Text = dgvDuAn.Rows[r].Cells[1].Value.ToString();
                txtDiaDiem.Text = dgvDuAn.Rows[r].Cells[2].Value.ToString();
                txtMaPhong.Text = dgvDuAn.Rows[r].Cells[3].Value.ToString();
            }
        }

        private void FormDuAn_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem == true)
            {
                try
                {
                    DuAn da = new DuAn();
                    da.ThemDuAn(this.txtMaDuAn.Text, this.txtTenDuAn.Text, this.txtDiaDiem.Text, this.txtMaPhong.Text, ref error);

                    Loaddata();

                    MessageBox.Show("Đã thêm");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi thêm");
                }
            }
            else
            {
                try
                {
                    DuAn da = new DuAn();
                    da.CapNhatDuAn(this.txtMaDuAn.Text, this.txtTenDuAn.Text, this.txtDiaDiem.Text, this.txtMaPhong.Text, ref error);

                    Loaddata();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi sửa");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                PhanCong pc = new PhanCong();
                pc.XoaPhanCong(txtMaDuAn.Text, ref error);

                DuAn da = new DuAn();
                da.XoaDuAn(this.txtMaDuAn.Text, ref error);

                Loaddata();
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi trong khi xóa!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form main = new Form();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
    }
}
