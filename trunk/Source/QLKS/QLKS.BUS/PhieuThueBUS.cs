using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.BUS
{
    public class PHIEUTHUEBUS
    {
        public static bool ThemPhieu(string MPT, string MP, DateTime day, string TT, KHACHHANG[] dsKH)
        {
            return PHIEUTHUEDAO.ThemPhieu(MPT, MP, day, TT, dsKH);
        }
        public static List<PHIEUTHUE> layDSPT()
        {
            return PHIEUTHUEDAO.layDSPT();
        }
        public static PHIEUTHUE layPT(string MPT)
        {
            return PHIEUTHUEDAO.layPT(MPT);
        }
        public static void CapNhat(string MPT, string TT)
        {
            PHIEUTHUEDAO.CapNhat(MPT, TT);
        }
    }
}
