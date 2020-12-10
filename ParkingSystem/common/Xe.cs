using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class Xe
    {
        // My_DB mydb = new My_DB("192.168.56.1", "hieu02", "12345678");
        My_DB mydb = new My_DB("DESKTOP-8AHUGCC", "sa", "12345678");

        public DataTable showXe(String maLoaiXe, String baiXeID)
        {
            SqlCommand cmd = new SqlCommand("exec p_showXe @maLX, @baiXeID");
            cmd.Connection = mydb.getConnection;
            cmd.Parameters.Add("@maLX", SqlDbType.Char).Value = maLoaiXe;
            cmd.Parameters.Add("@baiXeID", SqlDbType.Char).Value = baiXeID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable searchXe(String searchKey)
        {
            SqlCommand cmd = new SqlCommand("exec p_searchXe @key");
            cmd.Connection = mydb.getConnection;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = searchKey;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
