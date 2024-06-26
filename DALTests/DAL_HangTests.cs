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
    public class DAL_HangTests
    {
        [TestMethod()]
        public void ThemHangTest()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang themhang=new DAL_Hang();
            h.TenHang = "Bia";
            h.SoLuong = 5;
            h.DonGiaNhap = 100;
            h.DonGiaBan = 150;
            h.GhiChu = "Test";
            h.MaNV = "NV01";
            bool result = themhang.ThemHang(h);
            Assert.IsTrue(result);
        }
        public void ThemHangTest1()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang themhang = new DAL_Hang();
            h.TenHang = "Bia";
            h.SoLuong = 5;
            h.DonGiaNhap = 140;
            h.DonGiaBan = 150;
            h.GhiChu = "Test";
            h.MaNV = "NV1";
            bool result = themhang.ThemHang(h);
            Assert.IsTrue(result);
        }
        public void XoaHangTest()
        {
            DAL_Hang xoahang = new DAL_Hang();
            bool result = xoahang.XoaHang(1);
            Assert.IsTrue(result);
        }

    }
}