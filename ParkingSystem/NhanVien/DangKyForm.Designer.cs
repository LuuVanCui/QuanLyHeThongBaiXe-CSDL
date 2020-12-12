namespace ParkingSystem.NhanVien
{
    partial class DangKyForm
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
            this.dataGridViewDangKyGiuXe = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonDangKy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMaKH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTenKH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLoaiXe = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMaTheXe = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDangKyGiuXe)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDangKyGiuXe
            // 
            this.dataGridViewDangKyGiuXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDangKyGiuXe.Location = new System.Drawing.Point(37, 361);
            this.dataGridViewDangKyGiuXe.Name = "dataGridViewDangKyGiuXe";
            this.dataGridViewDangKyGiuXe.RowHeadersWidth = 62;
            this.dataGridViewDangKyGiuXe.RowTemplate.Height = 28;
            this.dataGridViewDangKyGiuXe.Size = new System.Drawing.Size(1218, 330);
            this.dataGridViewDangKyGiuXe.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(37, 299);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(1016, 30);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonDangKy
            // 
            this.buttonDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangKy.Location = new System.Drawing.Point(1123, 161);
            this.buttonDangKy.Name = "buttonDangKy";
            this.buttonDangKy.Size = new System.Drawing.Size(132, 57);
            this.buttonDangKy.TabIndex = 2;
            this.buttonDangKy.Text = "Đăng ký";
            this.buttonDangKy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã KH:";
            // 
            // comboBoxMaKH
            // 
            this.comboBoxMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMaKH.FormattingEnabled = true;
            this.comboBoxMaKH.Location = new System.Drawing.Point(137, 136);
            this.comboBoxMaKH.Name = "comboBoxMaKH";
            this.comboBoxMaKH.Size = new System.Drawing.Size(360, 33);
            this.comboBoxMaKH.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên KH:";
            // 
            // comboBoxTenKH
            // 
            this.comboBoxTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTenKH.FormattingEnabled = true;
            this.comboBoxTenKH.Location = new System.Drawing.Point(137, 220);
            this.comboBoxTenKH.Name = "comboBoxTenKH";
            this.comboBoxTenKH.Size = new System.Drawing.Size(360, 33);
            this.comboBoxTenKH.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(557, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã thẻ xe:";
            // 
            // comboBoxLoaiXe
            // 
            this.comboBoxLoaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLoaiXe.FormattingEnabled = true;
            this.comboBoxLoaiXe.Location = new System.Drawing.Point(693, 139);
            this.comboBoxLoaiXe.Name = "comboBoxLoaiXe";
            this.comboBoxLoaiXe.Size = new System.Drawing.Size(360, 33);
            this.comboBoxLoaiXe.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại Xe:";
            // 
            // comboBoxMaTheXe
            // 
            this.comboBoxMaTheXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMaTheXe.FormattingEnabled = true;
            this.comboBoxMaTheXe.Location = new System.Drawing.Point(693, 220);
            this.comboBoxMaTheXe.Name = "comboBoxMaTheXe";
            this.comboBoxMaTheXe.Size = new System.Drawing.Size(360, 33);
            this.comboBoxMaTheXe.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(1123, 272);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(132, 57);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(514, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(319, 46);
            this.label5.TabIndex = 3;
            this.label5.Text = "Đăng Ký Giữ Xe";
            // 
            // DangKyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 723);
            this.Controls.Add(this.comboBoxMaTheXe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxLoaiXe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTenKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMaKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDangKy);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewDangKyGiuXe);
            this.Name = "DangKyForm";
            this.Text = "Đăng Ký";
            this.Load += new System.EventHandler(this.DangKyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDangKyGiuXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDangKyGiuXe;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonDangKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLoaiXe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMaTheXe;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label5;
    }
}