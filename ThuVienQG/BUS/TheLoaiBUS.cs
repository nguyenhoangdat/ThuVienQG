using System.Collections.Generic;
using ThuVienQG.DTO;
using ThuVienQG.DAO;

namespace ThuVienQG.BUS
{
    public class TheLoaiBUS
    {
        public static List<TheLoaiDTO> GetBookCategorys()
        {
            return TheLoaiDAO.SelecBookCategorys();
        }
        public static int AddBookCategory(string theLoai)
        {
            return TheLoaiDAO.InserBookCategory(new TheLoaiDTO(theLoai));
        }
        public static int ChangeBookCategory(TheLoaiDTO theLoai)
        {
            return TheLoaiDAO.UpdatBookCategory(theLoai);
        }
    }
}
