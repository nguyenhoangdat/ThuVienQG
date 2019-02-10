using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThuVienQG.BUS;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public class PReceiptNote : Panel
    {
        private DauSachDTO dauSach;
        private NXBDTO nhaCungCap;
        private Label lblNameTitle;
        private Label lblHead1;
        private Label lblHead2;
        private Label lblHead3;
        private Label lblHead4;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudPrice;
        private DateTimePicker dtpDeliveryDay;
        private ComboBox cbbSupplier;
        private Label lblNameSupplier;
        private Button btnDelete;
        public PReceiptNote(DauSachDTO dauSach)
        {
            InitPanelReceiptNote(true);
            this.dauSach = dauSach;
            lblNameTitle.Text = dauSach.Ten;
            cbbSupplier.DataSource = NXBBUS.GetSuppliers();
            cbbSupplier.DisplayMember = "ten";
        }
        public PReceiptNote(TTPhieuNhapDTO chiTiet, bool Deli)
        {
            InitPanelReceiptNote(false);
            this.Enabled = Deli;
            dauSach = chiTiet.Mads;
            lblNameTitle.Text = dauSach.Ten;
            nudQuantity.Value = chiTiet.Soluong;
            nudPrice.Value = chiTiet.Dongia;
            dtpDeliveryDay.Value = chiTiet.Ngaygiao;
            lblNameSupplier.Text = chiTiet.NXB;
            nhaCungCap = chiTiet.Manxb;
        }
        public void InitPanelReceiptNote(bool add)
        {
            lblNameTitle = new Label();
            lblHead1 = new Label();
            lblHead2 = new Label();
            lblHead3 = new Label();
            lblHead4 = new Label();
            nudQuantity = new NumericUpDown();
            nudPrice = new NumericUpDown();
            dtpDeliveryDay = new DateTimePicker();
            cbbSupplier = new ComboBox();
            lblNameSupplier = new Label();
            btnDelete = new Button();
            // 
            // panelReceiptNote
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblNameTitle);
            this.Controls.Add(this.lblHead1);
            this.Controls.Add(this.lblHead2);
            this.Controls.Add(this.lblHead3);
            this.Controls.Add(this.lblHead4);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.dtpDeliveryDay);
            if (add)
                this.Controls.Add(this.cbbSupplier);
            else
                this.Controls.Add(this.lblNameSupplier);
            this.Controls.Add(this.btnDelete);
            this.Location = new System.Drawing.Point(3, 3);
            this.Size = new System.Drawing.Size(574, 115);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTitle.Location = new System.Drawing.Point(3, 5);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(128, 23);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "<Tên đầu sách>";
            //
            // lblHead1
            // 
            this.lblHead1.AutoSize = true;
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead1.Location = new System.Drawing.Point(3, 36);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Size = new System.Drawing.Size(86, 23);
            this.lblHead1.TabIndex = 0;
            this.lblHead1.Text = "Số lượng:";
            // 
            // lblHead2
            // 
            this.lblHead2.AutoSize = true;
            this.lblHead2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead2.Location = new System.Drawing.Point(268, 36);
            this.lblHead2.Name = "lblHead2";
            this.lblHead2.Size = new System.Drawing.Size(41, 23);
            this.lblHead2.TabIndex = 0;
            this.lblHead2.Text = "Giá:";
            // 
            // lblHead3
            // 
            this.lblHead3.AutoSize = true;
            this.lblHead3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead3.Location = new System.Drawing.Point(3, 77);
            this.lblHead3.Name = "lblHead3";
            this.lblHead3.Size = new System.Drawing.Size(89, 23);
            this.lblHead3.TabIndex = 0;
            this.lblHead3.Text = "Ngày hẹn:";
            // 
            // lblHead4
            // 
            this.lblHead4.AutoSize = true;
            this.lblHead4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead4.Location = new System.Drawing.Point(268, 74);
            this.lblHead4.Name = "lblHead4";
            this.lblHead4.Size = new System.Drawing.Size(119, 23);
            this.lblHead4.TabIndex = 0;
            this.lblHead4.Text = "Nhà cung cấp:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(105, 34);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(140, 31);
            this.nudQuantity.TabIndex = 1;
            // 
            // nudPrice
            // 
            this.nudPrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrice.Location = new System.Drawing.Point(391, 31);
            this.nudPrice.Maximum = new decimal(new int[] {
            999999000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(178, 31);
            this.nudPrice.TabIndex = 2;
            this.nudPrice.ThousandsSeparator = true;
            if (add)
                this.nudPrice.ValueChanged += new EventHandler(FAddReceiptNote.SumChange_ValueChanged);
            else
                this.nudPrice.ValueChanged += new EventHandler(FEditReceiptNote.SumChange_ValueChanged);
            // 
            // dtpDeliveryDay
            // 
            this.dtpDeliveryDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDay.Location = new System.Drawing.Point(105, 71);
            this.dtpDeliveryDay.Name = "dtpDeliveryDay";
            this.dtpDeliveryDay.Size = new System.Drawing.Size(140, 31);
            this.dtpDeliveryDay.TabIndex = 3;
            // 
            // cbbSupplier
            // 
            this.cbbSupplier.FormattingEnabled = true;
            this.cbbSupplier.Location = new System.Drawing.Point(391, 71);
            this.cbbSupplier.Name = "cbbSupplier";
            this.cbbSupplier.Size = new System.Drawing.Size(178, 31);
            this.cbbSupplier.TabIndex = 4;
            this.cbbSupplier.SelectedValueChanged += new EventHandler(cbbSupplier_SelectedValueChanged);
            // 
            // lblNameSupplier
            // 
            this.lblNameSupplier.AutoSize = true;
            this.lblNameSupplier.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSupplier.Location = new System.Drawing.Point(391, 75);
            this.lblNameSupplier.Name = "lblNameSupplier";
            this.lblNameSupplier.Size = new System.Drawing.Size(128, 23);
            this.lblNameSupplier.TabIndex = 0;
            this.lblNameSupplier.Text = "<Tên nhà cung cấp>";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(544, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "x";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }
        public DauSachDTO DauSach { get => dauSach; }
        public int Price { get => (int)nudPrice.Value; }
        public int Quantity { get => (int)nudQuantity.Value; }
        public DateTime DeliveryDay { get => dtpDeliveryDay.Value; }
        public NXBDTO Supplier { get => nhaCungCap; }
        public bool CheckReceiptNote()
        {
            if (Price == 0 || Quantity == 0 || DeliveryDay < DateTime.Now)
                return false;
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void cbbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            nhaCungCap = cbbSupplier.SelectedValue as NXBDTO;
        }
    }
}
