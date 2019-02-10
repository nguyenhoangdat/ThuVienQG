namespace ThuVienQG.GUI
{
    partial class FAddReceiptNote
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
            this.pnlTitles = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            this.pnlReceNote = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            lblSum = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.pnlReceNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitles
            // 
            this.pnlTitles.Controls.Add(this.label1);
            this.pnlTitles.Controls.Add(this.dgvTitles);
            this.pnlTitles.Location = new System.Drawing.Point(0, 0);
            this.pnlTitles.Name = "pnlTitles";
            this.pnlTitles.Size = new System.Drawing.Size(617, 611);
            this.pnlTitles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đầu Sách";
            // 
            // dgvTitles
            // 
            this.dgvTitles.AllowUserToResizeRows = false;
            this.dgvTitles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTitles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.Location = new System.Drawing.Point(10, 55);
            this.dgvTitles.MultiSelect = false;
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.RowHeadersVisible = false;
            this.dgvTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTitles.Size = new System.Drawing.Size(597, 544);
            this.dgvTitles.TabIndex = 1;
            this.dgvTitles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTitles_CellClick);
            // 
            // pnlReceNote
            // 
            this.pnlReceNote.Controls.Add(this.label2);
            this.pnlReceNote.Controls.Add(this.flpDetail);
            this.pnlReceNote.Controls.Add(this.label3);
            this.pnlReceNote.Controls.Add(lblSum);
            this.pnlReceNote.Controls.Add(this.btnSave);
            this.pnlReceNote.Location = new System.Drawing.Point(617, 0);
            this.pnlReceNote.Name = "pnlReceNote";
            this.pnlReceNote.Size = new System.Drawing.Size(617, 611);
            this.pnlReceNote.TabIndex = 1;
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
            // FAddReceiptNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.pnlReceNote);
            this.Controls.Add(this.pnlTitles);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FAddReceiptNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddReceiptNote_Load);
            this.pnlTitles.ResumeLayout(false);
            this.pnlTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.pnlReceNote.ResumeLayout(false);
            this.pnlReceNote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTitles;
        private System.Windows.Forms.Panel pnlReceNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpDetail;
        private System.Windows.Forms.Label label3;
        private static System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Button btnSave;
    }
}