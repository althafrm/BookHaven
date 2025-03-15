using BookHaven.Models;
using BookHaven.Services;
using BookHaven.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms.Books
{
    public partial class Books : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;

        private Panel parentPanel;

        private Guid selectedBookId;
        private List<Book> allBooks;
        private List<Book> currentBooks;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private string searchQuery = "";

        public Books(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
            _bookService = serviceProvider.GetRequiredService<IBookService>();
            _bookGenreService = serviceProvider.GetRequiredService<IBookGenreService>();

            LoadBooks();
            LoadGenres();
        }

        private void LoadBooks()
        {
            gridBooks.DataSource = _bookService.GetBooksPaginated(currentPage, pageSize, searchQuery, out totalRecords);
            UpdatePaginationControls();

            if (gridBooks.Columns.Contains("GenreId"))
            {
                gridBooks.Columns["GenreId"].Visible = false;
            }

            if (gridBooks.Columns.Contains("GenreName"))
            {
                gridBooks.Columns["GenreName"].HeaderText = "Genre";
            }
        }

        private void LoadGenres()
        {
            cmbGenre.DataSource = _bookGenreService.GetGenres();
            cmbGenre.DisplayMember = "GenreName";
            cmbGenre.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtIsbn.Text) ||
                string.IsNullOrWhiteSpace(numPrice.Text) ||
                numPrice.Value <= 0 ||
                string.IsNullOrWhiteSpace(numStock.Text) ||
                numStock.Value < 0 ||
                cmbGenre.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "All fields are required, and price must be greater than 0.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var book = new Book
            {
                Id = selectedBookId == Guid.Empty ? Guid.NewGuid() : selectedBookId,
                GenreId = (Guid)cmbGenre.SelectedValue,
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Isbn = txtIsbn.Text,
                Price = decimal.Parse(numPrice.Text),
                StockQuantity = int.Parse(numStock.Text)
            };

            if (selectedBookId == Guid.Empty)
            {
                _bookService.AddBook(book);
            }
            else
            {
                book.UpdatedAt = DateTime.Now;
                _bookService.UpdateBook(book);
            }

            MessageBox.Show("Book saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBooks();
            btnClear_Click(sender, e);
        }

        private void gridBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedBookId = (Guid)gridBooks.Rows[e.RowIndex].Cells["Id"].Value;
                lblIdValue.Text = selectedBookId.ToString();
                txtTitle.Text = gridBooks.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                txtAuthor.Text = gridBooks.Rows[e.RowIndex].Cells["Author"].Value.ToString();
                txtIsbn.Text = gridBooks.Rows[e.RowIndex].Cells["Isbn"].Value.ToString();
                numPrice.Text = gridBooks.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                numStock.Text = gridBooks.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();
                cmbGenre.SelectedValue = gridBooks.Rows[e.RowIndex].Cells["GenreId"].Value;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblIdValue.Text = "-";
            txtTitle.Clear();
            txtAuthor.Clear();
            txtIsbn.Clear();
            numPrice.Value = 0;
            numStock.Value = 0;
            cmbGenre.SelectedIndex = -1;
            selectedBookId = Guid.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchQuery = txtSearch.Text.Trim();
            currentPage = 1;
            LoadBooks();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadBooks();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadBooks();
            }
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == Guid.Empty)
            {
                MessageBox.Show("Please select a book to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this book?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                _bookService.DeleteBook(selectedBookId);
                MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBooks();
                btnClear_Click(sender, e);
            }
        }
    }
}
