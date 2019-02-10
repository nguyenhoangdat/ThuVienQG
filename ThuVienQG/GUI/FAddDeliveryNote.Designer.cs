namespace ThuVienQG.GUI
{
    partial class FAddDeliveryNote
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
            this.pnlDeliNote = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSumPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlReceNotes = new System.Windows.Forms.Panel();
            this.cbbSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReceNote = new System.Windows.Forms.DataGridView();
            this.pnlDeliNote.SuspendLayout();
            this.pnlReceNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceNote)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDeliNote
            // 
            this.pnlDeliNote.Controls.Add(this.label2);
            this.pnlDeliNote.Controls.Add(this.flpDetail);
            this.pnlDeliNote.Controls.Add(this.label3);
            this.pnlDeliNote.Controls.Add(this.lblSumPrice);
            this.pnlDeliNote.Controls.Add(this.btnSave);
            this.pnlDeliNote.Location = new System.Drawing.Point(617, 0);
            this.pnlDeliNote.Name = "pnlDeliNote";
            this.pnlDeliNote.Size = new System.Drawing.Size(617, 611);
            this.pnlDeliNote.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phiếu Giao";
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
            this.lblSumPrice.AutoSize = true;
            this.lblSumPrice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumPrice.Location = new System.Drawing.Point(497, 539);
            this.lblSumPrice.Name = "lblSum";
            this.lblSumPrice.Size = new System.Drawing.Size(0, 23);
            this.lblSumPrice.TabIndex = 2;
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
            // pnlReceNotes
            // 
            this.pnlReceNotes.Controls.Add(this.cbbSupplier);
            this.pnlReceNotes.Controls.Add(this.label1);
            this.pnlReceNotes.Controls.Add(this.dgvReceNote);
            this.pnlReceNotes.Location = new System.Drawing.Point(0, 0);
            this.pnlReceNotes.Name = "pnlReceNotes";
            this.pnlReceNotes.Size = new System.Drawing.Size(617, 611);
            this.pnlReceNotes.TabIndex = 2;
            // 
            // cbbSupplier
            // 
            this.cbbSupplier.FormattingEnabled = true;
            this.cbbSupplier.Location = new System.Drawing.Point(12, 55);
            this.cbbSupplier.Name = "cbbSupplier";
            this.cbbSupplier.Size = new System.Drawing.Size(595, 31);
            this.cbbSupplier.TabIndex = 1;
            this.cbbSupplier.SelectedValueChanged += new System.EventHandler(this.cbbSupplier_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin đặt";
            // 
            // dgvReceNote
            // 
            this.dgvReceNote.AllowUserToResizeRows = false;
            this.dgvReceNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceNote.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvReceNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceNote.Location = new System.Drawing.Point(10, 92);
            this.dgvReceNote.MultiSelect = false;
            this.dgvReceNote.Name = "dgvReceNote";
            this.dgvReceNote.ReadOnly = true;
            this.dgvReceNote.RowHeadersVisible = false;
            this.dgvReceNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceNote.Size = new System.Drawing.Size(597, 507);
            this.dgvReceNote.TabIndex = 2;
            this.dgvReceNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceNote_CellClick);
            // 
            // FAddDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.pnlDeliNote);
            this.Controls.Add(this.pnlReceNotes);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FAddDeliveryNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddDeliveryNote_Load);
            this.pnlDeliNote.ResumeLayout(false);
            this.pnlDeliNote.PerformLayout();
            this.pnlReceNotes.ResumeLayout(false);
            this.pnlReceNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeliNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSumPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlReceNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReceNote;
        private System.Windows.Forms.ComboBox cbbSupplier;
    }
}