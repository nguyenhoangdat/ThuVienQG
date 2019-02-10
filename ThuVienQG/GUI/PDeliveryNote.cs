using System;
using System.Windows.Forms;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public class PDeliveryNote : Panel
    {
        TTPhieuNhapDTO chitiet;
        private Label lblNameTitle;
        private Label lblHead1;
        private Label lblHead2;
        private Label lblHead3;
        private Label lblHead4;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblDeliveryDay;
        private Label lblNameSupplier;
        private Button btnDelete;
        public PDeliveryNote(TTPhieuNhapDTO chitiet)
        {
            InitPanelDeliveryNote();
            this.Chitiet = chitiet;
            lblNameTitle.Text = chitiet.DauSach;
            lblQuantity.Text = chitiet.Soluong.ToString();
            lblPrice.Text = chitiet.Dongia.ToString("#,0");
            lblDeliveryDay.Text = chitiet.Ngaygiao.ToShortDateString();
            lblNameSupplier.Text = chitiet.NXB;
        }

        public void InitPanelDeliveryNote()
        {
            lblNameTitle = new Label();
            lblHead1 = new Label();
            lblHead2 = new Label();
            lblHead3 = new Label();
            lblHead4 = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblDeliveryDay = new Label();
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
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDeliveryDay);
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
            this.lblHead4.Location = new System.Drawing.Point(268, 77);
            this.lblHead4.Name = "lblHead4";
            this.lblHead4.Size = new System.Drawing.Size(119, 23);
            this.lblHead4.TabIndex = 0;
            this.lblHead4.Text = "Nhà cung cấp:";
            // 
            // lblStt
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(105, 36);
            this.lblQuantity.Name = "lblStt";
            this.lblQuantity.Size = new System.Drawing.Size(140, 31);
            this.lblQuantity.TabIndex = 0;
            // 
            // lblPriceBook
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(391, 36);
            this.lblPrice.Name = "lblPriceBook";
            this.lblPrice.Size = new System.Drawing.Size(140, 31);
            this.lblPrice.TabIndex = 0;
            // 
            // lblDeliveryDay
            // 
            this.lblDeliveryDay.AutoSize = true;
            this.lblDeliveryDay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDay.Location = new System.Drawing.Point(105, 77);
            this.lblDeliveryDay.Name = "lblDeliveryDay";
            this.lblDeliveryDay.Size = new System.Drawing.Size(140, 31);
            this.lblDeliveryDay.TabIndex = 0;
            // 
            // lblNameSupplier
            // 
            this.lblNameSupplier.AutoSize = true;
            this.lblNameSupplier.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameSupplier.Location = new System.Drawing.Point(391, 77);
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
        public TTPhieuNhapDTO Chitiet { get => chitiet; set => chitiet = value; }
        public Button Delete { get => btnDelete; }
        // Sự kiện Delete phần chi tiết 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
