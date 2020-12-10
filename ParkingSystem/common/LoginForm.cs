using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (My_DB.isConnectExist(textBoxServerName.Text,
                textBox_username.Text, textBox_password.Text))
            {
                MessageBox.Show("Login Successfully!");
            }
            else
            {
                MessageBox.Show("Login error!");
            }
        }
    }
}
