using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLKS.DTO;
using QLKS.BUS;

namespace QLKS
{
    public partial class LapPhieuThueForm : Form
    {
        public LapPhieuThueForm()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_LamLai_Click(object sender, EventArgs e)
        {
            txt_MaPhieuThue.Text = txt_MaPhong.Text = txt_MaKhachHang.Text = "";
        }

        private void btn_ChonMaKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHangForm dsform = new DanhSachKhachHangForm(this);
            dsform.Show();
        }

        public void setMaKhachHang(string maKhachHang)
        {
            this.txt_MaKhachHang.Text = maKhachHang;
        }

        public void setMaPhong(string maPhong)
        {
            this.txt_MaPhong.Text = maPhong;
        }
    }
}
