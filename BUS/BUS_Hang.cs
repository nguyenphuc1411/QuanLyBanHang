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
    public class BUS_Hang
    {
        DAL_Hang dAL_Hang=new DAL_Hang();
        public DataTable DanhSachHang()
        {
            return dAL_Hang.DanhSachHang();
        }
        public bool ThemHang(DTO_Hang h)
        {
            return dAL_Hang.ThemHang(h);
        }
        public bool SuaHang(DTO_Hang h)
        {
            return dAL_Hang.SuaHang(h);
        }
        public bool XoaHang(int maHang)
        {
            return dAL_Hang.XoaHang(maHang);
        }
        public bool KiemTraID(int MaHang)
        {
            return dAL_Hang.KiemTraID(MaHang);
        }
        public DataTable ThongKeHang()
        {
            return dAL_Hang.ThongKeHang();
        }
        public DataTable ThongKeTonKho()
        {
            return dAL_Hang.ThongKeTonKho();
        }
    }
}
