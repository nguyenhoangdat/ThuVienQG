using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FAddTitle : Form
    {
        public FAddTitle()
        {
            InitializeComponent();
        }
        /* Sự kiện load form để lấy thể loại cho vào cbb */
        private void FAddTitle_Load(object sender, EventArgs e)
        {
            List<TheLoaiDTO> theLoais = TheLoaiBUS.GetBookCategorys();
            if (theLoais.Count > 0)
            {
                cbbBookCate.DataSource = theLoais;
                cbbBookCate.DisplayMember = "Ten";
            }
            else
            {
                cbbBookCate.Items.Add("Không tìm thấy thể loại");
                cbbBookCate.SelectedIndex = 0;
            }
        }
        /* Sự kiện gõ phím enter để lưu */
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện lưu thông tin đầu sách được tạo */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                string ten = txbNameTitle.Text;
                int soluong = (Int32)nudQuantity.Value;
                int songay = (Int32)nudDay.Value;
                int phat = (Int32)nudMultc.Value;
                TheLoaiDTO theLoai = cbbBookCate.SelectedValue as TheLoaiDTO;
                int giabia = (Int32)nudPrice.Value;
                if (DauSachBUS.AddTitle(ten, soluong, songay, phat, theLoai, giabia) > 0)
                    this.Close();
                else
                    MessageBox.Show("Lưu không thành công.", "Thông báo");
            }
            else
                MessageBox.Show("Vui lòng nhập dữ liệu.", "Thông báo");
        }
        /* Phương thức kiểm tra đầu nhập liệu đầu sách*/
        private bool CheckInput()
        {
            if (txbNameTitle.Text == String.Empty) return false;
            // Cho phép nhập số lượng bằng 0
            if (nudDay.Value == 0) return false;
            if (nudMultc.Value == 0) return false;
            if (cbbBookCate.SelectedValue == null) return false;
            if (nudPrice.Value == 0) return false;
            return true;
        }
        /* Sự kiện thêm thể loại là mở form thêm thể loại */
        private void btnAddBookCate_Click(object sender, EventArgs e)
        {
            FAddBookCategory bookCategory = new FAddBookCategory();
            bookCategory.ShowDialog();
            this.OnLoad(new EventArgs());
        }
    }
}
