using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLKS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.NguoiDung == "admin")
            {
                quảnLýChungToolStripMenuItem.Enabled = true;
                btn_QuanLyChung.Enabled = true;
            }
        }

        private void btn_QuanLyPhong_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelThongKe.Visible = false;
            panelChoThuePhong.Visible = false;
            panelQuanLyPhong.Visible = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_LamLai_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_CapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChoThuePhong_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelThongKe.Visible = false;
            panelQuanLyPhong.Visible = false;
            panelChoThuePhong.Visible = true;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelQuanLyPhong.Visible = false;
            panelChoThuePhong.Visible = false;
            panelThongKe.Visible = true;
        }

        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelQuanLyPhong.Visible = false;
            panelChoThuePhong.Visible = false;
            panelThongKe.Visible = false;
            panelTraCuu.Visible = true;
        }

        private void btn_QuanLyChung_Click(object sender, EventArgs e)
        {
            panelQuanLyPhong.Visible = false;
            panelChoThuePhong.Visible = false;
            panelThongKe.Visible = false;
            panelTraCuu.Visible = false;
            panelQuanLyChung.Visible = true;
        }

        private void thêmPhòngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_QuanLyPhong_Click(sender, e);
        }









    }
}
