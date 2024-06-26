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
    public class DAL_NhanVienTests
    {
        [TestMethod()]
        public void NhanVienDangNhapTest1()
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien login = new DAL_NhanVien();
            nv.Email = "";
            nv.MatKhau = "123";
            bool result = login.NhanVienDangNhap(nv);
            Assert.IsFalse(result);
        }
        public void NhanVienDangNhapTest2()
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien login = new DAL_NhanVien();
            nv.Email = "nguyenphuc14112003@gmail.com";
            nv.MatKhau = "123";
            bool result = login.NhanVienDangNhap(nv);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LuuNhanVienTest()
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien themnv=new DAL_NhanVien();
            nv.MaNV = themnv.TaoMaNhanVien();
            nv.Email = "nguyenphuc123@gmail.com";
            nv.TenNV = "Phúc Nguyễn";
            nv.DiaChi = "Bình Định";
            nv.VaiTro = 0;
            nv.TinhTrang = 1;
            nv.MatKhau = "123";
            bool result = themnv.LuuNhanVien(nv);
            Assert.IsFalse(result);
        }
        public void LuuNhanVienTest1()
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            DAL_NhanVien themnv = new DAL_NhanVien();
            nv.MaNV = themnv.TaoMaNhanVien();
            nv.Email = "";
            nv.TenNV = "Phúc Nguyễn";
            nv.DiaChi = "Bình Dương";
            nv.VaiTro = 0;
            nv.TinhTrang = 1;
            nv.MatKhau = "123";
            bool result = themnv.LuuNhanVien(nv);
            Assert.IsFalse(result);
        }
    }
}