using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FEditReceiptNote : Form
    {
        private static List<PReceiptNote> pnlreceiptNotes;
        private PhieuDTO phieuNhap;
        /* Khởi tạo khi truyền một phiếu nhập vào để lấy thông tin chi tiết phiếu nhập */
        public FEditReceiptNote(PhieuDTO phieuNhap)
        {
            InitializeComponent();
            this.phieuNhap = phieuNhap;
            int gia = TTPhieuNhapBUS.GetReceiptNote(phieuNhap, out List<TTPhieuNhapDTO> chitiet);
            ConvertToPanel(chitiet);
            lblSum.Text = gia.ToString("#,0");
        }
        /* Phương thức chuyển đổi từ TTPhieuNhapDTO sang panel của phiếu nhập */
        private void ConvertToPanel(List<TTPhieuNhapDTO> phieuNhaps)
        {
            pnlreceiptNotes = new List<PReceiptNote>();
            foreach (TTPhieuNhapDTO chitiet in phieuNhaps)
            {
                if (chitiet.Mapg.Ticks != 0)
                    pnlreceiptNotes.Add(new PReceiptNote(chitiet, false));
                else
                    pnlreceiptNotes.Add(new PReceiptNote(chitiet, true));
                flpDetail.Controls.Add(pnlreceiptNotes[pnlreceiptNotes.Count - 1]);
            }
        }
        /* Sự kiện thay đổi tổng tiền khi có sự thay đổi */
        public static void SumChange_ValueChanged(object sender, EventArgs e)
        {
            lblSum.Text = SumPrice().ToString("#,0");
        }
        /* Phương thức trả ra tổng số tiền của phiếu nhập này */
        private static int SumPrice()
        {
            int sum = 0;
            foreach (PReceiptNote item in pnlreceiptNotes)
                if (!item.Disposing && !item.IsDisposed)
                    sum += item.Price;
            return sum;
        }
        /* Sự kiện xóa đi Panel sách nhập khi được nhấn xóa bỏ */
        private void flpDetail_ControlRemoved(object sender, ControlEventArgs e)
        {
            SumChange_ValueChanged(null, new EventArgs());
        }
        /* Sự kiện lưu thông tin đã thay đổi của các đầu sách cần nhập */
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu lại thay đổi thông tin phiếu nhập không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<TTPhieuNhapDTO> receiptNote = new List<TTPhieuNhapDTO>();
                foreach (PReceiptNote item in pnlreceiptNotes)
                {
                    if (!item.IsDisposed)
                        receiptNote.Add(new TTPhieuNhapDTO(phieuNhap.Ngaynhap, item.DauSach, item.Price, item.Quantity, item.DeliveryDay, item.Supplier));
                    else
                        receiptNote.Add(new TTPhieuNhapDTO(phieuNhap.Ngaynhap, item.DauSach, 0, item.Quantity, item.DeliveryDay, item.Supplier));
                }
                if (TTPhieuNhapBUS.ChangeReceiptNote(phieuNhap, receiptNote) < 1)
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
                else
                    this.Close();
            }
        }
    }
}
