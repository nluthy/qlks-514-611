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
            if (tb_MaPhong.TextLength > 0)
            {
                String maPhong = tb_MaPhong.Text;
                PhongDTO phong = PhongBUS.LayPhong(maPhong);
                if (phong.GhiChu.Equals("Phong khong ton tai"))
                {
                    try
                    {
                        PhongBUS.NhapPhong(maPhong, tb_TenPhong.Text, Int32.Parse(cb_MaLoaiPhong.SelectedItem.ToString()), tb_GhiChu.Text, cb_TinhTrangPhong.SelectedItem.ToString());
                        MessageBox.Show("Thêm phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_DSPhong.DataSource = PhongBUS.LayDSPhong();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm phòng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phòng đã tồn tại\nVui lòng nhập mã phòng khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã phòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LamLai_Click(object sender, EventArgs e)
        {
            tb_MaPhong.Text = tb_SoLuongKhach.Text = tb_GhiChu.Text = tb_TenPhong.Text = "";
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

        private void dgvSua_DSPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbSua_TinhTrangPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbSua_MaLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        

        private void tabPage_CapNhatPhong_Enter(object sender, EventArgs e)
        {
            dgvSua_DSPhong.DataSource = PhongBUS.LayDSPhong();
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
            txtTenDangNhap.Text = txtMatKhau.Text = txtEmail.Text = "";
        }

        private void btnQuanLyNguoiDung_Sua_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyNguoiDung_ThemMoi_Click(object sender, EventArgs e)
        {
        }

        private void dgvQuanLyNguoiDung_DanhSachNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }




        #region Panel chức năng (xong rồi, không sửa nữa)
        //
        //
        private void btn_QuanLyPhong_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelThongKe.Visible = false;
            panelChoThuePhong.Visible = false;
            panelQuanLyPhong.Visible = true;
            List<LoaiPhongDTO> dsLoaiPhong = PhongBUS.LayDSLoaiPhong();
            foreach (LoaiPhongDTO loaiPhong in dsLoaiPhong)
            {
                cb_MaLoaiPhong.Items.Add(loaiPhong.MaLoaiPhong.ToString());
            }
            cb_MaLoaiPhong.SelectedIndex = 0;
            cb_TinhTrangPhong.Items.Add("Trống");
            cb_TinhTrangPhong.Items.Add("Có người");
            cb_TinhTrangPhong.SelectedIndex = 0;

            foreach (LoaiPhongDTO loaiPhong in dsLoaiPhong)
            {
                cbSua_MaLoaiPhong.Items.Add(loaiPhong.MaLoaiPhong.ToString());
            }
            cbSua_MaLoaiPhong.SelectedIndex = 0;
            cbSua_TinhTrangPhong.Items.Add("Trống");
            cbSua_TinhTrangPhong.Items.Add("Có người");
            cbSua_TinhTrangPhong.SelectedIndex = 0;

            dgv_DSPhong.DataSource = PhongBUS.LayDSPhong();
           
        }

        private void btn_ChoThuePhong_Click(object sender, EventArgs e)
        {
            panelQuanLyChung.Visible = false;
            panelTraCuu.Visible = false;
            panelThongKe.Visible = false;
            panelQuanLyPhong.Visible = false;
            panelChoThuePhong.Visible = true;
            List<PhongDTO> dsPhong = PhongBUS.LayDSPhong();
            List<PhongDTO> dsPhongTrong = new List<PhongDTO>();
            foreach (PhongDTO phg in dsPhong)
            {
                if (phg.TinhTrang.Equals("Trống"))
                {
                    dsPhongTrong.Add(phg);
                }
            }
            dgvChonPhong_DSPhongTrong.DataSource = dsPhongTrong;
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
            dgvQuanLyNguoiDung_DanhSachNguoiDung.DataSource = NguoiDungBUS.hienThiTatCaNguoiDung();
        }

        #endregion

        #region Các sự kiện menu
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
        #endregion








    }
}
