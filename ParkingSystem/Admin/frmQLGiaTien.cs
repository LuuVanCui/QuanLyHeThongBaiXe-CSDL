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
    public partial class frmQLGiaTien : Form
    {
        public frmQLGiaTien()
        {
            InitializeComponent();
            Globals.makeUpViews(dataGridView1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmQLGiaTien_Load(object sender, EventArgs e)
        {

            string query = "select * from view_BangGia";
            dataGridView1.DataSource = Globals.getData(new SqlCommand(query));

            String q = "select * from view_LoaiXe";

            DataTable tb1 = new DataTable();
            tb1 = Globals.getData(new SqlCommand(q));
            comboBoxLoaiXe.DisplayMember = "TenLoaiXe";
            comboBoxLoaiXe.ValueMember = "MaLoaiXe";
            comboBoxLoaiXe.DataSource = tb1;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Xác nhận thêm giá tiền mới", "Thêm giá tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    if (verif())

                    {
                        GiaTien gt = new GiaTien();

                        DateTime ngayApDung = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                        String maloaigia = textBoxMaLoaiGia.Text;
                        int giaTien = int.Parse(textBoxGiaTien.Text);
                        String tenLoaiGia = textBoxTenLoaiGia.Text;
                        String maloaixe = comboBoxLoaiXe.SelectedValue.ToString();

                        if (gt.insertGiaTien(maloaigia,tenLoaiGia,giaTien,ngayApDung,maloaixe))
                        {
                            MessageBox.Show("Thêm thành công!", "Thêm giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLGiaTien_Load(sender, e);

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
                    MessageBox.Show(ex.Message, "Thêm giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        bool verif()
        {
            if (textBoxMaLoaiGia.Text.Trim() == "" ||
                textBoxGiaTien.Text.Trim() == "" ||
                textBoxTenLoaiGia.Text.Trim() == "")

            {
                return false;
            }
            return true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Xác nhận sửa giá tiền mới", "Cập nhật giá tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    if (verif())
                    {
                        GiaTien gt = new GiaTien();

                        DateTime ngayApDung = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                        String maloaigia = textBoxMaLoaiGia.Text;
                        int giaTien = int.Parse(textBoxGiaTien.Text);
                        String tenLoaiGia = textBoxTenLoaiGia.Text;
                        String maloaixe = comboBoxLoaiXe.SelectedValue.ToString();

                        if (gt.updateGiaTien(maloaigia, tenLoaiGia, giaTien, ngayApDung, maloaixe))
                        {
                            MessageBox.Show("Cap nhat thành công!", "Cập nhật giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLGiaTien_Load(sender, e);

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
                    MessageBox.Show(ex.Message, "Cập nhật giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Xác nhận xóa", "Xóa giá tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                try
                {
                    GiaTien gt = new GiaTien();
                    if (textBoxMaLoaiGia.Text.Trim() != "")
                    {
                        String ID = textBoxMaLoaiGia.Text;
                        if (gt.deleteGiaTien(ID))
                        {
                            MessageBox.Show("Xóa thành công!", "Xóa giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmQLGiaTien_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Không thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa giá tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            textBoxMaLoaiGia.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxGiaTien.Text   = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxTenLoaiGia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
