using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private string dienThoai;
        private string tenKhach;
        private string diaChi;
        private string phai;
        private string maNV;

        public string DienThoai { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string Phai { get; set; }
        public string MaNV { get; set; }

        public DTO_KhachHang(string dienThoai, string tenkhach, string diaChi, string phai, string maNV)
        {
            this.dienThoai = dienThoai;
            this.tenKhach = tenkhach;
            this.diaChi = diaChi;
            this.phai = phai;
            this.maNV = maNV;
        }
        public DTO_KhachHang() { }
    }
}
