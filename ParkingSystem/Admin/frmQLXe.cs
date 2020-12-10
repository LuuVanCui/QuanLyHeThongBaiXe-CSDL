using ParkingSystem.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Admin
{
    public partial class frmQLXe : Form
    {
        public frmQLXe()
        {
            InitializeComponent();
        }
        Xe xe = new Xe();

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            String key = textBoxSearch.Text;
            dataGridView1.DataSource = xe.searchXe(key);
            Globals.makeUpViews(dataGridView1);
        }

        private void frmQLXe_Load(object sender, EventArgs e)
        {

        }
    }
}
