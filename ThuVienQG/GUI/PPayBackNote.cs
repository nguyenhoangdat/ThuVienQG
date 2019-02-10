using System;
using System.Windows.Forms;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public class PPayBackNote : Panel
    {
        private TTPhieuMuonDTO sach;
        private Label lblNameBook;
        private Label lblHead1;
        private Label lblHead2;
        private Label lblHead3;
        private Label lblHead4;
        private Label lblHead5;
        private Label lblStt;
        private Label lblPayBackDay;
        private Label lblLater;
        private Label lblPriceBook;
        private Label lblLaterMulct;
        private Label lblDamagesMulct;
        private Label lblSumMuclt;
        private RadioButton rdbPercent0;
        private RadioButton rdbPercent5;
        private RadioButton rdbPercent100;
        private RadioButton rdbPercent200;
        private Button btnDelete;
        public PPayBackNote(TTPhieuMuonDTO sach)
        {
            InitPanelDeliveryNote();
            this.sach = sach;
            lblNameBook.Text = sach.DauSach;
            lblStt.Text = sach.Stt.ToString();
            lblPayBackDay.Text = sach.Mapm.Ngaymuon.AddDays(sach.Mads.Mads.Songaytoida).ToShortDateString();
            int songaytre = Songaytratre();
            string text;
            if (songaytre <= 60)
            {
                text = $"{sach.Mads.Mads.Sotienphat.ToString("#,0")} x {songaytre}";
                lblLaterMulct.Text = (songaytre * sach.Mads.Mads.Sotienphat).ToString();
            }
            else if (songaytre <= 120)
                text = "Độc giả này sẽ bị khóa 2 tháng.";
            else text = "Độc giả này sẽ bị khóa vĩnh viễn.";
            lblLater.Text = text;
            lblPriceBook.Text = sach.Mads.Mads.Giabia.ToString("#,0");
        }
        public void InitPanelDeliveryNote()
        {
            lblNameBook = new Label();
            lblHead1 = new Label();
            lblHead2 = new Label();
            lblHead3 = new Label();
            lblHead4 = new Label();
            lblHead5 = new Label();
            lblStt = new Label();
            lblPayBackDay = new Label();
            lblLater = new Label();
            lblPriceBook = new Label();
            lblLaterMulct = new Label();
            lblDamagesMulct = new Label();
            lblSumMuclt = new Label();
            rdbPercent0 = new RadioButton();
            rdbPercent5 = new RadioButton();
            rdbPercent100 = new RadioButton();
            rdbPercent200 = new RadioButton();
            btnDelete = new Button();
            // 
            // panelReceiptNote
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblNameBook);
            this.Controls.Add(this.lblHead1);
            this.Controls.Add(this.lblHead2);
            this.Controls.Add(this.lblHead3);
            this.Controls.Add(this.lblHead4);
            this.Controls.Add(this.lblHead5);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.lblPayBackDay);
            this.Controls.Add(this.lblLater);
            this.Controls.Add(this.lblPriceBook);
            this.Controls.Add(this.lblLaterMulct);
            this.Controls.Add(this.lblDamagesMulct);
            this.Controls.Add(this.lblSumMuclt);
            this.Controls.Add(this.rdbPercent0);
            this.Controls.Add(this.rdbPercent5);
            this.Controls.Add(this.rdbPercent100);
            this.Controls.Add(this.rdbPercent200);
            this.Controls.Add(this.btnDelete);
            this.Location = new System.Drawing.Point(3, 3);
            this.Size = new System.Drawing.Size(574, 198);
            // 
            // lblNameTitle
            // 
            this.lblNameBook.AutoSize = true;
            this.lblNameBook.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBook.Location = new System.Drawing.Point(3, 5);
            this.lblNameBook.Name = "lblNameTitle";
            this.lblNameBook.Size = new System.Drawing.Size(126, 23);
            this.lblNameBook.TabIndex = 0;
            this.lblNameBook.Text = "<Tên đầu sách>";
            //
            // lblHead1
            // 
            this.lblHead1.AutoSize = true;
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead1.Location = new System.Drawing.Point(3, 36);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Size = new System.Drawing.Size(81, 23);
            this.lblHead1.TabIndex = 0;
            this.lblHead1.Text = "Số thứ tự:";
            // 
            // lblHead2
            // 
            this.lblHead2.AutoSize = true;
            this.lblHead2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead2.Location = new System.Drawing.Point(268, 36);
            this.lblHead2.Name = "lblHead2";
            this.lblHead2.Size = new System.Drawing.Size(108, 23);
            this.lblHead2.TabIndex = 0;
            this.lblHead2.Text = "Ngày hẹn trả:";
            // 
            // lblHead3
            // 
            this.lblHead3.AutoSize = true;
            this.lblHead3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead3.Location = new System.Drawing.Point(3, 70);
            this.lblHead3.Name = "lblHead3";
            this.lblHead3.Size = new System.Drawing.Size(145, 23);
            this.lblHead3.TabIndex = 0;
            this.lblHead3.Text = "Tiền phạt trễ hẹn:";
            // 
            // lblHead4
            // 
            this.lblHead4.AutoSize = true;
            this.lblHead4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead4.Location = new System.Drawing.Point(3, 102);
            this.lblHead4.Name = "lblHead4";
            this.lblHead4.Size = new System.Drawing.Size(136, 23);
            this.lblHead4.TabIndex = 0;
            this.lblHead4.Text = "Tình trạng sách:";
            // 
            // lblHead5
            // 
            this.lblHead5.AutoSize = true;
            this.lblHead5.Location = new System.Drawing.Point(173, 102);
            this.lblHead5.Name = "lblHead5";
            this.lblHead5.Size = new System.Drawing.Size(67, 23);
            this.lblHead5.TabIndex = 0;
            this.lblHead5.Text = "Giá bìa:";
            // 
            // lblStt
            // 
            this.lblStt.AutoSize = true;
            this.lblStt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.Location = new System.Drawing.Point(105, 36);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(30, 23);
            this.lblStt.TabIndex = 0;
            // 
            // lblPayBackDay
            // 
            this.lblPayBackDay.AutoSize = true;
            this.lblPayBackDay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayBackDay.Location = new System.Drawing.Point(391, 36);
            this.lblPayBackDay.Name = "lblPayBackDay";
            this.lblPayBackDay.Size = new System.Drawing.Size(80, 23);
            this.lblPayBackDay.TabIndex = 0;
            // 
            // lblLater
            // 
            this.lblLater.AutoSize = true;
            this.lblLater.Location = new System.Drawing.Point(167, 70);
            this.lblLater.Name = "lblLater";
            this.lblLater.Size = new System.Drawing.Size(81, 23);
            this.lblLater.TabIndex = 0;
            // 
            // lblPriceBook
            // 
            this.lblPriceBook.AutoSize = true;
            this.lblPriceBook.Location = new System.Drawing.Point(246, 102);
            this.lblPriceBook.Name = "lblPriceBook";
            this.lblPriceBook.Size = new System.Drawing.Size(75, 31);
            this.lblPriceBook.TabIndex = 0;
            // 
            // lblLaterMulct
            // 
            this.lblLaterMulct.AutoSize = true;
            this.lblLaterMulct.ForeColor = System.Drawing.Color.Red;
            this.lblLaterMulct.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaterMulct.Location = new System.Drawing.Point(504, 70);
            this.lblLaterMulct.Name = "lblLaterMulct";
            this.lblLaterMulct.Size = new System.Drawing.Size(65, 23);
            this.lblLaterMulct.TabIndex = 0;
            this.lblLaterMulct.Text = "0";
            this.lblLaterMulct.TextChanged += new EventHandler(PriceChange_TextChanged);
            // 
            // lblDamagesMulct
            // 
            this.lblDamagesMulct.AutoSize = true;
            this.lblDamagesMulct.ForeColor = System.Drawing.Color.Red;
            this.lblDamagesMulct.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamagesMulct.Location = new System.Drawing.Point(504, 102);
            this.lblDamagesMulct.Name = "lblDamagesMulct";
            this.lblDamagesMulct.Size = new System.Drawing.Size(65, 23);
            this.lblDamagesMulct.TabIndex = 0;
            this.lblDamagesMulct.Text = "0";
            this.lblDamagesMulct.TextChanged += new EventHandler(PriceChange_TextChanged);
            // 
            // lblSumMuclt
            // 
            this.lblSumMuclt.AutoSize = true;
            this.lblSumMuclt.ForeColor = System.Drawing.Color.Red;
            this.lblSumMuclt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumMuclt.Location = new System.Drawing.Point(504, 165);
            this.lblSumMuclt.Name = "lblSumMulct";
            this.lblSumMuclt.Size = new System.Drawing.Size(65, 23);
            this.lblSumMuclt.TabIndex = 0;
            this.lblSumMuclt.Text = "0";
            this.lblSumMuclt.TextChanged += new EventHandler(FAddPayBackNote.SumChange_TextChanged);
            // 
            // rdbPercent0
            // 
            this.rdbPercent0.AutoSize = true;
            this.rdbPercent0.Checked = true;
            this.rdbPercent0.Location = new System.Drawing.Point(18, 128);
            this.rdbPercent0.Name = "rdbPercent0";
            this.rdbPercent0.Size = new System.Drawing.Size(123, 27);
            this.rdbPercent0.TabIndex = 10;
            this.rdbPercent0.TabStop = true;
            this.rdbPercent0.Text = "Bình thường";
            this.rdbPercent0.UseVisualStyleBackColor = true;
            this.rdbPercent0.CheckedChanged += new EventHandler(Percent_CheckedChanged);
            // 
            // rdbPercent5
            // 
            this.rdbPercent5.AutoSize = true;
            this.rdbPercent5.Location = new System.Drawing.Point(236, 128);
            this.rdbPercent5.Name = "rdbPercent5";
            this.rdbPercent5.Size = new System.Drawing.Size(194, 27);
            this.rdbPercent5.TabIndex = 11;
            this.rdbPercent5.TabStop = true;
            this.rdbPercent5.Text = "Hỏng dưới 10 tờ (5%)";
            this.rdbPercent5.UseVisualStyleBackColor = true;
            this.rdbPercent5.CheckedChanged += new EventHandler(Percent_CheckedChanged);
            // 
            // rdbPercent100
            // 
            this.rdbPercent100.AutoSize = true;
            this.rdbPercent100.Location = new System.Drawing.Point(18, 161);
            this.rdbPercent100.Name = "rdbPercent100";
            this.rdbPercent100.Size = new System.Drawing.Size(210, 27);
            this.rdbPercent100.TabIndex = 12;
            this.rdbPercent100.TabStop = true;
            this.rdbPercent100.Text = "Hỏng trên 10 tờ (100%)";
            this.rdbPercent100.UseVisualStyleBackColor = true;
            this.rdbPercent100.CheckedChanged += new EventHandler(Percent_CheckedChanged);
            // 
            // rdbPercent200
            // 
            this.rdbPercent200.AutoSize = true;
            this.rdbPercent200.Location = new System.Drawing.Point(236, 161);
            this.rdbPercent200.Name = "rdbPercent200";
            this.rdbPercent200.Size = new System.Drawing.Size(119, 27);
            this.rdbPercent200.TabIndex = 13;
            this.rdbPercent200.TabStop = true;
            this.rdbPercent200.Text = "Mất (200%)";
            this.rdbPercent200.UseVisualStyleBackColor = true;
            this.rdbPercent200.CheckedChanged += new EventHandler(Percent_CheckedChanged);
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
        public TTPhieuMuonDTO Sach { get => sach; }
        // Sự kiện Delete phần chi tiết 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        // Hàm tính số ngày trễ
        private int Songaytratre()
        {
            DateTime ngayhen = DateTime.Parse(sach.Ngayhen);
            DateTime homnay = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (homnay <= ngayhen)
                return 0;
            return (Int32)((homnay.Ticks - ngayhen.Ticks) / 864000000000);
        }
        // Hàm tính số tháng khóa
        public int MonthBlock()
        {
            int songaytre = Songaytratre();
            if (songaytre <= 60) return -1;
            if (songaytre <= 120)
                return 2;
            return 0;
        }
        // Sự kiện chọn rdb
        private void Percent_CheckedChanged(object sender, EventArgs e)
        {
            int percent = 0;
            if (rdbPercent5.Checked)
                percent = 5;
            else if (rdbPercent100.Checked)
                percent = 100;
            else if (rdbPercent200.Checked)
                percent = 200;
            lblDamagesMulct.Text = (sach.Mads.Mads.Giabia * percent / 100).ToString();
        }
        // Sự kiện thay đổi tiền phạt
        private void PriceChange_TextChanged(object sender, EventArgs e)
        {
            int laterMulct = Int32.Parse(lblLaterMulct.Text);
            int damagesMulct = Int32.Parse(lblDamagesMulct.Text);
            sach.Phat = laterMulct + damagesMulct;
            lblSumMuclt.Text = (laterMulct + damagesMulct).ToString("#,0");
        }
    }
}
