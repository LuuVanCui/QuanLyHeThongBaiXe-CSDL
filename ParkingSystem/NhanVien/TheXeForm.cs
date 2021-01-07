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
            SqlCommand cmd = new SqlCommand("select * from f_NVXemTheXe(@baixeId)");
            cmd.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            dataGridViewTheXe.DataSource = Globals.getData(cmd);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text;
            string query = "select * from f_timKiemTheXe(@query, @baixeId)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@query", SqlDbType.NVarChar).Value = searchQuery;
            command.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            dataGridViewTheXe.DataSource = Globals.getData(command);
        }
    }
}
