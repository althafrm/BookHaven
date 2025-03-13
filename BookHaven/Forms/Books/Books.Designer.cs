namespace BookHaven.Forms.Books
{
    partial class Books
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
            btnManageGenres = new Button();
            gbManageBook = new GroupBox();
            numStock = new NumericUpDown();
            numPrice = new NumericUpDown();
            lblStock = new Label();
            lblPrice = new Label();
            txtIsbn = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            lblIsbn = new Label();
            lblAuthor = new Label();
            lblTitle = new Label();
            cmbGenre = new ComboBox();
            lblGenre = new Label();
            lblIdValue = new Label();
            lblId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            gbBookList = new GroupBox();
            lblPageInfo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gridBooks = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            gbManageBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            gbBookList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBooks).BeginInit();
            SuspendLayout();
            // 
            // btnManageGenres
            // 
            btnManageGenres.Location = new Point(762, 81);
            btnManageGenres.Name = "btnManageGenres";
            btnManageGenres.Size = new Size(135, 29);
            btnManageGenres.TabIndex = 1;
            btnManageGenres.Text = "Manage Genres";
            btnManageGenres.UseVisualStyleBackColor = true;
            btnManageGenres.Click += btnManageGenres_Click;
            // 
            // gbManageBook
            // 
            gbManageBook.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageBook.Controls.Add(numStock);
            gbManageBook.Controls.Add(numPrice);
            gbManageBook.Controls.Add(lblStock);
            gbManageBook.Controls.Add(lblPrice);
            gbManageBook.Controls.Add(txtIsbn);
            gbManageBook.Controls.Add(txtAuthor);
            gbManageBook.Controls.Add(txtTitle);
            gbManageBook.Controls.Add(lblIsbn);
            gbManageBook.Controls.Add(lblAuthor);
            gbManageBook.Controls.Add(lblTitle);
            gbManageBook.Controls.Add(cmbGenre);
            gbManageBook.Controls.Add(lblGenre);
            gbManageBook.Controls.Add(lblIdValue);
            gbManageBook.Controls.Add(lblId);
            gbManageBook.Controls.Add(btnClear);
            gbManageBook.Controls.Add(btnDelete);
            gbManageBook.Controls.Add(btnSave);
            gbManageBook.Controls.Add(btnManageGenres);
            gbManageBook.Location = new Point(12, 318);
            gbManageBook.Name = "gbManageBook";
            gbManageBook.Size = new Size(936, 330);
            gbManageBook.TabIndex = 2;
            gbManageBook.TabStop = false;
            gbManageBook.Text = "Manage Book";
            // 
            // numStock
            // 
            numStock.Location = new Point(170, 168);
            numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(180, 27);
            numStock.TabIndex = 12;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(576, 167);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(180, 27);
            numPrice.TabIndex = 12;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(6, 170);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(45, 20);
            lblStock.TabIndex = 11;
            lblStock.Text = "Stock";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(412, 170);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 11;
            lblPrice.Text = "Price";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(170, 125);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(180, 27);
            txtIsbn.TabIndex = 10;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(576, 125);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(180, 27);
            txtAuthor.TabIndex = 10;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(170, 82);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(180, 27);
            txtTitle.TabIndex = 10;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(6, 128);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(41, 20);
            lblIsbn.TabIndex = 9;
            lblIsbn.Text = "ISBN";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(412, 128);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 85);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Title";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(576, 82);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(180, 28);
            cmbGenre.TabIndex = 8;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(412, 85);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(48, 20);
            lblGenre.TabIndex = 7;
            lblGenre.Text = "Genre";
            // 
            // lblIdValue
            // 
            lblIdValue.AutoSize = true;
            lblIdValue.Location = new Point(170, 46);
            lblIdValue.Name = "lblIdValue";
            lblIdValue.Size = new Size(15, 20);
            lblIdValue.TabIndex = 6;
            lblIdValue.Text = "-";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(6, 46);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 5;
            lblId.Text = "Id";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(288, 294);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(147, 294);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 294);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // gbBookList
            // 
            gbBookList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbBookList.Controls.Add(lblPageInfo);
            gbBookList.Controls.Add(txtSearch);
            gbBookList.Controls.Add(btnSearch);
            gbBookList.Controls.Add(gridBooks);
            gbBookList.Controls.Add(btnPrevious);
            gbBookList.Controls.Add(btnNext);
            gbBookList.Location = new Point(12, 12);
            gbBookList.Name = "gbBookList";
            gbBookList.Size = new Size(936, 300);
            gbBookList.TabIndex = 3;
            gbBookList.TabStop = false;
            gbBookList.Text = "Book List";
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(542, 30);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(79, 20);
            lblPageInfo.TabIndex = 10;
            lblPageInfo.Text = "Page - of -";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(270, 27);
            txtSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(282, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // gridBooks
            // 
            gridBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBooks.Dock = DockStyle.Bottom;
            gridBooks.Location = new Point(3, 62);
            gridBooks.MultiSelect = false;
            gridBooks.Name = "gridBooks";
            gridBooks.RowHeadersWidth = 51;
            gridBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBooks.Size = new Size(930, 235);
            gridBooks.TabIndex = 5;
            gridBooks.CellClick += gridBooks_CellClick;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(654, 26);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(135, 29);
            btnPrevious.TabIndex = 7;
            btnPrevious.Text = "< Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(795, 26);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Books
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(957, 653);
            Controls.Add(gbBookList);
            Controls.Add(gbManageBook);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Books";
            Text = "Books";
            gbManageBook.ResumeLayout(false);
            gbManageBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            gbBookList.ResumeLayout(false);
            gbBookList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnManageGenres;
        private GroupBox gbManageBook;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private GroupBox gbBookList;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridBooks;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblId;
        private Label lblGenre;
        private Label lblIdValue;
        private ComboBox cmbGenre;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private Label lblAuthor;
        private Label lblTitle;
        private NumericUpDown numPrice;
        private Label lblPrice;
        private TextBox txtIsbn;
        private Label lblIsbn;
        private NumericUpDown numStock;
        private Label lblStock;
        private Label lblPageInfo;
    }
}