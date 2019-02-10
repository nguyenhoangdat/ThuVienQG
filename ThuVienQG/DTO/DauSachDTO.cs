using System;

namespace ThuVienQG.DTO
{
    public class DauSachDTO
    {
        private string mads;
        private string ten;
        private int soluong;
        private int songaytoida;
        private int sotienphat;
        private int giabia;
        private TheLoaiDTO matl;

        public DauSachDTO(string ten)
        {
            this.ten = ten;
        }

        public DauSachDTO(string mads, string ten)
        {
            this.mads = mads;
            this.ten = ten;
        }

        public DauSachDTO(string ten, int songaytoida)
        {
            this.ten = ten;
            this.songaytoida = songaytoida;
        }

        public DauSachDTO(string ten, int soluong, int songaytoida, int sotienphat, int giabia, TheLoaiDTO matl)
        {
            this.ten = ten;
            this.soluong = soluong;
            this.songaytoida = songaytoida;
            this.sotienphat = sotienphat;
            this.giabia = giabia;
            this.matl = matl;
        }

        public DauSachDTO(string mads, string ten, int songaytoida, int sotienphat, int giabia)
        {
            this.mads = mads;
            this.ten = ten;
            this.songaytoida = songaytoida;
            this.sotienphat = sotienphat;
            this.giabia = giabia;
        }

        public DauSachDTO(string mads, string ten, int soluong, int songaytoida, int sotienphat, int giabia, TheLoaiDTO matl)
        {
            this.mads = mads;
            this.ten = ten;
            this.soluong = soluong;
            this.songaytoida = songaytoida;
            this.sotienphat = sotienphat;
            this.giabia = giabia;
            this.matl = matl;
        }

        public string Mads { get => mads; set => mads = value; }
        public string Ten { get => ten; set => ten = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Songaytoida { get => songaytoida; set => songaytoida = value; }
        public int Sotienphat { get => sotienphat; set => sotienphat = value; }
        public int Giabia { get => giabia; set => giabia = value; }
        public TheLoaiDTO Matl { get => matl; set => matl = value; }
    }
}
