using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=pc\sqlexpress;Initial Catalog=QuanLiBanHang;Integrated Security=True");
        // 
       /* static string conStr = ConfigurationManager.ConnectionStrings["QLBH"].ToString();

        protected SqlConnection _con=new SqlConnection(conStr);*/
    }
}
