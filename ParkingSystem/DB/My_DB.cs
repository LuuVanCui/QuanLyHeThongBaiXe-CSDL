using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.DB
{
    class My_DB
    {
        SqlConnection con;
        public My_DB(string serverName, string username, string password)
        {
            con = new SqlConnection("Data Source=" + serverName + ";Initial Catalog=PARKING;User ID=" + username + ";Password=" + password);
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
