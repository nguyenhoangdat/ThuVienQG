using System;

namespace ThuVienQG.DTO
{
    public class TTPhieuNhapDTO
    {
        private DateTime mapn;
        private DauSachDTO mads;
        private int dongia;
        private int soluong;
        private DateTime ngaygiao;
        private DateTime mapg;
        private NXBDTO manxb;
        
        public TTPhieuNhapDTO(DateTime mapn, DauSachDTO mads, int dongia, int soluong, DateTime ngaygiao, NXBDTO manxb)
        {
            this.mapn = mapn;
            this.mads = mads;
            this.dongia = dongia;
            this.soluong = soluong;
            this.ngaygiao = ngaygiao;
            this.manxb = manxb;
        }

        public TTPhieuNhapDTO(DateTime mapn, DauSachDTO mads, int dongia, int soluong, DateTime ngaygiao, DateTime mapg, NXBDTO manxb)
        {
            this.mapn = mapn;
            this.mads = mads;
            this.dongia = dongia;
            this.soluong = soluong;
            this.ngaygiao = ngaygiao;
            this.mapg = mapg;
            this.manxb = manxb;
        }

        public DateTime Mapn { get => mapn; set => mapn = value; }
        public DauSachDTO Mads { get => mads; set => mads = value; }
        public string DauSach { get => mads.Ten; }
        public NXBDTO Manxb { get => manxb; set => manxb = value; }
        public string NXB { get => manxb.Ten; }
        public int Soluong { get => soluong; set => soluong = value; }
        public DateTime Ngaygiao { get => ngaygiao; set => ngaygiao = value; }
        public DateTime Mapg { get => mapg; set => mapg = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}
