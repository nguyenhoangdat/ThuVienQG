using System;

namespace ThuVienQG.DTO
{
    public class PhieuMuonDTO
    {
        private DateTime ngaymuon;
        private DocGiaDTO madg;

        public PhieuMuonDTO(DateTime ngaymuon)
        {
            this.ngaymuon = ngaymuon;
        }

        public PhieuMuonDTO(DateTime ngaymuon, DocGiaDTO madg)
        {
            this.ngaymuon = ngaymuon;
            this.madg = madg;
        }

        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DocGiaDTO Madg { get => madg; set => madg = value; }
        public string Docgia { get => madg.Ten; }
    }
}
