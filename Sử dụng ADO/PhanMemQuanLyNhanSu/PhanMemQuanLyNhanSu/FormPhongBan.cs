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

        DataTable dtPhongBan = null;
        string error;
        bool isThem = true;
        PhongBan dbPhongBan = new PhongBan();

        void Loaddata()
        {
            try
            {
                dtPhongBan = new DataTable();
                dtPhongBan.Clear();

                DataSet ds = dbPhongBan.LayPhongBan();
                dtPhongBan = ds.Tables[0];

                dgvPhongBan.DataSource = dtPhongBan;
                dgvPhongBan.AutoResizeColumns();

                dgvPhongBan_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table PhongBan!");
            }
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem == true)
            {
                try
                {
                    PhongBan pb = new PhongBan();
                    pb.ThemPhongBan(this.txtMaPhongBan.Text, this.txtTenPhongBan.Text, this.txtTruongPhong.Text, this.dtbNgayNhanChuc.Text, ref error);
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
                    PhongBan pb = new PhongBan();
                    pb.CapNhatPhongBan(this.txtMaPhongBan.Text, this.txtTenPhongBan.Text, this.txtTruongPhong.Text, this.dtbNgayNhanChuc.Text, ref error);

                    Loaddata();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi sửa");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                int r = dgvPhongBan.CurrentCell.RowIndex;
                txtMaPhongBan.Text = dgvPhongBan.Rows[r].Cells[0].Value.ToString();
                txtTenPhongBan.Text = dgvPhongBan.Rows[r].Cells[1].Value.ToString();
                txtTruongPhong.Text = dgvPhongBan.Rows[r].Cells[2].Value.ToString();
                dtbNgayNhanChuc.Text = dgvPhongBan.Rows[r].Cells[3].Value.ToString();
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
