namespace ThuVienQG.GUI
{
    partial class FAddTitle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.btnAddBookCate = new System.Windows.Forms.Button();
            this.cbbBookCate = new System.Windows.Forms.ComboBox();
            this.nudMultc = new System.Windows.Forms.NumericUpDown();
            this.nudDay = new System.Windows.Forms.NumericUpDown();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.txbNameTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đầu Sách";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.nudPrice);
            this.panel1.Controls.Add(this.btnAddBookCate);
            this.panel1.Controls.Add(this.cbbBookCate);
            this.panel1.Controls.Add(this.nudMultc);
            this.panel1.Controls.Add(this.nudDay);
            this.panel1.Controls.Add(this.nudQuantity);
            this.panel1.Controls.Add(this.txbNameTitle);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 235);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(349, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "đồng/ngày";
            // 
            // nudPrice
            // 
            this.nudPrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrice.Location = new System.Drawing.Point(142, 193);
            this.nudPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(301, 31);
            this.nudPrice.TabIndex = 12;
            this.nudPrice.ThousandsSeparator = true;
            this.nudPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // btnAddBookCate
            // 
            this.btnAddBookCate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBookCate.Location = new System.Drawing.Point(412, 154);
            this.btnAddBookCate.Name = "btnAddBookCate";
            this.btnAddBookCate.Size = new System.Drawing.Size(31, 31);
            this.btnAddBookCate.TabIndex = 11;
            this.btnAddBookCate.Text = "+";
            this.btnAddBookCate.UseVisualStyleBackColor = true;
            this.btnAddBookCate.Click += new System.EventHandler(this.btnAddBookCate_Click);
            // 
            // cbbBookCate
            // 
            this.cbbBookCate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBookCate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBookCate.FormattingEnabled = true;
            this.cbbBookCate.Location = new System.Drawing.Point(142, 155);
            this.cbbBookCate.Name = "cbbBookCate";
            this.cbbBookCate.Size = new System.Drawing.Size(264, 31);
            this.cbbBookCate.TabIndex = 10;
            this.cbbBookCate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // nudMultc
            // 
            this.nudMultc.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMultc.Location = new System.Drawing.Point(142, 118);
            this.nudMultc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMultc.Name = "nudMultc";
            this.nudMultc.Size = new System.Drawing.Size(201, 31);
            this.nudMultc.TabIndex = 9;
            this.nudMultc.ThousandsSeparator = true;
            this.nudMultc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // nudDay
            // 
            this.nudDay.Location = new System.Drawing.Point(142, 81);
            this.nudDay.Name = "nudDay";
            this.nudDay.Size = new System.Drawing.Size(301, 31);
            this.nudDay.TabIndex = 8;
            this.nudDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(142, 44);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(301, 31);
            this.nudQuantity.TabIndex = 7;
            this.nudQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // txbNameTitle
            // 
            this.txbNameTitle.Location = new System.Drawing.Point(142, 7);
            this.txbNameTitle.Name = "txbNameTitle";
            this.txbNameTitle.Size = new System.Drawing.Size(301, 31);
            this.txbNameTitle.TabIndex = 6;
            this.txbNameTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Giá: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Thể loại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mức phạt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số ngày mượn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đầu sách:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FAddTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FAddTitle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddTitle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbBookCate;
        private System.Windows.Forms.NumericUpDown nudMultc;
        private System.Windows.Forms.NumericUpDown nudDay;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txbNameTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Button btnAddBookCate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
    }
}