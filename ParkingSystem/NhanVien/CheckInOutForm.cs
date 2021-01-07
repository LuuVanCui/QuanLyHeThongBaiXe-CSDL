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
        SqlCommand cmdMaTheCheckIn = new SqlCommand();
        SqlCommand cmdMaTheCheckOut = new SqlCommand("select * from f_maTheXeCheckOut(@baixeId)");
        DateTime thoiGianVao;

        private void CheckInOutForm_Load(object sender, EventArgs e)
        {
            cmdMaTheCheckIn.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            cmdMaTheCheckIn.CommandText = "select * from f_maTheXeCheckInKhachVangLai(@baixeId)";

            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn); 
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaLoaiXe";

            cmdMaTheCheckOut.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            comboBoxMaTheXeCheckOut.DataSource = Globals.getData(cmdMaTheCheckOut);
            comboBoxMaTheXeCheckOut.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckOut.ValueMember = "MaLoaiXe";

            radioButtonXeVao.Checked = true;
            radioButtonXeVao_CheckedChanged(sender, e);
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
            string maLoaiXe = comboBoxMaTheXeCheckIn.SelectedValue.ToString().Trim();
            MessageBox.Show(maLoaiXe);
            if (pictureBoxAnhTruoc.Image != null && pictureBoxAnhSau.Image != null)
            {
                string maTheXe = comboBoxMaTheXeCheckIn.Text.Trim();
                
                string bienSo = textBoxBienSo.Text.Trim();
                MemoryStream anhTruoc = new MemoryStream();
                MemoryStream anhSau = new MemoryStream();
                pictureBoxAnhTruoc.Image.Save(anhTruoc, pictureBoxAnhTruoc.Image.RawFormat);
                pictureBoxAnhSau.Image.Save(anhSau, pictureBoxAnhSau.Image.RawFormat);
                DateTime thoiGianVao = DateTime.Now;
                try
                {
                    xe.insertXe(bienSo, anhTruoc, anhSau, thoiGianVao, maTheXe, maLoaiXe, Globals.baixeId);
                    MessageBox.Show("Check In thành công!", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // update data
                    radioButtonKhachDangKy_CheckedChanged(sender, e);
                    radioButtonKhachVangLai_CheckedChanged(sender, e);

                    comboBoxMaTheXeCheckOut.DataSource = Globals.getData(cmdMaTheCheckOut);
                    comboBoxMaTheXeCheckOut.DisplayMember = "MaTheXe";
                    comboBoxMaTheXeCheckOut.ValueMember = "MaTheXe";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Lỗi dữ liệu input!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DateTime thoiGianVao = DateTime.Now;
                    try
                    {
                    //    xe.updateXe(maTheXe, bienSo, thoiGianRa);
                        HoaDonForm hoaDon = new HoaDonForm(maTheXe, bienSo, thoiGianVao);
                        hoaDon.ShowDialog(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Check out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Lỗi dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButtonKhachVangLai_CheckedChanged(object sender, EventArgs e)
        {
            cmdMaTheCheckIn.CommandText = "select * from f_maTheXeCheckInKhachVangLai(@baixeId)";
            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn);
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaLoaiXe";
        }

        private void radioButtonKhachDangKy_CheckedChanged(object sender, EventArgs e)
        {
            cmdMaTheCheckIn.CommandText = "select * from f_maTheXeCheckInKhachDangKy(@baixeId)";
            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn);
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaLoaiXe";
        }

        private void comboBoxMaTheXeCheckOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maXeRa = comboBoxMaTheXeCheckOut.Text;

            SqlCommand cmdTenLoaiXe = new SqlCommand("select dbo.layTenLoaiXeTheoMaTheXe(@mathexe)");
            cmdTenLoaiXe.Parameters.Add("@mathexe", SqlDbType.Char).Value = maXeRa;
            DataTable tenLoaiXeTable = Globals.getData(cmdTenLoaiXe);
            labelTenLoaiXe.Text = tenLoaiXeTable.Rows[0][0].ToString();

            SqlCommand command = new SqlCommand("select * from f_layXeRa(@mathexe)");
            command.Parameters.Add("@mathexe", SqlDbType.Char).Value = maXeRa;
            DataTable tableXeRa = Globals.getData(command);

            foreach (DataRow row in tableXeRa.Rows)
            {
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

                thoiGianVao = (DateTime)row["ThoiGianVao"];
                
                break;
            }
        }

        private void comboBoxMaTheXeCheckIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maTheXe = comboBoxMaTheXeCheckIn.Text;
            SqlCommand cmd = new SqlCommand("select dbo.layTenLoaiXeTheoMaTheXe(@mathexe)");
            cmd.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
            DataTable tenLoaiXeTable = Globals.getData(cmd);
            labelTenLoaiXe.Text = tenLoaiXeTable.Rows[0][0].ToString();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            labelTenLoaiXe.Text = "";
            textBoxBienSo.Text = "";
            pictureBoxAnhTruoc.Image = null;
            pictureBoxAnhSau.Image = null;
        }

        private void radioButtonXeVao_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonKhachVangLai.Visible = true;
            radioButtonKhachDangKy.Visible = true;
            buttonCheckIn.Visible = true;
            label1.Visible = true;
            comboBoxMaTheXeCheckIn.Visible = true;
            buttonLoadAnhTruoc.Visible = true;
            buttonLoadAnhSau.Visible = true;

            comboBoxMaTheXeCheckOut.Visible = false;
            label10.Visible = false;
            buttonCheckOut.Visible = false;

            buttonRefresh_Click(sender, e);
        }

        private void radioButtonXeRa_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMaTheXeCheckOut.Visible = true;
            label10.Visible = true;
            buttonCheckOut.Visible = true;

            radioButtonKhachVangLai.Visible = false;
            radioButtonKhachDangKy.Visible = false;
            buttonCheckIn.Visible = false;
            label1.Visible = false;
            comboBoxMaTheXeCheckIn.Visible = false;
            buttonLoadAnhTruoc.Visible = false;
            buttonLoadAnhSau.Visible = false;

            buttonRefresh_Click(sender, e);
        }
    }
}
