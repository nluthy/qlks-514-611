using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class NguoiDungDTO
    {
        

        private string tenDangNhap;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        private string matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public NguoiDungDTO()
        {
        }

        public NguoiDungDTO(string tenDangNhap, string matKhau, string email)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.email = email;
        }
    }
}
