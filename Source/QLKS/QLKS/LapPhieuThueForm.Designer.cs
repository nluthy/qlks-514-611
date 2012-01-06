namespace QLKS
{
    partial class LapPhieuThueForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MaPhieuThue = new System.Windows.Forms.TextBox();
            this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
            this.txt_MaPhong = new System.Windows.Forms.TextBox();
            this.dtp_NgayBatDauThue = new System.Windows.Forms.DateTimePicker();
            this.btn_ChonMaKhachHang = new System.Windows.Forms.Button();
            this.dgvDanhSachPhieuThue = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_LamLai = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhieuThue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu thuê";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày bắt đầu thuê";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã phòng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(192, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "LẬP PHIẾU THUÊ PHÒNG";
            // 
            // txt_MaPhieuThue
            // 
            this.txt_MaPhieuThue.Location = new System.Drawing.Point(130, 60);
            this.txt_MaPhieuThue.Name = "txt_MaPhieuThue";
            this.txt_MaPhieuThue.Size = new System.Drawing.Size(155, 20);
            this.txt_MaPhieuThue.TabIndex = 0;
            // 
            // txt_MaKhachHang
            // 
            this.txt_MaKhachHang.Location = new System.Drawing.Point(130, 109);
            this.txt_MaKhachHang.Name = "txt_MaKhachHang";
            this.txt_MaKhachHang.ReadOnly = true;
            this.txt_MaKhachHang.Size = new System.Drawing.Size(75, 20);
            this.txt_MaKhachHang.TabIndex = 2;
            // 
            // txt_MaPhong
            // 
            this.txt_MaPhong.Location = new System.Drawing.Point(130, 85);
            this.txt_MaPhong.Name = "txt_MaPhong";
            this.txt_MaPhong.ReadOnly = true;
            this.txt_MaPhong.Size = new System.Drawing.Size(155, 20);
            this.txt_MaPhong.TabIndex = 1;
            // 
            // dtp_NgayBatDauThue
            // 
            this.dtp_NgayBatDauThue.Location = new System.Drawing.Point(435, 57);
            this.dtp_NgayBatDauThue.Name = "dtp_NgayBatDauThue";
            this.dtp_NgayBatDauThue.Size = new System.Drawing.Size(139, 20);
            this.dtp_NgayBatDauThue.TabIndex = 4;
            // 
            // btn_ChonMaKhachHang
            // 
            this.btn_ChonMaKhachHang.Location = new System.Drawing.Point(224, 107);
            this.btn_ChonMaKhachHang.Name = "btn_ChonMaKhachHang";
            this.btn_ChonMaKhachHang.Size = new System.Drawing.Size(61, 23);
            this.btn_ChonMaKhachHang.TabIndex = 3;
            this.btn_ChonMaKhachHang.Text = "Chọn";
            this.btn_ChonMaKhachHang.UseVisualStyleBackColor = true;
            this.btn_ChonMaKhachHang.Click += new System.EventHandler(this.btn_ChonMaKhachHang_Click);
            // 
            // dgvDanhSachPhieuThue
            // 
            this.dgvDanhSachPhieuThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachPhieuThue.Location = new System.Drawing.Point(36, 162);
            this.dgvDanhSachPhieuThue.Name = "dgvDanhSachPhieuThue";
            this.dgvDanhSachPhieuThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachPhieuThue.Size = new System.Drawing.Size(538, 149);
            this.dgvDanhSachPhieuThue.TabIndex = 7;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(387, 107);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 5;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            // 
            // btn_LamLai
            // 
            this.btn_LamLai.Location = new System.Drawing.Point(499, 107);
            this.btn_LamLai.Name = "btn_LamLai";
            this.btn_LamLai.Size = new System.Drawing.Size(75, 23);
            this.btn_LamLai.TabIndex = 6;
            this.btn_LamLai.Text = "Làm lại";
            this.btn_LamLai.UseVisualStyleBackColor = true;
            this.btn_LamLai.Click += new System.EventHandler(this.btn_LamLai_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Xóa phiếu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(336, 320);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // LapPhieuThueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 355);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_LamLai);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.dgvDanhSachPhieuThue);
            this.Controls.Add(this.btn_ChonMaKhachHang);
            this.Controls.Add(this.dtp_NgayBatDauThue);
            this.Controls.Add(this.txt_MaPhong);
            this.Controls.Add(this.txt_MaKhachHang);
            this.Controls.Add(this.txt_MaPhieuThue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LapPhieuThueForm";
            this.Text = "LapPhieuThueForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhieuThue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MaPhieuThue;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.TextBox txt_MaPhong;
        private System.Windows.Forms.DateTimePicker dtp_NgayBatDauThue;
        private System.Windows.Forms.Button btn_ChonMaKhachHang;
        private System.Windows.Forms.DataGridView dgvDanhSachPhieuThue;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_LamLai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThoat;
    }
}