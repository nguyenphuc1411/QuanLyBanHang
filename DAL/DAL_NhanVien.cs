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
    public class DAL_NhanVien : DbConnect
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraDangNhap";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matkhau", nv.MatKhau);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool TrangThaiHoatDong(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TrangThaiHoatDong";
                cmd.Parameters.AddWithValue("email",email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool XacNhanEmailQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("@email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return false;
        }
        public void CapNhatMatKhauMoi(string email, string matKhau)
        {
            try
            {
                _conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _conn;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "TaoMatKhauMoi";
                sqlCommand.Parameters.AddWithValue("email", email);
                sqlCommand.Parameters.AddWithValue("matkhau", matKhau);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
            }
            finally { _conn.Close(); }
        }
        public string VaiTroNV(string email)
        {
            string vaiTro = "";
            try
            {
                _conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _conn;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "VaiTroNV";
                sqlCommand.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(sqlCommand.ExecuteScalar()) > 0)
                { //0 là nhân viên 1 là admin
                    vaiTro = "Admin";
                }
                else
                {
                    vaiTro = "NhanVien";
                }
                return vaiTro;
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return vaiTro;
        }
        public DataTable DanhSachNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _conn;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "DanhSachNV";
                DataTable dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());
                return dt;
            }
            finally { _conn.Close(); }
        }
        public bool LuuNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LuuNhanVien";
                cmd.Parameters.AddWithValue("@maNV",nv.MaNV);
                cmd.Parameters.AddWithValue("@email", nv.Email);
                cmd.Parameters.AddWithValue("@tenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@diaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@vaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("@tinhTrang", nv.TinhTrang);
                cmd.Parameters.AddWithValue("@matKhau", nv.MatKhau);
                if (Convert.ToInt16(cmd.ExecuteNonQuery()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return false;
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SuaNhanVien";
                cmd.Parameters.AddWithValue("@maNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@email", nv.Email);
                cmd.Parameters.AddWithValue("@tenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@diaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@vaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("@tinhTrang", nv.TinhTrang);
                if (Convert.ToInt16(cmd.ExecuteNonQuery()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return false;
        }
        public DataTable TimKiemNhanVien(string tenNV)
        {
            try
            {
                DataTable dt=new DataTable();
                _conn.Open();
                SqlCommand cmd= new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemNhanVien";
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally { _conn.Close(); }
        }
        public string TaoMaNhanVien()
        {
            string maNV="NV01";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType= System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayMaNVCaoNhat";
                string maCaoNhat = cmd.ExecuteScalar().ToString();
                int number = int.Parse(maCaoNhat.Substring(2));
                if (number < 9)
                {
                    maNV = "NV0" + ((number+1).ToString());
                }
                else maNV = "NV" +( (number+1).ToString());
            }
            finally
            {
                _conn.Close();
            }
            return maNV;
        }
        public bool XoaNhanVien(string maNV)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "XoaNhanVien";
                cmd.Parameters.AddWithValue("@maNV",maNV);
                if(cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return false;
        }
        public string LayMaNhanVien(string email)
        {
            try
            {
                string MaNV = null;
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayMaNhanVien";
                cmd.Parameters.AddWithValue("@email", email);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MaNV = result.ToString();
                }

                return MaNV;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void GhiNhoMatKhau(string email,string pass)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "LuuGhiNhoMatKhau";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue ("@pass", pass);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
        }
        public string MatKhauDaNho()
        {
            string mk = "";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MatKhauDaNho";
                if(cmd.ExecuteScalar()!=null)
                {
                    mk = cmd.ExecuteScalar().ToString();
                }
                return mk;
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return mk;
        }
        public string EmailDaNho()
        {
            string email="";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmailDaNho";
                if (cmd.ExecuteScalar()!=null)
                {
                    email=cmd.ExecuteScalar().ToString();
                }
                return email;
            }
            catch (Exception e) { }
            finally { _conn.Close(); }
            return email;
        }
    }
}
