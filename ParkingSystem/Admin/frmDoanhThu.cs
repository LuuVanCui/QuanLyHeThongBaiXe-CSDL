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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            fillDataComboBox();
            String bx = comboBoxBX.SelectedValue.ToString();
            String lx = comboBoxLX.SelectedValue.ToString();
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            DoanhThu(bx,lx, dt1, dt2);
            
        }

        My_DB mydb = new My_DB();
        public void DoanhThu(String baiXe,String loaixe, DateTime dt1, DateTime dt2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec p_thongkeDoanhThu @dt1, @dt2, @bx, @lx", mydb.getConnection);
                cmd.Parameters.Add("@dt1", SqlDbType.DateTime).Value = dt1;
                cmd.Parameters.Add("@dt2", SqlDbType.DateTime).Value = dt2;
                cmd.Parameters.Add("@bx", SqlDbType.Char).Value = baiXe;
                cmd.Parameters.Add("@lx", SqlDbType.Char).Value = loaixe;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String bx = comboBoxBX.SelectedValue.ToString();
            String lx = comboBoxLX.SelectedValue.ToString();
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            DoanhThu(bx, lx, dt1, dt2);
        }

        void fillDataComboBox()
        {
            try

            {
                LoaiXe lx = new LoaiXe();
                String q = "select * from view_BaiXe";

                DataTable tb1 = new DataTable();
                tb1 = Globals.getData(new SqlCommand(q));
                tb1.Rows.Add(new Object[] { "All", "Tất Cả" });


                //comboBoxBaiXe.("Tất cả");
                comboBoxBX.DisplayMember = "Ten";
                comboBoxBX.ValueMember = "baixe_id";
                comboBoxBX.DataSource = tb1;
                //comboBoxBaiXe.SelectedItem= "Tất Cả";


                String q2 = "select * from view_Loaixe";
                DataTable tb2 = Globals.getData(new SqlCommand(q2));
                tb2.Rows.Add(new Object[] { "All", "Tất Cả" });

                comboBoxLX.DisplayMember = "TenLoaiXe";
                comboBoxLX.ValueMember = "MaLoaiXe";
                comboBoxLX.DataSource = tb2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
