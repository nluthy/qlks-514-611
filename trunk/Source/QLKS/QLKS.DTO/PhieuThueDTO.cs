using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKS.DTO
{
    public class PhieuThueDTO
    {
        private string maPhieuThue;

        public string MaPhieuThue
        {
            get { return maPhieuThue; }
            set { maPhieuThue = value; }
        }
        private PhongDTO phong;

        public PhongDTO Phong
        {
            get { return phong; }
            set { phong = value; }
        }
        private DateTime ngayThue;

        public DateTime NgayThue
        {
            get { return ngayThue; }
            set { ngayThue = value; }
        }
        private string daThanhToan;

        public string DaThanhToan
        {
            get { return daThanhToan; }
            set { daThanhToan = value; }
        }
        private List<KhachHangDTO> dsKH;

        public List<KhachHangDTO> DsKH
        {
            get { return dsKH; }
            set { dsKH = value; }
        }
        private int tienDV;

        public int TienDV
        {
            get { return tienDV; }
            set { tienDV = value; }
        }
    }

}
