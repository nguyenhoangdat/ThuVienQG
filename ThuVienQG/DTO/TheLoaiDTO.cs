using System;

namespace ThuVienQG.DTO
{
    public class TheLoaiDTO
    {
        private string matl;
        private string ten;

        public TheLoaiDTO(string ten)
        {
            this.ten = ten;
        }

        public TheLoaiDTO(string matl, string ten)
        {
            this.matl = matl;
            this.ten = ten;
        }

        public string Matl { get => matl; set => matl = value; }
        public string Ten { get => ten; set => ten = value; }
    }
}
