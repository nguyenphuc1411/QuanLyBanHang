using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Hang:DbConnect
    {
        public DataTable DanhSachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHang";
                cmd.Connection = _conn;
                dt.Load(cmd.ExecuteReader());
            }
            finally { _conn.Close(); }
            return dt;
        }
        public bool ThemHang(DTO_Hang h)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd=new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "ThemHang";
                cmd.Parameters.AddWithValue("@TenHang",h.TenHang);
                cmd.Parameters.AddWithValue("@SoLuong", h.SoLuong);
                cmd.Parameters.AddWithValue("@DonGiaBan", h.DonGiaBan);
                cmd.Parameters.AddWithValue("@DonGiaNhap", h.DonGiaNhap);
                cmd.Parameters.AddWithValue("@HinhAnh", h.HinhAnh);
                cmd.Parameters.AddWithValue("@GhiChu", h.GhiChu);
                cmd.Parameters.AddWithValue("@MaNV", h.MaNV);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally { _conn.Close (); }
            return false;
        }
        public bool SuaHang(DTO_Hang h)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaHang";
                cmd.Parameters.AddWithValue("@MaHang", h.MaHang);
                cmd.Parameters.AddWithValue("@TenHang", h.TenHang);
                cmd.Parameters.AddWithValue("@SoLuong", h.SoLuong);
                cmd.Parameters.AddWithValue("@DonGiaBan", h.DonGiaBan);
                cmd.Parameters.AddWithValue("@DonGiaNhap", h.DonGiaNhap);
                cmd.Parameters.AddWithValue("@HinhAnh", h.HinhAnh);
                cmd.Parameters.AddWithValue("@GhiChu", h.GhiChu);
                cmd.Parameters.AddWithValue("@MaNV", h.MaNV);
                cmd.ExecuteNonQuery();
                return true;
            }
            finally { _conn.Close(); }
            return false;

        }
        public bool XoaHang(int maHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaHang";
                cmd.Parameters.AddWithValue("@MaHang", maHang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally { _conn.Close(); }
            return false;
        }
        public DataTable TimKiemHang(DTO_Hang h)
        {
            DataTable dt = new DataTable();
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemHang";
                dt.Load(cmd.ExecuteReader());
            }
            finally { _conn.Close(); }
            return dt;
        }
        public bool KiemTraID(int MaHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraID";
                cmd.Parameters.AddWithValue("@MaHang", MaHang);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return false;
        }
        public DataTable ThongKeHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeSP";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { _conn.Close(); }
        }
        public DataTable ThongKeTonKho()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeTonKho";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { _conn.Close(); }

        }
    }
}
