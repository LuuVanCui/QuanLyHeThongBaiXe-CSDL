namespace ParkingSystem.Admin
{
    partial class frmQLTheXe
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
            this.textBoxMaThe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLoaiThe = new System.Windows.Forms.ComboBox();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.comboBoxBaiXe = new System.Windows.Forms.ComboBox();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMaThe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxLoaiThe);
            this.panel1.Controls.Add(this.comboBoxTrangThai);
            this.panel1.Controls.Add(this.comboBoxBaiXe);
            this.panel1.Controls.Add(this.buttonXoa);
            this.panel1.Controls.Add(this.buttonSua);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 592);
            this.panel1.TabIndex = 0;
            // 
            // textBoxMaThe
            // 
            this.textBoxMaThe.Location = new System.Drawing.Point(119, 113);
            this.textBoxMaThe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaThe.Name = "textBoxMaThe";
            this.textBoxMaThe.Size = new System.Drawing.Size(174, 26);
            this.textBoxMaThe.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã Thẻ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loại Thẻ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Trạng thái:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tìm kiếm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bãi Xe";
            // 
            // comboBoxLoaiThe
            // 
            this.comboBoxLoaiThe.FormattingEnabled = true;
            this.comboBoxLoaiThe.Items.AddRange(new object[] {
            "Vãng lai",
            "Thẻ tuần",
            "Thẻ tháng"});
            this.comboBoxLoaiThe.Location = new System.Drawing.Point(690, 113);
            this.comboBoxLoaiThe.Name = "comboBoxLoaiThe";
            this.comboBoxLoaiThe.Size = new System.Drawing.Size(300, 28);
            this.comboBoxLoaiThe.TabIndex = 8;
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Items.AddRange(new object[] {
            "sẵn dùng",
            "khóa"});
            this.comboBoxTrangThai.Location = new System.Drawing.Point(690, 176);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(300, 28);
            this.comboBoxTrangThai.TabIndex = 8;
            // 
            // comboBoxBaiXe
            // 
            this.comboBoxBaiXe.FormattingEnabled = true;
            this.comboBoxBaiXe.Location = new System.Drawing.Point(119, 176);
            this.comboBoxBaiXe.Name = "comboBoxBaiXe";
            this.comboBoxBaiXe.Size = new System.Drawing.Size(239, 28);
            this.comboBoxBaiXe.TabIndex = 8;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Location = new System.Drawing.Point(1030, 212);
            this.buttonXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(118, 50);
            this.buttonXoa.TabIndex = 7;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Location = new System.Drawing.Point(1030, 150);
            this.buttonSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(118, 50);
            this.buttonSua.TabIndex = 7;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(1030, 96);
            this.buttonThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(118, 50);
            this.buttonThem.TabIndex = 7;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(398, 236);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(592, 26);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 283);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1189, 295);
            this.dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(499, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quản lý thẻ xe";
            // 
            // frmQLTheXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 616);
            this.Controls.Add(this.panel1);
            this.Name = "frmQLTheXe";
            this.Text = "frmQLTheXe";
            this.Load += new System.EventHandler(this.frmQLTheXe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaThe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaiXe;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLoaiThe;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
    }
}