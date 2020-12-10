using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    public static class Globals
    {
        public static string serverName = "172.16.2.209";
        public static string username = "user1";
        public static string password = "1234";
        public static void makeUpViews(DataGridView gridView)
        {
            gridView.ReadOnly = true;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static DataTable getData(SqlCommand cmd)
        {
            My_DB mydb = new My_DB(serverName, username, password);
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            Application.Run(new EmployeeDashBoardForm());
        }
    }
}
