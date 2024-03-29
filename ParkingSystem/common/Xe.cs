﻿using System;
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
            SqlCommand cmd = new SqlCommand("select * from f_searchXe(@key)");
            cmd.Connection = mydb.getConnection;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = searchKey;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateXe(string maTheXe, string bienSo, DateTime thoiGianRa)
        {
            string query = "exec p_insertUpdateXe 'update', " + Globals.baixeId + ", @mathexe, @bienso, @thoigianra";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            command.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
            command.Parameters.Add("@bienso", System.Data.SqlDbType.VarChar).Value = bienSo;
            command.Parameters.Add("@ThoiGianRa", SqlDbType.DateTime).Value = thoiGianRa;

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

        public bool insertXe(string bienSo, MemoryStream anhTruoc, MemoryStream anhSau, DateTime thoiGianVao, 
            string maTheXe, string maLoaiXe, string baixeId)
        {
            string query = "exec p_insertUpdateXe 'insert', @baixe_id, @MaTheXe, " +
                "@BienSo, null, @ThoiGianVao, @AnhTruoc, " +
                "@AnhSau, @MaLoaiXe";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            command.Parameters.Add("@MaTheXe", SqlDbType.Char).Value = maTheXe;
            command.Parameters.Add("@BienSo", System.Data.SqlDbType.VarChar).Value = bienSo;
            command.Parameters.Add("@ThoiGianVao", SqlDbType.DateTime).Value = thoiGianVao;
            command.Parameters.Add("@AnhTruoc", System.Data.SqlDbType.Image).Value = anhTruoc.ToArray();
            command.Parameters.Add("@AnhSau", System.Data.SqlDbType.Image).Value = anhSau.ToArray();
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
        public bool deleteXe(String baixe, String lx, DateTime time1, DateTime time2)
        {
            SqlCommand command = new SqlCommand("exec deleteXeByDay @bx, @lx, @t1, @t2", mydb.getConnection);
            command.Parameters.Add("@bx", SqlDbType.Char).Value = baixe;
            command.Parameters.Add("@lx", SqlDbType.Char).Value = lx;
            command.Parameters.Add("@t1", SqlDbType.DateTime).Value = time1;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = time2;

            mydb.openConnection();
            if (command.ExecuteNonQuery() >= 1)
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
