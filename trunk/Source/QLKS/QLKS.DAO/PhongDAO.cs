using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DAO
{
    public class PHONGDAO : DataAccess
    {
        public static List<PHONG> LayDSPhong()
        {
            OleDbConnection link = null;
            List<PHONG> dsPhong = new List<PHONG>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select MaPhong,TenPhong,PHONG.MaLoaiPhong,TenLoaiPhong,SLKhachToiDa,DonGia,GhiChu,TinhTrang,SLKhach from PHONG , LOAIPHONG Where PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong order by MaPhong";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);


                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    PHONG phg = new PHONG();
                    phg.MaPhong = Doc.GetString(0);
                    phg.TenPhong = Doc.GetString(1);
                    LOAIPHONG Loai = new LOAIPHONG();
                    Loai.MaLoaiPhong = Doc.GetInt32(2);
                    Loai.TenLoaiPhong = Doc.GetString(3);
                    Loai.SLKhachToiDa = Doc.GetInt32(4);
                    Loai.DonGia = Doc.GetInt32(5);
                    phg.LoaiPhong = Loai;
                    if (!Doc.IsDBNull(7))
                        phg.TinhTrang = Doc.GetString(7);
                    if (!Doc.IsDBNull(6))
                        phg.GhiChu = Doc.GetString(6);
                    if (!Doc.IsDBNull(8))
                        phg.SLKhach = Doc.GetInt32(8);

                    dsPhong.Add(phg);
                }
            }
            catch (Exception ex)
            {
                dsPhong = new List<PHONG>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsPhong;
        }
        public static List<LOAIPHONG> LayDSLoaiPhong()
        {
            OleDbConnection link = null;
            List<LOAIPHONG> dsPhong = new List<LOAIPHONG>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LOAIPHONG  ";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbDataReader Doc = lenh.ExecuteReader();
                while (Doc.Read())
                {
                    LOAIPHONG lphg = new LOAIPHONG();
                    lphg.MaLoaiPhong = Doc.GetInt32(0);
                    lphg.TenLoaiPhong = Doc.GetString(1);
                    lphg.DonGia = Doc.GetInt32(2);
                    lphg.SLKhachToiDa = Doc.GetInt32(3);
                    lphg.Daxoa = Doc.GetString(4);
                    dsPhong.Add(lphg);
                }
            }
            catch (Exception ex)
            {
                dsPhong = new List<LOAIPHONG>();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return dsPhong;
        }
        public static void NhapPhong(string MP, string TP, int LP, string GC)
        {

            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "insert into PHONG(MaPhong,TenPhong,MaLoaiPhong,TinhTrang,GhiChu,SLKhach) values(@MP,@Ten,@MLP,@TinhTrang,@GhiChu,@SLKhach)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@MP", OleDbType.LongVarChar);
                thamSo.Value = MP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@Ten", OleDbType.LongVarChar);
                thamSo.Value = TP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MLP", OleDbType.Integer);
                thamSo.Value = LP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TinhTrang", OleDbType.LongVarChar);
                thamSo.Value = "No";
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@GhiChu", OleDbType.LongVarChar);
                thamSo.Value = GC;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@SLKhach", OleDbType.Integer);
                thamSo.Value = 0;
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                Adapter.InsertCommand = lenh;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
        }
        public static void XoaPhong(string MP)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "delete from PHONG where (MaPhong=@MP or MaPhong>@MP) and TinhTrang=@TT";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamSo = new OleDbParameter("@MP", OleDbType.LongVarChar);
                if (MP == "") MP = "007";
                thamSo.Value = MP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TT", OleDbType.LongVarChar);
                thamSo.Value = "No";
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
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
        public static void CapNhat(string MP, string TP, int LP, string GC, string TT, int SL)
        {

            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh = "update PHONG set TenPhong=@TP,MaLoaiPhong=@LP,GhiChu=@GC,Tinhtrang=@TT,SLKhach=@SL where MaPhong=@MP";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@TP", OleDbType.LongVarChar);
                thamSo.Value = TP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@LP", OleDbType.Integer);
                thamSo.Value = LP;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@GC", OleDbType.LongVarChar);
                thamSo.Value = GC;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TT", OleDbType.LongVarChar);
                thamSo.Value = TT;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@SL", OleDbType.Integer);
                thamSo.Value = SL;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MP", OleDbType.LongVarChar);
                thamSo.Value = MP;
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                Adapter.UpdateCommand = lenh;

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

        public static PHONG LayPhong(string MP)
        {
            OleDbConnection link = null;
            PHONG phg = new PHONG();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from PHONG , LOAIPHONG Where PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong and MaPhong=@MP";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamSo = new OleDbParameter("@MP", OleDbType.LongVarChar);
                thamSo.Value = MP;
                lenh.Parameters.Add(thamSo);

                OleDbDataReader Doc = lenh.ExecuteReader();
                if (Doc.Read())
                {
                    phg.MaPhong = Doc.GetString(0);
                    phg.TenPhong = Doc.GetString(1);
                    LOAIPHONG loai = new LOAIPHONG();
                    loai.MaLoaiPhong = Doc.GetInt32(2);
                    loai.TenLoaiPhong = Doc.GetString(7);
                    loai.DonGia = Doc.GetInt32(8);
                    loai.SLKhachToiDa = Doc.GetInt32(9);
                    phg.LoaiPhong = loai;
                    phg.GhiChu = Doc.GetString(3);
                    phg.TinhTrang = Doc.GetString(4);
                    phg.SLKhach = Doc.GetInt32(5);
                }
                else phg.GhiChu = "Phong khong ton tai";
            }
            catch (Exception ex)
            {
                phg = new PHONG();
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return phg;
        }
        public static List<int> layDSTBThang(int thang)
        {
            OleDbConnection link = null;
            List<int> arr = new List<int>();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select Tien from THONGKETHIETBI Where  Thang =@thang  order by MaPhong ";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamso = new OleDbParameter("@thang", OleDbType.Integer);
                thamso.Value = thang;
                lenh.Parameters.Add(thamso);

                OleDbDataReader Doc = lenh.ExecuteReader();

                while (Doc.Read())
                {
                    int i = Doc.GetInt32(0);
                    arr.Add(i);
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
            return arr;
        }
        public static LOAIPHONG LaylPhong(int MLP)
        {
            OleDbConnection link = null;
            LOAIPHONG lphg = new LOAIPHONG();
            try
            {
                link = KetNoi();
                string chuoiLenh = "Select * from LOAIPHONG where MaLoaiPhong=@MLP ";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbParameter thamso = new OleDbParameter("@MLP", OleDbType.Integer);
                thamso.Value = MLP;
                lenh.Parameters.Add(thamso);
                OleDbDataReader Doc = lenh.ExecuteReader();
                Doc.Read();

                lphg.MaLoaiPhong = Doc.GetInt32(0);
                lphg.TenLoaiPhong = Doc.GetString(1);
                lphg.DonGia = Doc.GetInt32(2);
                lphg.SLKhachToiDa = Doc.GetInt32(3);
                lphg.Daxoa = Doc.GetString(4);
            }
            catch
            {

            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return lphg;
        }
        public static void lPSuaThem(int MLP, string ten, int DG, int SL, string xoa, bool kihieu)
        {
            OleDbConnection link = null;
            try
            {
                link = KetNoi();
                string chuoiLenh;
                if (kihieu == true)
                    chuoiLenh = "insert into LOAIPHONG(TenLoaiPhong,DonGia,SLKhachToiDa,DaXoa,MaLoaiPhong) values(@ten,@DG,@SL,@xoa,@MLP)";
                else chuoiLenh = "update LOAIPHONG set TenLoaiPhong=@ten,DonGia=@DG,SLKhachToiDa=@SL,DaXoa=@xoa where MaLoaiPhong=@MLP";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@ten", OleDbType.LongVarChar);
                thamSo.Value = ten;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@DG", OleDbType.Integer);
                thamSo.Value = DG;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@SL", OleDbType.Integer);
                thamSo.Value = SL;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@xoa", OleDbType.LongVarChar);
                thamSo.Value = xoa;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@MLP", OleDbType.LongVarChar);
                thamSo.Value = MLP;
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
