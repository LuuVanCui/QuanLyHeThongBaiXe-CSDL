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
using ParkingSystem.common;

namespace ParkingSystem.NhanVien
{
    public partial class DangKyForm : Form
    {
        public DangKyForm()
        {
            InitializeComponent();
        }

        DangKy dangKy = new DangKy();

        private void DangKyForm_Load(object sender, EventArgs e)
        {
            DataTable tableKhachHang = Globals.getData(new SqlCommand("select * from view_KhachHang"));
            comboBoxMaKH.DataSource = tableKhachHang;
            comboBoxMaKH.DisplayMember = "Mã KH";
            comboBoxMaKH.ValueMember = "Mã KH";

            comboBoxTenKH.DataSource = tableKhachHang;
            comboBoxTenKH.DisplayMember = "Tên KH";
            comboBoxTenKH.ValueMember = "Tên KH";

            comboBoxLoaiTheXe.DataSource = Globals.getData(new SqlCommand("select * from f_layLoaiTheXeDangKy()"));
            comboBoxLoaiTheXe.DisplayMember = "TenLoaiThe";
            comboBoxLoaiTheXe.ValueMember = "MaLoaiThe";

            dataGridViewDangKy.DataSource = Globals.getData(new SqlCommand("select * from view_DangKy"));
            Globals.makeUpViews(dataGridViewDangKy);

            dateTimePickerNgayKetThuc.Enabled = false;

        }

        private void comboBoxLoaiTheXe_DropDownClosed(object sender, EventArgs e)
        {
            string maLoaiThe = comboBoxLoaiTheXe.SelectedValue.ToString().Trim();
            string query = "select * from f_layMaTheXeTheoLoaiThe(@maloaithe, @baixeid)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@maloaithe", SqlDbType.Char).Value = maLoaiThe;
            command.Parameters.Add("@baixeid", SqlDbType.Char).Value = Globals.baixeId;

            comboBoxMaTheXe.DataSource = Globals.getData(command);
            comboBoxMaTheXe.DisplayMember = "MaTheXe";
            comboBoxMaTheXe.ValueMember = "MaTheXe";

            DateTime ngayBatDau = dateTimePickerNgayBatDau.Value;

            if (maLoaiThe == "TheTuan")
            {
                dateTimePickerNgayKetThuc.Value = ngayBatDau.AddDays(7);
            }
            else if (maLoaiThe == "TheThang")
            {
                dateTimePickerNgayKetThuc.Value = ngayBatDau.AddDays(30);
            }
        }

        private void dataGridViewDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxMaKH.SelectedValue = dataGridViewDangKy.CurrentRow.Cells[0].Value;
            comboBoxMaTheXe.Text = dataGridViewDangKy.CurrentRow.Cells[2].Value.ToString();
            comboBoxLoaiTheXe.Text = dataGridViewDangKy.CurrentRow.Cells[3].Value.ToString();
            dateTimePickerNgayBatDau.Value = Convert.ToDateTime(dataGridViewDangKy.CurrentRow.Cells[4].Value.ToString());
            dateTimePickerNgayKetThuc.Value = Convert.ToDateTime(dataGridViewDangKy.CurrentRow.Cells[5].Value.ToString());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text;
            string query = "select * from f_timKiemTrongViewDangKy(@query)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@query", SqlDbType.NVarChar).Value = searchQuery;
            dataGridViewDangKy.DataSource = Globals.getData(command);
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            string kh_id = comboBoxMaKH.Text;
            string maTheXe = comboBoxMaTheXe.Text;
            DateTime ngayCap = dateTimePickerNgayBatDau.Value;
            DateTime ngayHetHan = dateTimePickerNgayKetThuc.Value;
            try
            {
                dangKy.insertDangKy(kh_id, maTheXe, ngayCap, ngayHetHan);
                MessageBox.Show("Đăng ký thành công!", "Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DangKyForm_Load(sender, e);
        }

        private void buttonTraThe_Click(object sender, EventArgs e)
        {

        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {

        }
    }
}
