using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class BaiXe
    {
        My_DB mydb = new My_DB();

        public bool insertBaiXe(String maBaiXe, String tenBaiXe, String diaChi, int sucChua)
        {
            SqlCommand command = new SqlCommand("exec p_BaiXe 'insert',@ma, @ten, @dc, @sc", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maBaiXe;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenBaiXe;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@sc", SqlDbType.Int).Value = sucChua;

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

        public bool updateBaiXe(String maBaiXe, String tenBaiXe, String diaChi, int sucChua)
        {
            SqlCommand command = new SqlCommand("exec p_BaiXe 'update',@ma, @ten, @dc, @sc", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = maBaiXe;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenBaiXe;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@sc", SqlDbType.Int).Value = sucChua;

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

        public bool deleteBaiXee(String maBaiXe)
        {
             SqlCommand command = new SqlCommand("exec p_BaiXe 'delete',@ma", mydb.getConnection);
                command.Parameters.Add("@ma", SqlDbType.Char).Value = maBaiXe;
               

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

      /*  public bool loaiXeExists(String ma)
        {
            SqlCommand command = new SqlCommand("", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = ma;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
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
            }
            return true;
        }*/
    }
}

