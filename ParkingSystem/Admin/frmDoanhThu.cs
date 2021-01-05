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

namespace ParkingSystem.Admin
{
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            String bx = "spktE";
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            DoanhThu(bx, dt1, dt2);
        }

        My_DB mydb = new My_DB();
        public void DoanhThu(String baiXe, DateTime dt1, DateTime dt2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec p_thongkeDoanhThu @dt1, @dt2, @bx", mydb.getConnection);
                cmd.Parameters.Add("@dt1", SqlDbType.DateTime).Value = dt1;
                cmd.Parameters.Add("@dt2", SqlDbType.DateTime).Value = dt2;
                cmd.Parameters.Add("@bx", SqlDbType.Char).Value = baiXe;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
