using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class TheXe
    {
        My_DB mydb = new My_DB();
        public bool insertTheXe(String maThe, String baiXe, String trangThai, String maLoaiThe)
        {
            SqlCommand command = new SqlCommand("exec insertUpdateTheXe 'insert',@ma, @bx, @tt, @ml", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maThe;
            command.Parameters.Add("@bx", SqlDbType.Char).Value = baiXe;
            command.Parameters.Add("@tt", SqlDbType.NVarChar).Value = trangThai;
            command.Parameters.Add("@ml", SqlDbType.Char).Value = maLoaiThe;

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

        public bool updateTheXe(String maThe, String baiXe, String trangThai, String maLoaiThe)
        {
            SqlCommand command = new SqlCommand("exec insertUpdateTheXe 'update',@ma, @bx, @tt, @ml", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maThe;
            command.Parameters.Add("@bx", SqlDbType.Char).Value = baiXe;
            command.Parameters.Add("@tt", SqlDbType.NVarChar).Value = trangThai;
            command.Parameters.Add("@ml", SqlDbType.Char).Value = maLoaiThe;

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
        public bool deleteTheXe(String ma)
        {
            SqlCommand command = new SqlCommand("exec deleteTheXe @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = ma;
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
