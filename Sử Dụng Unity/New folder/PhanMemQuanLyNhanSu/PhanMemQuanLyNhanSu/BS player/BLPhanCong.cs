using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLPhanCong
    {
        public DataTable LayPhanCong()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var pcs =
                from p in qlbhEntity.PhanCongNV
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDA");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("ThoiGianStart");
            dt.Columns.Add("ThoiGianEnd");
            foreach (var p in pcs)
            {
                dt.Rows.Add(p.MaDA, p.MaNV, p.ThoiGianStart, p.ThoiGianEnd);
            }
            return dt;
        }
        public bool ThemPhanCong(string MaDA, string MaNV, DateTime ThoiGianStart, DateTime ThoiGianEnd, 
            ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            PhanCongNV pc = new PhanCongNV();
            pc.MaDA = MaDA;
            pc.MaNV = MaNV;
            pc.ThoiGianStart = ThoiGianStart;
            pc.ThoiGianEnd = ThoiGianEnd;
            qlbhEntity.PhanCongNV.Add(pc);
            qlbhEntity.SaveChanges();
            return true;
        }
        public bool CapNhatPhanCong(string MaDA, string MaNV, DateTime ThoiGianStart, DateTime ThoiGianEnd,
            ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var pbQuery = (from pc in qlbhEntity.PhanCongNV
                           where pc.MaDA == MaDA && pc.MaNV == MaNV
                           select pc).SingleOrDefault();
            if (pbQuery != null)
            {
                pbQuery.ThoiGianStart = ThoiGianStart;
                pbQuery.ThoiGianEnd = ThoiGianEnd;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
        public bool XoaPhanCong(ref string err, string MaDA, string MaNV)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();

            PhanCongNV pc = new PhanCongNV();
            pc.MaDA = MaDA;
            pc.MaNV = MaNV;

            qlbhEntity.PhanCongNV.Attach(pc);
            qlbhEntity.PhanCongNV.Remove(pc);

            qlbhEntity.SaveChanges();

            return true;
        }
    }
}
