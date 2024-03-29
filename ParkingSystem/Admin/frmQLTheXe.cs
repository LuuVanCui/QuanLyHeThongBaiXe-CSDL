﻿using ParkingSystem.common;
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
    public partial class frmQLTheXe : Form
    {
        public frmQLTheXe()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }

        private void frmQLTheXe_Load(object sender, EventArgs e)
        {
            try
            {
              

                string query = "select * from view_XemTheXe";
                dataGridView1.DataSource = Globals.getData(new SqlCommand(query));

                String q = "select * from view_BaiXe";
                DataTable tb1 = new DataTable();
                tb1 = Globals.getData(new SqlCommand(q));
                comboBoxBaiXe.DisplayMember = "Ten";
                comboBoxBaiXe.ValueMember = "baixe_id";
                comboBoxBaiXe.DataSource = tb1;

                String q2 = "select * from LoaiTheXe";
                DataTable tb2 = new DataTable();
                tb2 = Globals.getData(new SqlCommand(q2));
                comboBoxLoaiThe.DisplayMember = "TenLoaiThe";
                comboBoxLoaiThe.ValueMember = "MaLoaiThe";
                comboBoxLoaiThe.DataSource = tb2;

                //LoaiXe lx = new LoaiXe();
                String q3 = "select * from LoaiXe";

                DataTable tb3 = new DataTable();
                tb3 = Globals.getData(new SqlCommand(q3));
                comboBoxLoaiXe.DisplayMember = "TenLoaiXe";
                comboBoxLoaiXe.ValueMember = "MaLoaiXe";
                comboBoxLoaiXe.DataSource = tb3;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        TheXe tx = new TheXe();
        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaThe.Text.Trim() != "" )
                {
                    if (tx.insertTheXe(textBoxMaThe.Text, comboBoxBaiXe.SelectedValue.ToString(), comboBoxTrangThai.Text,comboBoxLoaiThe.SelectedValue.ToString(),comboBoxLoaiXe.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Thêm thẻ xe thành công!", "Thêm thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLTheXe_Load(sender, e);
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
                MessageBox.Show(ex.Message, "Thêm thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaThe.Text.Trim() != "")
                {
                    if (tx.updateTheXe(textBoxMaThe.Text, comboBoxBaiXe.SelectedValue.ToString(), comboBoxTrangThai.Text, comboBoxLoaiThe.SelectedValue.ToString(), comboBoxLoaiXe.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Sửa thẻ xe thành công!", "Sửa thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLTheXe_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn hãy nhập đầy đủ thông tin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMaThe.Text.Trim() != "")
                {
                    if (tx.deleteTheXe(textBoxMaThe.Text))
                    {
                        MessageBox.Show("Xóa thẻ xe thành công!", "Xóa thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLTheXe_Load(sender, e);
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
                MessageBox.Show(ex.Message, "Xóa thẻ xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                My_DB mydb = new My_DB();
                String key = textBoxSearch.Text;
                SqlCommand cmd = new SqlCommand("select * from f_searchTheXe(@key)", mydb.getConnection);
                cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
                dataGridView1.DataSource = Globals.getData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaThe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
