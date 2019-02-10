using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FAddReceiptNote : Form
    {
        /* Vấn đề thêm bản hiện thị chi tiết nhà cung cấp */
        private static List<PReceiptNote> pnlreceiptNotes = new List<PReceiptNote>();
        public FAddReceiptNote()
        {
            InitializeComponent();
        }
        /* Sự kiện load form là lấy danh sách đầu sách */
        private void FAddReceiptNote_Load(object sender, EventArgs e)
        {
            dgvTitles.DataSource = DauSachBUS.GetTitleBooks(null);
            dgvTitles.Columns[0].Visible = false;
            dgvTitles.Columns[1].HeaderText = "Tên đầu sách";
            dgvTitles.Columns[2].HeaderText = "Số lượng";
            dgvTitles.Columns[3].Visible = false;
            dgvTitles.Columns[4].Visible = false;
            dgvTitles.Columns[5].Visible = false;
            dgvTitles.Columns[6].Visible = false;
        }
        /* Sự kiện chọn sách đầu sách cần nhập bằng việc thêm một Panel sách nhập đã được tạo */
        private void dgvTitles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[e.RowIndex];
            if (CheckTitle(dauSach))
            {
                pnlreceiptNotes.Add(new PReceiptNote(dauSach));
                flpDetail.Controls.Add(pnlreceiptNotes[pnlreceiptNotes.Count - 1]);
            }
        }
        /* Phương thức kiểm tra đầu sách đã được thêm vào chưa */
        private bool CheckTitle(DauSachDTO dauSach)
        {
            foreach (PReceiptNote item in pnlreceiptNotes)
                if (dauSach.Mads == item.DauSach.Mads) return false;
            return true;
        }
        /* Sự kiện xóa đi Panel sách nhập khi được nhấn xóa bỏ */
        private void flpDetail_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnlreceiptNotes.Remove(e.Control as PReceiptNote);
            SumChange_ValueChanged(null, new EventArgs());
        }
        /* Sự kiện cập nhật lại tổng tiền khi có sự thay đổi */
        public static void SumChange_ValueChanged(object sender, EventArgs e)
        {
            lblSum.Text = SumPrice().ToString("#,0");
        }
        /* Phương thức trả ra tổng số tiền của phiếu nhập này */
        private static int SumPrice()
        {
            int sum = 0;
            foreach (PReceiptNote item in pnlreceiptNotes)
                sum += item.Price;
            return sum;
        }
        /* Sự kiện lưu thông tin phiếu nhập được tạo */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pnlreceiptNotes.Count < 1)
            {
                MessageBox.Show("Chưa có đầu sách cần nhập.", "Thông báo");
                return;
            }
            List<TTPhieuNhapDTO> phieuNhaps = new List<TTPhieuNhapDTO>();
            DateTime ngaynhap = DateTime.Now;
            foreach (PReceiptNote item in pnlreceiptNotes)
            {
                if (item.CheckReceiptNote())
                {
                    phieuNhaps.Add(new TTPhieuNhapDTO(
                            ngaynhap,
                            item.DauSach,
                            item.Price,
                            item.Quantity,
                            item.DeliveryDay,
                            item.Supplier
                    ));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                    return;
                }
            }
            if (TTPhieuNhapBUS.AddReceiptNote(phieuNhaps) < 1)
                MessageBox.Show("Lưu không thành công.", "Thông báo");
            else
                this.Close();
        }
    }
}