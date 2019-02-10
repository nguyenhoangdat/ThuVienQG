using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class TTPhieuMuonBUS
    {
        /* Phương thức lấy toàn bộ phiếu mượn */
        public static List<PhieuMuonDTO> GetLendNotes()
        {
            return TTPhieuMuonDAO.SelecLendNotes();
        }
        /* Phương thức lấy toàn bộ phiếu trả */
        public static List<PhieuDTO> GetPayBackNotes()
        {
            return TTPhieuMuonDAO.SelecPayBackNotes();
        }
        /* Phương thức lấy toàn bộ phiếu mượn mà trong đó có ít nhất 1 sách chưa trả */
        public static List<PhieuMuonDTO> GetLendNotesNotPayBackNotes()
        {
            return TTPhieuMuonDAO.SelecLendNotesNotPayBackNotes();
        }
        /* Phương thức lấy chi tiết phiếu mượn của 1 phiếu mượn rồi trả về tổng giá tiền phạt */
        public static int GetLendNote(PhieuMuonDTO phieuMuon, out List<TTPhieuMuonDTO> chiTiet)
        {
            chiTiet = new List<TTPhieuMuonDTO>();
            chiTiet = TTPhieuMuonDAO.SelecLendNote(phieuMuon);
            return SumPriceNote(chiTiet);
        }
        /* Phương thức lấy chi tiết phiếu mượn của 1 phiếu trả rồi trả về tổng giá tiền phạt */
        public static int GetPayBackNote(PhieuDTO phieuTra, out List<TTPhieuMuonDTO> chiTiet)
        {
            chiTiet = new List<TTPhieuMuonDTO>();
            chiTiet = TTPhieuMuonDAO.SelecPayBackNote(phieuTra);
            return SumPriceNote(chiTiet);
        }
        /* Phương thức trả về tổng số tiền phạt trong 1 danh sách chi tiết phiếu mượn */
        private static int SumPriceNote(List<TTPhieuMuonDTO> phieuTras)
        {
            int sum = 0;
            foreach (TTPhieuMuonDTO chiTiet in phieuTras)
                sum += chiTiet.Phat;
            return sum;
        }
        /* Phương thức thêm phiếu mượn rồi trả về số dòng thực hiện được
         * thêm phiếu mượn trước rồi thêm chi tiết phiếu mượn sau */
        public static int AddLendNote(List<TTPhieuMuonDTO> phieuMuons)
        {
            PhieuMuonDTO phieuMuon = phieuMuons[0].Mapm;
            int check = TTPhieuMuonDAO.InserLendNote(phieuMuon);
            if (check > 0)
                return (check + TTPhieuMuonDAO.InserDetailLendNote(phieuMuons));
            return 0;
        }
        /* Phương thức lấy chi tiết các phiếu mượn ở những phiếu mượn khác nhau
         mà có sách chưa trả */
        public static List<TTPhieuMuonDTO> GetLendBookNotPayBack(DocGiaDTO docGia)
        {
            return TTPhieuMuonDAO.SelectLendBookNotPayBack(docGia);
        }
        public static int AddPayBackNote(List<TTPhieuMuonDTO> phieuTras)
        {
            PhieuDTO phieuTra = new PhieuDTO(phieuTras[0].Mapt);
            int check = TTPhieuMuonDAO.InserPayBackNote(phieuTra);
            if (check > 0)
                return (check + TTPhieuMuonDAO.InserDetailPayBackNote(phieuTras));
            return 0;
        }
    }
}
