using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanSu.BS
{
    class PhongBan
    {
            DBMain db = null;
            public PhongBan()
            {

                db = new DBMain();
            }
            public DataSet LayPhongBan()
            {
                return db.ExecuteQueryDataSet("select * from PhongBan", CommandType.Text);
            }

            public bool ThemPhongBan(string MaPB,string TenPB,string TruongPhong,string NgayNhanChuc, ref string error)
            {
                string sqlString = "Insert Into PhongBan Values('"+ MaPB +"',N'"+TenPB+"',N'"+TruongPhong+"',N'"+NgayNhanChuc+"')";
                return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            }

            public bool CapNhatPhongBan(string MaPB, string TenPB, string TruongPhong, string NgayNhanChuc,ref string error)
            {
                string sqlString =
                   "Update PhongBan Set TenPB=N'"+TenPB+"', TruongPhong='"+TruongPhong+"' , NgayNhanChuc='"+NgayNhanChuc+"' Where MaPB='"+MaPB+"'";
                return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            }
    }
}
