using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FAddBookCategory : Form
    {
        public FAddBookCategory()
        {
            InitializeComponent();
        }
        /* Sự kiện load form để lấy thể loại cho vào dgv */
        private void FAddBookCategory_Load(object sender, EventArgs e)
        {
            List<TheLoaiDTO> theLoais = TheLoaiBUS.GetBookCategorys();
            dgvBookCate.DataSource = theLoais;
            dgvBookCate.Columns[0].Visible = false;
            dgvBookCate.Columns[1].HeaderText = "Thể loại";
        }
        /* Sự kiện lưu thông tin thể loại */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbBookCategory.Text == String.Empty)
            {
                MessageBox.Show("Tên thể loại không được bỏ trống.", "Thông báo");
                return;
            }
            int check = TheLoaiBUS.AddBookCategory(txbBookCategory.Text);
            if (check > 0)
                this.Close();
            else
                MessageBox.Show("Lưu không thành công.", "Thông báo");
        }
        /* Sự kiện gõ phím không cho phép gõ kí tự là ngoại trừ backspace và space 
         và nhấn phím enter để lưu */
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)32 || e.KeyChar == (char)8))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện sửa tên thể loại */
        private void dgvBookCate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TheLoaiDTO theLoai = (dgvBookCate.DataSource as List<TheLoaiDTO>)[e.RowIndex];
            int check = TheLoaiBUS.ChangeBookCategory(theLoai);
            if (check < 1)
            {
                MessageBox.Show("Lưu không thành công.", "Thông báo");
                this.OnLoad(new EventArgs());
            }
        }
    }
}
