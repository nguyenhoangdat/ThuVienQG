using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class TTPhieuNhapBUS
    {
        /* Phương thức lấy toàn bộ phiếu nhập */
        public static List<PhieuDTO> GetReceiptNotes()
        {
            return TTPhieuNhapDAO.SelecReceiptNotes();
        }
        /* Phương thức lấy toàn bộ phiếu trả */
        public static List<PhieuDTO> GetDeliveryNotes()
        {
            return TTPhieuNhapDAO.SelecDeliveryNotes();
        }
        /* Phương thức lấy toàn bộ phiếu mượn mà trong đó có ít nhất đầu sách chưa giao */
        public static List<PhieuDTO> GetReceiptNotesNotDeliveryNotes()
        {
            return TTPhieuNhapDAO.SelecReceiptNotesNotDeliveryNotes();
        }
        /* Phương thức lấy toàn bộ chi tiết phiếu nhập và trả về tổng giá tiền */
        public static int GetReceiptNote(PhieuDTO phieuNhap, out List<TTPhieuNhapDTO> chiTiet )
        {
            chiTiet = new List<TTPhieuNhapDTO>();
            chiTiet = TTPhieuNhapDAO.SelecReceiptNote(phieuNhap);
            return SumPriceNote(chiTiet);
        }
        /* Phương thức lấy toàn bộ chi tiết phiếu giao và trả về tổng giá tiền */
        public static int GetDeliveryNote(PhieuDTO phieuGiao, out List<TTPhieuNhapDTO> chiTiet)
        {
            chiTiet = new List<TTPhieuNhapDTO>();
            chiTiet = TTPhieuNhapDAO.SelecDeliveryNote(phieuGiao);
            return SumPriceNote(chiTiet);
        }
        /* Phương thức tính tổng giá tiền của một danh sách truyền vào */
        private static int SumPriceNote(List<TTPhieuNhapDTO> phieuNhaps)
        {
            int sum = 0;
            foreach(TTPhieuNhapDTO chiTiet in phieuNhaps)
                sum += chiTiet.Dongia;
            return sum;
        }
        /* Phương thức lấy chi tiết nhập của nhà cung cấp chưa giao */
        public static List<TTPhieuNhapDTO> GetReceiptNotesOfSupplier(NXBDTO nhaCungCap)
        {
            return TTPhieuNhapDAO.SelecReceiptNotesOfSupplier(nhaCungCap);
        }
        /* Phương thức thêm đơn nhập và trả về số dòng đã thêm
         * thêm phiếu nhập trước rồi thêm chi tiết phiếu nhập  */
        public static int AddReceiptNote(List<TTPhieuNhapDTO> phieuNhaps)
        {
            PhieuDTO phieuNhap = new PhieuDTO(phieuNhaps[0].Mapn);
            int check = TTPhieuNhapDAO.InserReceiptNote(phieuNhap);
            if(check > 0)
                return (check + TTPhieuNhapDAO.InserDetailReceiptNote(phieuNhaps));
            return check;
        }
        /* Phương thức thay đổi phiếu nhập trong chi tiết phiếu nhập trả về số dòng thay đổi
         * Đơn hàng nào có đơn giá là không thì là xóa đơn hàng đó 
         * Còn đơn nào giá khác không thì chỉ thay đổi thuộc tính */
        public static int ChangeReceiptNote(PhieuDTO phieuNhap,List<TTPhieuNhapDTO> detail)
        {
            int numrow = 0;
            int delete = 0; // Biến đếm số dòng đã xóa
            foreach(TTPhieuNhapDTO chitiet in detail)
            {
                if (chitiet.Dongia == 0)
                {
                    numrow += TTPhieuNhapDAO.DeletDetailReceiptNote(chitiet);
                    delete++;
                    continue;
                }
                if(chitiet.Mapg.Ticks == 0)
                    numrow += TTPhieuNhapDAO.ChangDetailReceiptNote(chitiet);
            }
            if (delete == detail.Count)
                numrow += TTPhieuNhapDAO.DeletReceiptNote(phieuNhap);
            return numrow;
        }
        /* Phương thức thêm 1 phiếu giao trả về 
         * thêm phiếu giao trước khi thêm chi tiết phiếu giao */
        public static int AddDeliveryNote(List<TTPhieuNhapDTO> phieuGiaos)
        {
            PhieuDTO phieuGiao = new PhieuDTO(phieuGiaos[0].Mapg);
            int check = TTPhieuNhapDAO.InserDeliveryNote(phieuGiao);
            if (check > 0)
                return (check + TTPhieuNhapDAO.InserDetailDeliveryNote(phieuGiaos));
            return check;
        }
    }
}
