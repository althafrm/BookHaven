namespace BookHaven.Forms.Books
{
    partial class BookGenres
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
            gbGenreList = new GroupBox();
            lblPageInfo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gridGenres = new DataGridView();
            btnPrevious = new Button();
            btnNext = new Button();
            txtGenreName = new TextBox();
            lblGenreName = new Label();
            lblIdValue = new Label();
            lblId = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            gbManageGenre = new GroupBox();
            gbGenreList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridGenres).BeginInit();
            gbManageGenre.SuspendLayout();
            SuspendLayout();
            // 
            // gbGenreList
            // 
            gbGenreList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbGenreList.Controls.Add(lblPageInfo);
            gbGenreList.Controls.Add(txtSearch);
            gbGenreList.Controls.Add(btnSearch);
            gbGenreList.Controls.Add(gridGenres);
            gbGenreList.Controls.Add(btnPrevious);
            gbGenreList.Controls.Add(btnNext);
            gbGenreList.Location = new Point(10, 8);
            gbGenreList.Name = "gbGenreList";
            gbGenreList.Size = new Size(936, 300);
            gbGenreList.TabIndex = 5;
            gbGenreList.TabStop = false;
            gbGenreList.Text = "Book Genre List";
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
            // gridGenres
            // 
            gridGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridGenres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGenres.Dock = DockStyle.Bottom;
            gridGenres.Location = new Point(3, 62);
            gridGenres.MultiSelect = false;
            gridGenres.Name = "gridGenres";
            gridGenres.RowHeadersWidth = 51;
            gridGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridGenres.Size = new Size(930, 235);
            gridGenres.TabIndex = 5;
            gridGenres.CellClick += gridGenres_CellClick;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(654, 27);
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
            btnNext.Location = new Point(795, 27);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // txtGenreName
            // 
            txtGenreName.Location = new Point(170, 82);
            txtGenreName.Name = "txtGenreName";
            txtGenreName.Size = new Size(180, 27);
            txtGenreName.TabIndex = 10;
            // 
            // lblGenreName
            // 
            lblGenreName.AutoSize = true;
            lblGenreName.Location = new Point(6, 85);
            lblGenreName.Name = "lblGenreName";
            lblGenreName.Size = new Size(92, 20);
            lblGenreName.TabIndex = 9;
            lblGenreName.Text = "Genre Name";
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
            // gbManageGenre
            // 
            gbManageGenre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbManageGenre.Controls.Add(txtGenreName);
            gbManageGenre.Controls.Add(lblGenreName);
            gbManageGenre.Controls.Add(lblIdValue);
            gbManageGenre.Controls.Add(lblId);
            gbManageGenre.Controls.Add(btnClear);
            gbManageGenre.Controls.Add(btnDelete);
            gbManageGenre.Controls.Add(btnSave);
            gbManageGenre.Location = new Point(10, 314);
            gbManageGenre.Name = "gbManageGenre";
            gbManageGenre.Size = new Size(936, 330);
            gbManageGenre.TabIndex = 4;
            gbManageGenre.TabStop = false;
            gbManageGenre.Text = "Manage Book Genre";
            // 
            // BookGenres
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(957, 653);
            Controls.Add(gbGenreList);
            Controls.Add(gbManageGenre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BookGenres";
            Text = "Book Genres";
            gbGenreList.ResumeLayout(false);
            gbGenreList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridGenres).EndInit();
            gbManageGenre.ResumeLayout(false);
            gbManageGenre.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbGenreList;
        private Label lblPageInfo;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView gridGenres;
        private Button btnPrevious;
        private Button btnNext;
        private TextBox txtGenreName;
        private Label lblGenreName;
        private Label lblIdValue;
        private Label lblId;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private GroupBox gbManageGenre;
    }
}