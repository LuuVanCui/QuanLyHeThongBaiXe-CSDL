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
        BaiXe bx = new BaiXe();
        
        private void frmBaiXe_Load(object sender, EventArgs e)
        {

            string query = "select * from view_BaiXe";
            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));
            
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

        My_DB mydb = new My_DB();
        private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                String key = textBoxSearch.Text;
                SqlCommand cmd = new SqlCommand("exec p_searchBaiXe @key", mydb.getConnection);
                cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    if (bx.insertBaiXe(textBoxBaiXeID.Text, textBoxTenBaiXe.Text, textBoxAddress.Text, Convert.ToInt32(textBoxSlot.Text)))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmBaiXe_Load(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
                    }
                }
                else
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    if (bx.updateBaiXe(textBoxBaiXeID.Text, textBoxTenBaiXe.Text, textBoxAddress.Text, Convert.ToInt32(textBoxSlot.Text)))
                    {
                        MessageBox.Show("cập nhật thành công!", "Cập nhật bãi xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmBaiXe_Load(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
                    }
                }
                else
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhật bãi xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBoxBaiXeID.Text.Trim() != "")
                {
                    String baixeID = textBoxBaiXeID.Text;
                   if(bx.deleteBaiXee(baixeID))
                    {
                        MessageBox.Show("Xóa thành công!", "Xóa bãi xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmBaiXe_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa bãi xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxBaiXeID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBoxAddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBoxTenBaiXe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBoxSlot.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
