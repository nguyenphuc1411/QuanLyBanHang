using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private string maNV;
        private string email;
        private string tenNV;
        private string diaChi;
        private int vaiTro;
        private int tinhTrang;
        private string matKhau;


        public string MaNV { get; set; }
        public string Email { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public int VaiTro { get; set; }
        public int TinhTrang { get; set; }
        public string MatKhau { get; set; }
        public DTO_NhanVien(string maNV, string email, string tenNV, string diaChi, int vaiTro, int tinhTrang, string matKhau)
        {
            this.maNV = maNV;
            this.email = email;
            this.tenNV = tenNV;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.tinhTrang = tinhTrang;
            this.matKhau = matKhau;
        }
        public DTO_NhanVien(string maNV, string email, string tenNV, string diaChi, int vaiTro, int tinhTrang)
        {
            this.maNV = maNV;
            this.email = email;
            this.tenNV = tenNV;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.tinhTrang = tinhTrang;
        }
        public DTO_NhanVien() { }
        public DTO_NhanVien(string email, string matKhau)
        {
            this.email = email;
            this.matKhau = matKhau;
        }
    }
}
