using System;

namespace ThuVienQG.DTO
{
    public class SachDTO
    {
        private DauSachDTO mads;
        private int stt;
        private string trangthai = String.Empty;
        public const string IsLend = "Được mượn";
        public const string IsLost = "Đã mất";
        public const string IsExisted = "Vẫn còn";
        public const string Exist = "0";
        public const string Lost = "1";

        public SachDTO(DauSachDTO mads, int stt)
        {
            this.mads = mads;
            this.stt = stt;
        }

        public SachDTO(DauSachDTO mads, int stt, string trangthai)
        {
            this.mads = mads;
            this.stt = stt;
            this.trangthai = trangthai;
        }

        public DauSachDTO Mads { get => mads; set => mads = value; }
        public string Ten { get => mads.Ten; }
        public int Stt { get => stt; set => stt = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
