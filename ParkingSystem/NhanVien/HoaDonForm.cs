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
        string maTheXe;
        string bienSo;
        DateTime thoiGianVao;
        public HoaDonForm(string maTheXe, string bienSo, DateTime thoiGianVao)
        {
            InitializeComponent();
            this.maTheXe = maTheXe;
            this.bienSo = bienSo;
            this.thoiGianVao = thoiGianVao;
        }

        private void HoaDonForm_Load(object sender, EventArgs e)
        {
            labelMaTheXe.Text = maTheXe;
            labelBienSo.Text = bienSo;
    
        }
    }
}
