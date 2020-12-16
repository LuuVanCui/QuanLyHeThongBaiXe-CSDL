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
<<<<<<< HEAD
                kh.insertKhachHang(textBoxID.Text, textBoxTenKH.Text, textBoxSDT.Text);
                MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmQuanLyKhachHang_Load(sender, e);
=======
                if (textBoxSDT.Text.Trim() != "" && textBoxTenKH.Text.Trim() != "")
                {
                    if (kh.insertKhachHang(textBoxTenKH.Text, textBoxSDT.Text))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQuanLyKhachHang_Load(sender, e);
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
>>>>>>> 6690441... cap nhat 1 so form
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

            DataTable tb1 = new DataTable();
            tb1 = Globals.getData(new SqlCommand(sql));
            tb1.Rows.Add(new Object[] { "all", "Tất Cả" });
            comboBoxbaiXe.DataSource = tb1;
        }

        My_DB mydb = new My_DB();
        private void comboBoxbaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "exec p_findKHByBaiXeID @id";
                String bxID = comboBoxbaiXe.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.Char).Value = bxID;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                String key = textBoxSearch.Text;
                SqlCommand cmd = new SqlCommand("exec p_searchKH @key", mydb.getConnection);
                cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("Bạn có thực sự muốn xóa xe vừa chọn?", "Xóa Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBoxSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
