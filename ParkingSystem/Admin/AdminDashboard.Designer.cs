namespace ParkingSystem
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonQLGiaTien = new System.Windows.Forms.Button();
            this.buttonQLDoanhThu = new System.Windows.Forms.Button();
            this.buttonCapQuyen = new System.Windows.Forms.Button();
            this.buttonBLNhanVien = new System.Windows.Forms.Button();
            this.buttonQLLoaiXe = new System.Windows.Forms.Button();
            this.buttonQLBaiXe = new System.Windows.Forms.Button();
            this.buttonQLKhachHang = new System.Windows.Forms.Button();
            this.buttonQLTheXe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonQLGiaTien);
            this.panel1.Controls.Add(this.buttonQLDoanhThu);
            this.panel1.Controls.Add(this.buttonCapQuyen);
            this.panel1.Controls.Add(this.buttonBLNhanVien);
            this.panel1.Controls.Add(this.buttonQLLoaiXe);
            this.panel1.Controls.Add(this.buttonQLBaiXe);
            this.panel1.Controls.Add(this.buttonQLKhachHang);
            this.panel1.Controls.Add(this.buttonQLTheXe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 557);
            this.panel1.TabIndex = 0;
            // 
            // buttonQLGiaTien
            // 
            this.buttonQLGiaTien.Location = new System.Drawing.Point(1004, 73);
            this.buttonQLGiaTien.Name = "buttonQLGiaTien";
            this.buttonQLGiaTien.Size = new System.Drawing.Size(226, 140);
            this.buttonQLGiaTien.TabIndex = 0;
            this.buttonQLGiaTien.Text = "Quản lý tiền gửi & tiền phạt";
            this.buttonQLGiaTien.UseVisualStyleBackColor = true;
            this.buttonQLGiaTien.Click += new System.EventHandler(this.buttonQLGiaTien_Click);
            // 
            // buttonQLDoanhThu
            // 
            this.buttonQLDoanhThu.Location = new System.Drawing.Point(698, 73);
            this.buttonQLDoanhThu.Name = "buttonQLDoanhThu";
            this.buttonQLDoanhThu.Size = new System.Drawing.Size(226, 140);
            this.buttonQLDoanhThu.TabIndex = 0;
            this.buttonQLDoanhThu.Text = "Quản lý doanh thu";
            this.buttonQLDoanhThu.UseVisualStyleBackColor = true;
            this.buttonQLDoanhThu.Click += new System.EventHandler(this.buttonQLDoanhThu_Click);
            // 
            // buttonCapQuyen
            // 
            this.buttonCapQuyen.Location = new System.Drawing.Point(1004, 295);
            this.buttonCapQuyen.Name = "buttonCapQuyen";
            this.buttonCapQuyen.Size = new System.Drawing.Size(226, 140);
            this.buttonCapQuyen.TabIndex = 0;
            this.buttonCapQuyen.Text = "Cấp quyền";
            this.buttonCapQuyen.UseVisualStyleBackColor = true;
            this.buttonCapQuyen.Click += new System.EventHandler(this.buttonCapQuyen_Click);
            // 
            // buttonBLNhanVien
            // 
            this.buttonBLNhanVien.Location = new System.Drawing.Point(414, 73);
            this.buttonBLNhanVien.Name = "buttonBLNhanVien";
            this.buttonBLNhanVien.Size = new System.Drawing.Size(226, 140);
            this.buttonBLNhanVien.TabIndex = 0;
            this.buttonBLNhanVien.Text = "Quản lý nhân viên";
            this.buttonBLNhanVien.UseVisualStyleBackColor = true;
            this.buttonBLNhanVien.Click += new System.EventHandler(this.buttonBLNhanVien_Click);
            // 
            // buttonQLLoaiXe
            // 
            this.buttonQLLoaiXe.Location = new System.Drawing.Point(698, 295);
            this.buttonQLLoaiXe.Name = "buttonQLLoaiXe";
            this.buttonQLLoaiXe.Size = new System.Drawing.Size(226, 140);
            this.buttonQLLoaiXe.TabIndex = 0;
            this.buttonQLLoaiXe.Text = "Quản lý loại xe";
            this.buttonQLLoaiXe.UseVisualStyleBackColor = true;
            this.buttonQLLoaiXe.Click += new System.EventHandler(this.buttonQLLoaiXe_Click);
            // 
            // buttonQLBaiXe
            // 
            this.buttonQLBaiXe.Location = new System.Drawing.Point(101, 73);
            this.buttonQLBaiXe.Name = "buttonQLBaiXe";
            this.buttonQLBaiXe.Size = new System.Drawing.Size(226, 140);
            this.buttonQLBaiXe.TabIndex = 0;
            this.buttonQLBaiXe.Text = "Quản lý các bãi";
            this.buttonQLBaiXe.UseVisualStyleBackColor = true;
            this.buttonQLBaiXe.Click += new System.EventHandler(this.buttonQLBaiXe_Click);
            // 
            // buttonQLKhachHang
            // 
            this.buttonQLKhachHang.Location = new System.Drawing.Point(414, 295);
            this.buttonQLKhachHang.Name = "buttonQLKhachHang";
            this.buttonQLKhachHang.Size = new System.Drawing.Size(226, 140);
            this.buttonQLKhachHang.TabIndex = 0;
            this.buttonQLKhachHang.Text = "Quản lý khách hàng";
            this.buttonQLKhachHang.UseVisualStyleBackColor = true;
            this.buttonQLKhachHang.Click += new System.EventHandler(this.buttonQLKhachHang_Click);
            // 
            // buttonQLTheXe
            // 
            this.buttonQLTheXe.Location = new System.Drawing.Point(101, 295);
            this.buttonQLTheXe.Name = "buttonQLTheXe";
            this.buttonQLTheXe.Size = new System.Drawing.Size(226, 140);
            this.buttonQLTheXe.TabIndex = 0;
            this.buttonQLTheXe.Text = "Quản lý thẻ xe";
            this.buttonQLTheXe.UseVisualStyleBackColor = true;
            this.buttonQLTheXe.Click += new System.EventHandler(this.buttonQLTheXe_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 557);
            this.Controls.Add(this.panel1);
            this.Name = "AdminDashboard";
            this.Text = "Admin Dashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonQLGiaTien;
        private System.Windows.Forms.Button buttonQLDoanhThu;
        private System.Windows.Forms.Button buttonCapQuyen;
        private System.Windows.Forms.Button buttonBLNhanVien;
        private System.Windows.Forms.Button buttonQLLoaiXe;
        private System.Windows.Forms.Button buttonQLBaiXe;
        private System.Windows.Forms.Button buttonQLKhachHang;
        private System.Windows.Forms.Button buttonQLTheXe;
    }
}