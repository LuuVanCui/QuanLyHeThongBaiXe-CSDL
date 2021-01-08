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
    public partial class frmQLLoaiXe : Form
    {
        public frmQLLoaiXe()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }
        My_DB mydb = new My_DB();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQLLoaiXe_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from view_LoaiXe", mydb.getConnection);
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaLoaiXe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTenLoaiXe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String key = textBoxTimKiem.Text;
                SqlCommand cmd = new SqlCommand("exec p_searchLoaiXe @key", mydb.getConnection);
                cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        LoaiXe lx = new LoaiXe();
        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaLoaiXe.Text.Trim() != "" && textBoxTenLoaiXe.Text.Trim() != "")
                {
                    if (lx.insertLoaiXe(textBoxMaLoaiXe.Text, textBoxTenLoaiXe.Text))
                    {
                        MessageBox.Show("Thêm loại xe thành công!", "Thêm loại xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLLoaiXe_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm loại xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaLoaiXe.Text.Trim() != "" && textBoxTenLoaiXe.Text.Trim() != "")
                {
                    if (lx.updateLoaiXe(textBoxMaLoaiXe.Text, textBoxTenLoaiXe.Text))
                    {
                        MessageBox.Show("Cập nhật loại xe thành công!", "Cập nhật loại xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLLoaiXe_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhật loại xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Bạn có thực sự muốn xóa loại xe vừa chọn?", "Xóa loại Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    if (textBoxMaLoaiXe.Text.Trim() != "" && textBoxTenLoaiXe.Text.Trim() != "")
                    {
                        if (lx.deleteLoaiXe(textBoxMaLoaiXe.Text))
                        {
                            MessageBox.Show("Xóa loại xe thành công!", "Xóa loại xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLLoaiXe_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn hãy nhập đầy đủ thông tin!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa loại xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
