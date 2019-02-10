using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FAddDeliveryNote : Form
    {
        List<PDeliveryNote> pnldeliveryNotes = new List<PDeliveryNote>();
        public FAddDeliveryNote()
        {
            InitializeComponent();
        }
        /* Sự kiện load form là lấy danh sách nhà cung cấp để đổ vào cbb */
        private void FAddDeliveryNote_Load(object sender, EventArgs e)
        {
            cbbSupplier.DataSource = NXBBUS.GetSuppliers();
            cbbSupplier.DisplayMember = "ten";
        }
        /* Sự kiện chọn giá trị trong cbb để load danh sách đơn nhập chưa giao */
        private void cbbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvReceNote.DataSource = TTPhieuNhapBUS.GetReceiptNotesOfSupplier(cbbSupplier.SelectedValue as NXBDTO);
            dgvReceNote.Columns[0].Visible = false;
            dgvReceNote.Columns[1].Visible = false;
            dgvReceNote.Columns[2].HeaderText = "Đầu sách";
            dgvReceNote.Columns[3].Visible = false;
            dgvReceNote.Columns[4].Visible = false;
            dgvReceNote.Columns[5].HeaderText = "Số lượng";
            dgvReceNote.Columns[6].HeaderText = "Ngày hẹn";
            dgvReceNote.Columns[7].Visible = false;
            dgvReceNote.Columns[8].HeaderText = "Đơn giá";
            while (pnldeliveryNotes.Count > 0)
            {
                pnldeliveryNotes[0].Delete.PerformClick();
            }
        }
        /* Sự kiện thêm một đơn chưa giao bằng việc tạo một panel sách giao */
        private void dgvReceNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            TTPhieuNhapDTO chitiet = (dgvReceNote.DataSource as List<TTPhieuNhapDTO>)[e.RowIndex];
            if (CheckReceNote(chitiet))
            {
                pnldeliveryNotes.Add(new PDeliveryNote(chitiet));
                flpDetail.Controls.Add(pnldeliveryNotes[pnldeliveryNotes.Count - 1]);
                lblSumPrice.Text = SumPrice().ToString("#,0");
            }
        }
        /* Phương thức kiểm tra đơn nhập đã được chọn chưa */
        private bool CheckReceNote(TTPhieuNhapDTO chitiet)
        {
            foreach (PDeliveryNote item in pnldeliveryNotes)
                if (item.Chitiet == chitiet) return false;
            return true;
        }
        /* Sự kiện xóa đi panel sách giao khi được xóa bỏ */
        private void flpDetail_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnldeliveryNotes.Remove(e.Control as PDeliveryNote);
            lblSumPrice.Text = SumPrice().ToString("#,0");
        }
        /* Phương thức tính tổng số tiền */
        private int SumPrice()
        {
            int sum = 0;
            foreach (PDeliveryNote item in pnldeliveryNotes)
                sum += item.Chitiet.Dongia;
            return sum;
        }
        /* Sự kiện lưu thông tin phiếu giao */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pnldeliveryNotes.Count < 1)
            {
                MessageBox.Show("Chưa có đầu sách nào được giao.", "Thông báo");
                return;
            }
            List<TTPhieuNhapDTO> phieuGiaos = new List<TTPhieuNhapDTO>();
            DateTime ngaygiao = DateTime.Now;
            foreach (PDeliveryNote item in pnldeliveryNotes)
            {
                item.Chitiet.Mapg = ngaygiao;
                phieuGiaos.Add(item.Chitiet);
            }
            if (TTPhieuNhapBUS.AddDeliveryNote(phieuGiaos) < 1)
                MessageBox.Show("Lưu không thành công.", "Thông báo");
            else
                this.Close();
        }
    }
}
