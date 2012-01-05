using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.BUS
{
    public class KHACHHANGBUS
    {
        public static List<KHACHHANG> LayDSKhach()
        {
            return KHACHHANGDAO.LayDSKhach();
        }
        public static List<LOAIKHACH> LayDSLoaiKhach()
        {
            return KHACHHANGDAO.LayDSLoaiKhach();
        }
        public static KHACHHANG LayKhach(string MKH)
        {
            return KHACHHANGDAO.LayKhach(MKH);
        }
        public static void ThemKhach(string MKH, string HT, int MLK, string DC, string GT, bool kihieu)
        {
            KHACHHANGDAO.ThemKhach(MKH, HT, MLK, DC, GT, kihieu);
        }
        public static LOAIKHACH LaylKhach(int MLK)
        {
            return KHACHHANGDAO.LaylKhach(MLK);
        }
        public static void lKSuaThem(int MLK, string ten, int HS, string xoa, bool kihieu)
        {
            KHACHHANGDAO.lKSuaThem(MLK, ten, HS, xoa, kihieu);
        }
    }
}
