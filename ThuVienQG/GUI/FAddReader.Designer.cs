namespace ThuVienQG.GUI
{
    partial class FAddReader
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
            this.txbPhoneReader = new System.Windows.Forms.TextBox();
            this.cbbTOReader = new System.Windows.Forms.ComboBox();
            this.txbNameReader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Độc giả";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbPhoneReader);
            this.panel1.Controls.Add(this.cbbTOReader);
            this.panel1.Controls.Add(this.txbNameReader);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 119);
            this.panel1.TabIndex = 1;
            // 
            // txbPhoneReader
            // 
            this.txbPhoneReader.Location = new System.Drawing.Point(142, 43);
            this.txbPhoneReader.Name = "txbPhoneReader";
            this.txbPhoneReader.Size = new System.Drawing.Size(301, 31);
            this.txbPhoneReader.TabIndex = 2;
            this.txbPhoneReader.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // cbbTOReader
            // 
            this.cbbTOReader.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbTOReader.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbTOReader.FormattingEnabled = true;
            this.cbbTOReader.Location = new System.Drawing.Point(142, 80);
            this.cbbTOReader.Name = "cbbTOReader";
            this.cbbTOReader.Size = new System.Drawing.Size(301, 31);
            this.cbbTOReader.TabIndex = 3;
            this.cbbTOReader.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // txbNameReader
            // 
            this.txbNameReader.Location = new System.Drawing.Point(142, 7);
            this.txbNameReader.Name = "txbNameReader";
            this.txbNameReader.Size = new System.Drawing.Size(301, 31);
            this.txbNameReader.TabIndex = 1;
            this.txbNameReader.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại độc giả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên độc giả:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FAddReader
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
            this.Name = "FAddReader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddReader_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbNameReader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbPhoneReader;
        private System.Windows.Forms.ComboBox cbbTOReader;
    }
}