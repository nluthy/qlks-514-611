using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKS.DTO;
using QLKS.DAO;

namespace QLKS.BUS
{
    public class HoaDonBUS
    {
        public static List<HoaDonDTO> layDSHoaDon()
        {
            return HoaDonDAO.layDSHoaDon();
        }
        public static void themHD(string MHD, string MKH, DateTime ngayTT, int tien, List<ChiTietHoaDonDTO> arrHD)
        {
            HoaDonDAO.themHD(MHD, MKH, ngayTT, tien, arrHD);
        }
        public static List<ChiTietHoaDonDTO> layCTHD(string MHD)
        {
            return HoaDonDAO.layCTHD(MHD);
        }
    }
}
