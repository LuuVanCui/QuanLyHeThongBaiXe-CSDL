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

namespace ParkingSystem
{
    public partial class TheXeForm : Form
    {
        public TheXeForm()
        {
            InitializeComponent();
        }

        private void TheXeForm_Load(object sender, EventArgs e)
        {
            Globals.makeUpViews(dataGridViewTheXe);
            string query = "select * from view_NVXemTheXe";
            dataGridViewTheXe.DataSource = Globals.getData(new SqlCommand(query));
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text;
            string query = "select * from f_timKiemTheXe(@query)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@query", SqlDbType.NVarChar).Value = searchQuery;
            dataGridViewTheXe.DataSource = Globals.getData(command);
        }
    }
}
