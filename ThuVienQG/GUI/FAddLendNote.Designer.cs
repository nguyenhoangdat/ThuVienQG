namespace ThuVienQG.GUI
{
    partial class FAddLendNote
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
            this.cbbReader = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flpDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitles = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.cbbBookCate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            this.btnAddReader = new System.Windows.Forms.Button();
            this.pnlReceNote.SuspendLayout();
            this.pnlTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlReceNote
            // 
            this.pnlReceNote.Controls.Add(this.btnAddReader);
            this.pnlReceNote.Controls.Add(this.cbbReader);
            this.pnlReceNote.Controls.Add(this.label2);
            this.pnlReceNote.Controls.Add(this.flpDetail);
            this.pnlReceNote.Controls.Add(this.btnSave);
            this.pnlReceNote.Location = new System.Drawing.Point(617, 0);
            this.pnlReceNote.Name = "pnlReceNote";
            this.pnlReceNote.Size = new System.Drawing.Size(617, 611);
            this.pnlReceNote.TabIndex = 3;
            // 
            // cbbReader
            // 
            this.cbbReader.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbReader.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbReader.FormattingEnabled = true;
            this.cbbReader.Location = new System.Drawing.Point(10, 55);
            this.cbbReader.Name = "cbbReader";
            this.cbbReader.Size = new System.Drawing.Size(560, 31);
            this.cbbReader.TabIndex = 2;
            this.cbbReader.SelectedValueChanged += new System.EventHandler(this.cbbReader_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phiếu Mượn";
            // 
            // flpDetail
            // 
            this.flpDetail.AutoScroll = true;
            this.flpDetail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpDetail.Location = new System.Drawing.Point(10, 92);
            this.flpDetail.Name = "flpDetail";
            this.flpDetail.Size = new System.Drawing.Size(597, 471);
            this.flpDetail.TabIndex = 1;
            this.flpDetail.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flpDetail_ControlRemoved);
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
            // pnlTitles
            // 
            this.pnlTitles.Controls.Add(this.dgvBooks);
            this.pnlTitles.Controls.Add(this.cbbBookCate);
            this.pnlTitles.Controls.Add(this.label1);
            this.pnlTitles.Controls.Add(this.dgvTitles);
            this.pnlTitles.Location = new System.Drawing.Point(0, 0);
            this.pnlTitles.Name = "pnlTitles";
            this.pnlTitles.Size = new System.Drawing.Size(617, 611);
            this.pnlTitles.TabIndex = 2;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(313, 92);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(294, 507);
            this.dgvBooks.TabIndex = 4;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // 
            // cbbBookCate
            // 
            this.cbbBookCate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBookCate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBookCate.FormattingEnabled = true;
            this.cbbBookCate.Location = new System.Drawing.Point(12, 55);
            this.cbbBookCate.Name = "cbbBookCate";
            this.cbbBookCate.Size = new System.Drawing.Size(595, 31);
            this.cbbBookCate.TabIndex = 2;
            this.cbbBookCate.SelectedValueChanged += new System.EventHandler(this.cbbBookCate_SelectedValueChanged);
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
            this.dgvTitles.Location = new System.Drawing.Point(10, 92);
            this.dgvTitles.MultiSelect = false;
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.RowHeadersVisible = false;
            this.dgvTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTitles.Size = new System.Drawing.Size(297, 507);
            this.dgvTitles.TabIndex = 1;
            this.dgvTitles.SelectionChanged += new System.EventHandler(this.dgvTitles_SelectionChanged);
            // 
            // btnAddReader
            // 
            this.btnAddReader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReader.Location = new System.Drawing.Point(576, 54);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(31, 31);
            this.btnAddReader.TabIndex = 12;
            this.btnAddReader.Text = "+";
            this.btnAddReader.UseVisualStyleBackColor = true;
            this.btnAddReader.Click += new System.EventHandler(this.btnAddReader_Click);
            // 
            // FAddLendNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.pnlReceNote);
            this.Controls.Add(this.pnlTitles);
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FAddLendNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư Viện";
            this.Load += new System.EventHandler(this.FAddLendNote_Load);
            this.pnlReceNote.ResumeLayout(false);
            this.pnlReceNote.PerformLayout();
            this.pnlTitles.ResumeLayout(false);
            this.pnlTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReceNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTitles;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.ComboBox cbbBookCate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTitles;
        private System.Windows.Forms.ComboBox cbbReader;
        private System.Windows.Forms.Button btnAddReader;
    }
}