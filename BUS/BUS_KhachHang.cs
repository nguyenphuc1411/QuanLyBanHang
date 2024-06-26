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
    public class BUS_KhachHang
    {
        DAL_KhachHang dAL_KhachHang=new DAL_KhachHang();
        public DataTable DanhSachKhachHang()
        {
            return dAL_KhachHang.DanhSachKhachHang();
        }
        public bool LuuKhachHang(DTO_KhachHang kh)
        {
            return dAL_KhachHang.LuuKhachHang(kh);
        }
        public bool KiemTraSDT(string sdt)
        {
            return dAL_KhachHang.KiemTraSDT(sdt);
        }
        public bool SuaKhachHang(DTO_KhachHang kh)
        {
            return dAL_KhachHang.SuaKhachHang(kh);
        }
        public bool XoaKhachHang(string sdt)
        {
            return dAL_KhachHang.XoaKhachHang(sdt);
        }
        public DataTable TimKiemKhachHang(string TenKH)
        {
            return dAL_KhachHang.TimKiemKhachHang(TenKH);
        }
    }
}
