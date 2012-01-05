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
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            int kiemTra = NguoiDungBUS.kiemTraDangNhap(tenDangNhap, matKhau);

            if (kiemTra == 1)
            {
                if (tenDangNhap.Equals("admin"))
                {
                    AdminForm form = new AdminForm();
                    form.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("OK");
                }
            }
            else if (kiemTra == 0)
                MessageBox.Show("Tên đăng nhập không tồn tại", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Mật khẩu chưa đúng", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
