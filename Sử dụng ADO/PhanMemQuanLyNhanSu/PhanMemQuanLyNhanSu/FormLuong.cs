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
    public partial class FormLuong : Form
    {
        public FormLuong()
        {
            InitializeComponent();
        }

        DataTable dtLuong = null;
        string error;
        bool isThem = true;
        Luong dbLuong = new Luong();

        void Loaddata()
        {
            try
            {
                dtLuong = new DataTable();
                dtLuong.Clear();

                DataSet ds = dbLuong.LayLuong();
                dtLuong = ds.Tables[0];

                dgvLuong.DataSource = dtLuong;
                dgvLuong.AutoResizeColumns();

                dgvLuong_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table Luong!");
            }
        }
        private void FormLuong_Load(object sender, EventArgs e)
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
                    Luong luong = new Luong();
                    luong.ThemLuong(this.txtMaLuong.Text, this.txtTenLuong.Text, this.txtLuongCB.Text, this.txtHeSoLuong.Text, ref error);
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
                    Luong luong = new Luong();
                    luong.CapNhatLuong(this.txtMaLuong.Text, this.txtTenLuong.Text, this.txtLuongCB.Text, this.txtHeSoLuong.Text, ref error);
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
                Luong luong = new Luong();
                luong.XoaLuong(this.txtMaLuong.Text, ref error);

                Loaddata();
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi trong khi xóa!");
            }
        }

       

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLuong.CurrentCell.RowIndex;
            if (!dgvLuong.Rows[r].Cells[0].Value.ToString().Equals(""))
            {
                txtMaLuong.Text = dgvLuong.Rows[r].Cells[0].Value.ToString();
                txtTenLuong.Text = dgvLuong.Rows[r].Cells[1].Value.ToString();
                txtLuongCB.Text = dgvLuong.Rows[r].Cells[2].Value.ToString();
                txtHeSoLuong.Text = dgvLuong.Rows[r].Cells[3].Value.ToString();
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
