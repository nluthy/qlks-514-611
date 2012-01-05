using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class HoaDonDTO
    {
        private string maHD;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private List<ChiTietHoaDonDTO> dsCTHD;

        public List<ChiTietHoaDonDTO> DsCTHD
        {
            get { return dsCTHD; }
            set { dsCTHD = value; }
        }
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private DateTime ngayTT;

        public DateTime NgayTT
        {
            get { return ngayTT; }
            set { ngayTT = value; }
        }
        private int thanhtien;

        public int Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
    }
}
