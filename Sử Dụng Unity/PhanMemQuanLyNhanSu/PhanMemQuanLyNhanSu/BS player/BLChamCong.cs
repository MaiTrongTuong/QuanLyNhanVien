using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLChamCong
    {
        public DataTable LayChamCong()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var CCs =
                from p in qlbhEntity.ChamCong
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV");
            dt.Columns.Add("TenNV");
            dt.Columns.Add("MaLuong");
            dt.Columns.Add("LuongChinh");
            dt.Columns.Add("SoNgayNghi");
            dt.Columns.Add("SoNgayDiLam");
            dt.Columns.Add("PhuCap");
            dt.Columns.Add("TienThuong");
            dt.Columns.Add("TienPhat");
            dt.Columns.Add("TONGTIEN");
            foreach (var p in CCs)
            {
                dt.Rows.Add(p.MaNV, p.TenNV, p.MaLuong, p.LuongChinh ,p.SoNgayNghi, p.SoNgayDiLam,
                    p.PhuCap,p.TienThuong, p.TienPhat,p.TONGTIEN);
            }
            return dt;
        }
        public bool ThemChamCong(string MaNV, string TenNV,string MaLuong,
        ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            ChamCong chamcong = new ChamCong();
            chamcong.MaNV = MaNV;
            chamcong.TenNV = TenNV;
            chamcong.MaLuong = MaLuong;
            qlbhEntity.ChamCong.Add(chamcong);
            qlbhEntity.SaveChanges();
            return true;

        }
        public bool XoaChamCong(ref string err, string MaNV)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();

            ChamCong chamcong = new ChamCong();
            chamcong.MaNV = MaNV;

            qlbhEntity.ChamCong.Attach(chamcong);
            qlbhEntity.ChamCong.Remove(chamcong);

            qlbhEntity.SaveChanges();

            return true;
        }
        public bool CapNhatChamCong(string MaNV, string TenNV,string MaLuong,
        ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var chamcongQuery = (from chamcong in qlbhEntity.ChamCong
                              where chamcong.MaNV == MaNV
                              select chamcong).SingleOrDefault();
            if (chamcongQuery != null)
            {
                chamcongQuery.TenNV = TenNV;
                chamcongQuery.MaLuong = MaLuong;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
        public bool CapNhatChamCongIn(string MaNV, float LuongChinh, int SoNgayNghi, int SoNgayDiLam,
            float PhuCap, float TienThuong, float TienPhat, float TONGTIEN, ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var chamcongQuery = (from chamcong in qlbhEntity.ChamCong
                                 where chamcong.MaNV == MaNV
                                 select chamcong).SingleOrDefault();
            if (chamcongQuery != null)
            {
                chamcongQuery.LuongChinh = LuongChinh;
                chamcongQuery.SoNgayNghi = SoNgayNghi;
                chamcongQuery.SoNgayDiLam = SoNgayDiLam;
                chamcongQuery.PhuCap = PhuCap;
                chamcongQuery.TienThuong = TienThuong;
                chamcongQuery.TienPhat = TienPhat;
                chamcongQuery.TONGTIEN = TONGTIEN;
                qlbhEntity.SaveChanges();
            }
            return true;
        }
    }
}
