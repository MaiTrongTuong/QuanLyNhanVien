using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLNhanVien
    {
        public DataTable LayNhanVien()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var khs =
                from p in qlbhEntity.NhanVien
                select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV");
            dt.Columns.Add("HoTenNV");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("Phong");
            dt.Columns.Add("CMND");
            dt.Columns.Add("CongViec");
            dt.Columns.Add("Luong");
            dt.Columns.Add("GhiChu");
            foreach (var p in khs)
            {
                dt.Rows.Add(p.MaNV, p.HoTenNV, p.NgaySinh, p.GioiTinh, p.DiaChi, p.Phong, p.CMND, p.CongViec,
                    p.Luong, p.GhiChu);
            }
            return dt;
        }
        public bool ThemNhanVien(string MaNV, string TenNV,
        DateTime NgaySinh, string GioiTinh, string DiaChi,
        string Phong, string CMND, string CongViec,
            string Salary, string GhiChu,
            ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.HoTenNV = TenNV;
            nv.NgaySinh = NgaySinh;
            nv.GioiTinh = GioiTinh;
            nv.DiaChi = DiaChi;
            nv.Phong = Phong;
            nv.CMND = CMND;
            nv.CongViec = CongViec;
            nv.Luong = Salary;
            nv.GhiChu = GhiChu;
            qlbhEntity.NhanVien.Add(nv);
            qlbhEntity.SaveChanges();
            return true;

        }
        public bool XoaNhanVien(ref string err,string MaNV)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();

            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;

            qlbhEntity.NhanVien.Attach(nv);
            qlbhEntity.NhanVien.Remove(nv);

            qlbhEntity.SaveChanges();

            return true;
        }
        public bool CapNhatNhanVien(string MaNV, string TenNV,
        DateTime NgaySinh, string GioiTinh, string DiaChi,
        string Phong, string CMND, string CongViec,
            string Salary, string GhiChu,
            ref string err)
        {
           QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var tpQuery = (from nv in qlbhEntity.NhanVien
                           where nv.MaNV == MaNV
                           select nv).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.HoTenNV = TenNV;
                tpQuery.NgaySinh = NgaySinh;
                tpQuery.GioiTinh = GioiTinh;
                tpQuery.DiaChi = DiaChi;
                tpQuery.Phong = Phong;
                tpQuery.CMND = CMND;
                tpQuery.CongViec = CongViec;
                tpQuery.Luong = Salary;
                tpQuery.GhiChu = GhiChu;
                qlbhEntity.SaveChanges();
            }
            return true;

        }
    }
}
