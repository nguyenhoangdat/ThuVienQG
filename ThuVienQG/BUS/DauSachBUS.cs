using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class DauSachBUS
    {
        public static List<DauSachDTO> GetTitleBooks(TheLoaiDTO theLoai)
        {
            return DauSachDAO.SelecTitleBooks(theLoai);
        }
        public static int ChangeTitleBook(string mads, string ten, int soluong, int songay, int phat, TheLoaiDTO theLoai, int giabia)
        {
            return DauSachDAO.UpdatTitleBook(new DauSachDTO(mads, ten, soluong, songay, phat, giabia, theLoai));
        }
        public static int DelTitBook(DauSachDTO dauSach)
        {
            if (SachBUS.DelAllBooks(dauSach) > -1)
                return DauSachDAO.DeletTitleBook(dauSach);
            return -1;
        }
        public static int AddTitle(string ten,int soluong,int songay,int phat,TheLoaiDTO theLoai,int giabia)
        {
            return DauSachDAO.InsertTitleBook(new DauSachDTO(ten, soluong, songay, phat, giabia, theLoai));
        }
    }
}
