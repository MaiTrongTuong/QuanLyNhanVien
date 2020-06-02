 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLDuAn
    {
        public DataTable LayDuAN()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var DAs =
                from p in qlbhEntity.DuAn
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDA");
            dt.Columns.Add("TenDA");
            dt.Columns.Add("DiaDiem");
            dt.Columns.Add("Phong");
            foreach (var p in DAs)
            {
                dt.Rows.Add(p.MaDA, p.TenDA, p.DiaDiem, p.Phong);
            }
            return dt;
        }
        public bool ThemDuAn(string MaDA, string TenDA,
        string DiaDiem, string Phong, ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            DuAn DA = new DuAn();
            DA.MaDA = MaDA;
            DA.TenDA = TenDA;
            DA.DiaDiem = DiaDiem;
            DA.Phong = Phong;
            qlbhEntity.DuAn.Add(DA);
            qlbhEntity.SaveChanges();
            return true;

        }
        public bool XoaDA(ref string err, string MaDA)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();

            DuAn DA = new DuAn();
            DA.MaDA = MaDA;

            qlbhEntity.DuAn.Attach(DA);
            qlbhEntity.DuAn.Remove(DA);

            qlbhEntity.SaveChanges();

            return true;
        }
        public bool CapNhatLuong(string MaDA, string TenDA,
        string DiaDiem, string Phong, ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var DAQuery = (from DA in qlbhEntity.DuAn
                              where DA.MaDA == MaDA
                              select DA).SingleOrDefault();
            if (DAQuery != null)
            {
                DAQuery.TenDA = TenDA;
                DAQuery.DiaDiem = DiaDiem;
                DAQuery.Phong = Phong;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
    }
}
