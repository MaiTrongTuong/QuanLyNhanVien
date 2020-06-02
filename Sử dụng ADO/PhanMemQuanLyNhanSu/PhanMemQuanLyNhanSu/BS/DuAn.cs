using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanSu.BS
{
    class DuAn
    {
        DBMain db = null;
        public DuAn()
        {

            db = new DBMain();
        }
        public DataSet LayDuAn()
        {
            return db.ExecuteQueryDataSet("select * from DuAn", CommandType.Text);
        }

        public bool ThemDuAn(string MaDA,string TenDA,string DiaDiem,string Phong, ref string error)
        {
            string sqlString = "Insert Into DuAn Values('" + MaDA+ "',N'" + TenDA + "',N'" + DiaDiem + "','" + Phong + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool CapNhatDuAn(string MaDA, string TenDA, string DiaDiem, string Phong, ref string error)
        {
            string sqlString =
               "Update DuAn Set TenDA=N'" + TenDA + "', DiaDiem=N'" + DiaDiem + "', Phong =N'"+Phong+"' Where MaDA='" + MaDA + "' and MaDA='" + MaDA + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool XoaDuAn(string MaDA, ref string err)
        {
            string sqlString = "Delete From DuAn Where MaDA='" + MaDA + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
