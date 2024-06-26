using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Hang
    {
        private int maHang;
        private string tenHang;
        private int soLuong;
        private float donGiaBan;
        private float donGiaNhap;
        private string hinhAnh;
        private string ghiChu;
        private string maNV;
        public int MaHang { get;set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGiaBan { get; set; }
        public float DonGiaNhap { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
        public string MaNV { get; set; }

        public DTO_Hang(string tenHang, int soLuong, float donGiaBan, float donGiaNhap, string hinhAnh, string ghiChu, string maNV)
        {
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.donGiaBan = donGiaBan;
            this.donGiaNhap = donGiaNhap;
            this.hinhAnh = hinhAnh;
            this.ghiChu = ghiChu;
            this.maNV = maNV;
        }
        public DTO_Hang(int maHang,string tenHang, int soLuong, float donGiaBan, float donGiaNhap, string hinhAnh, string ghiChu, string maNV)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.donGiaBan = donGiaBan;
            this.donGiaNhap = donGiaNhap;
            this.hinhAnh = hinhAnh;
            this.ghiChu = ghiChu;
            this.maNV = maNV;
        }
        public DTO_Hang() { }
    }
}
