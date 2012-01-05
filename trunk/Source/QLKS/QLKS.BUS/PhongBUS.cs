using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKS.DAO;
using QLKS.DTO;

namespace QLKS.BUS
{
    public class PhongBUS
    {
        public static List<PhongDTO> LayDSPhong()
        {
            return PhongDAO.LayDSPhong();
        }
        public static List<LoaiPhongDTO> LayDSLoaiPhong()
        {
            return PhongDAO.LayDSLoaiPhong();
        }
        public static void NhapPhong(string MP, string TP, int LP, string GC)
        {
            PhongDAO.NhapPhong(MP, TP, LP, GC);
        }
        public static void XoaPhong(string MP)
        {
            PhongDAO.XoaPhong(MP);
        }
        public static void CapNhat(string MP, string TP, int LP, string GC, string TT, int SL)
        {
            PhongDAO.CapNhat(MP, TP, LP, GC, TT, SL);
        }
        public static PhongDTO LayPhong(string MP)
        {
            return PhongDAO.LayPhong(MP);
        }
        public static List<int> layDSTBThang(int thang)
        {
            List<int> arr = new List<int>();
            arr = PhongDAO.layDSTBThang(thang);
            List<PhongDTO> dsphg = new List<PhongDTO>();
            dsphg = PhongDAO.LayDSPhong();
            int temp = arr.Count;
            if (temp < dsphg.Count)
                for (int i = 0; i < dsphg.Count - temp; i++)
                    arr.Add(0);
            return arr;
        }
        public static LoaiPhongDTO LaylPhong(int MLP)
        {
            return PhongDAO.LaylPhong(MLP);
        }
        public static void lPSuaThem(int MLP, string ten, int DG, int SL, string xoa, bool kihieu)
        {
            PhongDAO.lPSuaThem(MLP, ten, DG, SL, xoa, kihieu);
        }
        public static void TimPhong(List<PhongDTO> temp, string maphong, string loaiphong, string tenphong, string tinhtrang)
        {
            List<PhongDTO> dsPhong = PhongBUS.LayDSPhong();
            for (int i = 0; i < dsPhong.Count; ++i)
            {
                if (KiemTraMaPhong(dsPhong[i], maphong) || maphong.Equals(""))
                    if (KiemTraLoaiPhong(dsPhong[i], loaiphong) || loaiphong.Equals(""))
                        if (KiemTraTenPhong(dsPhong[i], tenphong) || tenphong.Equals(""))
                            if (KiemTraTinhTrang(dsPhong[i], tinhtrang) || tinhtrang.Equals(""))
                                temp.Add(dsPhong[i]);

            }
        }

        private static bool KiemTraMaPhong(PhongDTO phong, string maphong)
        {
            if (phong.MaPhong.Equals(maphong))
                return true;
            return false;
        }
        private static bool KiemTraLoaiPhong(PhongDTO phong, string loaiphong)
        {
            if (phong.LoaiPhong.TenLoaiPhong.Equals(loaiphong))
                return true;
            return false;
        }
        private static bool KiemTraTenPhong(PhongDTO phong, string tenphong)
        {
            if (phong.TenPhong.Equals(tenphong))
                return true;
            return false;
        }
        private static bool KiemTraTinhTrang(PhongDTO phong, string tinhtrang)
        {
            if (phong.TinhTrang.Equals(tinhtrang))
                return true;
            return false;
        }
        public static int[] LapBaoCaoDoanhThu(int thang)
        {
            List<HoaDonDTO> dsHD = new List<HoaDonDTO>();
            dsHD = HoaDonBUS.layDSHoaDon();
            List<PhongDTO> dsphg = new List<PhongDTO>();
            dsphg = LayDSPhong();
            int[] arrDoanhThu = new int[dsphg.Count];
            for (int i = 0; i < dsHD.Count; i++)
            {
                if (dsHD[i].NgayTT.Month != thang)
                {
                    dsHD.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < dsHD.Count; i++)
            {
                List<ChiTietHoaDonDTO> dsCT = new List<ChiTietHoaDonDTO>();
                dsCT = dsHD[i].DsCTHD;
                for (int j = 0; j < dsCT.Count; j++)
                {
                    int tienphong = dsCT[j].TongCong;

                    for (int k = 0; k < dsphg.Count(); k++)
                        if (string.Compare(dsCT[j].Phieuthue.Phong.MaPhong, dsphg[k].MaPhong, true) == 0)
                        {
                            arrDoanhThu[k] += tienphong;
                            break;
                        }
                }
            }
            return arrDoanhThu;
        }
        public static int[] LapBaoCaoMatDo(int thang)
        {
            List<HoaDonDTO> dsHD = new List<HoaDonDTO>();
            dsHD = HoaDonBUS.layDSHoaDon();
            List<PhongDTO> dsphg = new List<PhongDTO>();
            dsphg = LayDSPhong();
            int[] arrNgayThue = new int[dsphg.Count];
            for (int i = 0; i < dsHD.Count; i++)
            {
                if (dsHD[i].NgayTT.Month != thang)
                {
                    dsHD.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < dsHD.Count; i++)
            {
                List<ChiTietHoaDonDTO> dsCT = new List<ChiTietHoaDonDTO>();
                dsCT = dsHD[i].DsCTHD;
                for (int j = 0; j < dsCT.Count; j++)
                {
                    int ngaythue = dsCT[j].SoNgayThue;

                    for (int k = 0; k < dsphg.Count(); k++)
                        if (string.Compare(dsCT[j].Phieuthue.Phong.MaPhong, dsphg[k].MaPhong, true) == 0)
                        {
                            arrNgayThue[k] += ngaythue;
                            break;
                        }
                }
            }
            return arrNgayThue;
        }
    }
}
