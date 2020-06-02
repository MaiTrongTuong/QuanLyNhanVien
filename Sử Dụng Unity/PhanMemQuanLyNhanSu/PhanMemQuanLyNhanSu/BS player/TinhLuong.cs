using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class TinhLuong
    {
        public DataTable LayTinhLuong()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var Ls =
                from l in qlbhEntity.Luong
                select l;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("MaLuong");
            dt1.Columns.Add("LươngCB");
            dt1.Columns.Add("HeSoLuong");
            foreach (var l in Ls)
            {
                dt1.Rows.Add(l.MaLuong, l.LuongCB, l.HeSoLuong);
            }

            return dt1;
        }
        public DataTable LayTinhLuong2()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var CCs =
                from cc in qlbhEntity.ChamCong
                select cc;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("MaNV");
            dt2.Columns.Add("SoNgayNghi");
            dt2.Columns.Add("SoNgayDiLam");
            dt2.Columns.Add("PhuCap");
            dt2.Columns.Add("TienThuong");
            dt2.Columns.Add("TienPhat");
            dt2.Columns.Add("TONGTIEN");
            foreach (var cc in CCs)
            {
                dt2.Rows.Add(cc.MaNV, cc.SoNgayNghi, cc.SoNgayDiLam, cc.PhuCap, cc.TienThuong, cc.TienPhat, cc.TONGTIEN);
            }
            return dt2;
        }
        public DataTable LayTinhLuong3()
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            DataTable dt3 = new DataTable();
            var NVs =
                from nv in qlbhEntity.NhanVien
                select nv;
            dt3.Columns.Add("MaNV");
            dt3.Columns.Add("Luong");
            foreach (var nv in NVs)
            {
                dt3.Rows.Add(nv.MaNV, nv.Luong);
            }
            return dt3;
        }
    }
}
