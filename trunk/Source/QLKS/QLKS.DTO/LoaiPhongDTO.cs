using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class LoaiPhongDTO
    {
        private int maLoaiPhong;

        public int MaLoaiPhong
        {
            get { return maLoaiPhong; }
            set { maLoaiPhong = value; }
        }
        private string tenLoaiPhong;

        public string TenLoaiPhong
        {
            get { return tenLoaiPhong; }
            set { tenLoaiPhong = value; }
        }
        private int donGia;

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private int sLKhachToiDa;

        public int SLKhachToiDa
        {
            get { return sLKhachToiDa; }
            set { sLKhachToiDa = value; }
        }
        private string daxoa;

        public string Daxoa
        {
            get { return daxoa; }
            set { daxoa = value; }
        }
    }

}
