using ParkingSystem.common;
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
    public partial class frmQuanLyKhachHang : Form
    {
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            fillComboBoxBaiXe();

        }
        KhachHang kh = new KhachHang();
        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            Globals.makeUpViews(dataGridView1);
            string query = "select * from view_KhachHang";
            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                kh.insertKhachHang(textBoxID.Text, textBoxTenKH.Text, textBoxSDT.Text);
                MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmQuanLyKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void fillComboBoxBaiXe()
        {
            String sql = "select * from view_BaiXe";
            comboBoxbaiXe.ValueMember = "baixe_id";
            comboBoxbaiXe.DisplayMember = "ten";
            comboBoxbaiXe.DataSource = Globals.getData(new SqlCommand(sql));
        }
    }
}
