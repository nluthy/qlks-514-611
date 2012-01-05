using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKS.DTO;
using QLKS.DAO;

namespace QLKS.BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHangDTO> LayDSKhach()
        {
            return KhachHangDAO.LayDSKhach();
        }
        public static List<LoaiKhachDTO> LayDSLoaiKhach()
        {
            return KhachHangDAO.LayDSLoaiKhach();
        }
        public static KhachHangDTO LayKhach(string MKH)
        {
            return KhachHangDAO.LayKhach(MKH);
        }
        public static void ThemKhach(string MKH, string HT, int MLK, string DC, string GT, bool kihieu)
        {
            KhachHangDAO.ThemKhach(MKH, HT, MLK, DC, GT, kihieu);
        }
        public static LoaiKhachDTO LaylKhach(int MLK)
        {
            return KhachHangDAO.LaylKhach(MLK);
        }
        public static void lKSuaThem(int MLK, string ten, int HS, string xoa, bool kihieu)
        {
            KhachHangDAO.lKSuaThem(MLK, ten, HS, xoa, kihieu);
        }
    }
}
