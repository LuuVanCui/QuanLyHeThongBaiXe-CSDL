using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    class My_DB
    {
        SqlConnection con = new SqlConnection();

        public My_DB()
        {
            string cs = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=PARKING;Integrated Security=True";
           // string cs = @"Data Source=DESKTOP-8AHUGCC;Initial Catalog=PARKING;Integrated Security=True";
            con.ConnectionString = cs;
        }

        public My_DB(string serverName, string username, string password)
        {
            string cs = "Data Source=" + serverName + ";Initial Catalog=PARKING;User ID=" + username + ";Password=" + password;
            con.ConnectionString = cs;
        }

        public static bool isConnectExist(string serverName, string username, string password)
        {
            try
            {
                string cs = "Data Source=" + serverName + ";Initial Catalog=PARKING;User ID=" + username + ";Password=" + password;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                }
            } catch(Exception)
            {
                return false;
            }
            return true;
        }

        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
