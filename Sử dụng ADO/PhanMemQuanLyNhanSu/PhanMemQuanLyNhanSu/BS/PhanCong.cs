using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhanMemQuanLyNhanSu.DB;

namespace PhanMemQuanLyNhanSu.BS
{
    class PhanCong
    {
        DBMain db = null;
        public PhanCong()
        {

            db = new DBMain();
        }
        public DataSet LayPhanCong()
        {
            return db.ExecuteQueryDataSet("select * from PhanCongNV", CommandType.Text);
        }

        public bool ThemPhanCong(string MaNV, string MaDA, string ThoiGianStart, string ThoiGianEnd, ref string error)
        {
            string sqlString = "Insert Into PhanCongNV Values('" + MaNV + "','" +MaDA + "','" + ThoiGianStart + "','" + ThoiGianEnd + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool CapNhatPhanCong(string MaNV, string MaDA, string ThoiGianStart, string ThoiGianEnd, ref string error)
        {
            string sqlString =
               "Update PhanCongNV Set ThoiGianStart='" + ThoiGianStart + "', ThoiGianEnd='" + ThoiGianEnd + "' Where MaNV='" + MaNV + "' and MaDA='"+MaDA+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool XoaPhanCong(string MaNV, string MaDA, ref string err)
        {
            string sqlString = "Delete From PhanCongNV Where MaNV='" + MaNV + "' and MaDA='"+MaDA+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaPhanCong(string MaNV, ref string err)
        {
            string sqlString = "Delete From PhanCongNV Where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
