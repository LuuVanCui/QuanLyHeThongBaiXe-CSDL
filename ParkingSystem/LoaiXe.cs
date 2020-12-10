using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class LoaiXe
    {
        My_DB mydb = new My_DB("192.168.56.1", "hieu02", "12345678");
        public DataTable getAllLoaiXe()
        {
            SqlCommand cmd = new SqlCommand("select * from view_LoaiXe");
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertLoaiXe(String maLoaiXe, String tenLoaiXe)
        {
            SqlCommand command = new SqlCommand("exec p_insertUpdateLoaiXe 'insert',@ma, @ten", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maLoaiXe;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenLoaiXe;

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

        public bool updateLoaiXe(String maLoaiXe, String tenLoaiXe)
        {
            SqlCommand command = new SqlCommand("exec p_insertUpdateLoaiXe 'update',@ma, @ten", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maLoaiXe;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenLoaiXe;

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

        public bool deleteLoaiXe(String maLoaiXe, String tenLoaiXe="")
        {
            SqlCommand command = new SqlCommand("exec p_insertUpdateLoaiXe 'delete',@ma, @ten", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maLoaiXe;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenLoaiXe;

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

        public bool loaiXeExists(String ma)
        {
            SqlCommand command = new SqlCommand("", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = ma;

            /* SqlDataAdapter adapter = new SqlDataAdapter(command);
             DataTable table = new DataTable();

             adapter.Fill(table);

             mydb.openConnection();
             if ((table.Rows.Count == 0))
             {
                 return false;
             }
             else
             {
                 return true;
             }*/
            return true;
        }
    }
}
