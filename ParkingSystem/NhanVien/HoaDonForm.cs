using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.NhanVien
{
    public partial class HoaDonForm : Form
    {
        public HoaDonForm()
        {
            InitializeComponent();
        }

        string maTheXe;
        string loaiXe; 
        string bienSo;

        public HoaDonForm(string bienSo)
        {
            this.bienSo = bienSo;
        }

        DateTime thoiGianVao;

        public HoaDonForm(string maTheXe, string loaiXe, string bienSo, DateTime thoiGianVao)
        {
            this.maTheXe = maTheXe;
            this.loaiXe = loaiXe;
            this.bienSo = bienSo;
            this.thoiGianVao = thoiGianVao;
        }

        private void HoaDonForm_Load(object sender, EventArgs e)
        {
            labelBienSo.Text = this.bienSo;
        }
    }
}
