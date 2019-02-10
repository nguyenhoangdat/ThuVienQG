namespace ThuVienQG.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ThuVienQG.BUS;
    using ThuVienQG.DTO;

    public partial class FAddLendNote : Form
    {
        List<PLendNote> pnlLendNotes = new List<PLendNote>();
        public FAddLendNote()
        {
            InitializeComponent();
        }
        /* Sự kiện lấy danh sách thể loại để cho vào cbb thể loại 
         * và lấy danh sách độc giả cho vào cbb độc giả */
        private void FAddLendNote_Load(object sender, EventArgs e)
        {
            InitBookCate();
            InitReader();
        }
        private void InitBookCate()
        {
            List<TheLoaiDTO> bookCates = TheLoaiBUS.GetBookCategorys();
            if (bookCates.Count > 0)
            {
                cbbBookCate.DataSource = bookCates;
                cbbBookCate.DisplayMember = "ten";
            }
            else
            {
                cbbBookCate.Items.Add("Không tìm thấy thể loại");
                cbbBookCate.SelectedIndex = 0;
            }
        }
        private void InitReader()
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
        /* Sự kiện lấy danh sách đầu sách dựa trên cbb đã chọn */
        private void cbbBookCate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbBookCate.SelectedValue != null)
            {
                TheLoaiDTO theLoai = cbbBookCate.SelectedValue as TheLoaiDTO;
                dgvTitles.DataSource = DauSachBUS.GetTitleBooks(theLoai);
                dgvTitles.Columns[0].Visible = false;
                dgvTitles.Columns[1].HeaderText = "Đầu sách";
                dgvTitles.Columns[2].Visible = false;
                dgvTitles.Columns[3].Visible = false;
                dgvTitles.Columns[4].Visible = false;
                dgvTitles.Columns[5].Visible = false;
                dgvTitles.Columns[6].Visible = false;
            }
        }
        /* Sự kiện chọn một dòng trong dgv để hiện thị chi tiết đầu sách và trạng thái từng cuốn sách */
        private void dgvTitles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTitles.CurrentRow != null)
            {
                int index = dgvTitles.CurrentRow.Index;
                DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[index];
                dgvBooks.DataSource = SachBUS.GetBooks(dauSach);
                dgvBooks.Columns[0].Visible = false;
                dgvBooks.Columns[1].Visible = false;
                dgvBooks.Columns[2].HeaderText = "Số thứ tự";
                dgvBooks.Columns[3].HeaderText = "Trạng thái";
            }
        }
        /* Sự kiện chọn sách đầu sách cần nhập bằng việc thêm một Panel sách mượn đã được tạo */
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            SachDTO sach = (dgvBooks.DataSource as List<SachDTO>)[e.RowIndex];
            if (sach.Trangthai == SachDTO.IsExisted)
            {
                if (CheckBook(sach))
                {
                    pnlLendNotes.Add(new PLendNote(sach));
                    flpDetail.Controls.Add(pnlLendNotes[pnlLendNotes.Count - 1]);
                }
            }
        }
        /* Phương thức kiểm tra sách đã được chọn chưa */
        private bool CheckBook(SachDTO sach)
        {
            foreach (PLendNote item in pnlLendNotes)
                if (sach.Mads.Mads == item.Sach.Mads.Mads && sach.Stt == item.Sach.Stt) return false;
            return true;
        }
        /* Sự kiện chọn độc giả trong cbb */
        private void cbbReader_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbReader.SelectedValue != null)
            {
                DocGiaDTO docGia = cbbReader.SelectedValue as DocGiaDTO;
                if (docGia.TrangThai != DocGiaDTO.UnLock)
                    MessageBox.Show("Độc giả đã khóa.", "Thông báo");
            }
        }
        /* Sự kiện xóa đi panel sách mượn khi được xóa bỏ */
        private void flpDetail_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnlLendNotes.Remove(e.Control as PLendNote);
        }
        /* Sự kiện lưu thông tin phiếu mượn */
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra chọn độc giả
            if (cbbReader.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn độc giả.", "Thông báo");
                return;
            }
            // Kiểm tra trạng thái độc giả
            DocGiaDTO docGia = cbbReader.SelectedValue as DocGiaDTO;
            if (docGia.TrangThai != DocGiaDTO.UnLock)
            {
                MessageBox.Show("Độc giả đã khóa.", "Thông báo");
                return;
            }
            // Kiểm tra số sách chọn khác rỗng
            if (pnlLendNotes.Count == 0)
            {
                MessageBox.Show("Chưa có cuốn sách nào được chọn.", "Thông báo");
                return;
            }
            // Kiểm tra số lượng sách có thể mượn
            int numBookCanBeLend = SachBUS.NumberBookCanBeLend(docGia);
            if (numBookCanBeLend < pnlLendNotes.Count)
            {
                MessageBox.Show($"Độc giả chỉ mượn thêm được {numBookCanBeLend}.", "Thông báo");
                return;
            }
            List<TTPhieuMuonDTO> phieuMuons = new List<TTPhieuMuonDTO>();
            DateTime ngaymuon = DateTime.Now;
            foreach (PLendNote item in pnlLendNotes)
                phieuMuons.Add(new TTPhieuMuonDTO(
                    new PhieuMuonDTO(ngaymuon, docGia),
                    item.Sach
                ));
            int check = TTPhieuMuonBUS.AddLendNote(phieuMuons);
            // Kiểm tra lưu thông tin
            if (check < 1)
                MessageBox.Show("Lưu không thành công.", "Thông báo");
            else this.Close();
        }
        /* Sự kiện thêm độc giả */
        private void btnAddReader_Click(object sender, EventArgs e)
        {
            FAddReader reader = new FAddReader();
            reader.ShowDialog();
            InitReader();
        }
    }
}
