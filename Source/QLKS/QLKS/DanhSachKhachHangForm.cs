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
    public partial class DanhSachKhachHangForm : Form
    {
        private LapPhieuThueForm parent;

        public DanhSachKhachHangForm(LapPhieuThueForm phieuThue)
        {
            parent = phieuThue;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            parent.setMaKhachHang(dgvDanhSachKhachHang.SelectedRows[0].Cells[0].Value.ToString());
            Close();
        }

        private void DanhSachKhachHangForm_Load(object sender, EventArgs e)
        {
            dgvDanhSachKhachHang.DataSource = KhachHangBUS.LayDSKhach();

            List<LoaiKhachDTO> ds = new List<LoaiKhachDTO>();
            ds = KhachHangBUS.LayDSLoaiKhach();
            for (int i = 0; i < ds.Count; i++)
                cbbLoaiKhachHang.Items.Add(ds[i].MaLoaiKH);
            cbbLoaiKhachHang.Text = ds[0].MaLoaiKH.ToString();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

        }


        
    }
}
