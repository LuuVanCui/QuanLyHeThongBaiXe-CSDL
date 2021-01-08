using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.NhanVien;

namespace ParkingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(isExsistUser(textBox_username.Text, textBox_password.Text).ToString());

                if (isExsistUser(textBox_username.Text, textBox_password.Text)==2)
                {
                    EmployeeDashBoardForm ed = new EmployeeDashBoardForm();
                    ed.ShowDialog();
                }
                else if(isExsistUser(textBox_username.Text, textBox_password.Text) == 1)
                {
                    AdminDashboard ad = new AdminDashboard();
                    ad.ShowDialog();
                }
            
               // MessageBox.Show("Login Successfully!");
        }
            
        

        int isExsistUser(String uname, String pass)
        {
            My_DB mydb = new My_DB();
            string query = "select dbo.f_checkLogin(@un,@pw)";
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = uname;
            cmd.Parameters.Add("@pw", SqlDbType.VarChar).Value = pass;

            DataTable tb = new DataTable();
            tb = Globals.getData(cmd);
            string r = tb.Rows[0][0].ToString();
           // MessageBox.Show(r);
            if (r == "2")
                return 2;
            else if (r == "1")
                return 1;
            return 0;
        }
    }
}
