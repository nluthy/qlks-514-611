using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class LoaiKhachDTO
    {
        private int maLoaiKH;

        public int MaLoaiKH
        {
            get { return maLoaiKH; }
            set { maLoaiKH = value; }
        }
        private string tenLoaiKH;

        public string TenLoaiKH
        {
            get { return tenLoaiKH; }
            set { tenLoaiKH = value; }
        }
        private int heSo;

        public int HeSo
        {
            get { return heSo; }
            set { heSo = value; }
        }
        private string xoa;

        public string Xoa
        {
            get { return xoa; }
            set { xoa = value; }
        }
    }
}
