using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLLuong
    {
        public DataTable LayLuong()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var Ls =
                from p in qlbhEntity.Luong
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLuong");
            dt.Columns.Add("TenLuong");
            dt.Columns.Add("LươngCB");
            dt.Columns.Add("HeSoLuong");
            foreach (var p in Ls)
            {
                dt.Rows.Add(p.MaLuong, p.TenLuong, p.LuongCB, p.HeSoLuong);
            }
            return dt;
        }
        public bool ThemLuong(string MaLuong, string TenLuong,
        float LuongCB, float HeSoLuong, ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            Luong luong = new Luong();
            luong.MaLuong = MaLuong;
            luong.TenLuong = TenLuong;
            luong.LuongCB = LuongCB;
            luong.HeSoLuong = HeSoLuong;
            qlbhEntity.Luong.Add(luong);
            qlbhEntity.SaveChanges();
            return true;

        }
        public bool XoaLuong(ref string err, string MaLuong)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();

            Luong luong = new Luong();
            luong.MaLuong = MaLuong;

            qlbhEntity.Luong.Attach(luong);
            qlbhEntity.Luong.Remove(luong);

            qlbhEntity.SaveChanges();

            return true;
        }
        public bool CapNhatLuong(string MaLuong, string TenLuong,
        float LuongCB, float HeSoLuong, ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var luongQuery = (from luong in qlbhEntity.Luong
                           where luong.MaLuong == MaLuong 
                           select luong).SingleOrDefault();
            if (luongQuery != null)
            {
                luongQuery.TenLuong = TenLuong;
                luongQuery.LuongCB = LuongCB;
                luongQuery.HeSoLuong = HeSoLuong;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
    }
}
