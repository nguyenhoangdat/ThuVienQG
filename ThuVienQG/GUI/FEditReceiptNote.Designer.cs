namespace ThuVienQG.GUI
{
    partial class FEditReceiptNote
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
            this.pnlReceNote = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            lblSum = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlReceNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReceNote
            // 
            this.pnlReceNote.Controls.Add(this.label2);
            this.pnlReceNote.Controls.Add(this.flpDetail);
            this.pnlReceNote.Controls.Add(this.label3);
            this.pnlReceNote.Controls.Add(lblSum);
            this.pnlReceNote.Controls.Add(this.btnSave);
            this.pnlReceNote.Location = new System.Drawing.Point(-4, 0);
            this.pnlReceNote.Name = "pnlReceNote";
            this.pnlReceNote.Size = new System.Drawing.Size(617, 611);
            this.pnlReceNote.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phiếu Nhập";
            // 
            // flpDetail
            // 
            this.flpDetail.AutoScroll = true;
            this.flpDetail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpDetail.Location = new System.Drawing.Point(10, 55);
            this.flpDetail.Name = "flpDetail";
            this.flpDetail.Size = new System.Drawing.Size(597, 475);
            this.flpDetail.TabIndex = 1;
            this.flpDetail.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flpDetail_ControlRemoved);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tổng tiền: ";
            // 
            // lblSum
            // 
            lblSum.AutoSize = true;
            lblSum.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSum.Location = new System.Drawing.Point(497, 539);
            lblSum.Name = "lblSum";
            lblSum.Size = new System.Drawing.Size(0, 23);
            lblSum.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(532, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FEditReceiptNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 611);
            this.Controls.Add(this.pnlReceNote);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FEditReceiptNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.pnlReceNote.ResumeLayout(false);
            this.pnlReceNote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReceNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private static System.Windows.Forms.Label lblSum;
    }
}