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




        //
        // Màn hình Thêm phòng mới
        //
        private void btn_Them_Click(object sender, EventArgs e)
        {
        }

        private void btn_LamLai_Click(object sender, EventArgs e)
        {
        }

        private void cb_TinhTrangPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cb_MaLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //
        // Màn hình Cập nhật phòng
        //
        private void btnSua_CapNhat_Click(object sender, EventArgs e)
        {
        }

        private void btnSua_Xoa_Click(object sender, EventArgs e)
        {
        }

        private void cbSua_TinhTrangPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbSua_MaLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //
        //Màn hình Cho thuê phòng
        //
        private void btnChoThuePhong_Chon_Click(object sender, EventArgs e)
        {
        }

        //
        //Màn hình lập hóa đơn
        //
        private void btnLapHoaDon_ThanhToan_Click(object sender, EventArgs e)
        {
        }

        private void btnLapHoaDon_Them_Click(object sender, EventArgs e)
        {
        }

        private void cbLapHoaDon_MaPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbLapHoaDon_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //
        //Màn hình thống kê mật độ sử dụng
        //
        private void btnMatDoSuDung_ThongKe_Click(object sender, EventArgs e)
        {
        }

        private void cbMatDoSuDung_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnDoanhThu_ThongKe_Click(object sender, EventArgs e)
        {
        }

        private void cbDoanhThu_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //
        //Màn hình tra cứu phòng
        //
        private void btbTraCuuPhong_Tim_Click(object sender, EventArgs e)
        {
        }

        private void cbTraCuuPhong_TinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbTraCuuPhong_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //
        //Màn hình tra cứu hóa đơn
        //
        private void btnTraCuuHD_Tim_Click(object sender, EventArgs e)
        {
        }

        //
        //Màn hình tra cứu khách hàng
        //
        private void btnTraCuuKH_Tim_Click(object sender, EventArgs e)
        {
        }

        //
        //Màn hình quản lý người dùng
        //
        private void btnQuanLyNguoiDung_LamLai_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyNguoiDung_Sua_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyNguoiDung_ThemMoi_Click(object sender, EventArgs e)
        {
        }




        #region Panel chức năng (xong rồi, không sửa nữa)
        private void btn_QuanLyPhong_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelThongKe.Visible = false;
            panelChoThuePhong.Visible = false;
            panelQuanLyPhong.Visible = true;
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

        #endregion

        private void thêmPhòngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_QuanLyPhong_Click(sender, e);
        }

        private void tiếpNhậnKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_ChoThuePhong_Click(sender, e);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_ThongKe_Click(sender, e);
        }

        private void trToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_TraCuu_Click(sender, e);
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_QuanLyChung_Click(sender, e);
        }









    }
}
