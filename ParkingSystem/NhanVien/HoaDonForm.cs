using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using ParkingSystem.common;

namespace ParkingSystem.NhanVien
{
    public partial class HoaDonForm : Form
    {
        string maTheXe;
        string bienSo;
        DateTime thoiGianVao;
        string maLoaiXe;
        public HoaDonForm(string maTheXe, string bienSo, DateTime thoiGianVao, string maLoaiXe)
        {
            InitializeComponent();
            this.maTheXe = maTheXe;
            this.bienSo = bienSo;
            this.thoiGianVao = thoiGianVao;
            this.maLoaiXe = maLoaiXe;
        }

        int soGioTre;
        float tongTien;

        private void HoaDonForm_Load(object sender, EventArgs e)
        {
            try
            {
                TimeSpan time = DateTime.Now - thoiGianVao;
                soGioTre = time.Days;

                labelMaTheXe.Text = maTheXe;
                labelBienSo.Text = bienSo;
                dateTimePickerNgayIn.Enabled = false;
                labelTreGio.Text = soGioTre + " ngày";

                SqlCommand command = new SqlCommand("select dbo.layGiaGiuXe(@maloaixe, @maloaigia)");
                command.Parameters.Add("@maloaixe", SqlDbType.Char).Value = maLoaiXe;

                if (soGioTre > 0)
                {
                    // Phạt
                    command.Parameters.Add("@maloaigia", SqlDbType.Char).Value = "Phat" + maLoaiXe;
                    DataTable giaGiuXeTable = Globals.getData(command);
                
                    tongTien = soGioTre * float.Parse(giaGiuXeTable.Rows[0][0].ToString().Trim());
                }
                else
                {
                    // Đúng giờ
                    command.Parameters.Add("@maloaigia", SqlDbType.Char).Value = "Giu" + maLoaiXe;
                    DataTable giaGiuXeTable = Globals.getData(command);
                    float giaGiuXe = float.Parse(giaGiuXeTable.Rows[0][0].ToString().Trim());
                    tongTien = giaGiuXe;
                }

                labelTongTien.Text = tongTien.ToString() + " đồng";
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

}

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            Xe xe = new Xe();
            if (MessageBox.Show("Thanh toán hóa đơn này?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    xe.updateXe(this.maTheXe, this.bienSo, DateTime.Now);
                    hoaDon.insertHoaDon(soGioTre, tongTien, DateTime.Now, textBoxGhiChu.Text, this.maTheXe);
                    MessageBox.Show("Thanh toán thành công", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
