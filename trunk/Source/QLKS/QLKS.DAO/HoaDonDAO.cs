using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DAO
{
    public class HOADONDAO : DataAccess
    {
        public static List<HOADON> layDSHoaDon()
        {
            OleDbConnection link = null;
            List<HOADON> dsHoaDon = new List<HOADON>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from HOADON ";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    HOADON hd = new HOADON();
                    hd.MaHD = Doc.GetString(0);
                    hd.MaKH = Doc.GetString(1);
                    hd.NgayTT = Doc.GetDateTime(2);
                    hd.Thanhtien = Doc.GetInt32(3);
                    List<CHITIETHOADON> cthd = new List<CHITIETHOADON>();
                    cthd = HOADONDAO.layCTHD(hd.MaHD);
                    hd.DsCTHD = cthd;
                    dsHoaDon.Add(hd);
                }
            }
            catch (Exception ex)
            {
                dsHoaDon = new List<HOADON>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsHoaDon;
        }
        public static List<CHITIETHOADON> layCTHD(string MHD)
        {
            OleDbConnection link = null;
            List<CHITIETHOADON> dsChiTiet = new List<CHITIETHOADON>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from CHITIETHOADON where MaHoaDon =@MHD";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamso = new OleDbParameter("@MHD", OleDbType.LongVarChar);
                thamso.Value = MHD;
                lenh.Parameters.Add(thamso);
                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    CHITIETHOADON chitiet = new CHITIETHOADON();
                    chitiet.SoNgayThue = Doc.GetInt32(2);
                    chitiet.TienThue = Doc.GetInt32(3);
                    chitiet.TongCong = Doc.GetInt32(4);
                    string MPT = Doc.GetString(1);
                    PHIEUTHUE pt = new PHIEUTHUE();
                    pt = PHIEUTHUEDAO.layPT(MPT);
                    chitiet.Phieuthue = pt;
                    dsChiTiet.Add(chitiet);
                }
            }
            catch (Exception ex)
            {
                dsChiTiet = new List<CHITIETHOADON>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsChiTiet;
        }
        public static void themHD(string MHD, string MKH, DateTime ngayTT, int tien, List<CHITIETHOADON> arrHD)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "insert into HOADON(MaHoaDon,MaKH,NgayThanhToan,ThanhTien) values (@MHD,@MKH,@NTT,@tien)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamso = new OleDbParameter("@MHD", OleDbType.LongVarChar);
                thamso.Value = MHD;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@MKH", OleDbType.LongVarChar);
                thamso.Value = MKH;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@NTT", OleDbType.Date);
                thamso.Value = ngayTT;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@tien", OleDbType.Integer);
                thamso.Value = tien;
                lenh.Parameters.Add(thamso);

                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                Adapter.InsertCommand = lenh;

                for (int i = 0; i < arrHD.Count; i++)
                {
                    HOADONDAO.themCTPT(MHD, arrHD[i].Phieuthue.MaPhieuThue,
                        arrHD[i].SoNgayThue, arrHD[i].TienThue, arrHD[i].TongCong);
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
        private static void themCTPT(string MHD, string MPT, int songay, int tien, int tong)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "insert into CHITIETHOADON(MaHoaDon,MaPhieuThue,SoNgayThue,TienThue,TongCong) values (@MHD,@MPT,@SN,@tien,@tong)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamso = new OleDbParameter("@MHD", OleDbType.LongVarChar);
                thamso.Value = MHD;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@MPT", OleDbType.LongVarChar);
                thamso.Value = MPT;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@SN", OleDbType.Integer);
                thamso.Value = songay;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@tien", OleDbType.Integer);
                thamso.Value = tien;
                lenh.Parameters.Add(thamso);
                thamso = new OleDbParameter("@tong", OleDbType.Integer);
                thamso.Value = tong;
                lenh.Parameters.Add(thamso);

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
    }
}
