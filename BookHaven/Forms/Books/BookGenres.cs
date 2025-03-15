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
    public partial class BookGenres : Form
    {
        private Panel parentPanel;

        private readonly IServiceProvider _serviceProvider;
        private readonly IBookGenreService _bookGenreService;

        private Guid selectedGenreId;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private string searchQuery = "";

        public BookGenres(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
            _bookGenreService = serviceProvider.GetRequiredService<IBookGenreService>();

            LoadGenres();
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void LoadGenres()
        {
            gridGenres.DataSource = _bookGenreService.GetGenresPaginated(currentPage, pageSize, searchQuery, out totalRecords);
            UpdatePaginationControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreName.Text))
            {
                MessageBox.Show("Genre Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var genre = new BookGenre
            {
                Id = selectedGenreId == Guid.Empty ? Guid.NewGuid() : selectedGenreId,
                GenreName = txtGenreName.Text
            };

            if (selectedGenreId == Guid.Empty)
            {
                _bookGenreService.AddGenre(genre);
            }
            else
            {
                genre.UpdatedAt = DateTime.Now;
                _bookGenreService.UpdateGenre(genre);
            }

            MessageBox.Show("Genre saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGenres();
            btnClear_Click(sender, e);
        }

        private void gridGenres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedGenreId = (Guid)gridGenres.Rows[e.RowIndex].Cells["Id"].Value;
                lblIdValue.Text = selectedGenreId.ToString();
                txtGenreName.Text = gridGenres.Rows[e.RowIndex].Cells["GenreName"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblIdValue.Text = "-";
            selectedGenreId = Guid.Empty;
            txtGenreName.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchQuery = txtSearch.Text.Trim();
            currentPage = 1;
            LoadGenres();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadGenres();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadGenres();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGenreId == Guid.Empty)
            {
                MessageBox.Show("Please select a genre to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this genre?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                _bookGenreService.DeleteGenre(selectedGenreId);
                MessageBox.Show("Genre deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGenres();
                btnClear_Click(sender, e);
            }
        }
    }
}
