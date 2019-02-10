using System;

namespace ThuVienQG.DTO
{
    public class NXBDTO
    {
        private string manxb;
        private string ten;
        private string email;
        private string sdt;
        private string fax;

        public NXBDTO(string ten, string email, string sdt, string fax)
        {
            this.ten = ten;
            this.email = email;
            this.sdt = sdt;
            this.fax = fax;
        }

        public NXBDTO(string ten)
        {
            this.ten = ten;
        }

        public NXBDTO(string manxb, string ten, string email, string sdt, string fax)
        {
            this.manxb = manxb;
            this.ten = ten;
            this.email = email;
            this.sdt = sdt;
            this.fax = fax;
        }

        public string Manxb { get => manxb; set => manxb = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Fax { get => fax; set => fax = value; }
    }
}
