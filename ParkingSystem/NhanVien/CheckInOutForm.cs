using ParkingSystem.common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            SqlCommand cmdMaTheCheckIn = new SqlCommand("select * from f_maTheXeCheckIn(@baixeId)");
            cmdMaTheCheckIn.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn);
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaTheXe";

            SqlCommand cmdMaTheCheckOut = new SqlCommand("select * from f_maTheXeCheckOut(@baixeId)");
            cmdMaTheCheckOut.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            comboBoxMaTheXeCheckOut.DataSource = Globals.getData(cmdMaTheCheckOut);
            comboBoxMaTheXeCheckOut.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckOut.ValueMember = "MaTheXe";

            comboBoxLoaiXe.DataSource = Globals.getData(new SqlCommand("select * from view_Loaixe"));
            comboBoxLoaiXe.DisplayMember = "TenLoaiXe";
            comboBoxLoaiXe.ValueMember = "MaLoaiXe";
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
            if (comboBoxLoaiXe.SelectedValue != null && pictureBoxAnhTruoc.Image != null && pictureBoxAnhSau.Image != null)
            {
                string maTheXe = comboBoxMaTheXeCheckIn.Text;
                string maLoaiXe = comboBoxLoaiXe.SelectedValue.ToString();
                string bienSo = textBoxBienSo.Text;
                MemoryStream anhTruoc = new MemoryStream();
                MemoryStream anhSau = new MemoryStream();
                pictureBoxAnhTruoc.Image.Save(anhTruoc, pictureBoxAnhTruoc.Image.RawFormat);
                pictureBoxAnhSau.Image.Save(anhSau, pictureBoxAnhSau.Image.RawFormat);
                DateTime thoiGianVao = DateTime.Now;
                try
                {
                    xe.insertXe(bienSo, anhTruoc, anhSau, thoiGianVao, maTheXe, maLoaiXe, Globals.baixeId);
                    MessageBox.Show("Check In thành công!", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CheckInOutForm_Load(sender, e);
            }
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            // get input data
            if (comboBoxMaTheXeCheckOut.Text.Trim() != "" && textBoxBienSo.Text.Trim() != "")
            {
                try
                {
                    string maTheXe = comboBoxMaTheXeCheckOut.Text;
                    string bienSo = textBoxBienSo.Text;
                    DateTime thoiGianRa = DateTime.Now;
                    try
                    {
                        //xe.updateXe(maTheXe, bienSo, thoiGianRa);
                        //MessageBox.Show("Check Out thành công!", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HoaDonForm hoaDon = new HoaDonForm(bienSo);
                        hoaDon.ShowDialog(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CheckInOutForm_Load(sender, e);
            }
        }

        private void comboBoxMaTheXeCheckOut_DropDownClosed(object sender, EventArgs e)
        {
            string maXeRa = comboBoxMaTheXeCheckOut.Text;
            SqlCommand command = new SqlCommand("select * from f_layXeRa(@mathexe)");
            command.Parameters.Add("@mathexe", SqlDbType.Char).Value = maXeRa;
            DataTable tableXeRa = Globals.getData(command);

            foreach (DataRow row in tableXeRa.Rows)
            {
                // Hiển thị tên loại xe
                SqlCommand cmd = new SqlCommand("select dbo.f_layTenLoaiXe(@maloaixe)");
                cmd.Parameters.Add("@maloaixe", SqlDbType.Char).Value = row["MaLoaiXe"].ToString();
                DataTable tableTenLoaiXe = Globals.getData(cmd);
                comboBoxLoaiXe.Text = tableTenLoaiXe.Rows[0][0].ToString();

                textBoxBienSo.Text = row["BienSo"].ToString();

                // load anh truoc
                if (row["AnhTruoc"].ToString() != "")
                {
                    byte[] bytes = (byte[])row["AnhTruoc"];
                    MemoryStream ms_anhTruoc = new MemoryStream(bytes);
                    pictureBoxAnhTruoc.Image = Image.FromStream(ms_anhTruoc);
                }

                // load anh sau
                if (row["AnhSau"].ToString() != "")
                {
                    byte[] bytes = (byte[])row["AnhSau"];
                    MemoryStream ms_anhSau = new MemoryStream(bytes);
                    pictureBoxAnhSau.Image = Image.FromStream(ms_anhSau);
                }

                break;
            }
        }
    }
}
