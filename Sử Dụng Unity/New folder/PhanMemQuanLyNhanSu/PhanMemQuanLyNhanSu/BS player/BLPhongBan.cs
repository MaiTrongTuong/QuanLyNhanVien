using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLPhongBan
    {
        public DataTable LayPhongBan()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var pbs =
                from p in qlbhEntity.PhongBan
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPB");
            dt.Columns.Add("TenPB");
            dt.Columns.Add("TruongPhong");
            dt.Columns.Add("NgayNhanChuc");
            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaPB, p.TenPB, p.TruongPhong, p.NgayNhanChuc);
            }
            return dt;
        }
        public bool ThemPhongBan(string MaPB, string TenPB,string TruongPhong,
        DateTime NgayNhanChuc,
            ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            PhongBan pb = new PhongBan();
            pb.MaPB = MaPB;
            pb.TenPB = TenPB;
            pb.TruongPhong = TruongPhong;
            pb.NgayNhanChuc = NgayNhanChuc;
            qlbhEntity.PhongBan.Add(pb);
            qlbhEntity.SaveChanges();
            return true;
        }
        public bool CapNhatPhongBan(string MaPB, string TenPB, string TruongPhong,
        DateTime NgayNhanChuc,
            ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var pbQuery = (from pb in qlbhEntity.PhongBan
                           where pb.MaPB == MaPB
                           select pb).SingleOrDefault();

            if (pbQuery != null)
            {
                pbQuery.TenPB = TenPB;
                pbQuery.TruongPhong = TruongPhong;
                pbQuery.NgayNhanChuc = NgayNhanChuc;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
    }
}
