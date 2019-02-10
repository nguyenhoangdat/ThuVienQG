using System;

namespace ThuVienQG.DTO
{
    public class TTPhieuMuonDTO
    {
        private PhieuMuonDTO mapm;
        private SachDTO mads;
        private int phat;
        private DateTime mapt;

        public TTPhieuMuonDTO(PhieuMuonDTO mapm, SachDTO mads)
        {
            this.mapm = mapm;
            this.mads = mads;
        }

        public TTPhieuMuonDTO(PhieuMuonDTO mapm, SachDTO mads, int phat, DateTime mapt)
        {
            this.mapm = mapm;
            this.mads = mads;
            this.phat = phat;
            this.mapt = mapt;
        }

        public PhieuMuonDTO Mapm { get => mapm; set => mapm = value; }
        public SachDTO Mads { get => mads; set => mads = value; }
        public string DauSach { get => mads.Ten; }
        public int Stt { get => mads.Stt; }
        public int Phat { get => phat; set => phat = value; }
        public string Ngayhen { get => mapm.Ngaymuon.AddDays(mads.Mads.Songaytoida).ToShortDateString(); }
        public DateTime Mapt { get => mapt; set => mapt = value; }
    }
}
