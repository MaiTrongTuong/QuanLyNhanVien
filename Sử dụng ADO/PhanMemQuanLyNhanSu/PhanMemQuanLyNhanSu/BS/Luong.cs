using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanSu.BS
{
    class Luong
    {
        DBMain db = null;
        public Luong()
        {

            db = new DBMain();
        }
        public DataSet LayLuong()
        {
            return db.ExecuteQueryDataSet("select * from Luong", CommandType.Text);
        }

        public bool ThemLuong(string MaLuong, string TenLuong, string LuongCB, string HeSoLuong, ref string error)
        {
            string sqlString = "Insert Into Luong Values('" + MaLuong + "',N'" + TenLuong + "','" + LuongCB + "','" + HeSoLuong + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool CapNhatLuong(string MaLuong, string TenLuong, string LuongCB, string HeSoLuong, ref string error)
        {
            string sqlString =
               "Update Luong Set TenLuong=N'" + TenLuong + "', LuongCB='" + LuongCB + "', HeSoLuong ='" + HeSoLuong + "' Where MaLuong='" + MaLuong + "' and MaLuong='" + MaLuong + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool XoaLuong(string MaLuong, ref string err)
        {
            string sqlString = "Delete From Luong Where MaLuong='" + MaLuong + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
