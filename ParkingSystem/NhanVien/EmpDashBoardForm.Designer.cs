namespace ParkingSystem
{
    partial class EmployeeDashBoardForm
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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonTheXe = new System.Windows.Forms.Button();
            this.buttonKhachHang = new System.Windows.Forms.Button();
            this.buttonDangKy = new System.Windows.Forms.Button();
            this.buttonCheckInOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Location = new System.Drawing.Point(-1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 116);
            this.panel1.TabIndex = 0;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Red;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLogout.Location = new System.Drawing.Point(628, 26);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(121, 73);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(41, 52);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(133, 32);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome";
            // 
            // buttonTheXe
            // 
            this.buttonTheXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTheXe.Location = new System.Drawing.Point(44, 140);
            this.buttonTheXe.Name = "buttonTheXe";
            this.buttonTheXe.Size = new System.Drawing.Size(321, 129);
            this.buttonTheXe.TabIndex = 1;
            this.buttonTheXe.Text = "Thẻ xe";
            this.buttonTheXe.UseVisualStyleBackColor = true;
            this.buttonTheXe.Click += new System.EventHandler(this.buttonTheXe_Click);
            // 
            // buttonKhachHang
            // 
            this.buttonKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhachHang.Location = new System.Drawing.Point(424, 140);
            this.buttonKhachHang.Name = "buttonKhachHang";
            this.buttonKhachHang.Size = new System.Drawing.Size(324, 129);
            this.buttonKhachHang.TabIndex = 1;
            this.buttonKhachHang.Text = "Khách hàng";
            this.buttonKhachHang.UseVisualStyleBackColor = true;
            this.buttonKhachHang.Click += new System.EventHandler(this.buttonKhachHang_Click);
            // 
            // buttonDangKy
            // 
            this.buttonDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangKy.Location = new System.Drawing.Point(424, 302);
            this.buttonDangKy.Name = "buttonDangKy";
            this.buttonDangKy.Size = new System.Drawing.Size(324, 126);
            this.buttonDangKy.TabIndex = 1;
            this.buttonDangKy.Text = "Đăng ký";
            this.buttonDangKy.UseVisualStyleBackColor = true;
            this.buttonDangKy.Click += new System.EventHandler(this.buttonDangKy_Click);
            // 
            // buttonCheckInOut
            // 
            this.buttonCheckInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckInOut.Location = new System.Drawing.Point(44, 302);
            this.buttonCheckInOut.Name = "buttonCheckInOut";
            this.buttonCheckInOut.Size = new System.Drawing.Size(321, 126);
            this.buttonCheckInOut.TabIndex = 1;
            this.buttonCheckInOut.Text = "Check in/out";
            this.buttonCheckInOut.UseVisualStyleBackColor = true;
            this.buttonCheckInOut.Click += new System.EventHandler(this.buttonCheckInOut_Click);
            // 
            // EmployeeDashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 463);
            this.Controls.Add(this.buttonDangKy);
            this.Controls.Add(this.buttonCheckInOut);
            this.Controls.Add(this.buttonKhachHang);
            this.Controls.Add(this.buttonTheXe);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeDashBoardForm";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonTheXe;
        private System.Windows.Forms.Button buttonKhachHang;
        private System.Windows.Forms.Button buttonDangKy;
        private System.Windows.Forms.Button buttonCheckInOut;
    }
}