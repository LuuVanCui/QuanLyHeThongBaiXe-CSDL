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
    public partial class frmQLLoaiXe : Form
    {
        public frmQLLoaiXe()
        {
            InitializeComponent();
        }

        My_DB mydb = new My_DB("192.168.56.1","hieu02","12345678");
        LoaiXe loaixe = new LoaiXe();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQLLoaiXe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = loaixe.getAllLoaiXe();
            dataGridView1.Columns["TenLoaiXe"].HeaderText = "Tên loại xe";
            dataGridView1.Columns["MaLoaiXe"].HeaderText = "Mã loại xe";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            String ma = textBoxMaLoaiXe.Text.Trim();
            String ten = textBoxTenLoaiXe.Text.Trim();

            if (verif())
            {

            }
        }

        bool verif()
        {
            if (textBoxMaLoaiXe.Text.Trim() == ""
                || textBoxTenLoaiXe.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
