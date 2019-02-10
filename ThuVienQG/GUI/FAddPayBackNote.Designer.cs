namespace ThuVienQG.GUI
{
    partial class FAddPayBackNote
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
            this.pnlPayBackNote = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            lblSum = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlLendNotes = new System.Windows.Forms.Panel();
            this.cbbReader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBookIsLend = new System.Windows.Forms.DataGridView();
            this.pnlPayBackNote.SuspendLayout();
            this.pnlLendNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookIsLend)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPayBackNote
            // 
            this.pnlPayBackNote.Controls.Add(this.label2);
            this.pnlPayBackNote.Controls.Add(this.flpDetail);
            this.pnlPayBackNote.Controls.Add(this.label3);
            this.pnlPayBackNote.Controls.Add(lblSum);
            this.pnlPayBackNote.Controls.Add(this.btnSave);
            this.pnlPayBackNote.Location = new System.Drawing.Point(617, 0);
            this.pnlPayBackNote.Name = "pnlPayBackNote";
            this.pnlPayBackNote.Size = new System.Drawing.Size(617, 611);
            this.pnlPayBackNote.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phiếu Trả";
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
            // pnlLendNotes
            // 
            this.pnlLendNotes.Controls.Add(this.cbbReader);
            this.pnlLendNotes.Controls.Add(this.label1);
            this.pnlLendNotes.Controls.Add(this.dgvBookIsLend);
            this.pnlLendNotes.Location = new System.Drawing.Point(0, 0);
            this.pnlLendNotes.Name = "pnlLendNotes";
            this.pnlLendNotes.Size = new System.Drawing.Size(617, 611);
            this.pnlLendNotes.TabIndex = 4;
            // 
            // cbbReader
            // 
            this.cbbReader.FormattingEnabled = true;
            this.cbbReader.Location = new System.Drawing.Point(12, 55);
            this.cbbReader.Name = "cbbReader";
            this.cbbReader.Size = new System.Drawing.Size(595, 31);
            this.cbbReader.TabIndex = 1;
            this.cbbReader.SelectedValueChanged += new System.EventHandler(this.cbbReader_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin mượn sách";
            // 
            // dgvBookIsLend
            // 
            this.dgvBookIsLend.AllowUserToResizeRows = false;
            this.dgvBookIsLend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookIsLend.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBookIsLend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookIsLend.Location = new System.Drawing.Point(10, 92);
            this.dgvBookIsLend.MultiSelect = false;
            this.dgvBookIsLend.Name = "dgvBookIsLend";
            this.dgvBookIsLend.ReadOnly = true;
            this.dgvBookIsLend.RowHeadersVisible = false;
            this.dgvBookIsLend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookIsLend.Size = new System.Drawing.Size(597, 507);
            this.dgvBookIsLend.TabIndex = 2;
            this.dgvBookIsLend.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookIsLend_CellClick);
            // 
            // FAddPayBackNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.pnlPayBackNote);
            this.Controls.Add(this.pnlLendNotes);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FAddPayBackNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddPayBackNote_Load);
            this.pnlPayBackNote.ResumeLayout(false);
            this.pnlPayBackNote.PerformLayout();
            this.pnlLendNotes.ResumeLayout(false);
            this.pnlLendNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookIsLend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPayBackNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlLendNotes;
        private System.Windows.Forms.ComboBox cbbReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBookIsLend;
        private System.Windows.Forms.FlowLayoutPanel flpDetail;
        private static System.Windows.Forms.Label lblSum;
    }
}