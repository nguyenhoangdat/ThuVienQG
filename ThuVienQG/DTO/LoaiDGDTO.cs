using System;

namespace ThuVienQG.DTO
{
    public class LoaiDGDTO
    {
        private string maloai;
        private int socuon;

        public LoaiDGDTO(string maloai, int socuon)
        {
            this.maloai = maloai;
            this.socuon = socuon;
        }

        public string Maloai { get => maloai; set => maloai = value; }
        public int Socuon { get => socuon; set => socuon = value; }
        public string Socuonstr { get => "Tối đa " + socuon.ToString() +" cuốn"; }
    }
}
