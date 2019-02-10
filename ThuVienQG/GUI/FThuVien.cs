using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FThuVien : Form
    {
        private const string All = "Tất cả";
        private const string pPhone = @"^0[35789]\d{8}$";
        private const string pEmail = @"[a-z0-9._%+-]{1,40}[@]{1}[a-z]{1,10}[.]{1}[a-z]{3}";
        private const int tabTitle = 0;
        private const int tabReader = 1;
        private const int tabSupplier = 2;
        private const int tabReceNote = 3;
        private const int tabDeliNote = 4;
        private const int tabLendNote = 5;
        private const int tabPayBackNote = 6;
        public FThuVien()
        {
            InitializeComponent();
        }
        /* Sự kiện load sẽ chọn tab đầu tiên để gọi sự kiện chọn tab */
        private void FThuVien_Load(object sender, EventArgs e)
        {
            InitBookCate(ref cbbBookCate);
        }
        /* Sự kiện chọn các tab để load dữ liệu theo mục đã chọn */
        private void ctnManager_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case tabTitle: InitBookCate(ref cbbBookCate); break;
                case tabReader: InitTypeOfReaders(); break;
                case tabSupplier: InitSupplier(); break;
                case tabReceNote: InitReceNotes(); break;
                case tabDeliNote: InitDeliNotes(); break;
                case tabLendNote: InitLendNotes(); break;
                case tabPayBackNote: InitPayBackNotes(); break;
            }
        }
        /* Phương thức khởi tạo tab đầu sách là lấy toàn bộ thể loại để đổ vào combobox */
        private void InitBookCate(ref ComboBox cbbBC)
        {
            List<TheLoaiDTO> theLoais = TheLoaiBUS.GetBookCategorys();
            if (theLoais.Count > 0)
            {
                cbbBC.DataSource = theLoais;
                cbbBC.DisplayMember = "Ten";
            }
            else
            {
                cbbBC.Items.Add("Không tìm thấy thể loại");
                cbbBC.SelectedIndex = 0;
            }
        }
        /* Phương thức khởi tạo tab độc giả là lấy toàn bộ loại độc giả để đổ vào combobox */
        private void InitTypeOfReaders()
        {
            List<LoaiDGDTO> loaiDGs = LoaiDGBUS.GetTypeOfReaders();
            if (loaiDGs.Count > 0)
            {
                cbbTypeOfReaders.DataSource = loaiDGs;
                cbbTypeOfReaders.DisplayMember = "socuonstr";
            }
            else
            {
                cbbTypeOfReaders.Items.Add("Không tìm thấy loại độc giả");
                cbbTypeOfReaders.SelectedIndex = 0;
            }
        }
        /* Phương thức khởi tạo tab nhà cung cấp là lấy danh sách nhà cung cấp để vào dgv*/
        private void InitSupplier()
        {
            List<NXBDTO> nhaCungCaps = NXBBUS.GetSuppliers();
            if (nhaCungCaps.Count > 0)
            {
                dgvSuppliers.DataSource = nhaCungCaps;
                dgvSuppliers.Columns[0].Visible = false;
                dgvSuppliers.Columns[1].HeaderText = "Nhà cung cấp";
                dgvSuppliers.Columns[2].HeaderText = "Email";
                dgvSuppliers.Columns[3].HeaderText = "Số điện thoại";
                dgvSuppliers.Columns[4].HeaderText = "Fax";
            }
            else
            {
                dgvSuppliers.DataSource = null;
                lbNameSupplier.Text = String.Empty;
                lbEmailSupplier.Text = String.Empty;
                lbPhoneSupplier.Text = String.Empty;
                lbFaxSupplier.Text = String.Empty;
                dgvNotDeliBook.DataSource = null;
            }
        }
        /* Phương thức khỏi tạo tab thông tin phiếu nhập dựa trên rdb để lấy thông tin phiếu nhập */
        private void InitReceNotes()
        {
            List<PhieuDTO> receNotes;
            if (rdbAllReceptNotes.Checked)
                receNotes = TTPhieuNhapBUS.GetReceiptNotes();
            else
                receNotes = TTPhieuNhapBUS.GetReceiptNotesNotDeliveryNotes();
            if (receNotes.Count > 0)
            {
                dgvReceNotes.DataSource = receNotes;
                dgvReceNotes.Columns[0].HeaderText = "Thời gian lập";
            }
            else
            {
                dgvReceNotes.DataSource = null;
                lbDayReceNote.Text = String.Empty;
                dgvReceNote.DataSource = null;
                lbSumPriceRN.Text = "0";
                btnEditReceNote.Enabled = false;
            }
        }
        /* Phương thức khỏi tạo tab thông tin phiếu giao là lấy toàn bộ danh sách phiếu giao đổ vào dgv */
        private void InitDeliNotes()
        {
            List<PhieuDTO> deliNotes = TTPhieuNhapBUS.GetDeliveryNotes();
            if (deliNotes.Count > 0)
            {
                dgvDeliNotes.DataSource = deliNotes;
                dgvDeliNotes.Columns[0].HeaderText = "Thời gian lập";
            }
            else
            {
                dgvDeliNotes.DataSource = null;
                lbDayDeliNote.Text = String.Empty;
                lbNCC.Text = String.Empty;
                dgvDeliNote.DataSource = null;
                lbSumPriceDN.Text = "0";
            }
        }
        /* Phương thức khỏi tạo tab thông tin phiếu mượn là lấy toàn bộ danh sách phiếu mượn đổ vào dgv */
        private void InitLendNotes()
        {
            List<PhieuMuonDTO> lendNotes;
            if (rdbAllLendNotes.Checked)
                lendNotes = TTPhieuMuonBUS.GetLendNotes();
            else
                lendNotes = TTPhieuMuonBUS.GetLendNotesNotPayBackNotes();
            if (lendNotes.Count > 0)
            {
                dgvLendNotes.DataSource = lendNotes;
                dgvLendNotes.Columns[0].HeaderText = "Thời gian lập";
                dgvLendNotes.Columns[1].Visible = false;
                dgvLendNotes.Columns[2].HeaderText = "Độc giả";
            }
            else
            {
                dgvLendNotes.DataSource = null;
                lbDayLendBook.Text = String.Empty;
                lbDocGia.Text = String.Empty;
                dgvLendNote.DataSource = null;
            }
        }
        /* Phương thức khỏi tạo tab thông tin phiếu trả là lấy toàn bộ danh sách phiếu trả đổ vào dgv */
        private void InitPayBackNotes()
        {
            List<PhieuDTO> payBackNotes = TTPhieuMuonBUS.GetPayBackNotes();
            if (payBackNotes.Count > 0)
            {
                dgvPayBackNotes.DataSource = payBackNotes;
                dgvPayBackNotes.Columns[0].HeaderText = "Thời gian lập";
            }
            else
            {
                dgvPayBackNotes.DataSource = null;
                lbDayPayBackBook.Text = String.Empty;
                dgvPayBackNote.DataSource = null;
                lbSumPricePB.Text = "0";
            }
        }
        /* Sự kiện thoát form sẽ ngắt kết nối đến cơ sở dữ liệu */
        private void FThuVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            DAO.MySQL.DisConnec();
        }
        /// <summary>
        /// Tabpage Đầu sách
        /// </summary>
        /* Sự kiện chọn thể loại trong cbb để lấy dữ liệu đầu sách cho vào dgv */
        private void cbbBookCate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbBookCate.SelectedValue != null)
            {
                TheLoaiDTO theLoai = cbbBookCate.SelectedValue as TheLoaiDTO;
                dgvTitles.DataSource = DauSachBUS.GetTitleBooks(theLoai);
                dgvTitles.Columns[0].Visible = false;
                dgvTitles.Columns[1].HeaderText = "Tên";
                dgvTitles.Columns[2].HeaderText = "Số lượng";
                dgvTitles.Columns[3].HeaderText = "Số ngày";
                dgvTitles.Columns[4].HeaderText = "Số tiền phạt";
                dgvTitles.Columns[5].HeaderText = "Giá bìa";
                dgvTitles.Columns[6].Visible = false;
                btnAddBook.Enabled = true;
                btnDelBook.Enabled = true;
                btnDeleTit.Enabled = true;
            }
            if (dgvTitles.Rows.Count == 0)
            {
                lbNameTit.Text = String.Empty;
                lbQuantity.Text = String.Empty;
                lbDay.Text = String.Empty;
                lbMulct.Text = String.Empty;
                lbBookCate.Text = String.Empty;
                lbPrice.Text = String.Empty;
                dgvBooks.DataSource = null;
                btnAddBook.Enabled = false;
                btnDelBook.Enabled = false;
                btnDeleTit.Enabled = false;
            }
        }
        /* Sự kiện chọn một dòng trong dgv để hiện thị chi tiết đầu sách và trạng thái từng cuốn sách */
        private void dgvTitle_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTitles.CurrentRow != null)
            {
                int index = dgvTitles.CurrentRow.Index;
                DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[index];
                lbNameTit.Text = dauSach.Ten;
                lbQuantity.Text = dauSach.Soluong.ToString();
                lbDay.Text = dauSach.Songaytoida.ToString();
                lbMulct.Text = dauSach.Sotienphat.ToString("#,0");
                lbBookCate.Text = dauSach.Matl.Ten;
                lbPrice.Text = dauSach.Giabia.ToString("#,0");
                dgvBooks.DataSource = SachBUS.GetBooks(dauSach);
                dgvBooks.Columns[0].Visible = false;
                dgvBooks.Columns[1].Visible = false;
                dgvBooks.Columns[2].HeaderText = "Số thứ tự";
                dgvBooks.Columns[3].HeaderText = "Trạng thái";
            }
        }
        /* Sự kiện double click vào các thông tin chi tiết đầu sách để add các control
         * để thay đổi thông tin chi tiêt */
        private void Title_DoubleClick(object sender, EventArgs e)
        {
            // Tên đầu sách
            txbNameTit.Text = lbNameTit.Text;
            pnlBook.Controls.Remove(lbNameTit);
            pnlBook.Controls.Add(txbNameTit);
            // Số lượng sách
            nudQuantity.Text = lbQuantity.Text;
            pnlBook.Controls.Remove(lbQuantity);
            pnlBook.Controls.Add(nudQuantity);
            // Số ngày tối đa
            nudDay.Text = lbDay.Text;
            pnlBook.Controls.Remove(lbDay);
            pnlBook.Controls.Add(nudDay);
            // Tiền phạt 
            nudMulct.Text = lbMulct.Text;
            pnlBook.Controls.Remove(lbMulct);
            pnlBook.Controls.Add(nudMulct);
            // Thể loại đầu sách
            cbbBookCategorys.DataSource = cbbBookCate.DataSource;
            cbbBookCate.DataSource = null;
            cbbBookCategorys.DisplayMember = "ten";
            pnlBook.Controls.Remove(lbBookCate);
            pnlBook.Controls.Add(cbbBookCategorys);
            pnlBook.Controls.Add(btnAddBookCate);
            // Giá đầu sách
            nudPrice.Text = lbPrice.Text;
            pnlBook.Controls.Remove(lbPrice);
            pnlBook.Controls.Add(nudPrice);
            // Nút lưu đầu sách
            pnlBook.Controls.Remove(btnAddBook);
            pnlBook.Controls.Remove(btnDelBook);
            pnlBook.Controls.Remove(btnDeleTit);
            pnlBook.Controls.Add(btnSaveTit);
            dgvBooks.Enabled = false;
            pnlTitle.Enabled = false;
        }
        /* Sự kiện bấm nút lưu để lưu thông tin đầu sách đã nhập */
        private void btnSaveTit_Click(object sender, EventArgs e)
        {
            if (!CheckInput_Title())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
            if (CheckChange_Title())
            {
                int check = DauSachBUS.ChangeTitleBook(dgvTitles[0, dgvTitles.CurrentRow.Index].Value.ToString(), txbNameTit.Text, (Int32)nudQuantity.Value, (Int32)nudDay.Value, (Int32)nudMulct.Value, cbbBookCategorys.SelectedValue as TheLoaiDTO, (Int32)nudPrice.Value);
                if (check < 1)
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
            }
            // Tên đầu sách
            pnlBook.Controls.Remove(txbNameTit);
            pnlBook.Controls.Add(lbNameTit);
            // Số lượng đầu sách
            pnlBook.Controls.Remove(nudQuantity);
            pnlBook.Controls.Add(lbQuantity);
            // Số ngày tối đa
            pnlBook.Controls.Remove(nudDay);
            pnlBook.Controls.Add(lbDay);
            // Số tiến phạt
            pnlBook.Controls.Remove(nudMulct);
            pnlBook.Controls.Add(lbMulct);
            // Thể loại đầu sách
            pnlBook.Controls.Remove(cbbBookCategorys);
            pnlBook.Controls.Remove(btnAddBookCate);
            pnlBook.Controls.Add(lbBookCate);
            // Giá cuốn sách
            pnlBook.Controls.Remove(nudPrice);
            pnlBook.Controls.Add(lbPrice);
            // Nút lưu đầu sách
            pnlBook.Controls.Remove(btnSaveTit);
            pnlBook.Controls.Add(btnDeleTit);
            pnlBook.Controls.Add(btnAddBook);
            pnlBook.Controls.Add(btnDelBook);
            // Đẩy lại dữ liệu vào combobox
            cbbBookCate.DataSource = cbbBookCategorys.DataSource;
            cbbBookCate.DisplayMember = "ten";
            cbbBookCategorys.DataSource = null;
            pnlTitle.Enabled = true;
            dgvBooks.Enabled = true;
        }
        /* Phương thức kiểm tra xem các control trong chỉnh sửa thông tin đầu sách có trống hay không */
        private bool CheckInput_Title()
        {
            if (txbNameTit.Text == String.Empty) return false;
            if (nudQuantity.Value == 0) return false;
            if (nudDay.Value == 0) return false;
            if (nudMulct.Value == 0) return false;
            if (cbbBookCategorys.SelectedValue == null) return false;
            if (nudPrice.Value == 0) return false;
            return true;
        }
        /* Phương thức kiểm tra xem các giá trị thông tin đầu sách có thay đổi hay không */
        private bool CheckChange_Title()
        {
            if (txbNameTit.Text != lbNameTit.Text) return true;
            if (nudQuantity.Value.ToString() != lbQuantity.Text) return true;
            if (nudDay.Value.ToString() != lbDay.Text) return true;
            if (nudMulct.Value.ToString() != lbMulct.Text) return true;
            if ((cbbBookCategorys.SelectedValue as TheLoaiDTO).Ten != lbBookCate.Text) return true;
            if (nudPrice.Value.ToString() != lbPrice.Text) return true;
            return false;
        }
        /* Sự kiện gõ phím enter sẽ gọi sự kiện lưu thông tin đầu sách */
        private void Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSaveTit.PerformClick();
        }
        /* Sự kiện thêm sách cho đầu sách */
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            int index = dgvTitles.CurrentRow.Index;
            DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[index];
            if (SachBUS.AddBook(dauSach) < 1)
                MessageBox.Show("Đã xảy ra lỗi.", "Thông báo");
            dgvBooks.DataSource = SachBUS.GetBooks(dauSach);
            dgvBooks.Columns[0].Visible = false;
            dgvBooks.Columns[1].HeaderText = "Số thứ tự";
            dgvBooks.Columns[2].HeaderText = "Trạng thái";
        }
        /* Sự kiện xóa một cuốn sách trong đầu sách khi sách đã bị mất */
        private void btnDelBook_Click(object sender, EventArgs e)
        {
            int index = dgvTitles.CurrentRow.Index;
            DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[index];
            if (SachBUS.DelBook(dauSach) < 1)
                MessageBox.Show("Không thể xóa vì sách đang được sử dụng hoặc không có cuốn sách nào", "Thông báo");
            dgvBooks.DataSource = SachBUS.GetBooks(dauSach);
            dgvBooks.Columns[0].Visible = false;
            dgvBooks.Columns[1].HeaderText = "Số thứ tự";
            dgvBooks.Columns[2].HeaderText = "Trạng thái";
        }
        /* Sự kiện xóa đầu sách khi tất cả sách của đầu sách không còn cuốn nào */
        private void btnDeleTit_Click(object sender, EventArgs e)
        {
            int index = dgvTitles.CurrentRow.Index;
            DauSachDTO dauSach = (dgvTitles.DataSource as List<DauSachDTO>)[index];
            int check = DauSachBUS.DelTitBook(dauSach);
            if (check > -1)
                if (check == 0)
                    MessageBox.Show("Không xóa được vui lòng thử lại", "Thông báo");
                else
                    cbbBookCate_SelectedValueChanged(cbbBookCate, new EventArgs());
            else
                MessageBox.Show("Còn sách tồn tại không thể xóa được", "Thông báo");

        }
        /* Sự kiện double click vào các trạng thái sách để thay đổi từ mất sách sang còn và ngược lại */
        private void dgvBooks_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                List<SachDTO> saches = dgvBooks.DataSource as List<SachDTO>;
                SachDTO sach = saches[index];
                int check = SachBUS.ChangeStatusBook(ref sach);
                if (check == 0)
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
                else if (check == -1)
                    MessageBox.Show("Sách đang được mượn không thể thay đổi.", "Thông báo");
            }
        }
        /* Sự kiện thêm đầu sách là gọi form thêm đầu sách */
        private void btnAddTit_Click(object sender, EventArgs e)
        {
            FAddTitle title = new FAddTitle();
            title.ShowDialog();
            InitBookCate(ref cbbBookCate);
        }
        /* Sự kiện thêm thể loại là gọi form thêm thể loại */
        private void btnAddBookCate_Click(object sender, EventArgs e)
        {
            FAddBookCategory bookCategory = new FAddBookCategory();
            bookCategory.ShowDialog();
            InitBookCate(ref cbbBookCate);
        }
        /// <summary>
        /// Tabpage Độc giả
        /// </summary>
        /* Sự kiện chọn loại độc giả trong cbb để lấy dữ liệu độc giả cho vào dgv */
        private void cbbTypeOfReaders_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbTypeOfReaders.SelectedValue != null)
            {
                LoaiDGDTO loaiDG = cbbTypeOfReaders.SelectedValue as LoaiDGDTO;
                dgvReaders.DataSource = DocGiaBUS.GetReaders(loaiDG);
                dgvReaders.Columns[0].Visible = false;
                dgvReaders.Columns[1].HeaderText = "Tên";
                dgvReaders.Columns[2].HeaderText = "Số điện thoại";
                dgvReaders.Columns[3].Visible = false;
                dgvReaders.Columns[4].Visible = false;
                dgvReaders.Columns[5].HeaderText = "Trạng thái";
                dgvReaders.Columns[6].Visible = false;
                dgvReaders.Columns[7].Visible = false;
                btnChangeStatus.Enabled = true;
            }
            if (dgvReaders.Rows.Count == 0)
            {
                lbNameReader.Text = String.Empty;
                lbPhoneReader.Text = String.Empty;
                lbTypeOfReader.Text = String.Empty;
                lbSttReader.Text = String.Empty;
                dgvBookIsLend.DataSource = null;
                btnChangeStatus.Enabled = false;
            }
        }
        /* Sự kiện chọn một dòng trong dgv để hiện thị chi tiết độc giả và hiện thị những cuốn sách đang mượn */
        private void dgvReaders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReaders.CurrentRow != null)
            {
                int index = dgvReaders.CurrentRow.Index;
                DocGiaDTO docGia = (dgvReaders.DataSource as List<DocGiaDTO>)[index];
                lbNameReader.Text = docGia.Ten;
                lbPhoneReader.Text = docGia.Sdt;
                lbTypeOfReader.Text = docGia.Maloai.Socuonstr;
                lbSttReader.Text = docGia.TrangThaiChiTiet;
                dgvBookIsLend.DataSource = SachBUS.GetBookIsLend(docGia);
                dgvBookIsLend.Columns[0].Visible = false;
                dgvBookIsLend.Columns[1].HeaderText = "Tên đầu sách";
                dgvBookIsLend.Columns[2].HeaderText = "Stt";
                dgvBookIsLend.Columns[3].Visible = false;
                if (docGia.TrangThai == DocGiaDTO.UnLock)
                {
                    btnChangeStatus.Text = "Khóa";
                    pnlReader.Controls.Add(lblMonth);
                    pnlReader.Controls.Add(cbbTimeBlock);
                }
                else
                {
                    btnChangeStatus.Text = "Mở";
                    pnlReader.Controls.Remove(lblMonth);
                    pnlReader.Controls.Remove(cbbTimeBlock);
                }
            }
        }
        /* Sự kiện double click vào các thông tin chi tiết độc giả để add các control
         * để thay đổi thông tin chi tiêt */
        private void Reader_DoubleClick(object sender, EventArgs e)
        {
            // Tên độc giả
            txbNameReader.Text = lbNameReader.Text;
            pnlReader.Controls.Remove(lbNameReader);
            pnlReader.Controls.Add(txbNameReader);
            // Số điện thoại độc giả
            txbPhoneReader.Text = lbPhoneReader.Text;
            pnlReader.Controls.Remove(lbPhoneReader);
            pnlReader.Controls.Add(txbPhoneReader);
            // Loại độc giả
            cbbTOReaders.DataSource = cbbTypeOfReaders.DataSource;
            cbbTypeOfReaders.DataSource = null;
            cbbTOReaders.DisplayMember = "socuonstr";
            pnlReader.Controls.Remove(lbTypeOfReader);
            pnlReader.Controls.Add(cbbTOReaders);
            // Nút lưu độc giả
            pnlReader.Controls.Remove(btnChangeStatus);
            pnlReader.Controls.Add(btnSaveInfReader);
            pnlReaders.Enabled = false;
        }
        /* Sự kiện bấm nút lưu để lưu thông tin độc giả đã nhập */
        private void btnSaveInfReader_Click(object sender, EventArgs e)
        {
            if (!CheckInput_Reader())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
            if (CheckChange_Reader())
            {
                if (CheckPhoneNumber(txbPhoneReader.Text))
                {
                    MessageBox.Show("Số điện thoại di động không hợp.", "Thông báo");
                    return;
                }
                int check = DocGiaBUS.ChangeInfReader(dgvReaders[0, dgvReaders.CurrentRow.Index].Value.ToString(), txbNameReader.Text, txbPhoneReader.Text, cbbTOReaders.SelectedValue as LoaiDGDTO);
                if (check < 1)
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
            }
            // Tên độc giả
            pnlReader.Controls.Remove(txbNameReader);
            pnlReader.Controls.Add(lbNameReader);
            // Số điện thoại độc giả
            pnlReader.Controls.Remove(txbPhoneReader);
            pnlReader.Controls.Add(lbPhoneReader);
            // Loại độc giả
            pnlReader.Controls.Remove(cbbTOReaders);
            pnlReader.Controls.Add(lbTypeOfReader);
            // Nút lưu độc giả
            pnlReader.Controls.Remove(btnSaveInfReader);
            pnlReader.Controls.Add(btnChangeStatus);
            // Đẩy dữ liệu vào combobox
            cbbTypeOfReaders.DataSource = cbbTOReaders.DataSource;
            cbbTypeOfReaders.DisplayMember = "socuonstr";
            cbbTOReaders.DataSource = null;
            pnlReaders.Enabled = true;
        }
        /* Phương thức kiểm tra các thông tin có để trống không */
        private bool CheckInput_Reader()
        {
            if (txbNameReader.Text == String.Empty) return false;
            if (txbPhoneReader.Text == String.Empty) return false;
            if (cbbTOReaders.SelectedValue == null) return false;
            return true;
        }
        /* Phương thức kiểm tra có sự thay đổi giá trị thông tin không */
        private bool CheckChange_Reader()
        {
            if (txbNameReader.Text != lbNameReader.Text) return true;
            if (txbPhoneReader.Text != lbPhoneReader.Text) return true;
            if ((cbbTOReaders.SelectedValue as LoaiDGDTO).Socuonstr != lbPhoneReader.Text) return true;
            return false;
        }
        /* Phương thức kiểm tra số điện thoại có hợp lệ */
        private bool CheckPhoneNumber(string sdt)
        {
            Regex pattern = new Regex(pPhone, RegexOptions.IgnoreCase);
            return pattern.Match(sdt).Success;
        }
        /* Sự kiện gõ phím enter sẽ gọi sự kiện lưu thông tin độc giả */
        private void Reader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSaveInfReader.PerformClick();
        }
        /* Sự kiện mở/ khóa tài khoản nếu cbb có giá trị ngày thì khóa không thì Vĩnh viễn */
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            DocGiaDTO docGia = (dgvReaders.DataSource as List<DocGiaDTO>)[dgvReaders.CurrentRow.Index];
            int month = -1;
            if (btnChangeStatus.Text == "Khóa")
            {
                if (cbbTimeBlock.SelectedItem != null)
                    month = Int32.Parse(cbbTimeBlock.SelectedItem.ToString());
                else
                    month = 0;
            }
            if (DocGiaBUS.LockOrUnlock(ref docGia, month) < 1)
            {
                MessageBox.Show("Thay đổi không thành công", "Thông báo");
            }
            dgvReaders_SelectionChanged(dgvReaders, new EventArgs());
        }
        /* Sự kiện thêm độc giả là gọi form thêm độc giả */
        private void btnAddReader_Click(object sender, EventArgs e)
        {
            FAddReader reader = new FAddReader();
            reader.ShowDialog();
            cbbTypeOfReaders_SelectedValueChanged(cbbTypeOfReaders, new EventArgs());
        }
        /// <summary>
        /// Tabpage Nhà cung cấp
        /// </summary>
        /* Sự kiện chọn một dòng trong dgv để hiện thị chi tiết nhà cung cấp
         * và hiện thị những cuốn sách đang đặt */
        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow != null)
            {
                int index = dgvSuppliers.CurrentRow.Index;
                NXBDTO nhaCungCap = (dgvSuppliers.DataSource as List<NXBDTO>)[index];
                lbNameSupplier.Text = nhaCungCap.Ten;
                lbEmailSupplier.Text = nhaCungCap.Email;
                lbPhoneSupplier.Text = nhaCungCap.Sdt;
                lbFaxSupplier.Text = nhaCungCap.Fax;
                dgvNotDeliBook.DataSource = TTPhieuNhapBUS.GetReceiptNotesOfSupplier(nhaCungCap);
                dgvNotDeliBook.Columns[0].HeaderText = "Ngày nhập";
                dgvNotDeliBook.Columns[1].Visible = false;
                dgvNotDeliBook.Columns[2].HeaderText = "Đầu sách";
                dgvNotDeliBook.Columns[3].Visible = false;
                dgvNotDeliBook.Columns[4].Visible = false;
                dgvNotDeliBook.Columns[5].HeaderText = "Số lượng";
                dgvNotDeliBook.Columns[6].HeaderText = "Ngày hẹn";
                dgvNotDeliBook.Columns[7].Visible = false;
                dgvNotDeliBook.Columns[8].HeaderText = "Giá";
            }
        }
        /* Sự kiện double click vào các thông tin chi tiết nhà cung cấp để add các control
         * để thay đổi thông tin chi tiêt */
        private void Supplier_DoubleClick(object sender, EventArgs e)
        {
            // Tên nhà cung cấp
            txbNameSupplier.Text = lbNameSupplier.Text;
            pnlSupplier.Controls.Remove(lbNameSupplier);
            pnlSupplier.Controls.Add(txbNameSupplier);
            // Email
            txbEmailSupplier.Text = lbEmailSupplier.Text;
            pnlSupplier.Controls.Remove(lbEmailSupplier);
            pnlSupplier.Controls.Add(txbEmailSupplier);
            // Số điện thoại
            txbPhoneSupplier.Text = lbPhoneSupplier.Text;
            pnlSupplier.Controls.Remove(lbPhoneSupplier);
            pnlSupplier.Controls.Add(txbPhoneSupplier);
            // Fax
            txbFaxSupplier.Text = lbFaxSupplier.Text;
            pnlSupplier.Controls.Remove(lbFaxSupplier);
            pnlSupplier.Controls.Add(txbFaxSupplier);
            // Nút lưu nhà cung cấp
            pnlSupplier.Controls.Add(btnSaveInfSupplier);
            pnlSuppliers.Enabled = false;
        }
        /* Sự kiện bấm nút lưu để lưu thông tin nhà cung cấp đã nhập */
        private void btnSaveInfSupplier_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập rỗng
            if (!CheckInput_Supplier())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
            // Kiểm tra hợp lệ số điện thoại
            if (!CheckPhoneNumber(txbPhoneSupplier.Text))
            {
                MessageBox.Show("Số điện thoại di động không hợp.", "Thông báo");
                return;
            }
            // Kiểm trả hợp lệ số fax
            if (!CheckPhoneNumber(txbFaxSupplier.Text))
            {
                MessageBox.Show("Số fax không hợp lệ.", "Thông báo");
                return;
            }
            // Kiểm tra hợp lệ của email
            if (!CheckEmail(txbEmailSupplier.Text))
            {
                MessageBox.Show("Email không hợp lệ.", "Thông báo");
                return;
            }
            // Kiểm tra các giá trị có thay đổi không
            if (CheckChange_Supplier())
            {
                int check = NXBBUS.ChangeInfSupplier(dgvSuppliers[0, dgvSuppliers.CurrentRow.Index].Value.ToString(), txbNameSupplier.Text, txbEmailSupplier.Text, txbPhoneSupplier.Text, txbFaxSupplier.Text);
                if (check < 1)
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
                InitSupplier();
            }
            // Tên nhà cung cấp
            pnlSupplier.Controls.Remove(txbNameSupplier);
            pnlSupplier.Controls.Add(lbNameSupplier);
            // Email nhà cung cấp
            pnlSupplier.Controls.Remove(txbEmailSupplier);
            pnlSupplier.Controls.Add(lbEmailSupplier);
            // Phone nhà cung cấp
            pnlSupplier.Controls.Remove(txbPhoneSupplier);
            pnlSupplier.Controls.Add(lbPhoneSupplier);
            // Fax nhà cung cấp
            pnlSupplier.Controls.Remove(txbFaxSupplier);
            pnlSupplier.Controls.Add(lbFaxSupplier);
            pnlSupplier.Controls.Remove(btnSaveInfSupplier);
            pnlSuppliers.Enabled = true;


        }
        /* Sự kiện kiểm tra thông tin không được để trống */
        private bool CheckInput_Supplier()
        {
            if (txbNameSupplier.Text == String.Empty) return false;
            if (txbEmailSupplier.Text == String.Empty) return false;
            if (txbPhoneSupplier.Text == String.Empty) return false;
            return true;
        }
        /* Sự kiện kiểm tra giá trị có thay đổi */
        private bool CheckChange_Supplier()
        {
            if (txbNameSupplier.Text != lbNameSupplier.Text) return true;
            if (txbEmailSupplier.Text != lbEmailSupplier.Text) return true;
            if (txbPhoneSupplier.Text != lbPhoneSupplier.Text) return true;
            if (txbFaxSupplier.Text != lbFaxSupplier.Text) return true;
            return false;
        }
        /* Sự kiện kiểm tra sự hợp lệ của email */
        private bool CheckEmail(string email)
        {
            Regex pattern = new Regex(pEmail, RegexOptions.IgnoreCase);
            return pattern.Match(email).Success;
        }
        /* Sự kiện gõ phím enter sẽ gọi sự kiện lưu thông tin nhà cung cấp */
        private void Supplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSaveInfSupplier.PerformClick();
        }
        /* Sự kiện thêm nhà cung cấp là gọi form thêm nhà cung cấp */
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            FAddSupplier suppier = new FAddSupplier();
            suppier.ShowDialog();
            InitSupplier();
        }
        /// <summary>
        /// Tabpage phiếu nhập
        /// </summary>
        /* Sự kiện thay đổi rdb */
        private void rdbAllReceptNotes_CheckedChanged(object sender, EventArgs e)
        {
            InitReceNotes();
        }
        /* Sự kiện chọn một dòng để lấy thông tin chi tiết của phiếu nhập */
        private void dgvReceNotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReceNotes.CurrentRow != null)
            {
                int index = dgvReceNotes.CurrentRow.Index;
                PhieuDTO phieuNhap = (dgvReceNotes.DataSource as List<PhieuDTO>)[index];
                int gia = TTPhieuNhapBUS.GetReceiptNote(phieuNhap, out List<TTPhieuNhapDTO> chiTiet);
                lbDayReceNote.Text = phieuNhap.Ngaynhap.ToString();
                dgvReceNote.DataSource = chiTiet;
                dgvReceNote.Columns[0].Visible = false;
                dgvReceNote.Columns[1].Visible = false;
                dgvReceNote.Columns[2].HeaderText = "Đầu sách";
                dgvReceNote.Columns[3].Visible = false;
                dgvReceNote.Columns[4].HeaderText = "Nhà cung cấp";
                dgvReceNote.Columns[5].HeaderText = "Số lượng";
                dgvReceNote.Columns[6].HeaderText = "Ngày giao dự kiến";
                dgvReceNote.Columns[7].HeaderText = "Ngày giao";
                dgvReceNote.Columns[8].HeaderText = "Giá";
                lbSumPriceRN.Text = gia.ToString("#,0");
            }
        }
        /* Sự kiện thêm phiếu nhập là gọi form thêm phiếu nhập */
        private void btnAddReceNote_Click(object sender, EventArgs e)
        {
            FAddReceiptNote receiptNote = new FAddReceiptNote();
            receiptNote.ShowDialog();
            InitReceNotes();
        }
        /* Sự kiện chỉnh sửa phiếu nhập là gọi form chỉnh sửa phiếu nhập */
        private void btnEditReceNote_Click(object sender, EventArgs e)
        {
            PhieuDTO phieuNhap = (dgvReceNotes.DataSource as List<PhieuDTO>)[dgvReceNotes.CurrentRow.Index];
            FEditReceiptNote receiptNote = new FEditReceiptNote(phieuNhap);
            receiptNote.ShowDialog();
            InitReceNotes();
        }
        /// <summary>
        /// Tabpage phiếu giao
        /// </summary>
        /* Sự kiện chọn một dòng để lấy thông tin chi tiết của phiếu giao */
        private void dgvDeliNotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReceNotes.CurrentRow != null)
            {
                int index = dgvDeliNotes.CurrentRow.Index;
                PhieuDTO phieuGiao = (dgvDeliNotes.DataSource as List<PhieuDTO>)[index];
                int gia = TTPhieuNhapBUS.GetDeliveryNote(phieuGiao, out List<TTPhieuNhapDTO> chiTiet);
                lbDayDeliNote.Text = phieuGiao.Ngaynhap.ToString();
                lbNCC.Text = chiTiet[0].Manxb.Ten;
                dgvDeliNote.DataSource = chiTiet;
                dgvDeliNote.Columns[0].Visible = false;
                dgvDeliNote.Columns[1].Visible = false;
                dgvDeliNote.Columns[2].HeaderText = "Đầu sách";
                dgvDeliNote.Columns[3].Visible = false;
                dgvDeliNote.Columns[4].Visible = false;
                dgvDeliNote.Columns[5].HeaderText = "Số lượng";
                dgvDeliNote.Columns[6].Visible = false;
                dgvDeliNote.Columns[7].HeaderText = "Ngày giao";
                dgvDeliNote.Columns[8].HeaderText = "Giá";
                lbSumPriceDN.Text = gia.ToString("#,0");
            }
        }
        /* Sự kiện thêm phiếu giao là gọi form thêm phiếu giao */
        private void btnAddDeliNote_Click(object sender, EventArgs e)
        {
            FAddDeliveryNote deliveryNote = new FAddDeliveryNote();
            deliveryNote.ShowDialog();
            InitDeliNotes();
        }
        /// <summary>
        /// Tabpage phiếu mượn
        /// </summary>
        /* Sự kiện thay đổi rdb */
        private void rdbAllLendNotes_CheckedChanged(object sender, EventArgs e)
        {
            InitLendNotes();
        }
        /* Sự kiện chọn một dòng để lấy thông tin chi tiết của phiếu mượn */
        private void dgvLendNotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLendNotes.CurrentRow != null)
            {
                int index = dgvLendNotes.CurrentRow.Index;
                PhieuMuonDTO phieuMuon = (dgvLendNotes.DataSource as List<PhieuMuonDTO>)[index];
                int gia = TTPhieuMuonBUS.GetLendNote(phieuMuon, out List<TTPhieuMuonDTO> chiTiet);
                lbDayLendBook.Text = phieuMuon.Ngaymuon.ToString();
                lbDocGia.Text = phieuMuon.Madg.Ten;
                dgvLendNote.DataSource = chiTiet;
                dgvLendNote.Columns[0].Visible = false;
                dgvLendNote.Columns[1].Visible = false;
                dgvLendNote.Columns[2].HeaderText = "Đầu sách";
                dgvLendNote.Columns[3].HeaderText = "Stt";
                dgvLendNote.Columns[4].Visible = false;
                dgvLendNote.Columns[5].HeaderText = "Ngày hẹn trả";
                dgvLendNote.Columns[6].HeaderText = "Ngày trả";
                lbSumPriceDN.Text = gia.ToString("#,0");
            }
        }
        /* Sự kiện thêm phiếu mượn là gọi form thêm phiếu mượn */
        private void btnAddLendNote_Click(object sender, EventArgs e)
        {
            FAddLendNote lendNote = new FAddLendNote();
            lendNote.ShowDialog();
            InitLendNotes();
        }
        /// <summary>
        /// Tabpage phiếu trả
        /// </summary>
        /* Sự kiện chọn một dòng để lấy thông tinc hi tiết của phiếu trả */
        private void dgvPayBackNotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayBackNotes.CurrentRow != null)
            {
                int index = dgvPayBackNotes.CurrentRow.Index;
                PhieuDTO phieuTra = (dgvPayBackNotes.DataSource as List<PhieuDTO>)[index];
                int gia = TTPhieuMuonBUS.GetPayBackNote(phieuTra, out List<TTPhieuMuonDTO> chiTiet);
                lbDayPayBackBook.Text = phieuTra.Ngaynhap.ToString();
                dgvPayBackNote.DataSource = chiTiet;
                dgvPayBackNote.Columns[0].Visible = false;
                dgvPayBackNote.Columns[1].Visible = false;
                dgvPayBackNote.Columns[2].HeaderText = "Đầu sách";
                dgvPayBackNote.Columns[3].HeaderText = "Stt";
                dgvPayBackNote.Columns[4].HeaderText = "Phạt";
                dgvPayBackNote.Columns[5].Visible = false;
                dgvPayBackNote.Columns[6].HeaderText = "Ngày trả";
                lbSumPricePB.Text = gia.ToString("#,0");
            }
        }
        /* Sự kiện thêm phiếu trả là gọi form thêm phiếu trả */
        private void btnAddPayBackNote_Click(object sender, EventArgs e)
        {
            FAddPayBackNote payBackNote = new FAddPayBackNote();
            payBackNote.ShowDialog();
            InitPayBackNotes();
        }
    }
}
