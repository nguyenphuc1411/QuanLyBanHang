using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Tests
{
    [TestClass()]
    public class DAL_KhachHangTests
    {
        [TestMethod()]
        public void LuuKhachHangTest()
        {
            DTO_KhachHang kh=new DTO_KhachHang();
            DAL_KhachHang themkh=new DAL_KhachHang();
            kh.DienThoai = "08988383482";
            kh.TenKhach = "Phúc";
            kh.DiaChi = "An Nhơn";
            kh.Phai = "Nam";
            kh.MaNV = "NV01";
            bool result = themkh.LuuKhachHang(kh);
            Assert.IsTrue(result);
        }
        public void LuuKhachHangTest2()
        {
            DTO_KhachHang kh = new DTO_KhachHang();
            DAL_KhachHang themkh = new DAL_KhachHang();
            kh.DienThoai = "08988383482";
            kh.TenKhach = "Phúc";
            kh.DiaChi = "An Nhơn";
            kh.Phai = "Nam";
            kh.MaNV = "NV003";
            bool result = themkh.LuuKhachHang(kh);
            Assert.IsTrue(result);
        }
        public void XoaKhachHangTest()
        {
            DAL_KhachHang xoakh = new DAL_KhachHang();
            bool result = xoakh.XoaKhachHang("0898827656");
            Assert.IsTrue(result);
        }

    }
}