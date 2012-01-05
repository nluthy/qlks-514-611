using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class KhachHangDTO
    {
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string hoTen;

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        private LoaiKhachDTO loaiKhach;

        public LoaiKhachDTO LoaiKhach
        {
            get { return loaiKhach; }
            set { loaiKhach = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string soGiayTo;

        public string SoGiayTo
        {
            get { return soGiayTo; }
            set { soGiayTo = value; }
        }
    }
}
