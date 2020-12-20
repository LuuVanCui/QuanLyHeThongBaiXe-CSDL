using ParkingSystem.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    public partial class EmployeeDashBoardForm : Form
    {
        public EmployeeDashBoardForm()
        {
            InitializeComponent();
        }

        private void buttonTheXe_Click(object sender, EventArgs e)
        {
            TheXeForm theXeForm = new TheXeForm();
            theXeForm.ShowDialog(this);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCheckInOut_Click(object sender, EventArgs e)
        {
            CheckInOutForm checkInOutForm = new CheckInOutForm();
            checkInOutForm.ShowDialog(this);
        }

        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            KhachHangForm khachHangForm = new KhachHangForm();
            khachHangForm.ShowDialog(this);
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            DangKyForm dangKyForm = new DangKyForm();
            dangKyForm.ShowDialog(this);
        }

        private void buttonBangGia_Click(object sender, EventArgs e)
        {
            BangGiaForm bangGiaForm = new BangGiaForm();
            bangGiaForm.ShowDialog(this);
        }
    }
}
