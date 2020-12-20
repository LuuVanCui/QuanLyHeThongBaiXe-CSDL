namespace ParkingSystem.NhanVien
{
    partial class BangGiaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBangGia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBangGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng Giá Giữ Xe";
            // 
            // dataGridViewBangGia
            // 
            this.dataGridViewBangGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBangGia.Location = new System.Drawing.Point(37, 116);
            this.dataGridViewBangGia.Name = "dataGridViewBangGia";
            this.dataGridViewBangGia.RowHeadersWidth = 62;
            this.dataGridViewBangGia.RowTemplate.Height = 28;
            this.dataGridViewBangGia.Size = new System.Drawing.Size(1008, 436);
            this.dataGridViewBangGia.TabIndex = 1;
            // 
            // BangGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 595);
            this.Controls.Add(this.dataGridViewBangGia);
            this.Controls.Add(this.label1);
            this.Name = "BangGiaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Giá Giữ Xe";
            this.Load += new System.EventHandler(this.BangGiaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBangGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewBangGia;
    }
}