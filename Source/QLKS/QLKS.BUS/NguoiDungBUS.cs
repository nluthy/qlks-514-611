using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLKS.DAO;
using QLKS.DTO;

namespace QLKS.BUS
{
    public class NguoiDungBUS
    {
        public static DataTable hienThiTatCaNguoiDung()
        {
            return NguoiDungDAO.hienThiTatCaNguoiDung();
        }

        public static int themNguoiDung(NguoiDungDTO nguoiDung)
        {
            return NguoiDungDAO.themNguoiDung(nguoiDung);
        }

        public static bool xoaNguoiDung(string tenDangNhap)
        {
            return NguoiDungDAO.xoaNguoiDung(tenDangNhap);
        }

        public static int kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return NguoiDungDAO.kiemTraDangNhap(tenDangNhap, matKhau);
        }

        public static bool suaNguoiDung(NguoiDungDTO nguoiDung)
        {
            return NguoiDungDAO.suaNguoiDung(nguoiDung);
        }
    }
}
