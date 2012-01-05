using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKS.DTO;
using QLKS.DAO;

namespace QLKS.BUS
{
    public class PhieuThueBUS
    {
        public static bool ThemPhieu(string MPT, string MP, DateTime day, string TT, KhachHangDTO[] dsKH)
        {
            return PhieuThueDAO.ThemPhieu(MPT, MP, day, TT, dsKH);
        }
        public static List<PhieuThueDTO> layDSPT()
        {
            return PhieuThueDAO.layDSPT();
        }
        public static PhieuThueDTO layPT(string MPT)
        {
            return PhieuThueDAO.layPT(MPT);
        }
        public static void CapNhat(string MPT, string TT)
        {
            PhieuThueDAO.CapNhat(MPT, TT);
        }
    }
}
