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
            lblBookGenres = new Label();
            btnBackBooks = new Button();
            SuspendLayout();
            // 
            // lblBookGenres
            // 
            lblBookGenres.AutoSize = true;
            lblBookGenres.Location = new Point(0, 0);
            lblBookGenres.Name = "lblBookGenres";
            lblBookGenres.Size = new Size(92, 20);
            lblBookGenres.TabIndex = 0;
            lblBookGenres.Text = "Book Genres";
            // 
            // btnBackBooks
            // 
            btnBackBooks.Location = new Point(12, 23);
            btnBackBooks.Name = "btnBackBooks";
            btnBackBooks.Size = new Size(130, 29);
            btnBackBooks.TabIndex = 1;
            btnBackBooks.Text = "< Back To Books";
            btnBackBooks.UseVisualStyleBackColor = true;
            btnBackBooks.Click += btnBackBooks_Click;
            // 
            // BookGenres
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(957, 653);
            Controls.Add(btnBackBooks);
            Controls.Add(lblBookGenres);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BookGenres";
            Text = "Book Genres";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBookGenres;
        private Button btnBackBooks;
    }
}