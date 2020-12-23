using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ParkingSystem.common
{
    class KhachHang
    {
        //My_DB mydb = new My_DB(Globals.serverName, Globals.username, Globals.password);
        My_DB mydb = new My_DB();
        public bool insertKhachHang(string id, string name, string phone)
        {
            string query = "exec p_InsertKhachHang @id, @name, @phone";
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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

        public bool updateKhachHang(string id, string name, string phone)
        {
            string query = "exec p_updateKhachHang @id, @name, @phone";
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Char).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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
