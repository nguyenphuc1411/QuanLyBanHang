using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dAL_NhanVien=new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien dTO_NhanVien)
        {
            return dAL_NhanVien.NhanVienDangNhap(dTO_NhanVien);
        }
        public bool XacNhanEmailQuenMatKhau(string email)
        {
            return dAL_NhanVien.XacNhanEmailQuenMatKhau(email);
        }
        public void CapNhatMatKhauMoi(string email,string matKhau)
        {
            dAL_NhanVien.CapNhatMatKhauMoi(email, matKhau);
        }
        public string VaiTroNV(string email)
        {
            return dAL_NhanVien.VaiTroNV(email);
        }
        public bool TrangThaiHoatDong(string email)
        {
            return dAL_NhanVien.TrangThaiHoatDong(email);
        }
        public DataTable DanhSachNhanVien()
        {
            return dAL_NhanVien.DanhSachNhanVien();
        }
        public bool LuuNhanVien(DTO_NhanVien nv)
        {
            return dAL_NhanVien.LuuNhanVien(nv);
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            return dAL_NhanVien.SuaNhanVien(nv);
        }
        public string TaoMaNhanVien()
        {
            return dAL_NhanVien.TaoMaNhanVien();
        }
        public bool XoaNhanVien(string maNV)
        {
            return dAL_NhanVien.XoaNhanVien(maNV);
        }
        public DataTable TimKiemNhanVien(string tenNV)
        {
            return dAL_NhanVien.TimKiemNhanVien(tenNV);
        }
        public string LayMaNhanVien(string email)
        {
            return dAL_NhanVien.LayMaNhanVien(email);
        }
        public void GhiNhoMatKhau(string email,string pass)
        {
            dAL_NhanVien.GhiNhoMatKhau(email, pass);
        }
        public string MatKhauDaNho()
        {
            return dAL_NhanVien.MatKhauDaNho();
        }
        public string EmailDaNho()
        {
            return dAL_NhanVien.EmailDaNho();
        }
    }
}
