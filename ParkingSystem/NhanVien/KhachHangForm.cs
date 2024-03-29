﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.common;

namespace ParkingSystem.NhanVien
{
    public partial class KhachHangForm : Form
    {
        public KhachHangForm()
        {
            InitializeComponent();
        }

        KhachHang kh = new KhachHang();

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            Globals.makeUpViews(dataGridViewCustomer);
            string query = "select * from view_KhachHang";
            dataGridViewCustomer.DataSource = Globals.getData(new SqlCommand(query));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                kh.insertKhachHang(textBoxID.Text.Trim(), textBoxCustomerName.Text.Trim(), textBoxPhone.Text.Trim());
                MessageBox.Show("Thêm khách hàng thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangForm_Load(sender, e);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCustomer.CurrentRow != null)
            {
                textBoxCustomerName.Text = dataGridViewCustomer.CurrentRow.Cells[1].Value.ToString();
                textBoxPhone.Text = dataGridViewCustomer.CurrentRow.Cells[2].Value.ToString();
                textBoxID.Text = dataGridViewCustomer.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCustomer.CurrentRow != null)
                {
                    string id = dataGridViewCustomer.CurrentRow.Cells[0].Value.ToString();
                    kh.updateKhachHang(id, textBoxCustomerName.Text, textBoxPhone.Text);
                    MessageBox.Show("Cập nhật thông tin hàng thành công!", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhachHangForm_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text;
            string query = "select * from f_timKiemKhachHang(@query)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@query", SqlDbType.NVarChar).Value = searchQuery;
            dataGridViewCustomer.DataSource = Globals.getData(command);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxPhone.Text = "";
            textBoxCustomerName.Text = "";
        }
    }
}
