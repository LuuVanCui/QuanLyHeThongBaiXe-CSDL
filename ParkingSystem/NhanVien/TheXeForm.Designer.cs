﻿namespace ParkingSystem
{
    partial class TheXeForm
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
            this.dataGridViewTheXe = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTheXe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thẻ xe";
            // 
            // dataGridViewTheXe
            // 
            this.dataGridViewTheXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTheXe.Location = new System.Drawing.Point(56, 162);
            this.dataGridViewTheXe.Name = "dataGridViewTheXe";
            this.dataGridViewTheXe.RowHeadersWidth = 62;
            this.dataGridViewTheXe.RowTemplate.Height = 28;
            this.dataGridViewTheXe.Size = new System.Drawing.Size(1034, 429);
            this.dataGridViewTheXe.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(56, 100);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(828, 30);
            this.textBoxSearch.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(907, 92);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(183, 42);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // TheXeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 632);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewTheXe);
            this.Controls.Add(this.label1);
            this.Name = "TheXeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thẻ xe";
            this.Load += new System.EventHandler(this.TheXeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTheXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTheXe;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
    }
}