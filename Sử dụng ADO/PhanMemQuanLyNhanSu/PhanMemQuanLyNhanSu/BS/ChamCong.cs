using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanSu.BS
{
    class ChamCong
    {
        DBMain db = null;
        public ChamCong()
        {

            db = new DBMain();
        }
        public DataSet LayChamCong()
        {
            return db.ExecuteQueryDataSet("select * from ChamCong", CommandType.Text);
        } 

        public bool ThemChamCong(string MaNV, string TenNV, string MaLuong,string LuongChinh,string SoNgayNghi,string SoNgayDiLam,string PhuCap,string TienThuong,string TienPhat,string TongLuong, ref string error)
        {
            string sqlString = "Insert into ChamCong Values('"+MaNV+"',N'"+TenNV+"','"+MaLuong+"','"+LuongChinh+"','"+SoNgayNghi+"','"+SoNgayDiLam+"',N'"+PhuCap+"','"+TienThuong+"','"+TienPhat+"','"+TongLuong+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool GetLuongString(string MaLuong,ref string LuongCB, ref string HeSoLuong)
        {
            string sql = "select LuongCB,HeSoLuong from Luong where MaLuong='" + MaLuong + "' ";
            return db.GetLuong(sql, ref LuongCB, ref HeSoLuong);
        }


        public bool CapNhatChamCong(string MaNV, string SoNgayNghi, string SoNgayDiLam, string PhuCap, string TienThuong, string TienPhat, string Total, ref string error)
        {
            string sqlString = "Update ChamCong Set SoNgayNghi=N'" + SoNgayNghi + "'" +
                                    ", SoNgayDiLam='" + SoNgayDiLam + "'" +
                                    ", PhuCap='" + PhuCap + "'" +
                                    ", TienThuong='" + TienThuong + "'" +
                                    ", TienPhat='" + TienPhat + "'" +
                                    ", TongLuong='" + Total + "' Where MaNV=N'" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool CapNhatChamCong(string MaNV, string MaLuong, string LuongChinh, ref string error)
        {
            string sqlString = "Update ChamCong Set MaLuong=N'" + MaLuong + "'" +
                                    ", LuongChinh=N'" + LuongChinh + "' Where MaNV=N'" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool XoaChamCong(string MaNV, ref string err)
        {
            string sqlString = "Delete From ChamCong Where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}

