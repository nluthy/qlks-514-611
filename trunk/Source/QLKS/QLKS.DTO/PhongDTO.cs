using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class PhongDTO
    {
        private string maPhong;

        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }
        private string tenPhong;

        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }
        private LoaiPhongDTO loaiPhong;

        public LoaiPhongDTO LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; }
        }

        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string tinhTrang;

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        private int sLKhach;

        public int SLKhach
        {
            get { return sLKhach; }
            set { sLKhach = value; }
        }
    }
}
