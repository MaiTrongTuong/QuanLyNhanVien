using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace PhanMemQuanLyNhanSu.BS_player
{
    class BLDangNhap
    {
        public bool KtraTaiKhoan(string TenDangNhap, string MatKhau,
        ref string err)
        {
            QuanLyNhanSuEntities qlbhEntity = new QuanLyNhanSuEntities();
            var luongQuery = (from dangnhap in qlbhEntity.DangNhap
                              where dangnhap.TenTaiKhoan.Trim() == TenDangNhap && dangnhap.MatKhau == MatKhau
                              select dangnhap).SingleOrDefault();
            if (luongQuery != null)
            {
                return true;
            }
            return false;
        }
    }
}
