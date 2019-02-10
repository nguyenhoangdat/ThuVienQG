using System;
using System.Windows.Forms;
using ThuVienQG.DTO;

namespace ThuVienQG.GUI
{
    public class PLendNote : Panel
    {
        private SachDTO book;
        private Label lblNameBook;
        private Label lblHead1;
        private Label lblHead2;
        private Label lblStt;
        private Label lblPayBackDay;
        private Button btnDelete;
        public PLendNote(SachDTO sach)
        {
            InitPanelLendNote();
            this.book = sach;
            this.lblNameBook.Text = book.Ten;
            this.lblStt.Text = book.Stt.ToString();
            this.lblPayBackDay.Text = DateTime.Now.AddDays(book.Mads.Songaytoida).ToShortDateString();
        }
        public void InitPanelLendNote()
        {
            this.lblNameBook = new Label();
            this.lblHead1 = new Label();
            this.lblHead2 = new Label();
            this.lblStt = new Label();
            this.lblPayBackDay = new Label();
            this.btnDelete = new Button();
            // 
            // panelReceiptNote
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblNameBook);
            this.Controls.Add(this.lblHead1);
            this.Controls.Add(this.lblHead2);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.lblPayBackDay);
            this.Controls.Add(this.btnDelete);
            this.Location = new System.Drawing.Point(3, 3);
            this.Size = new System.Drawing.Size(574, 72);
            // 
            // lblNameBook
            // 
            this.lblNameBook.AutoSize = true;
            this.lblNameBook.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBook.Location = new System.Drawing.Point(3, 5);
            this.lblNameBook.Name = "lblNameBook";
            this.lblNameBook.Size = new System.Drawing.Size(128, 23);
            this.lblNameBook.TabIndex = 0;
            this.lblNameBook.Text = "<Tên đầu sách>";
            //
            // lblHead1
            // 
            this.lblHead1.AutoSize = true;
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead1.Location = new System.Drawing.Point(3, 36);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Size = new System.Drawing.Size(86, 23);
            this.lblHead1.TabIndex = 0;
            this.lblHead1.Text = "Số thứ tự:";
            // 
            // lblHead2
            // 
            this.lblHead2.AutoSize = true;
            this.lblHead2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead2.Location = new System.Drawing.Point(268, 36);
            this.lblHead2.Name = "lblHead2";
            this.lblHead2.Size = new System.Drawing.Size(41, 23);
            this.lblHead2.TabIndex = 0;
            this.lblHead2.Text = "Ngày hẹn trả:";
            //
            // lblStt
            // 
            this.lblStt.AutoSize = true;
            this.lblStt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.Location = new System.Drawing.Point(105, 36);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(86, 23);
            this.lblStt.TabIndex = 0;
            this.lblStt.Text = "<Số thứ tự>";
            // 
            // lblPayBackDay
            // 
            this.lblPayBackDay.AutoSize = true;
            this.lblPayBackDay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayBackDay.Location = new System.Drawing.Point(391, 36);
            this.lblPayBackDay.Name = "lblPayBackDay";
            this.lblPayBackDay.Size = new System.Drawing.Size(41, 23);
            this.lblPayBackDay.TabIndex = 0;
            this.lblPayBackDay.Text = "<Ngày hẹn trả>";
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
        public SachDTO Sach { get => book; set => book = value; }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
