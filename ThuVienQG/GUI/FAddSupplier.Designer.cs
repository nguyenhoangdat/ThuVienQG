namespace ThuVienQG.GUI
{
    partial class FAddSupplier
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
            this.label5 = new System.Windows.Forms.Label();
            this.txbFaxSupplier = new System.Windows.Forms.TextBox();
            this.txbPhoneSupplier = new System.Windows.Forms.TextBox();
            this.txbEmailSupplier = new System.Windows.Forms.TextBox();
            this.txbNameSupplier = new System.Windows.Forms.TextBox();
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
            this.label1.Location = new System.Drawing.Point(157, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhà cung cấp";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txbFaxSupplier);
            this.panel1.Controls.Add(this.txbPhoneSupplier);
            this.panel1.Controls.Add(this.txbEmailSupplier);
            this.panel1.Controls.Add(this.txbNameSupplier);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 158);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số fax:";
            // 
            // txbFaxSupplier
            // 
            this.txbFaxSupplier.Location = new System.Drawing.Point(142, 117);
            this.txbFaxSupplier.Name = "txbFaxSupplier";
            this.txbFaxSupplier.Size = new System.Drawing.Size(301, 31);
            this.txbFaxSupplier.TabIndex = 4;
            this.txbFaxSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // txbPhoneSupplier
            // 
            this.txbPhoneSupplier.Location = new System.Drawing.Point(142, 80);
            this.txbPhoneSupplier.Name = "txbPhoneSupplier";
            this.txbPhoneSupplier.Size = new System.Drawing.Size(301, 31);
            this.txbPhoneSupplier.TabIndex = 3;
            this.txbPhoneSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // txbEmailSupplier
            // 
            this.txbEmailSupplier.Location = new System.Drawing.Point(142, 43);
            this.txbEmailSupplier.Name = "txbEmailSupplier";
            this.txbEmailSupplier.Size = new System.Drawing.Size(301, 31);
            this.txbEmailSupplier.TabIndex = 2;
            this.txbEmailSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbEmailSuppier_KeyPress);
            // 
            // txbNameSupplier
            // 
            this.txbNameSupplier.Location = new System.Drawing.Point(142, 7);
            this.txbNameSupplier.Name = "txbNameSupplier";
            this.txbNameSupplier.Size = new System.Drawing.Size(301, 31);
            this.txbNameSupplier.TabIndex = 1;
            this.txbNameSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số điện thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhà cung cấp:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FAddSupplier
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
            this.Name = "FAddSupplier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbEmailSupplier;
        private System.Windows.Forms.TextBox txbNameSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbFaxSupplier;
        private System.Windows.Forms.TextBox txbPhoneSupplier;
    }
}