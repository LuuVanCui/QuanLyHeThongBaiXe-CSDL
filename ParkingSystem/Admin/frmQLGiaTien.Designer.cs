namespace ParkingSystem.Admin
{
    partial class frmQLGiaTien
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxLoaiXe = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.textBoxGiaTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaLoaiGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTenLoaiGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxLoaiXe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonXoa);
            this.panel1.Controls.Add(this.buttonSua);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Controls.Add(this.textBoxGiaTien);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxMaLoaiGia);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxTenLoaiGia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 624);
            this.panel1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dateTimePicker1.Location = new System.Drawing.Point(521, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 23);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.Value = new System.DateTime(2020, 12, 6, 22, 31, 14, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(399, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ngày áp dụng:";
            // 
            // comboBoxLoaiXe
            // 
            this.comboBoxLoaiXe.FormattingEnabled = true;
            this.comboBoxLoaiXe.Location = new System.Drawing.Point(521, 161);
            this.comboBoxLoaiXe.Name = "comboBoxLoaiXe";
            this.comboBoxLoaiXe.Size = new System.Drawing.Size(226, 28);
            this.comboBoxLoaiXe.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(432, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Loại Xe:";
            // 
            // buttonXoa
            // 
            this.buttonXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonXoa.Location = new System.Drawing.Point(789, 190);
            this.buttonXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(185, 28);
            this.buttonXoa.TabIndex = 14;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSua.Location = new System.Drawing.Point(789, 150);
            this.buttonSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(185, 28);
            this.buttonSua.TabIndex = 15;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonThem.Location = new System.Drawing.Point(789, 113);
            this.buttonThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(185, 28);
            this.buttonThem.TabIndex = 16;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // textBoxGiaTien
            // 
            this.textBoxGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxGiaTien.Location = new System.Drawing.Point(144, 198);
            this.textBoxGiaTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGiaTien.Name = "textBoxGiaTien";
            this.textBoxGiaTien.Size = new System.Drawing.Size(226, 26);
            this.textBoxGiaTien.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(42, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Giá Tiền:";
            // 
            // textBoxMaLoaiGia
            // 
            this.textBoxMaLoaiGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxMaLoaiGia.Location = new System.Drawing.Point(144, 115);
            this.textBoxMaLoaiGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaLoaiGia.Name = "textBoxMaLoaiGia";
            this.textBoxMaLoaiGia.Size = new System.Drawing.Size(226, 26);
            this.textBoxMaLoaiGia.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(32, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã Loại Giá:";
            // 
            // textBoxTenLoaiGia
            // 
            this.textBoxTenLoaiGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxTenLoaiGia.Location = new System.Drawing.Point(144, 158);
            this.textBoxTenLoaiGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTenLoaiGia.Name = "textBoxTenLoaiGia";
            this.textBoxTenLoaiGia.Size = new System.Drawing.Size(226, 26);
            this.textBoxTenLoaiGia.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(32, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Loại giá:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 249);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1093, 373);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quản Lý Giá Tiền";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmQLGiaTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 646);
            this.Controls.Add(this.panel1);
            this.Name = "frmQLGiaTien";
            this.Text = "frmQLTien";
            this.Load += new System.EventHandler(this.frmQLGiaTien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.TextBox textBoxGiaTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTenLoaiGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLoaiXe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaLoaiGia;
        private System.Windows.Forms.Label label5;
    }
}