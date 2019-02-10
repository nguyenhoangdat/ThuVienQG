using System;

namespace ThuVienQG.DTO
{
    public class PhieuDTO
    {
        DateTime ngaynhap;

        public PhieuDTO(DateTime ngaynhap)
        {
            this.ngaynhap = ngaynhap;
        }

        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
    }
}
