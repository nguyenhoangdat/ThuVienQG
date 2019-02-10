namespace ThuVienQG.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ThuVienQG.BUS;
    using ThuVienQG.DTO;

    public partial class FAddPayBackNote : Form
    {
        private static List<PPayBackNote> pnlpayBackNotes = new List<PPayBackNote>();
        public FAddPayBackNote()
        {
            InitializeComponent();
        }
        /* Sự kiện load form là lấy danh sách độc giả đổ vào cbb */
        private void FAddPayBackNote_Load(object sender, EventArgs e)
        {
            List<DocGiaDTO> docGias = DocGiaBUS.GetReaders(null);
            if (docGias.Count > 0)
            {
                cbbReader.DataSource = docGias;
                cbbReader.DisplayMember = "ten";
            }
            else
            {
                cbbReader.Items.Add("Không tìm thấy độc giả");
                cbbReader.SelectedIndex = 0;
            }
        }
        /* Sự kiện chọn độc giả trong cbb */
        private void cbbReader_SelectedValueChanged(object sender, EventArgs e)
        {
            RemoveAll();
            if (cbbReader.SelectedValue != null)
            {
                DocGiaDTO docGia = cbbReader.SelectedValue as DocGiaDTO;
                dgvBookIsLend.DataSource = TTPhieuMuonBUS.GetLendBookNotPayBack(docGia);
                dgvBookIsLend.Columns[0].Visible = false;
                dgvBookIsLend.Columns[1].Visible = false;
                dgvBookIsLend.Columns[2].HeaderText = "Đầu sách";
                dgvBookIsLend.Columns[3].HeaderText = "Số thứ tự";
                dgvBookIsLend.Columns[4].Visible = false;
                dgvBookIsLend.Columns[5].HeaderText = "Ngày hẹn";
                dgvBookIsLend.Columns[6].Visible = false;
            }
        }
        /* Phương thức xóa toàn bộ chi tiết phiếu trả */
        private void RemoveAll()
        {
            while (pnlpayBackNotes.Count > 0)
                flpDetail.Controls.Remove(pnlpayBackNotes[0]);
        }
        /* Sự kiện thêm một đơn chưa giao bằng việc tạo một panel sách giao */
        private void dgvBookIsLend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            TTPhieuMuonDTO chitiet = (dgvBookIsLend.DataSource as List<TTPhieuMuonDTO>)[e.RowIndex];
            if (CheckReceNote(chitiet))
            {
                pnlpayBackNotes.Add(new PPayBackNote(chitiet));
                FAddPayBackNote.SumChange_TextChanged(null, new EventArgs());
                flpDetail.Controls.Add(pnlpayBackNotes[pnlpayBackNotes.Count - 1]);
            }
        }
        /* Phương thức kiểm tra đơn nhập đã được chọn chưa */
        private bool CheckReceNote(TTPhieuMuonDTO sachmuon)
        {
            foreach (PPayBackNote item in pnlpayBackNotes)
                if (item.Sach == sachmuon) return false;
            return true;
        }
        /* Sự kiện xóa đi panel sách trả khi được xóa bỏ */
        private void flpDetail_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnlpayBackNotes.Remove(e.Control as PPayBackNote);
        }
        /* Phương thức tính tổng số tiền */
        private static int SumPrice()
        {
            int sum = 0;
            foreach (PPayBackNote item in pnlpayBackNotes)
                sum += item.Sach.Phat;
            return sum;
        }
        /* Sự kiện cập nhật lại tổng tiền khi có sự thay đổi */
        public static void SumChange_TextChanged(object sender, EventArgs e)
        {
            lblSum.Text = SumPrice().ToString("#,0");
        }
        /* Sự kiện lưu thông tin phiếu trả */
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra không cho lưu khi chưa chọn sách trả
            if (pnlpayBackNotes.Count == 0)
            {
                MessageBox.Show("Chưa có sách trả.", "Thông báo");
                return;
            }
            // Lưu thông tin
            int month = -1;
            DocGiaDTO docGia = cbbReader.SelectedValue as DocGiaDTO;
            List<TTPhieuMuonDTO> chitiet = new List<TTPhieuMuonDTO>();
            DateTime today = DateTime.Now;
            foreach (PPayBackNote item in pnlpayBackNotes)
            {
                item.Sach.Mapt = today;
                chitiet.Add(item.Sach);
                if (item.MonthBlock() > -1)
                    if (month != 0)
                        month = item.MonthBlock();
            }
            int check = TTPhieuMuonBUS.AddPayBackNote(chitiet);
            if(check == 0)
            {
                MessageBox.Show("Lưu không thành công.", "Thông báo");
                return;
            }
            // Khóa người dùng
            if (month > -1)
            {
                DocGiaBUS.LockOrUnlock(ref docGia, month);
                if (month > 0)
                    MessageBox.Show($"Độc giả {docGia.Ten} bị khóa {month} tháng.", "Thông báo");
                else
                    MessageBox.Show($"Độc giả {docGia.Ten} bị khóa vĩnh viễn.", "Thông báo");
            }
            this.Close();
        }
    }
}
