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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;
            String maPhieuThue = txt_MaPhong.Text + hour.ToString() + day.ToString() + month.ToString() + year.ToString() + txt_MaKhachHang.Text;
            txt_MaPhieuThue.Text = maPhieuThue;
            
            
            if (txt_MaKhachHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    bool kq = PhieuThueBUS.ThemPhieu(maPhieuThue, txt_MaPhong.Text, dtp_NgayBatDauThue.Value, "No", KhachHangBUS.LayKhach(txt_MaKhachHang.Text));
                    if (kq)
                    {
                        MessageBox.Show("Thêm phiếu thuê thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu thuê thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    updateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateData()
        {
            List<PhieuThueDTO> dspt = PhieuThueBUS.layDSPT();
            dgvDanhSachPhieuThue.DataSource = dspt;
            dgvDanhSachPhieuThue.Columns.Remove("Phong");
            
            List<PhongDTO> dsp = new List<PhongDTO>();
            foreach (PhieuThueDTO pt in dspt)
            {
                dsp.Add(pt.Phong);
            }
            DataGridViewColumn column = new DataGridViewColumn();
            column.CellTemplate = new DataGridViewTextBoxCell();
            column.Name = "Phong";
            column.ValueType = dsp[0].TenPhong.GetType();
            dgvDanhSachPhieuThue.Columns.Add(column);
            
            for (int i = 0; i < dsp.Count; ++i)
            {
                dgvDanhSachPhieuThue.Rows[i].Cells[dgvDanhSachPhieuThue.Columns.Count-1].Value = dsp[i].TenPhong;
            }
        }

        private void LapPhieuThueForm_Load(object sender, EventArgs e)
        {
            
            updateData();
        }
    }
}
