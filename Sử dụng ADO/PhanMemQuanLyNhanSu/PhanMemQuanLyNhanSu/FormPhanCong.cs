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

        DataTable dtPhanCong = null;
        string error;
        bool isThem = true;
        PhanCong dbPhanCong = new PhanCong();

        void Loaddata()
        {
            try
            {
                dtPhanCong = new DataTable();
                dtPhanCong.Clear();

                DataSet ds = dbPhanCong.LayPhanCong();
                dtPhanCong = ds.Tables[0];

                dgvPhanCong.DataSource = dtPhanCong;
                dgvPhanCong.AutoResizeColumns();

                dgvPhanCong_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table PhanCong!");
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPhanCong.CurrentCell.RowIndex;
            if (!dgvPhanCong.Rows[r].Cells[0].Value.ToString().Equals(""))
            {
                txtMaNV.Text = dgvPhanCong.Rows[r].Cells[0].Value.ToString();
                txtMaDA.Text = dgvPhanCong.Rows[r].Cells[1].Value.ToString();
                dtpThoiGianBD.Text = dgvPhanCong.Rows[r].Cells[2].Value.ToString();
                dtpThoiGianHT.Text = dgvPhanCong.Rows[r].Cells[3].Value.ToString();

            }
        }

        private void FormPhanCong_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnReload_Click(object sender, EventArgs e)
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
                    PhanCong pc = new PhanCong();
                    pc.ThemPhanCong(this.txtMaNV.Text, this.txtMaDA.Text, this.dtpThoiGianBD.Text, this.dtpThoiGianHT.Text, ref error);
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
                    PhanCong pc = new PhanCong();
                    pc.CapNhatPhanCong(this.txtMaNV.Text, this.txtMaDA.Text, this.dtpThoiGianBD.Text, this.dtpThoiGianHT.Text, ref error);

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
                pc.XoaPhanCong(this.txtMaNV.Text, this.txtMaDA.Text,ref error);

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
