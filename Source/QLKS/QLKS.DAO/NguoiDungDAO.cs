using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using QLKS.DTO;

namespace QLKS.DAO
{
    public class NguoiDungDAO : DataAccess
    {
        public static DataTable hienThiTatCaNguoiDung()
        {
            OleDbConnection link = null;
            DataTable dt = new DataTable();

            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from NguoiDung order by TenDangNhap";


                OleDbCommand command = link.CreateCommand();
                command.CommandText = chuoiLenh;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);

                link.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }

            return dt;
        }

        public static NguoiDungDTO timNguoiDung(string tenDangNhap)
        {
            OleDbConnection link = null;
            NguoiDungDTO nguoidung = new NguoiDungDTO();
            //int ketQua = 0; // 0: Không tìm thấy người dùng có user name đó
            // 1: Đúng user name và mật khẩu
            //-1: Sai mật khẩu roài
            try
            {
                link = KetNoi();
                string chuoiLenh = "select * from NguoiDung where TenDangNhap = '" + tenDangNhap + "'";

                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                OleDbDataReader Doc = lenh.ExecuteReader();

                //if (!Doc.Read())
                //    return null;
                //else
                //{
                //    while (Doc.Read())
                //    {
                //        nguoidung.TenDangNhap = Doc.GetString(0);
                //        nguoidung.MatKhau = Doc.GetString(1);
                //        nguoidung.Email = Doc.GetString(2);
                //    }
                //}
                if (Doc.Read())
                {
                    nguoidung.TenDangNhap = Doc.GetString(0);
                    nguoidung.MatKhau = Doc.GetString(1);
                    nguoidung.Email = Doc.GetString(2);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }

            return nguoidung;
        }

        public static int kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            OleDbConnection link = null;
            NguoiDungDTO nguoiDung = new NguoiDungDTO();
            int ketQua = 0; 
                            // 0: Không tìm thấy người dùng có user name đó
                            // 1: Đúng user name và mật khẩu
                            //-1: Sai mật khẩu roài
            try
            {
                nguoiDung = timNguoiDung(tenDangNhap);
                if (nguoiDung == null)
                    ketQua = 0;
                else
                {
                    if (nguoiDung.MatKhau == matKhau)
                        ketQua = 1;
                    else
                        ketQua = -1;
                }

                //link = KetNoi();
                //string chuoiLenh = "select * from NguoiDung where TenDangNhap = '" + tenDangNhap + "'";

                //OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);
                //OleDbDataReader Doc = lenh.ExecuteReader();

                //if (!Doc.Read())
                //    ketQua = 0;
                //else
                //{
                //    while (Doc.Read())
                //    {
                //        nguoidung.Id = Doc.GetString(0);
                //        nguoidung.TenDangNhap = Doc.GetString(1);
                //        nguoidung.MatKhau = Doc.GetString(2);
                //        nguoidung.Email = Doc.GetString(3);
                //    }
                //}

                //if (matKhau == nguoidung.MatKhau)
                //    ketQua = 1;
                //else
                //    ketQua = -1;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }
            return ketQua;
        }

        public static int themNguoiDung(NguoiDungDTO nguoiDung)
        {
            OleDbConnection link = null;
            int ketQua = 0; // 0: Thêm thất bại
            // 1: Thêm thành công
            //-1: Đã tồn tại người dùng đó
            NguoiDungDTO kiemTraNguoiDung = new NguoiDungDTO();
            kiemTraNguoiDung = timNguoiDung(nguoiDung.TenDangNhap);

            if (kiemTraNguoiDung != null)
                ketQua = -1;
            else
                try
                {
                    link = KetNoi();
                    string chuoiLenh = "insert into NguoiDung (TenDangNhap, MatKhau, Email) values (@TenDangNhap, @MatKhau, @Email)";
                    OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                    OleDbParameter thamSo = new OleDbParameter("@TenDangNhap", OleDbType.LongVarChar);
                    thamSo.Value = nguoiDung.TenDangNhap;
                    lenh.Parameters.Add(thamSo);
                    thamSo = new OleDbParameter("@MatKhau", OleDbType.LongVarChar);
                    thamSo.Value = nguoiDung.MatKhau;
                    lenh.Parameters.Add(thamSo);
                    thamSo = new OleDbParameter("@Email", OleDbType.Integer);
                    thamSo.Value = nguoiDung.Email;
                    lenh.Parameters.Add(thamSo);

                    ketQua = lenh.ExecuteNonQuery();
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

            return ketQua;
        }

        public static bool xoaNguoiDung(string tenNguoiDung)
        {
            OleDbConnection link = null;
            int ketQua = 0;

            try
            {
                link = KetNoi();
                string chuoiLenh = "delete from NguoiDung where TenNguoiDung = '" + tenNguoiDung + "'";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                ketQua = lenh.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                if (link != null && link.State == System.Data.ConnectionState.Open)
                    link.Close();
            }

            if (ketQua == 0)
                return false;
            return true;
        }

        public static bool suaNguoiDung(NguoiDungDTO nguoiDung)
        {
            OleDbConnection link = null;
            int ketQua = 0;
            try
            {
                link = KetNoi();
                string chuoiLenh = "update NguoiDung set MatKhau=@MatKhau, Email = @Email where TenDangNhap = @TenDangNhap";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, link);

                OleDbParameter thamSo = new OleDbParameter("@MatKhau", OleDbType.LongVarChar);
                thamSo.Value = nguoiDung.MatKhau;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@Email", OleDbType.LongVarChar);
                thamSo.Value = nguoiDung.Email;
                lenh.Parameters.Add(thamSo);

                ketQua = lenh.ExecuteNonQuery();
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

            if (ketQua != 0)
                return true;
            return false;
        }
    }
}
