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

namespace BookHaven.Forms.Sales
{
    public partial class Sales : Form
    {
        private readonly ISalesService _salesService;
        private readonly IBookService _bookService;
        private List<SaleDetail> _saleDetails;

        private Panel parentPanel;

        private Sale _currentSale;
        private int _currentPage = 1;
        private int _totalRecords;
        private const int _pageSize = 10;

        public Sales(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _salesService = serviceProvider.GetRequiredService<ISalesService>();
            _bookService = serviceProvider.GetRequiredService<IBookService>();
            _saleDetails = new List<SaleDetail>();

            LoadSales();
            LoadBooks();
        }

        private void LoadSales()
        {
            gridSales.DataSource = _salesService.ListSalesPaginated(_currentPage, _pageSize, out _totalRecords);
            UpdatePaginationControls();
        }

        private void LoadBooks()
        {
            cmbBook.DataSource = _bookService.GetBooksPaginated(1, 100, "", out _);
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "Id";
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);
            lblPageInfo.Text = $"Page {_currentPage} of {totalPages}";
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
        }

        private void UpdateTotalAmount()
        {
            lblTotalAmountValue.Text = (_saleDetails.Sum(d => d.Price) - numDiscount.Value).ToString();
        }

        private void UpdateSalesDetails()
        {
            if (cmbBook.SelectedValue != null)
            {
                var selectedBook = (Book)cmbBook.SelectedItem;
                var quantity = (int)numQuantity.Value;

                if (quantity > selectedBook.StockQuantity)
                {
                    MessageBox.Show("Not enough stock available!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numQuantity.Value = selectedBook.StockQuantity;
                    return;
                }

                var existingDetail = _saleDetails.FirstOrDefault(d => d.BookId == selectedBook.Id);

                if (existingDetail != null)
                {
                    if (quantity == 0)
                    {
                        _saleDetails.Remove(existingDetail);
                    }
                    else
                    {
                        existingDetail.Quantity = quantity;
                        existingDetail.Price = quantity * selectedBook.Price;
                    }
                }
                else if (quantity > 0)
                {
                    _saleDetails.Add(new SaleDetail
                    {
                        SaleId = _currentSale?.Id ?? Guid.NewGuid(),
                        BookId = selectedBook.Id,
                        BookTitle = selectedBook.Title,
                        Quantity = quantity,
                        Price = selectedBook.Price * quantity
                    });
                }

                gridSalesDetails.DataSource = null;
                gridSalesDetails.DataSource = _saleDetails;

                UpdateTotalAmount();
            }
        }

        private void gridSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid saleId = (Guid)gridSales.Rows[e.RowIndex].Cells["Id"].Value;
                _currentSale = _salesService.GetSaleById(saleId);

                lblUserIdValue.Text = _currentSale.UserId.ToString();
                lblTotalAmountValue.Text = _currentSale.TotalAmount.ToString();
                numDiscount.Value = _currentSale.Discount;
                lblSaleDateValue.Text = _currentSale.SaleDate.ToString("yyyy-MM-dd HH:mm:ss");

                _saleDetails = _currentSale.SaleDetails;
                gridSalesDetails.DataSource = _saleDetails;
            }
        }

        private void gridSalesDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedDetail = _saleDetails[e.RowIndex];
                lblSaleIdValue.Text = selectedDetail.SaleId.ToString();
                cmbBook.SelectedValue = selectedDetail.BookId;
                numQuantity.Value = selectedDetail.Quantity;
                lblPriceValue.Text = selectedDetail.Price.ToString();
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateSalesDetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_saleDetails.Count == 0)
            {
                MessageBox.Show("Cannot save an empty sale! Add at least one book.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sale = new Sale
            {
                Id = _currentSale?.Id ?? Guid.NewGuid(),
                UserId = SessionManager.UserId,
                TotalAmount = _saleDetails.Sum(d => d.Price) - numDiscount.Value,
                Discount = numDiscount.Value,
                SaleDate = DateTime.Now,
                SaleDetails = _saleDetails
            };

            if (_currentSale == null)
                _salesService.AddSale(sale);
            else
                _salesService.UpdateSale(sale);

            MessageBox.Show("Sale saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridSalesDetails.DataSource = null;
            LoadSales();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentSale == null)
            {
                MessageBox.Show("No sale selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this sale?", "Confirm Deletion",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _salesService.DeleteSale(_currentSale.Id);
                MessageBox.Show("Sale deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSales();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _currentSale = null;
            _saleDetails.Clear();
            lblUserIdValue.Text = "-";
            lblTotalAmountValue.Text = "0.00";
            numDiscount.Value = 0;
            lblSaleDateValue.Text = "-";
            lblSaleIdValue.Text = "-";
            gridSalesDetails.DataSource = null;

            cmbBook.SelectedIndex = -1;
            lblPriceValue.Text = "0.00";
            numQuantity.Value = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadSales();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                LoadSales();
            }
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBook.SelectedValue != null)
            {
                var selectedBook = (Book)cmbBook.SelectedItem;
                lblPriceValue.Text = selectedBook.Price.ToString();
            }

            numQuantity.Value = 0;
        }
    }
}
