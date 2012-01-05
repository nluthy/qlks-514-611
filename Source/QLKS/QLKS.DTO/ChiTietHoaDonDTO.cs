using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class ChiTietHoaDonDTO
    {
        private PhieuThueDTO phieuthue;

        public PhieuThueDTO Phieuthue
        {
            get { return phieuthue; }
            set { phieuthue = value; }
        }
        private int soNgayThue;

        public int SoNgayThue
        {
            get { return soNgayThue; }
            set { soNgayThue = value; }
        }
        private int tienThue;

        public int TienThue
        {
            get { return tienThue; }
            set { tienThue = value; }
        }
        private int tongCong;

        public int TongCong
        {
            get { return tongCong; }
            set { tongCong = value; }
        }
    }
}
