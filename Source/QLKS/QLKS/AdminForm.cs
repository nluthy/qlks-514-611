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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = txtMatKhau.Text = txtEmail.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DangNhapForm dlg = new DangNhapForm();
            dlg.Show();
            this.Close();
        }
    }
}
