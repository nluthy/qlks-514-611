using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DAO
{
    public class PHIEUTHUEDAO : DataAccess
    {
        public static bool ThemPhieu(string MPT, string MP, DateTime day, string TT, KHACHHANG[] dsKH)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh;
                // if (kihieu == true)
                chuoiLenh = "insert into PHIEUTHUE(MaPhong,NgayBatDauThue,DaThanhToan,TienDichVu,MaPhieuThue) values(@MP,@day,@TT,@DV,@MPT)";
                // else chuoiLenh = "update KHACHHANG set HoTen=@HT,MaLoaiKH=@MLK,DiaChi=@DC,SoGiayTo=@GT where MaKH=@MKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@MP", OleDbType.LongVarChar);
                thamSo.Value = MP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@day", OleDbType.Date);
                thamSo.Value = day;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TT", OleDbType.LongVarChar);
                thamSo.Value = TT;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@DV", OleDbType.Integer);
                thamSo.Value = 0;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                thamSo.Value = MPT;
                lenh.Parameters.Add(thamSo);

                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                //  if (kihieu == true) 
                Adapter.InsertCommand = lenh;
                //  else Adapter.UpdateCommand = lenh;
                int dem = dsKH.Count<KHACHHANG>();
                for (int i = 0; i < dem; i++)
                    ThemCTPT(MPT, dsKH[i].MaKH);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return true;
        }
        private static void ThemCTPT(string MPT, string MKH)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "insert into CHITIETPHIEUTHUE(MaPhieuThue,MaKH) values (@MPT,@MKH)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamSo = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                thamSo.Value = MPT;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MKH", OleDbType.LongVarChar);
                thamSo.Value = MKH;
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                Adapter.InsertCommand = lenh;
            }
            catch
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
        }
        public static List<PHIEUTHUE> layDSPT()
        {
            OleDbConnection link = null;
            List<PHIEUTHUE> dsPhieu = new List<PHIEUTHUE>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from PHIEUTHUE,PHONG,LOAIPHONG where PHIEUTHUE.MaPhong=PHONG.MaPhong and PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    PHIEUTHUE phieu = new PHIEUTHUE();
                    phieu.MaPhieuThue = Doc.GetString(0);
                    phieu.NgayThue = Doc.GetDateTime(2);
                    phieu.TienDV = Doc.GetInt32(3);
                    phieu.DaThanhToan = Doc.GetString(4);
                    PHONG phg = new PHONG();
                    phg.MaPhong = Doc.GetString(5);
                    phg.TenPhong = Doc.GetString(6);
                    phg.GhiChu = Doc.GetString(8);
                    phg.TinhTrang = Doc.GetString(9);
                    phg.SLKhach = Doc.GetInt32(10);
                    LOAIPHONG loai = new LOAIPHONG();
                    loai.MaLoaiPhong = Doc.GetInt32(11);
                    loai.TenLoaiPhong = Doc.GetString(12);
                    loai.DonGia = Doc.GetInt32(13);
                    loai.SLKhachToiDa = Doc.GetInt32(14);
                    phg.LoaiPhong = loai;
                    phieu.Phong = phg;
                    dsPhieu.Add(phieu);
                }
                for (int i = 0; i < dsPhieu.Count; i++)
                {
                    List<KHACHHANG> dskh = new List<KHACHHANG>();
                    dskh = PHIEUTHUEDAO.NhapDSKhach(dsPhieu[i].MaPhieuThue);
                    dsPhieu[i].DsKH = dskh;
                }
            }
            catch (Exception ex)
            {
                dsPhieu = new List<PHIEUTHUE>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsPhieu;
        }
        private static List<KHACHHANG> NhapDSKhach(string maphieu)
        {
            OleDbConnection link = null;
            List<KHACHHANG> dsk = new List<KHACHHANG>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from CHITIETPHIEUTHUE where MaPhieuThue=@MPT";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamSo = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                thamSo.Value = maphieu;
                lenh.Parameters.Add(thamSo);
                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh = KHACHHANGDAO.LayKhach(Doc.GetString(1));
                    dsk.Add(kh);
                }
            }
            catch
            {
                dsk = new List<KHACHHANG>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsk;
        }
        public static PHIEUTHUE layPT(string MPT)
        {
            OleDbConnection link = null;
            PHIEUTHUE Phieu = new PHIEUTHUE();
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from PHIEUTHUE,PHONG,LOAIPHONG where PHIEUTHUE.MaPhong=PHONG.MaPhong and PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong and MaPhieuThue=@MPT";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamso = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                thamso.Value = MPT;
                lenh.Parameters.Add(thamso);

                OleDbDataReader Doc = lenh.ExecuteReader();
                Doc.Read();

                Phieu.MaPhieuThue = Doc.GetString(0);
                Phieu.NgayThue = Doc.GetDateTime(2);
                Phieu.TienDV = Doc.GetInt32(3);
                Phieu.DaThanhToan = Doc.GetString(4);
                PHONG phg = new PHONG();
                phg.MaPhong = Doc.GetString(5);
                phg.TenPhong = Doc.GetString(6);
                phg.GhiChu = Doc.GetString(8);
                phg.TinhTrang = Doc.GetString(9);
                phg.SLKhach = Doc.GetInt32(10);
                LOAIPHONG loai = new LOAIPHONG();
                loai.MaLoaiPhong = Doc.GetInt32(11);
                loai.TenLoaiPhong = Doc.GetString(12);
                loai.DonGia = Doc.GetInt32(13);
                loai.SLKhachToiDa = Doc.GetInt32(14);
                phg.LoaiPhong = loai;
                Phieu.Phong = phg;

                List<KHACHHANG> dskh = new List<KHACHHANG>();
                dskh = PHIEUTHUEDAO.NhapDSKhach(Phieu.MaPhieuThue);
                Phieu.DsKH = dskh;

            }
            catch (Exception ex)
            {
                Phieu = new PHIEUTHUE();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return Phieu;
        }
        public static void CapNhat(string MPT, string TT)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                int dv = 0;
                OleDbParameter thamSo = new OleDbParameter();
                OleDbCommand lenh = new OleDbCommand();
                try
                {
                    dv = int.Parse(TT);
                    string chuoiLenh = "update PHIEUTHUE set TienDichVu=@DV where MaPhieuThue=@MPT";
                    lenh = new OleDbCommand(chuoiLenh, link);
                    thamSo = new OleDbParameter("@DV", OleDbType.Integer);
                    thamSo.Value = dv;
                    lenh.Parameters.Add(thamSo);
                }
                catch
                {
                    string chuoiLenh = "update PHIEUTHUE set DaThanhToan=@TT where MaPhieuThue=@MPT";
                    lenh = new OleDbCommand(chuoiLenh, link);
                    thamSo = new OleDbParameter("@TT", OleDbType.LongVarChar);
                    thamSo.Value = TT;
                    lenh.Parameters.Add(thamSo);
                }
                finally
                {
                    thamSo = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                    thamSo.Value = MPT;
                    lenh.Parameters.Add(thamSo);
                    lenh.ExecuteNonQuery();
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.UpdateCommand = lenh;
                }
            }
            catch
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
        }
    }
}
