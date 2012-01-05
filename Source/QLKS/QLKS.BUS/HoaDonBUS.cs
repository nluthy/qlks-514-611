using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.BUS
{
    public class HOADONBUS
    {
        public static List<HOADON> layDSHoaDon()
        {
            return HOADONDAO.layDSHoaDon();
        }
        public static void themHD(string MHD, string MKH, DateTime ngayTT, int tien, List<CHITIETHOADON> arrHD)
        {
            HOADONDAO.themHD(MHD, MKH, ngayTT, tien, arrHD);
        }
        public static List<CHITIETHOADON> layCTHD(string MHD)
        {
            return HOADONDAO.layCTHD(MHD);
        }
    }
}
