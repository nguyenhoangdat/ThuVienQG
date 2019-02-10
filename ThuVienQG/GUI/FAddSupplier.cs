using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ThuVienQG.BUS;

namespace ThuVienQG.GUI
{
    public partial class FAddSupplier : Form
    {
        private const string pPhone = @"^0[35789]\d{8}$";
        private const string pEmail = @"[a-z0-9._%+-]{1,40}[@]{1}[a-z]{1,10}[.]{1}[a-z]{3}";
        public FAddSupplier()
        {
            InitializeComponent();
        }
        /* Sự kiện chỉ cho phép gõ chữ, số, khoảng trắng và xóa và enter */
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)32 || e.KeyChar == (char)8))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện chỉ cho phép gõ số và enter và xóa */
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện gõ enter để lưu */
        private void txbEmailSuppier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();
        }
        /* Sự kiện bấm nút lưu */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.", "Thông báo");
                return;
            }
            if (!CheckEmail(txbEmailSupplier.Text))
            {
                MessageBox.Show("Email không hợp lệ.", "Thông báo");
                return;
            }
            if (!CheckPhone(txbPhoneSupplier.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo");
                return;
            }
            if (txbFaxSupplier.Text != String.Empty && !CheckPhone(txbFaxSupplier.Text))
            {
                MessageBox.Show("Số fax không hợp lệ.", "Thông báo");
                return;
            }
            string name = txbNameSupplier.Text;
            string email = txbEmailSupplier.Text;
            string phone = txbPhoneSupplier.Text;
            string fax = txbFaxSupplier.Text;
            if (NXBBUS.AddSupplier(name, email, phone, fax) > 0)
                this.Close();
            else
                MessageBox.Show("Lưu không thành công.", "Thông báo");


        }
        /* Phương thức kiểm tra không được rỗng thông tin nhập ngoại trừ fax */
        private bool CheckInput()
        {
            if (txbNameSupplier.Text == String.Empty) return false;
            if (txbEmailSupplier.Text == String.Empty) return false;
            if (txbPhoneSupplier.Text == String.Empty) return false;
            // Cho phép không nhập fax
            return true;
        }
        /* Phương thức kiểm tra hợp lệ của số điện thoại */
        private bool CheckPhone(string sdt)
        {
            Regex pattern = new Regex(pPhone, RegexOptions.IgnoreCase);
            return pattern.Match(sdt).Success;
        }
        /* Phương thức kiểm tra hợp lệ của email */
        private bool CheckEmail(string email)
        {
            Regex pattern = new Regex(pEmail, RegexOptions.IgnoreCase);
            return pattern.Match(email).Success;
        }
    }
}
