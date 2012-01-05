using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DAO
{
    public class KHACHHANGDAO : DataAccess
    {
        public static List<KHACHHANG> LayDSKhach()
        {
            OleDbConnection link = null;
            List<KHACHHANG> dsKH = new List<KHACHHANG>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from KHACHHANG,LOAIKHACH Where KHACHHANG.MaLoaiKH=LOAIKHACH.MaLoaiKH order by MaKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);


                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh.MaKH = Doc.GetString(0);//1 MAKH 2 ten 3... 4 Diachi 5.so giay to
                    kh.HoTen = Doc.GetString(1);//7.ten loai
                    LOAIKHACH loai = new LOAIKHACH();
                    loai.MaLoaiKH = Doc.GetInt16(2);
                    loai.TenLoaiKH = Doc.GetString(6);
                    loai.HeSo = Doc.GetInt16(7);
                    kh.LoaiKhach = loai;
                    kh.DiaChi = Doc.GetString(3);
                    kh.SoGiayTo = Doc.GetString(4);
                    dsKH.Add(kh);
                }
            }
            catch (Exception ex)
            {
                dsKH = new List<KHACHHANG>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsKH;
        }
        public static List<LOAIKHACH> LayDSLoaiKhach()
        {
            OleDbConnection link = null;
            List<LOAIKHACH> ds = new List<LOAIKHACH>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LOAIKHACH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    LOAIKHACH lphg = new LOAIKHACH();
                    lphg.MaLoaiKH = Doc.GetInt16(0);
                    lphg.TenLoaiKH = Doc.GetString(1);
                    lphg.HeSo = Doc.GetInt16(2);
                    lphg.Xoa = Doc.GetString(3);
                    ds.Add(lphg);
                }
            }
            catch (Exception ex)
            {
                ds = new List<LOAIKHACH>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return ds;
        }
        public static KHACHHANG LayKhach(string MKH)
        {
            OleDbConnection link = null;
            KHACHHANG kh = new KHACHHANG();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from KHACHHANG,LOAIKHACH where MaKH=@MKH and KHACHHANG.MaLoaiKH=LOAIKHACH.MaLoaiKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamso = new OleDbParameter("@MKH", OleDbType.LongVarChar);
                thamso.Value = MKH;
                lenh.Parameters.Add(thamso);
                OleDbDataReader Doc = lenh.ExecuteReader();
                Doc.Read();
                kh.MaKH = Doc.GetString(0);
                kh.HoTen = Doc.GetString(1);
                LOAIKHACH loai = new LOAIKHACH();
                loai.MaLoaiKH = Doc.GetInt16(2);
                loai.TenLoaiKH = Doc.GetString(6);
                loai.HeSo = Doc.GetInt16(7);
                kh.LoaiKhach = loai;
                kh.DiaChi = Doc.GetString(3);
                kh.SoGiayTo = Doc.GetString(4);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return kh;

        }
        public static void ThemKhach(string MKH, string HT, int MLK, string DC, string GT, bool kihieu)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh;
                if (kihieu == true)
                    chuoiLenh = "insert into KHACHHANG(HoTen,MaLoaiKH,DiaChi,SoGiayTo,MaKH) values(@HT,@MLK,@DC,@GT,@MKH)";
                else chuoiLenh = "update KHACHHANG set HoTen=@HT,MaLoaiKH=@MLK,DiaChi=@DC,SoGiayTo=@GT where MaKH=@MKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@HT", OleDbType.LongVarChar);
                thamSo.Value = HT;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MLK", OleDbType.Integer);
                thamSo.Value = MLK;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@DC", OleDbType.LongVarChar);
                thamSo.Value = DC;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@GT", OleDbType.LongVarChar);
                thamSo.Value = GT;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MKH", OleDbType.LongVarChar);
                thamSo.Value = MKH;
                lenh.Parameters.Add(thamSo);

                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                if (kihieu == true) Adapter.InsertCommand = lenh;
                else Adapter.UpdateCommand = lenh;
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
        public static LOAIKHACH LaylKhach(int MLK)
        {
            OleDbConnection link = null;
            LOAIKHACH LK = new LOAIKHACH();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LOAIKHACH where MaLoaiKH=@MLK";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamso = new OleDbParameter("@MLK", OleDbType.Integer);
                thamso.Value = MLK;
                lenh.Parameters.Add(thamso);
                OleDbDataReader Doc = lenh.ExecuteReader();
                Doc.Read();
                LK.MaLoaiKH = Doc.GetInt16(0);
                LK.TenLoaiKH = Doc.GetString(1);
                LK.HeSo = Doc.GetInt16(2);
                LK.Xoa = Doc.GetString(3);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return LK;
        }
        public static void lKSuaThem(int MLK, string ten, int HS, string xoa, bool kihieu)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh;
                if (kihieu == true)
                    chuoiLenh = "insert into LOAIKHACH(TenLoaiKH,HeSo,DaXoa,MaLoaiKH) values(@ten,@HS,@xoa,@MLK)";
                else chuoiLenh = "update LOAIKHACH set TenLoaiKH=@ten,HeSo=@HS,DaXoa=@xoa where MaLoaiKH=@MLK";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@ten", OleDbType.LongVarChar);
                thamSo.Value = ten;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@HS", OleDbType.Integer);
                thamSo.Value = HS;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@xoa", OleDbType.LongVarChar);
                thamSo.Value = xoa;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MLK", OleDbType.LongVarChar);
                thamSo.Value = MLK;
                lenh.Parameters.Add(thamSo);

                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                if (kihieu == true) Adapter.InsertCommand = lenh;
                else Adapter.UpdateCommand = lenh;
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
