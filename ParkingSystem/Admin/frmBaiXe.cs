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
    public partial class frmBaiXe : Form
    {
        public frmBaiXe()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }
       // BaiXe bx = new BaiXe();
        private void frmBaiXe_Load(object sender, EventArgs e)
        {

            string query = "select * from view_BaiXe";
            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                   /* if (bx.insertBaiXe(textBoxBaiXeID.Text, textBoxTenBaiXe.Text, textBoxAddress.Text, Convert.ToInt32(textBoxSlot.Text)))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmBaiXe_Load(sender, e);

                    }*/
                }
                else
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

        }

        bool verif()
        {
            if (textBoxBaiXeID.Text.Trim() == ""
                || textBoxSlot.Text.Trim() == ""
                || textBoxTenBaiXe.Text.Trim() == ""
                || textBoxAddress.Text.Trim() == ""
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
