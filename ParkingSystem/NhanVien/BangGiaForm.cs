using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ParkingSystem.NhanVien
{
    public partial class BangGiaForm : Form
    {
        public BangGiaForm()
        {
            InitializeComponent();
        }

        private void BangGiaForm_Load(object sender, EventArgs e)
        {
            dataGridViewBangGia.DataSource = Globals.getData(new SqlCommand("select * from view_BangGia"));
            Globals.makeUpViews(dataGridViewBangGia);
        }
    }
}
