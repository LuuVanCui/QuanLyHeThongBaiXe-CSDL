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
        //public static string serverName = "192.168.44.49";
        //public static string username = "user1";
        //public static string password = "1234";

        public static string baixeId = "spktB";
        public static void makeUpViews(DataGridView gridView)
        {
            gridView.ReadOnly = true;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridView.AllowUserToAddRows = false;
        }

        public static DataTable getData(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            try
            {
                //My_DB mydb = new My_DB(serverName, username, password);
                My_DB mydb = new My_DB();
                cmd.Connection = mydb.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                adapter.Fill(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            Application.Run(new LoginForm());
           // Application.Run(new AdminDashboard());
           // Application.Run(new EmployeeDashBoardForm());
        }
    }
}
