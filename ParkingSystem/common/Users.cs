using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class Users
    {
        My_DB mydb = new My_DB();
        public bool insertNhanVien(String id, String TenDangNhap, String MatKhau, String Ten, String SDT, int TrangThai, String baixe_id)
        {
            SqlCommand command = new SqlCommand("exec p_Users_insertUpdate 'insert',@id, @TenDangNhap, @MatKhau, @Ten, @SDT, @TrangThai, @baixe_id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Char).Value = id;
            command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar).Value = TenDangNhap;
            command.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = MatKhau;
            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = Ten;
            command.Parameters.Add("@SDT", SqlDbType.VarChar).Value = SDT;
            command.Parameters.Add("@TrangThai", SqlDbType.Int).Value = TrangThai;
            command.Parameters.Add("@baixe_id", SqlDbType.Char).Value = baixe_id;

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
        public bool updateNhanVien(String id, String TenDangNhap, String MatKhau, String Ten, String SDT, int TrangThai, String baixe_id)
        {
            SqlCommand command = new SqlCommand("exec p_Users_insertUpdate 'update',@id, @TenDangNhap, @MatKhau, @Ten, @SDT, @TrangThai, @baixe_id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Char).Value = id;
            command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar).Value = TenDangNhap;
            command.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = MatKhau;
            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = Ten;
            command.Parameters.Add("@SDT", SqlDbType.VarChar).Value = SDT;
            command.Parameters.Add("@TrangThai", SqlDbType.Int).Value = TrangThai;
            command.Parameters.Add("@baixe_id", SqlDbType.Char).Value = baixe_id;

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
        public bool deleteNhanVien(String id)
        {
            SqlCommand command = new SqlCommand("exec p_Users_Delete @id ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Char).Value = id;
            
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
