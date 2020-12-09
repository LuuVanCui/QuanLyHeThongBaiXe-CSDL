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
using ParkingSystem.Class;

namespace ParkingSystem
{
    public partial class TheXeForm : Form
    {
        public TheXeForm()
        {
            InitializeComponent();
        }

        TheXe theXe = new TheXe();

        private void TheXeForm_Load(object sender, EventArgs e)
        {
            string query = "select * from view_NVXemTheXe";
            dataGridViewTheXe.DataSource = theXe.getData(new SqlCommand(query));
        }
    }
}
