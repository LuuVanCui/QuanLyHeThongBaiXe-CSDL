using ParkingSystem.Admin;
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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void buttonQLBaiXe_Click(object sender, EventArgs e)
        {
            frmQLXe xe = new frmQLXe();
            xe.ShowDialog();
        }

        private void buttonBLNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanVien nv = new frmQLNhanVien();
            nv.ShowDialog();
        }

        private void buttonQLTheXe_Click(object sender, EventArgs e)
        {
            frmQLTheXe thexe = new frmQLTheXe();
            thexe.Show(this);
        }

        private void buttonQLKhachHang_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang kh = new frmQuanLyKhachHang();
            kh.ShowDialog();
        }

        private void buttonQLLoaiXe_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonQLLoaiXe_Click_1(object sender, EventArgs e)
        {
            frmQLLoaiXe lx = new frmQLLoaiXe();
            lx.ShowDialog();
        }
    }
}
