using System;

namespace ThuVienQG.DTO
{
    public class DocGiaDTO
    {
        private string madg;
        private string ten;
        private string sdt;
        private DateTime ngaykhoa;
        private DateTime ngaymo;
        private LoaiDGDTO maloai;
        public const string UnLock = "Không khóa";

        public DocGiaDTO(string ten)
        {
            this.ten = ten;
        }

        public DocGiaDTO(string ten,string sdt, LoaiDGDTO maloai)
        {
            this.ten = ten;
            this.sdt = sdt;
            this.maloai = maloai;
        }

        public DocGiaDTO(string madg, string ten, string sdt)
        {
            this.madg = madg;
            this.ten = ten;
            this.sdt = sdt;
        }

        public DocGiaDTO(string madg, string ten, string sdt, LoaiDGDTO maloai)
        {
            this.madg = madg;
            this.ten = ten;
            this.sdt = sdt;
            this.maloai = maloai;
        }

        public DocGiaDTO(string madg, string ten, string sdt, DateTime ngaykhoa, DateTime ngaymo, LoaiDGDTO maloai)
        {
            this.madg = madg;
            this.ten = ten;
            this.sdt = sdt;
            this.ngaykhoa = ngaykhoa;
            this.ngaymo = ngaymo;
            this.maloai = maloai;
        }

        public string Madg { get => madg; set => madg = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Ngaykhoa { get => ngaykhoa; set => ngaykhoa = value; }
        public DateTime Ngaymo { get => ngaymo; set => ngaymo = value; }
        public string TrangThai
        {
            get => ngaykhoa.Ticks == 0 ? "Không khóa" : (ngaymo.Ticks == 0 ? "Khóa không thời hạn" : "Khóa có thời hạn");
        }
        public string TrangThaiChiTiet
        {
            get => (ngaykhoa.Ticks != 0) ? "Khóa(" + ngaykhoa.ToShortDateString() + ((ngaymo.Ticks != 0) ? "-" + ngaymo.ToShortDateString() : "") + ")" : "Không khóa";
        }
        public LoaiDGDTO Maloai { get => maloai; set => maloai = value; }
    }
}
