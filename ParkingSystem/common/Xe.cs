using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class Xe
    {
        // My_DB mydb = new My_DB("192.168.56.1", "hieu02", "12345678");
        //My_DB mydb = new My_DB("DESKTOP-8AHUGCC", "sa", "12345678");
        My_DB mydb = new My_DB();

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

        public bool insertUpdateXe(string statementType, string bienSo, 
            MemoryStream anhTruoc, MemoryStream anhSau, DateTime thoiGianVao, 
            DateTime thoiGianRa, string maTheXe, string maLoaiXe, string baixeId)
        {

            string query = "exec p_insertUpdateXe @statementType, @BienSo, " +
                "@AnhTruoc, @AnhSau, @ThoiGianVao, @ThoiGianRa, @MaTheXe, " +
                "@MaLoaiXe, @baixe_id";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            command.Parameters.Add("@statementType", System.Data.SqlDbType.VarChar).Value = statementType;
            command.Parameters.Add("@BienSo", System.Data.SqlDbType.VarChar).Value = bienSo;
            command.Parameters.Add("@AnhTruoc", System.Data.SqlDbType.Image).Value = anhTruoc.ToArray();
            command.Parameters.Add("@AnhSau", System.Data.SqlDbType.Image).Value = anhSau.ToArray();
            command.Parameters.Add("@ThoiGianVao", SqlDbType.DateTime).Value = thoiGianVao;
            command.Parameters.Add("@ThoiGianRa", SqlDbType.DateTime).Value = thoiGianRa;
            command.Parameters.Add("@MaTheXe", SqlDbType.Char).Value = maTheXe;
            command.Parameters.Add("@MaLoaiXe", SqlDbType.Char).Value = maLoaiXe;
            command.Parameters.Add("@baixe_id", SqlDbType.Char).Value = baixeId;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
