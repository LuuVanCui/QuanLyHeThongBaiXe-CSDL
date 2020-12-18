using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.common;

namespace ParkingSystem.NhanVien
{
    public partial class CheckInOutForm : Form
    {
        public CheckInOutForm()
        {
            InitializeComponent();
        }

        Xe xe = new Xe();

        private void CheckInOutForm_Load(object sender, EventArgs e)
        {
            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(new SqlCommand("select * from view_MaTheXeCheckIn"));
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaTheXe";

            comboBoxMaTheXeCheckOut.DataSource = Globals.getData(new SqlCommand("select * from view_MaTheXeCheckOut"));
            comboBoxMaTheXeCheckOut.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckOut.ValueMember = "MaTheXe";

            comboBoxLoaiXe.DataSource = Globals.getData(new SqlCommand("select * from view_Loaixe"));
            comboBoxLoaiXe.DisplayMember = "MaLoaiXe";
            comboBoxLoaiXe.ValueMember = "TenLoaiXe";
        }

        private void buttonLoadAnhTruoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxAnhTruoc.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadAnhSau_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxAnhSau.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            // get input data
            string maTheXe = comboBoxMaTheXeCheckIn.Text;
            string maLoaiXe = comboBoxLoaiXe.ValueMember;
            string bienSo = textBoxBienSo.Text;
            MemoryStream anhTruoc = new MemoryStream();
            MemoryStream anhSau = new MemoryStream();
            pictureBoxAnhTruoc.Image.Save(anhTruoc, pictureBoxAnhTruoc.Image.RawFormat);
            pictureBoxAnhSau.Image.Save(anhTruoc, pictureBoxAnhSau.Image.RawFormat);
            DateTime thoiGianVao = DateTime.Now;
            try
            {
                xe.insertUpdateXe("insert", bienSo, anhTruoc, anhSau, thoiGianVao, DateTime.Now, maTheXe, maLoaiXe, Globals.baixeId);
                MessageBox.Show("Check In thành công!", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            // get input data
            try
            {
                string maTheXe = comboBoxMaTheXeCheckIn.Text;
                string maLoaiXe = comboBoxLoaiXe.ValueMember;
                string bienSo = textBoxBienSo.Text;
                MemoryStream anhTruoc = new MemoryStream();
                MemoryStream anhSau = new MemoryStream();
                pictureBoxAnhTruoc.Image.Save(anhTruoc, pictureBoxAnhTruoc.Image.RawFormat);
                pictureBoxAnhSau.Image.Save(anhTruoc, pictureBoxAnhSau.Image.RawFormat);
                DateTime thoiGianVao = DateTime.Now;
                try
                {
                    xe.insertUpdateXe("update", bienSo, anhTruoc, anhSau, thoiGianVao, DateTime.Now, maTheXe, maLoaiXe, Globals.baixeId);
                    MessageBox.Show("Check Out thành công!", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
