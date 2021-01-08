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
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
            comboBoxTrangThai.SelectedIndex = 0;
            Globals.makeUpViews(dataGridView1);
        }

        My_DB mydb = new My_DB();
        Users nv = new Users();
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            String q = "select * from view_BaiXe";

            DataTable tb1 = new DataTable();
            tb1 = Globals.getData(new SqlCommand(q));
            comboBoxBaiXe.DisplayMember = "Ten";
            comboBoxBaiXe.ValueMember = "baixe_id";
            comboBoxBaiXe.DataSource = tb1;



            dataGridView1.DataSource = Globals.getData((new SqlCommand("select * from view_Users", mydb.getConnection)));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxMK.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxSdt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True")
            {
                comboBoxTrangThai.SelectedIndex = 0;
            }
            else
            {
                comboBoxTrangThai.SelectedIndex = 1;
            }

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Xác nhận thêm nhân viên", "Thêm nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    if (verif())

                    {
                        String bx = comboBoxBaiXe.SelectedValue.ToString();
                        int tt;
                        if (comboBoxTrangThai.Text == "Đang làm")
                        {
                            tt = 1;
                        }
                        else
                        {
                            tt = 0;
                        }
                        if (nv.insertNhanVien(textBoxID.Text, textBoxUsername.Text, textBoxMK.Text, textBoxName.Text, textBoxSdt.Text, tt, bx))
                        {
                            MessageBox.Show("Thêm nhân viên thành công!", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLNhanVien_Load(sender, e);

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
                    MessageBox.Show(ex.Message, "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Xác nhận sửa nhân viên", "Sửa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    if (verif())

                    {
                        String bx = comboBoxBaiXe.SelectedValue.ToString();
                        int tt;
                        if (comboBoxTrangThai.Text == "Đang làm")
                        {
                            tt = 1;
                        }
                        else
                        {
                            tt = 0;
                        }
                        if (nv.updateNhanVien(textBoxID.Text, textBoxUsername.Text, textBoxMK.Text, textBoxName.Text, textBoxSdt.Text, tt, bx))
                        {
                            MessageBox.Show("Cập nhật nhân viên thành công!", "Cập nhật nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLNhanVien_Load(sender, e);

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
                    MessageBox.Show(ex.Message, "Cập nhật nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Bạn có thực sự muốn xóa nhân viên vừa chọn?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {

                    if (textBoxID.Text.Trim() != "")
                    {
                        String id = textBoxID.Text;
                        if (nv.deleteNhanVien(id))
                        {
                            MessageBox.Show("Xóa thành công!", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLNhanVien_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Không thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        bool verif()
        {
            if (textBoxID.Text.Trim() == "" ||
                textBoxMK.Text.Trim() == "" ||
                textBoxName.Text.Trim() == "" ||
                textBoxSdt.Text.Trim() == "" ||
                textBoxUsername.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String key = textBoxSearch.Text;
                SqlCommand cmd = new SqlCommand("exec p_searchUsers @key", mydb.getConnection);
                cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
