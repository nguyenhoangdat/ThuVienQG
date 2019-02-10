using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class SachBUS
    {
        /* Phương thức lấy 1 danh sách sách của 1 đầu sách */
        public static List<SachDTO> GetBooks(DauSachDTO dauSach)
        {
            return SachDAO.SelecBooks(dauSach);
        }
        /* Phương thức thay đổi trạng thái sách và trả về số dòng thực hiện được
         * thay đổi từ mấy sang còn và ngược lại 
         * không thay đổi sách đã bị mượn */
        public static int ChangeStatusBook(ref SachDTO sach)
        {
            if (sach.Trangthai == SachDTO.IsLend) return -1;
            if (sach.Trangthai == SachDTO.IsLost)
                sach.Trangthai = SachDTO.Exist;
            else sach.Trangthai = SachDTO.Lost;
            int check = SachDAO.UpdatStatusBook(sach);
            if (sach.Trangthai == SachDTO.Exist)
                sach.Trangthai = SachDTO.IsExisted;
            else sach.Trangthai = SachDTO.IsLost;
            return check;
        }
        /* Phương thức tìm vị trí sách mất gần nhất
         * Duyệt từ đầu mảng đến cuối mảng 
         * trả về -1 khi không tìm thấy */
        private static int FindLostBook(List<SachDTO> saches)
        {
            for (int i = 0; i < saches.Count; i++)
                if (saches[i].Trangthai == SachDTO.IsLost)
                    return i;
            return -1;
        }
        /* Phương thức tìm vị trí sách mất gần nhất 
         * Duyệt từ cuối mảng lên đầu mảng
         * trả về -1 khi không tìm thấy */
        private static int FindLostBookLastIndex(List<SachDTO> saches)
        {
            for (int i = saches.Count - 1; i > -1; i--)
                if (saches[i].Trangthai == SachDTO.IsLost)
                    return i;
            return -1;
        }
        /* Phương thức thêm sách mới của một đầu sách, trả về số dòng thêm được 
         * Nếu có tồn tại một vị trí mất thì thay đổi vị trí đó thành sách 
         * còn không thì thêm một vị trí mới */
        public static int AddBook(DauSachDTO dauSach)
        {
            List<SachDTO> saches = GetBooks(dauSach);
            int indexlost = FindLostBook(saches);
            SachDTO sachmoi = null;
            if (indexlost == -1)
            {
                sachmoi = new SachDTO(dauSach, saches.Count + 1);
                for (int i = 0; i < saches.Count; i++)
                    if (i + 1 < saches[i].Stt)
                    {
                        sachmoi.Stt = i + 1;
                        break;
                    }
                return SachDAO.InserBook(sachmoi);
            }
            sachmoi = saches[indexlost];
            return ChangeStatusBook(ref sachmoi);
        }
        /* Phương thức xóa đi một cuốn sách được đánh dấu mất trả về số dòng thực hiện được */
        public static int DelBook(DauSachDTO dauSach)
        {
            List<SachDTO> saches = GetBooks(dauSach);
            int indexlost = FindLostBookLastIndex(saches);
            if (indexlost != -1)
                return SachDAO.DeletBook(saches[indexlost]);
            return 0;
        }
        /* Phương thức kiểm tra các đầu sách có sách không */
        private static bool NotHaveBook(DauSachDTO dauSach)
        {
            List<SachDTO> saches = GetBooks(dauSach);
            foreach (SachDTO sach in saches)
                if (sach.Trangthai != SachDTO.IsLost) return false;
            return true;
        }
        /* Phương thức xóa tất cả sách của một đầu sách */
        public static int DelAllBooks(DauSachDTO dauSach)
        {
            if (NotHaveBook(dauSach))
                return SachDAO.DeletAllBooks(dauSach);
            return -1;
        }
        /* Phương thức lấy danh sách sách đã mượn của một độc giả */
        public static List<SachDTO> GetBookIsLend(DocGiaDTO docGia)
        {
            return SachDAO.SelecBookIsLend(docGia);
        }
        /* Phương thức lấy số lượng sách đã mượn của độc giả */
        private static int NumberBookIsLend(DocGiaDTO docGia)
        {
            return SachDAO.CountBookIsLend(docGia);
        }
        /* Phương thức trả về số lượng sách có thể được mượn */
        public static int NumberBookCanBeLend(DocGiaDTO docGia)
        {
            return (docGia.Maloai.Socuon - NumberBookIsLend(docGia));
        }
    }
}
