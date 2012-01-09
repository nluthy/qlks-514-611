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
            tbSua_MaPhong.ReadOnly = false;
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
            string maPhong = dgvSua_DSPhong.SelectedRows[0].Cells[0].Value.ToString();
            PhongDTO phg = new PhongDTO();

            if (tbSua_MaPhong.TextLength > 0 && tbSua_TenPhong.TextLength > 0 && tbSua_GhiChu.TextLength > 0)
            {
                //Lấy các thông tin đã sửa từ các textbox và combobox
                string TP = tbSua_TenPhong.Text.Trim();
                int LP = int.Parse(cb_MaLoaiPhong.Text.Trim());
                string GC = tbSua_GhiChu.Text.Trim();
                string TT = cbSua_TinhTrangPhong.Text.Trim();
                int SL;
                if (tbSuaSoLuongKhach.Text.Trim() == "")
                    SL = 0;
                else SL = int.Parse(tbSuaSoLuongKhach.Text.Trim());

                phg = PhongBUS.LayPhong(maPhong);
                if (phg.MaPhong == null)
                    MessageBox.Show(phg.GhiChu, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                {
                    PhongBUS.CapNhat(maPhong, TP, LP, GC, TT, SL);
                    MessageBox.Show("Cập nhật phòng thành công", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_MaPhong.Text = tb_SoLuongKhach.Text = tb_GhiChu.Text = tb_TenPhong.Text = "";
                    tbSua_MaPhong.ReadOnly = false;
                    dgvSua_DSPhong.DataSource = PhongBUS.LayDSPhong();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn bảng bên dưới để sửa\nVui lòng điền đầy đủ thông tin", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSua_MaPhong.ReadOnly = false;
            }
        }

        private void btnSua_Xoa_Click(object sender, EventArgs e)
        {
            string MP = tbSua_MaPhong.Text.Trim();

            if ((MP == "") || (string.Compare(MP, "000", true) < 0))
                MessageBox.Show("Vui lòng nhập mã số phòng muốn xóa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                PhongDTO phg = new PhongDTO();
                phg = PhongBUS.LayPhong(MP);
                if (phg.MaPhong == null)
                    MessageBox.Show(phg.GhiChu);
                else if (string.Compare(phg.TinhTrang, "Có người", true) == 0)
                    MessageBox.Show("Phòng đang cho thuê,\nkhông thể xóa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    PhongBUS.XoaPhong(MP);
                    MessageBox.Show("Xóa thành công!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSua_DSPhong.DataSource = PhongBUS.LayDSPhong();
                    tb_MaPhong.Text = tb_SoLuongKhach.Text = tb_GhiChu.Text = tb_TenPhong.Text = "";
                }
            }
        }

        private void dgvSua_DSPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string maPhong = dgvSua_DSPhong.SelectedRows[0].Cells[0].Value.ToString();
            //PhongDTO phg = new PhongDTO();

            if (dgvSua_DSPhong.SelectedRows.Count == 1)
            {
                tbSua_MaPhong.Text = dgvSua_DSPhong.SelectedRows[0].Cells[0].Value.ToString();
                tbSua_MaPhong.ReadOnly = true;
                tbSua_TenPhong.Text = dgvSua_DSPhong.SelectedRows[0].Cells[1].Value.ToString();

                //PhongDTO phg = PhongBUS.LayPhong(tbSua_MaPhong.Text);
                cbSua_MaLoaiPhong.SelectedItem = PhongBUS.LayPhong(tbSua_MaPhong.Text).LoaiPhong.MaLoaiPhong.ToString();

                tbSua_GhiChu.Text = dgvSua_DSPhong.SelectedRows[0].Cells[3].Value.ToString();
                cbSua_TinhTrangPhong.SelectedItem = dgvSua_DSPhong.SelectedRows[0].Cells[4].Value.ToString();
                tbSuaSoLuongKhach.Text = dgvSua_DSPhong.SelectedRows[0].Cells[5].Value.ToString();
            }
            else
                MessageBox.Show("Vui lòng chỉ chọn 1 dòng để sửa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //PhongDTO phg = new PhongDTO();
            //string maPhong = dgvSua_DSPhong.SelectedRows[0].Cells[0].Value.ToString(); //Lấy mã phòng của dòng vừa chọn
            //phg = PhongBUS.LayPhong(maPhong);

            ////Hiển thị các thông tin của phòng đc chọn lên các textbox:
            //tbSua_MaPhong.Text = maPhong;
            //tbSua_MaPhong.ReadOnly = true;
            //tbSua_TenPhong.Text = phg.TenPhong;
            //tbSua_GhiChu.Text = phg.GhiChu;
            //tbSuaSoLuongKhach.Text = phg.SLKhach.ToString();
            //cbSua_MaLoaiPhong.SelectedItem = phg.LoaiPhong.MaLoaiPhong.ToString();
            //cbSua_TinhTrangPhong.SelectedItem = phg.TinhTrang;

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
            LapPhieuThueForm form = new LapPhieuThueForm();
            form.Show();
            form.setMaPhong(dgvChonPhong_DSPhongTrong.SelectedRows[0].Cells[0].Value.ToString());
        }

        public void setMaPhongChoPhieuThue()
        {

        }

        //
        //Màn hình lập hóa đơn
        //
        private void btnLapHoaDon_ThanhToan_Click(object sender, EventArgs e)
        {
            String maHoaDon = tbLapHoaDon_MaHD.Text;
            if (maHoaDon != "")
            {
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLapHoaDon_Them_Click(object sender, EventArgs e)
        {
            String maPhieuThue = cbLapHoaDon_MaPhieuThue.Text;
            if (maPhieuThue != "")
            {

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã phiếu thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLapHoaDon_MaPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbLapHoaDon_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh = KhachHangBUS.LayKhach(cbLapHoaDon_MaKH.Text);
            tbLapHoaDon_TenKhachHang.Text = kh.HoTen;
        }
        private void tabPage_LapHoaDon_Enter(object sender, EventArgs e)
        {
            tbLapHoaDon_NgayThanhToan.Text = DateTime.Now.Date.ToString();
            List<KhachHangDTO> dskh = KhachHangBUS.LayDSKhach();
            List<PhieuThueDTO> dspt = PhieuThueBUS.layDSPT();
            foreach (KhachHangDTO kh in dskh)
            {
                cbLapHoaDon_MaKH.Items.Add(kh.MaKH);
                           }
            foreach (PhieuThueDTO pt in dspt)
            {
                cbLapHoaDon_MaPhieuThue.Items.Add(pt.MaPhieuThue);
            }
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
            txtTenDangNhap.ReadOnly = false;
        }

        private void btnQuanLyNguoiDung_Sua_Click(object sender, EventArgs e)
        {
            string tenDangNhap = dgvQuanLyNguoiDung_DanhSachNguoiDung.SelectedRows[0].Cells[0].Value.ToString();

            if (txtTenDangNhap.TextLength > 0 && txtEmail.TextLength > 0 && txtMatKhau.TextLength > 0)
            {
                bool ketQua = NguoiDungBUS.suaNguoiDung(new NguoiDungDTO(tenDangNhap, txtMatKhau.Text, txtEmail.Text));

                if (ketQua)
                {
                    MessageBox.Show("Sửa người dùng thành công", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyNguoiDung_DanhSachNguoiDung.DataSource = NguoiDungBUS.hienThiTatCaNguoiDung();
                    txtTenDangNhap.Text = txtMatKhau.Text = txtEmail.Text = "";
                    txtTenDangNhap.ReadOnly = false;
                }
                else
                    MessageBox.Show("Sửa người dùng thất bại", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Vui lòng click chọn bảng bên dưới để sửa\nVà điền đầy đủ thông tin", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuanLyNguoiDung_ThemMoi_Click(object sender, EventArgs e)
        {
            int ketQua = 0; // 0: Thêm thất bại
                            // 1: Thêm thành công
                            //-1: Đã tồn tại người dùng đó
            if (txtTenDangNhap.TextLength > 0 && txtMatKhau.TextLength > 0 && txtEmail.TextLength > 0)
            {
                ketQua = NguoiDungBUS.themNguoiDung(new NguoiDungDTO(txtTenDangNhap.Text, txtMatKhau.Text, txtEmail.Text));
                if (ketQua == 1)
                {
                    MessageBox.Show("Thêm người dùng mới thành công", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyNguoiDung_DanhSachNguoiDung.DataSource = NguoiDungBUS.hienThiTatCaNguoiDung();
                    txtTenDangNhap.Text = txtMatKhau.Text = txtEmail.Text = "";
                }
                else if (ketQua == 0)
                    MessageBox.Show("Thêm người dùng mới thất bại", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Đã tồn tại tên đăng nhập đó\nVui lòng nhập tên khác", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Vui lòng điền tên đầy đủ thông tin", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvQuanLyNguoiDung_DanhSachNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuanLyNguoiDung_DanhSachNguoiDung.SelectedRows.Count == 1)
            {
                txtTenDangNhap.Text = dgvQuanLyNguoiDung_DanhSachNguoiDung.SelectedRows[0].Cells[0].Value.ToString();
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.Text = dgvQuanLyNguoiDung_DanhSachNguoiDung.SelectedRows[0].Cells[1].Value.ToString();
                txtEmail.Text = dgvQuanLyNguoiDung_DanhSachNguoiDung.SelectedRows[0].Cells[2].Value.ToString();
            }
            else
                MessageBox.Show("Vui lòng chỉ chọn 1 dòng để sửa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
