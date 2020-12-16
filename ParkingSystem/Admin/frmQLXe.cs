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
    public partial class frmQLXe : Form
    {
        public frmQLXe()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
            //fillDataComboBox();
            dataGridView1.RowHeadersVisible = false;
            
        }
        Xe xe = new Xe();

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            String key = textBoxSearch.Text;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
            dataGridView1.DataSource = xe.searchXe(key);

        }

        private void frmQLXe_Load(object sender, EventArgs e)
        {
            fillDataComboBox();
            string query = "select * from view_AdminXe";

            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));
           
        }

        void fillDataComboBox()
        {
            try

            {
                LoaiXe lx = new LoaiXe();
                String q = "select * from view_BaiXe";

                DataTable tb1 = new DataTable();
                tb1 = Globals.getData(new SqlCommand(q));
                tb1.Rows.Add(new Object[] { "Tất Cả", "Tất Cả" });


                //comboBoxBaiXe.("Tất cả");
                comboBoxBaiXe.DisplayMember = "Ten";
                comboBoxBaiXe.ValueMember = "baixe_id";
                comboBoxBaiXe.DataSource = tb1;
                //comboBoxBaiXe.SelectedItem= "Tất Cả";


                String q2 = "select * from view_Loaixe";
                DataTable tb2 = Globals.getData(new SqlCommand(q2));
                tb2.Rows.Add(new Object[] { "Tất Cả", "Tất Cả" });

                comboBoxLoaiXe.DisplayMember = "TenLoaiXe";
                comboBoxLoaiXe.ValueMember = "MaLoaiXe";
                comboBoxLoaiXe.DataSource = tb2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxBaiXe_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxLoaiXe.SelectedValue != null && comboBoxBaiXe.SelectedValue != null)
                {
                    String bxID = comboBoxBaiXe.SelectedValue.ToString();
                    String lxID = comboBoxLoaiXe.SelectedValue.ToString();
                    SqlCommand cmd = new SqlCommand("exec p_selectXe @bx, @lx");
                    cmd.Parameters.Add("@bx", SqlDbType.NVarChar).Value = bxID;
                    cmd.Parameters.Add("@lx", SqlDbType.NVarChar).Value = lxID;

                    dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
                    dataGridView1.DataSource = Globals.getData(cmd);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBoxLoaiXe_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxLoaiXe.SelectedValue != null && comboBoxBaiXe.SelectedValue != null)
            {
                String bxID = comboBoxBaiXe.SelectedValue.ToString();
                String lxID = comboBoxLoaiXe.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand("exec p_selectXe @bx, @lx");
                cmd.Parameters.Add("@bx", SqlDbType.NVarChar).Value = bxID;
                cmd.Parameters.Add("@lx", SqlDbType.NVarChar).Value = lxID;
               // dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss";
                dataGridView1.DataSource = Globals.getData(cmd);
            }
           
        }

        private void buttonXoa_Click_1(object sender, EventArgs e)
        {

            if ((MessageBox.Show("Bạn có thực sự muốn xóa xe vừa chọn?", "Xóa Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {


                if (dataGridView1.SelectedCells.Count.ToString() == "0" && dataGridView1.SelectedRows.Count.ToString() == "0")
                {
                    MessageBox.Show("Bạn phải chọn xe cần xóa trước", "Xóa xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String bs = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DateTime time = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    MessageBox.Show(time.ToString());

                    if (xe.deleteXe(bs, time))
                    {
                        MessageBox.Show("Xóa thành công!", "TXóa Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQLXe_Load(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
        }   }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
