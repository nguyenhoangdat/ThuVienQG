using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public partial class FAddReader : Form
    {
        private const string pPhone = @"^0[35789]\d{8}$";
        public FAddReader()
        {
            InitializeComponent();
        }
        /* Sự kiện load loại độc giả đổ vào cbb */
        private void FAddReader_Load(object sender, EventArgs e)
        {
            List<LoaiDGDTO> theLoais = LoaiDGBUS.GetTypeOfReaders();
            cbbTOReader.DataSource = theLoais;
            cbbTOReader.DisplayMember = "socuonstr";
        }
        /* Sự kiện chỉ cho phép gõ chữ, số, khoảng trắng và xóa và enter */
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)32 || e.KeyChar == (char)8))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện chỉ cho phép gõ số và enter */
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện lưu thông tin nhà độc giả */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.", "Thông báo");
                return;
            }
            if (!CheckPhone(txbPhoneReader.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo");
                return;
            }
            string name = txbNameReader.Text;
            string phone = txbPhoneReader.Text;
            LoaiDGDTO loai = cbbTOReader.SelectedValue as LoaiDGDTO;
            if (DocGiaBUS.AddReader(name, phone, loai) > 0)
                this.Close();
            else
                MessageBox.Show("Lưu không thành công.", "Thông báo");
        }
        /* Phương thức kiểm tra nhập liệu độc giả */
        private bool CheckInput()
        {
            if (txbNameReader.Text == String.Empty) return false;
            if (txbPhoneReader.Text == String.Empty) return false;
            if (cbbTOReader.SelectedValue == null) return false;
            return true;
        }
        /* Phương thức kiểm tra hợp lệ của số điện thoại */
        private bool CheckPhone(string sdt)
        {
            Regex pattern = new Regex(pPhone, RegexOptions.IgnoreCase);
            return pattern.Match(sdt).Success;
        }
    }
}
