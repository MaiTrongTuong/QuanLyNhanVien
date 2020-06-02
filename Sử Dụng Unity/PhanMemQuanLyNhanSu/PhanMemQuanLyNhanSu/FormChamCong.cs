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
    public partial class FormChamCong : Form
    {
        public FormChamCong()
        {
            InitializeComponent();
        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        DataTable dtTK = new DataTable();
        int dem = 0;
        int bienphucap =1; //biến phục cấp
        bool Them;
        string err;
        BLChamCong dbLuong = new BLChamCong();
        TinhLuong dbTinhLuong = new TinhLuong();
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView
                dgvChamCong.DataSource = dbLuong.LayChamCong();
                // Thay đổi độ rộng cột
                dgvChamCong.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                txtMaNV.ResetText();
                txtTenNV.ResetText();
                txtSoNgayNghi.ResetText();
                txtSoNgayDiLam.ResetText();
                txtPhuCap.ResetText();
                txtTienThuong.ResetText();
                txtTienPhat.ResetText();
                //
                //ẩn những textbox k cho nhập
                txtMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                txtLuongChinh.Enabled = false;
                txtMaLuong.Enabled = false;
                txtSoNgayDiLam.Enabled = false;
                txtPhuCap.Enabled = false;
                txtTONGLUONG.Enabled = false;
                //dgvChamCong_CellClick(null, null);
            }

            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table ChamCong. Lỗi rồi!!!");
            }
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BLLuong luong = new BLLuong();
                BLPhanCong pc = new BLPhanCong();
                dgvTest.DataSource = luong.LayLuong();
                dgvtest2.DataSource = pc.LayPhanCong();

                //Thứ tự dòng hiện hành
                int r = dgvChamCong.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                txtMaNV.Text = dgvChamCong.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dgvChamCong.Rows[r].Cells[1].Value.ToString();
                txtMaLuong.Text = dgvChamCong.Rows[r].Cells[2].Value.ToString();
                txtLuongChinh.Text = dgvChamCong.Rows[r].Cells[3].Value.ToString();
                txtSoNgayNghi.Text = dgvChamCong.Rows[r].Cells[4].Value.ToString();
                txtSoNgayDiLam.Text = dgvChamCong.Rows[r].Cells[5].Value.ToString();
                txtPhuCap.Text = dgvChamCong.Rows[r].Cells[6].Value.ToString();
                txtTienThuong.Text = dgvChamCong.Rows[r].Cells[7].Value.ToString();
                txtTienPhat.Text = dgvChamCong.Rows[r].Cells[8].Value.ToString();

                //tính lương
                for (int i = 0; i < dgvTest.Rows.Count - 1; i++)
                {
                    if (dgvChamCong.Rows[r].Cells[2].Value.ToString().Contains(dgvTest.Rows[i].Cells[0].Value.ToString()) !=false)
                    {
                        double luongchinh = Convert.ToDouble(dgvTest.Rows[i].Cells[2].Value) * Convert.ToDouble(dgvTest.Rows[i].Cells[3].Value);
                        txtLuongChinh.Text = luongchinh.ToString();
                    }
                }
                for (int j = 0; j < dgvtest2.Rows.Count - 2; j++)
                {
                    if (dgvChamCong.Rows[r].Cells[0].Value.ToString().Contains(dgvtest2.Rows[j].Cells[1].Value.ToString()) != false)
                    {
                        double phucap = bienphucap * 100000;
                        txtPhuCap.Text = phucap.ToString();
                    }
                }
                if (txtPhuCap.Text == "") 
                {
                    //double phucap = bienphucap * 100000;
                    //txtPhuCap.Text = phucap.ToString();
                    txtPhuCap.Text = 0.ToString();
                }

            }
            catch
            {
                MessageBox.Show("Bạn đã nhấp chuột ra khỏi vùng chữa dữ liệu!");
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int rr = dgvChamCong.CurrentCell.RowIndex;
            DataTable tb = new DataTable();
            BLLuong luong = new BLLuong();
            BLChamCong cc = new BLChamCong();
            dgvTest.DataSource = cc.LayChamCong();
            dgvtest2.DataSource = luong.LayLuong();
            // Thay đổi độ rộng cột
            //dgvChamCong.AutoResizeColumns();
            //for (int i = 0; i < dgvTest.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; i < dgvtest2.Rows.Count - 1; j++)
            //    {
            //        if (dgvTest.Rows[i].Cells[0].Value.ToString().Contains(dgvtest2.Rows[j].Cells[0].Value.ToString()) != false)
            //        {
            //            int luongchinh = Convert.ToInt32(dgvtest2.Rows[j].Cells[2].Value) * Convert.ToInt32(dgvtest2.Rows[j].Cells[3].Value);

            //        }
            //    }
            //}
            //tính lương kèm các điều kiện
            try
            {

                if (int.Parse(txtTienThuong.Text) != 0)
                {
                    if (int.Parse(txtTienPhat.Text) != 0)
                    {
                        if (int.Parse(txtSoNgayNghi.Text) != 0)
                        {
                            txtSoNgayDiLam.Text = (30 - Convert.ToDouble(txtSoNgayNghi.Text)).ToString();
                            double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                * (30 - Convert.ToDouble(txtSoNgayNghi.Text)) - Convert.ToDouble(txtTienPhat.Text);
                            txtTONGLUONG.Text = TONGTIEN.ToString();
                            //Thông báo
                            MessageBox.Show("Đã tính xong!");
                        }
                        else
                        {
                            // Khai báo biến trả lời
                            DialogResult traloi;
                            // Hiện hộp thoại hỏi đáp
                            traloi = MessageBox.Show("Bạn có chắc là số ngày nghĩ bằng 0 không?", "Trả lời",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            // Kiểm tra có nhắp chọn nút Ok không?
                            if (traloi == DialogResult.OK)
                            {
                                txtSoNgayDiLam.Text = 30.ToString();
                                double TONGTIEN = ((Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                * 30) - Convert.ToDouble(txtSoNgayNghi.Text);
                                txtTONGLUONG.Text = TONGTIEN.ToString();
                                //Thông báo
                                MessageBox.Show("Đã tính xong!");
                            }
                        }
                    }
                    else
                    {
                        // Khai báo biến trả lời
                        DialogResult traloi1;
                        // Hiện hộp thoại hỏi đáp
                        traloi1 = MessageBox.Show("Bạn có chắc là tiền phạt bằng 0 không?", "Trả lời",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        // Kiểm tra có nhắp chọn nút Ok không?
                        if (traloi1 == DialogResult.OK)
                        {
                            if (int.Parse(txtSoNgayNghi.Text) != 0)
                            {
                                txtSoNgayDiLam.Text = (30 - Convert.ToDouble(txtSoNgayNghi.Text)).ToString();
                                double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                    * (30 - Convert.ToDouble(txtSoNgayNghi.Text));
                                txtTONGLUONG.Text = TONGTIEN.ToString();
                                //Thông báo
                                MessageBox.Show("Đã tính xong!");
                            }
                            else
                            {
                                // Khai báo biến trả lời
                                DialogResult traloi2;
                                // Hiện hộp thoại hỏi đáp
                                traloi2 = MessageBox.Show("Bạn có chắc là số ngày nghĩ bằng 0 không?", "Trả lời",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                // Kiểm tra có nhắp chọn nút Ok không?
                                if (traloi2 == DialogResult.OK)
                                {
                                    txtSoNgayDiLam.Text = 30.ToString();
                                    double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text)) * 30;
                                    txtTONGLUONG.Text = TONGTIEN.ToString();
                                    //Thông báo
                                    MessageBox.Show("Đã tính xong!");
                                }
                            }
                        }
                    }

                }
                else
                {
                    // Khai báo biến trả lời
                    DialogResult traloi;
                    // Hiện hộp thoại hỏi đáp
                    traloi = MessageBox.Show("Bạn có chắc là tiền thưởng bằng 0 không?", "Trả lời",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    // Kiểm tra có nhắp chọn nút Ok không?
                    if (traloi == DialogResult.OK)
                    {
                        if (int.Parse(txtTienPhat.Text) != 0)
                        {
                            if (int.Parse(txtSoNgayNghi.Text) != 0)
                            {
                                txtSoNgayDiLam.Text = (30 - Convert.ToDouble(txtSoNgayNghi.Text)).ToString();
                                double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                    * (30 - Convert.ToDouble(txtSoNgayNghi.Text)) - Convert.ToDouble(txtTienPhat.Text);
                                txtTONGLUONG.Text = TONGTIEN.ToString();
                                //Thông báo
                                MessageBox.Show("Đã tính xong!");
                            }
                            else
                            {
                                // Khai báo biến trả lời
                                DialogResult traloi1;
                                // Hiện hộp thoại hỏi đáp
                                traloi1 = MessageBox.Show("Bạn có chắc là số ngày nghĩ bằng 0 không?", "Trả lời",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                // Kiểm tra có nhắp chọn nút Ok không?
                                if (traloi1 == DialogResult.OK)
                                {
                                    txtSoNgayDiLam.Text = 30.ToString();
                                    double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                    * 30 - Convert.ToDouble(txtTienPhat.Text);
                                    txtTONGLUONG.Text = TONGTIEN.ToString();
                                    //Thông báo
                                    MessageBox.Show("Đã tính xong!");
                                }
                            }
                        }
                        else
                        {
                            // Khai báo biến trả lời
                            DialogResult traloi2;
                            // Hiện hộp thoại hỏi đáp
                            traloi2 = MessageBox.Show("Bạn có chắc là tiền phạt bằng 0 không?", "Trả lời",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            // Kiểm tra có nhắp chọn nút Ok không?
                            if (traloi2 == DialogResult.OK)
                            {
                                if (int.Parse(txtSoNgayNghi.Text) != 0)
                                {
                                    txtSoNgayDiLam.Text = (30 - Convert.ToDouble(txtSoNgayNghi.Text)).ToString();
                                    double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text))
                                        * (30 - Convert.ToDouble(txtSoNgayNghi.Text));
                                    txtTONGLUONG.Text = TONGTIEN.ToString();
                                    //Thông báo
                                    MessageBox.Show("Đã tính xong!");
                                }
                                else
                                {
                                    // Khai báo biến trả lời
                                    DialogResult traloi3;
                                    // Hiện hộp thoại hỏi đáp
                                    traloi3 = MessageBox.Show("Bạn có chắc là số ngày nghĩ bằng 0 không?", "Trả lời",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                    // Kiểm tra có nhắp chọn nút Ok không?
                                    if (traloi3 == DialogResult.OK)
                                    {
                                        txtSoNgayDiLam.Text = 30.ToString();
                                        double TONGTIEN = (Convert.ToDouble(txtLuongChinh.Text) + Convert.ToDouble(txtPhuCap.Text)) * 30;
                                        txtTONGLUONG.Text = TONGTIEN.ToString();
                                        //Thông báo
                                        MessageBox.Show("Đã tính xong!");
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa nhập vào ô 1 là Tiền Phạt, 2 là Tiền Thưởng, 3 là Số Ngày Nghỉ!");
            }

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            LoadData();
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
            for (int i = 0; i < dgvChamCong.Rows.Count - 1; i++)
            {
                if (dgvChamCong.Rows[i].Cells[0].Value.ToString().Contains(txtSearch.Text) != false)
                {
                    DataRow rows = dtTK.NewRow();
                    rows["MaNV"] = dgvChamCong.Rows[i].Cells[0].Value.ToString();
                    rows["TenNV"] = dgvChamCong.Rows[i].Cells[1].Value.ToString();
                    rows["MaLuong"] = dgvChamCong.Rows[i].Cells[2].Value.ToString();
                    rows["LuongChinh"] = dgvChamCong.Rows[i].Cells[3].Value.ToString();
                    rows["SoNgayNghi"] = dgvChamCong.Rows[i].Cells[4].Value.ToString();
                    rows["SoNgayDiLam"] = dgvChamCong.Rows[i].Cells[5].Value.ToString();
                    rows["PhuCap"] = dgvChamCong.Rows[i].Cells[6].Value.ToString();
                    rows["TienThuong"] = dgvChamCong.Rows[i].Cells[7].Value.ToString();
                    rows["TienPhat"] = dgvChamCong.Rows[i].Cells[8].Value.ToString();
                    rows["TongTien"] = dgvChamCong.Rows[i].Cells[9].Value.ToString();
                    dtTK.Rows.Add(rows);
                }
                if (dgvChamCong.Rows[i].Cells[1].Value.ToString().Contains(txtSearch.Text) != false)
                {
                    DataRow rows = dtTK.NewRow();
                    rows["MaNV"] = dgvChamCong.Rows[i].Cells[0].Value.ToString();
                    rows["TenNV"] = dgvChamCong.Rows[i].Cells[1].Value.ToString();
                    rows["MaLuong"] = dgvChamCong.Rows[i].Cells[2].Value.ToString();
                    rows["LuongChinh"] = dgvChamCong.Rows[i].Cells[3].Value.ToString();
                    rows["SoNgayNghi"] = dgvChamCong.Rows[i].Cells[4].Value.ToString();
                    rows["SoNgayDiLam"] = dgvChamCong.Rows[i].Cells[5].Value.ToString();
                    rows["PhuCap"] = dgvChamCong.Rows[i].Cells[6].Value.ToString();
                    rows["TienThuong"] = dgvChamCong.Rows[i].Cells[7].Value.ToString();
                    rows["TienPhat"] = dgvChamCong.Rows[i].Cells[8].Value.ToString();
                    rows["TongTien"] = dgvChamCong.Rows[i].Cells[9].Value.ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BLChamCong cc = new BLChamCong();

                cc.CapNhatChamCongIn(txtMaNV.Text, float.Parse(txtLuongChinh.Text), int.Parse(txtSoNgayNghi.Text),
                    int.Parse(txtSoNgayDiLam.Text),
                    float.Parse(txtPhuCap.Text), float.Parse(txtTienThuong.Text), float.Parse(txtTienPhat.Text),
                    float.Parse(txtTONGLUONG.Text), ref err);
                LoadData();
                //Thông báo
                MessageBox.Show("Đã update xong!");
                //}
                //if (txtSoNgayNghi.Text == "" && txtTienThuong.Text == "")
                //{
                //    txtSoNgayNghi.Text = 0.ToString();
                //    txtTienThuong.Text = 0.ToString();
                //    cc.CapNhatChamCongIn(txtMaNV.Text, float.Parse(txtLuongChinh.Text), int.Parse(txtSoNgayNghi.Text),
                //        int.Parse(txtSoNgayDiLam.Text),
                //        float.Parse(txtPhuCap.Text), float.Parse(txtTienThuong.Text), float.Parse(txtTienPhat.Text),
                //        float.Parse(txtTONGLUONG.Text), ref err);
                //    LoadData();
                //    //Thông báo
                //    MessageBox.Show("Đã update xong!");
                //}
                //if (txtSoNgayNghi.Text == "" && txtTienPhat.Text == "")
                //{
                //    txtSoNgayNghi.Text = 0.ToString();
                //    txtTienPhat.Text = 0.ToString();
                //    cc.CapNhatChamCongIn(txtMaNV.Text, float.Parse(txtLuongChinh.Text), int.Parse(txtSoNgayNghi.Text),
                //        int.Parse(txtSoNgayDiLam.Text),
                //        float.Parse(txtPhuCap.Text), float.Parse(txtTienThuong.Text), float.Parse(txtTienPhat.Text),
                //        float.Parse(txtTONGLUONG.Text), ref err);
                //    LoadData();
                //    //Thông báo
                //    MessageBox.Show("Đã update xong!");
                //}
                //if (txtTienThuong.Text == "" && txtTienPhat.Text == "")
                //{
                //    txtTienThuong.Text = 0.ToString();
                //    txtTienPhat.Text = 0.ToString();
                //    cc.CapNhatChamCongIn(txtMaNV.Text, float.Parse(txtLuongChinh.Text), int.Parse(txtSoNgayNghi.Text),
                //        int.Parse(txtSoNgayDiLam.Text),
                //        float.Parse(txtPhuCap.Text), float.Parse(txtTienThuong.Text), float.Parse(txtTienPhat.Text),
                //        float.Parse(txtTONGLUONG.Text), ref err);
                //    LoadData();
                //    //Thông báo
                //    MessageBox.Show("Đã update xong!");
                //}
                //if (txtSoNgayNghi.Text == "" && txtTienThuong.Text == "" && txtTienPhat.Text == "")
                //{
                //    txtSoNgayNghi.Text = 0.ToString();
                //    txtTienThuong.Text = 0.ToString();
                //    txtTienPhat.Text = 0.ToString();
                //    cc.CapNhatChamCongIn(txtMaNV.Text, float.Parse(txtLuongChinh.Text), int.Parse(txtSoNgayNghi.Text),
                //        int.Parse(txtSoNgayDiLam.Text),
                //        float.Parse(txtPhuCap.Text), float.Parse(txtTienThuong.Text), float.Parse(txtTienPhat.Text),
                //        float.Parse(txtTONGLUONG.Text), ref err);
                //    LoadData();
                //    //Thông báo
                //    MessageBox.Show("Đã update xong!");
                //}

            }
            catch (SqlException)
            {
                MessageBox.Show("Không update được đã có lỗi!");
            }
        }
    }
}
