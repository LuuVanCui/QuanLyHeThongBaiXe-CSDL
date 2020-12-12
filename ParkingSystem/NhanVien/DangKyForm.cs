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
    public partial class DangKyForm : Form
    {
        public DangKyForm()
        {
            InitializeComponent();
        }

        private void DangKyForm_Load(object sender, EventArgs e)
        {
            comboBoxMaKH.DataSource = Globals.getData(new SqlCommand("select * from view_KhachHang"));
            comboBoxMaKH.DisplayMember = "kh_id";
            comboBoxMaKH.ValueMember = "ten";

            comboBoxLoaiXe.DataSource = Globals.getData(new SqlCommand("select * from view_Loaixe"));
            comboBoxLoaiXe.DisplayMember = "TenLoaiXe";
            comboBoxLoaiXe.ValueMember = "TenLoaiXe";
        }
    }
}
