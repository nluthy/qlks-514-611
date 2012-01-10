using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKS.DTO;
using System.Data.OleDb;

namespace QLKS.DAO
{
    public class KhachHangDAO : DataAccess
    {
        public static List<KhachHangDTO> LayDSKhach()
        {
            OleDbConnection link = null;
            List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from KhachHang,LoaiKhach Where KhachHang.MaLoaiKH=LoaiKhach.MaLoaiKH order by MaKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);


                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.MaKH = Doc.GetString(0);//1 MAKH 2 ten 3... 4 Diachi 5.so giay to
                    kh.HoTen = Doc.GetString(1);//7.ten loai
                    LoaiKhachDTO loai = new LoaiKhachDTO();
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
                dsKH = new List<KhachHangDTO>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsKH;
        }
        public static List<LoaiKhachDTO> LayDSLoaiKhach()
        {
            OleDbConnection link = null;
            List<LoaiKhachDTO> ds = new List<LoaiKhachDTO>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LoaiKhach";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    LoaiKhachDTO lphg = new LoaiKhachDTO();
                    lphg.MaLoaiKH = Doc.GetInt16(0);
                    lphg.TenLoaiKH = Doc.GetString(1);
                    lphg.HeSo = Doc.GetInt16(2);
                    lphg.Xoa = Doc.GetString(3);
                    ds.Add(lphg);
                }
            }
            catch (Exception ex)
            {
                ds = new List<LoaiKhachDTO>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return ds;
        }
        public static KhachHangDTO LayKhach(string MKH)
        {
            OleDbConnection link = null;
            KhachHangDTO kh = new KhachHangDTO();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from KhachHang,LoaiKhach where MaKH=@MKH and KhachHang.MaLoaiKH=LoaiKhach.MaLoaiKH";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamso = new OleDbParameter("@MKH", OleDbType.LongVarChar);
                thamso.Value = MKH;
                lenh.Parameters.Add(thamso);
                OleDbDataReader Doc = lenh.ExecuteReader();
                Doc.Read();
                kh.MaKH = Doc.GetString(0);
                kh.HoTen = Doc.GetString(1);
                LoaiKhachDTO loai = new LoaiKhachDTO();
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
                    chuoiLenh = "insert into KhachHang(HoTen,MaLoaiKH,DiaChi,SoGiayTo,MaKH) values(@HT,@MLK,@DC,@GT,@MKH)";
                else chuoiLenh = "update KhachHang set HoTen=@HT,MaLoaiKH=@MLK,DiaChi=@DC,SoGiayTo=@GT where MaKH=@MKH";
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
        public static LoaiKhachDTO LaylKhach(int MLK)
        {
            OleDbConnection link = null;
            LoaiKhachDTO LK = new LoaiKhachDTO();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LoaiKhach where MaLoaiKH=@MLK";
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
                    chuoiLenh = "insert into LoaiKhach(TenLoaiKH,HeSo,DaXoa,MaLoaiKH) values(@ten,@HS,@xoa,@MLK)";
                else chuoiLenh = "update LoaiKhach set TenLoaiKH=@ten,HeSo=@HS,DaXoa=@xoa where MaLoaiKH=@MLK";
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
