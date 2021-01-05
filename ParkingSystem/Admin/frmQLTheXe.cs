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
    public partial class frmQLTheXe : Form
    {
        public frmQLTheXe()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }

        private void frmQLTheXe_Load(object sender, EventArgs e)
        {
            comboBoxLoaiThe.SelectedText = "Vãng lai";
            comboBoxTrangThai.SelectedText = "Sẵn dùng";

            string query = "select * from view_AdminXemTheXe";
            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));

            String q = "select * from view_BaiXe";

            DataTable tb1 = new DataTable();
            tb1 = Globals.getData(new SqlCommand(q));
            comboBoxBaiXe.DisplayMember = "Ten";
            comboBoxBaiXe.ValueMember = "baixe_id";
            comboBoxBaiXe.DataSource = tb1;
        }
    }
}
