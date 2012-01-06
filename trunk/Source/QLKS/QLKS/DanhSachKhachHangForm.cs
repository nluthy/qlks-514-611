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
    }
}
