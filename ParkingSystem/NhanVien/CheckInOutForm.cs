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
        SqlCommand cmdMaTheCheckOut = new SqlCommand();
        DateTime thoiGianVao;

        private void CheckInOutForm_Load(object sender, EventArgs e)
        {
            cmdMaTheCheckIn.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            cmdMaTheCheckIn.CommandText = "select * from f_maTheXeCheckInKhachVangLai(@baixeId)";

            comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn); 
            comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
            comboBoxMaTheXeCheckIn.ValueMember = "MaLoaiXe";

            cmdMaTheCheckOut.Parameters.Add("@baixeId", SqlDbType.Char).Value = Globals.baixeId;
            cmdMaTheCheckOut.CommandText = "select* from f_maTheXeCheckOut(@baixeId)";
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
            
            if (pictureBoxAnhTruoc.Image != null && pictureBoxAnhSau.Image != null)
            {
                string maTheXe = comboBoxMaTheXeCheckIn.Text.Trim();
                string bienSo = textBoxBienSo.Text.Trim();
                if (labelTenLoaiXe.Text.Trim() != "Xe đạp")
                {
                    if (bienSo == "")
                    {
                        MessageBox.Show("Bạn phải nhập biển số.", "Lỗi input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                }

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
                    comboBoxMaTheXeCheckOut.ValueMember = "MaLoaiXe";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Bạn phải chọn ảnh trước và sau cho xe!", "Lỗi input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            // get input data
            if (comboBoxMaTheXeCheckOut.SelectedValue != null)
            {
                try
                {
                    string maTheXe = comboBoxMaTheXeCheckOut.Text;
                    string maLoaiXe = comboBoxMaTheXeCheckOut.SelectedValue.ToString();
                    string bienSo = textBoxBienSo.Text;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select dbo.laTheVangLai(@mathexe)");
                        cmd.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
                        DataTable table = Globals.getData(cmd);

                        int laTheVangLai = int.Parse(table.Rows[0][0].ToString());

                        if (laTheVangLai == 1)
                        {
                            HoaDonForm hoaDon = new HoaDonForm(maTheXe, bienSo, thoiGianVao, maLoaiXe);
                            hoaDon.ShowDialog(this);
                        } else
                        {
                            SqlCommand cmdSoNgayTre = new SqlCommand("select dbo.f_soNgayTreCuaTheDangKy(@mathexe)");
                            cmdSoNgayTre.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
                            DataTable tableSoNgayQuaHan = Globals.getData(cmdSoNgayTre);
                            int soNgayQuaHanGiuXe = int.Parse(tableSoNgayQuaHan.Rows[0][0].ToString());
                            if (soNgayQuaHanGiuXe > 0)
                            {
                                // Lấy tiền phạt
                                SqlCommand command = new SqlCommand("select dbo.layGiaGiuXe(@maloaixe, @maloaigia)");
                                command.Parameters.Add("@maloaixe", SqlDbType.Char).Value = maLoaiXe;
                                command.Parameters.Add("@maloaigia", SqlDbType.Char).Value = "Phat" + maLoaiXe;
                                DataTable giaGiuXeTable = Globals.getData(command);

                                double giaPhat = double.Parse(giaGiuXeTable.Rows[0][0].ToString());
                                double tongTienPhat = soNgayQuaHanGiuXe * giaPhat;
                                string message = "Xe đăng đã quá hạn " + soNgayQuaHanGiuXe + " ngày. Số tiền phạt của bạn là: " + tongTienPhat + " đồng";

                                if (MessageBox.Show(message, "Phạt quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    xe.updateXe(maTheXe, bienSo, DateTime.Now);
                                    HoaDon hoaDon = new HoaDon();
                                    hoaDon.insertHoaDon(soNgayQuaHanGiuXe, tongTienPhat, DateTime.Now, "Xe bị quá hạn", maTheXe);
                                    MessageBox.Show("Thanh toán thành công.", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            } else
                            {
                                xe.updateXe(maTheXe, bienSo, DateTime.Now);
                                MessageBox.Show("Mời xe ra.", "Xe đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        // Cập nhật data cho combobox
                        comboBoxMaTheXeCheckOut.DataSource = Globals.getData(cmdMaTheCheckOut);
                        comboBoxMaTheXeCheckOut.DisplayMember = "MaTheXe";
                        comboBoxMaTheXeCheckOut.ValueMember = "MaLoaiXe";

                        comboBoxMaTheXeCheckIn.DataSource = Globals.getData(cmdMaTheCheckIn);
                        comboBoxMaTheXeCheckIn.DisplayMember = "MaTheXe";
                        comboBoxMaTheXeCheckIn.ValueMember = "MaLoaiXe";
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
                MessageBox.Show("Bạn phải chọn mã thẻ xe.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBoxBienSo.Enabled = false;

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

                if (labelTenLoaiXe.Text.Trim() == "Xe đạp")
                {
                    label2.Visible = false;
                    textBoxBienSo.Visible = false;
                }
                else
                {
                    label2.Visible = true;
                    textBoxBienSo.Visible = true;
                }

                break;
            }
        }

        private void comboBoxMaTheXeCheckIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maTheXe = comboBoxMaTheXeCheckIn.Text;
            textBoxBienSo.Enabled = true;
            SqlCommand cmd = new SqlCommand("select dbo.layTenLoaiXeTheoMaTheXe(@mathexe)");
            cmd.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
            DataTable tenLoaiXeTable = Globals.getData(cmd);
            labelTenLoaiXe.Text = tenLoaiXeTable.Rows[0][0].ToString();

            if (labelTenLoaiXe.Text.Trim() == "Xe đạp")
            {
                label2.Visible = false;
                textBoxBienSo.Visible = false;
            }
            else
            {
                label2.Visible = true;
                textBoxBienSo.Visible = true;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            labelTenLoaiXe.Text = "";
            textBoxBienSo.Text = "";
            pictureBoxAnhTruoc.Image = null;
            pictureBoxAnhSau.Image = null;
            comboBoxMaTheXeCheckIn.Text = "";
            comboBoxMaTheXeCheckOut.Text = "";
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
