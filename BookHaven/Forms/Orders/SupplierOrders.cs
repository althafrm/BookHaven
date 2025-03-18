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

namespace BookHaven.Forms.Orders
{
    public partial class SupplierOrders : Form
    {
        private readonly ISupplierOrderService _supplierOrderService;
        private readonly IBookService _bookService;
        private readonly ISupplierService _supplierService;
        private List<SupplierOrderDetail> _supplierOrderDetails;
        private Panel parentPanel;
        private SupplierOrder _currentOrder;
        private int _currentPage = 1;
        private int _totalRecords;
        private const int _pageSize = 10;

        public SupplierOrders(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            parentPanel = panelContainer;
            _supplierOrderService = serviceProvider.GetRequiredService<ISupplierOrderService>();
            _bookService = serviceProvider.GetRequiredService<IBookService>();
            _supplierService = serviceProvider.GetRequiredService<ISupplierService>();
            _supplierOrderDetails = new List<SupplierOrderDetail>();
            LoadOrders();
            LoadBooks();
            LoadSuppliers();
            LoadOrderStatus();
        }

        private void LoadOrders()
        {
            gridSupplierOrders.DataSource = _supplierOrderService.ListSupplierOrdersPaginated(_currentPage, _pageSize, out _totalRecords);
            UpdatePaginationControls();
        }

        private void LoadBooks()
        {
            cmbBook.DataSource = _bookService.GetBooksPaginated(1, 100, "", out _);
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "Id";
        }

        private void LoadSuppliers()
        {
            cmbSupplier.DataSource = _supplierService.GetSuppliers();
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
        }

        private void LoadOrderStatus()
        {
            cmbOrderStatus.Items.Clear();
            cmbOrderStatus.Items.Add("Pending");
            cmbOrderStatus.Items.Add("Received");
            cmbOrderStatus.Items.Add("Cancelled");
            cmbOrderStatus.SelectedIndex = 0;
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
            lblTotalAmountValue.Text = _supplierOrderDetails.Sum(d => (d.Price * d.Quantity)).ToString();
        }

        private void UpdateSupplierOrderDetails()
        {
            if (cmbBook.SelectedValue != null)
            {
                var selectedBook = (Book)cmbBook.SelectedItem;
                var quantity = (int)numQuantity.Value;
                var existingDetail = _supplierOrderDetails.FirstOrDefault(d => d.BookId == selectedBook.Id);

                if (existingDetail != null)
                {
                    if (quantity == 0)
                    {
                        _supplierOrderDetails.Remove(existingDetail);
                    }
                    else
                    {
                        existingDetail.Quantity = quantity;
                        existingDetail.Price = selectedBook.Price;
                    }
                }
                else if (quantity > 0)
                {
                    _supplierOrderDetails.Add(new SupplierOrderDetail
                    {
                        SupplierOrderId = _currentOrder?.Id ?? Guid.NewGuid(),
                        BookId = selectedBook.Id,
                        BookTitle = selectedBook.Title,
                        Quantity = quantity,
                        Price = selectedBook.Price
                    });
                }

                gridSupplierOrderDetails.DataSource = null;
                gridSupplierOrderDetails.DataSource = _supplierOrderDetails;
                UpdateTotalAmount();
            }
        }

        private void gridSupplierOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid supplierOrderId = (Guid)gridSupplierOrders.Rows[e.RowIndex].Cells["Id"].Value;
                _currentOrder = _supplierOrderService.GetSupplierOrderById(supplierOrderId);
                cmbSupplier.SelectedValue = _currentOrder.SupplierId;
                cmbOrderStatus.SelectedItem = _currentOrder.OrderStatus;
                lblTotalAmountValue.Text = _currentOrder.TotalAmount.ToString();
                lblOrderDateValue.Text = _currentOrder.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

                _supplierOrderDetails = _currentOrder.SupplierOrderDetails;
                gridSupplierOrderDetails.DataSource = _supplierOrderDetails;
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateSupplierOrderDetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_supplierOrderDetails.Count == 0)
            {
                MessageBox.Show("Cannot save an empty order! Add at least one book.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = new SupplierOrder
            {
                Id = _currentOrder?.Id ?? Guid.NewGuid(),
                SupplierId = (Guid)cmbSupplier.SelectedValue,
                TotalAmount = _supplierOrderDetails.Sum(d => (d.Price * d.Quantity)),
                OrderStatus = cmbOrderStatus.SelectedItem.ToString(),
                OrderDate = DateTime.Now,
                SupplierOrderDetails = _supplierOrderDetails
            };

            if (_currentOrder == null)
                _supplierOrderService.AddSupplierOrder(order);
            else
                _supplierOrderService.UpdateSupplierOrder(order);

            MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridSupplierOrderDetails.DataSource = null;
            LoadOrders();
        }

        private void gridSupplierOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedDetail = _supplierOrderDetails[e.RowIndex];
                lblOrderIdValue.Text = selectedDetail.SupplierOrderId.ToString();
                cmbBook.SelectedValue = selectedDetail.BookId;
                numQuantity.Value = selectedDetail.Quantity;
                lblPriceValue.Text = selectedDetail.Price.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("No order selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Deletion",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _supplierOrderService.DeleteSupplierOrder(_currentOrder.Id);
                MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _currentOrder = null;
            _supplierOrderDetails.Clear();
            cmbSupplier.SelectedIndex = -1;
            cmbOrderStatus.SelectedIndex = 0;
            lblTotalAmountValue.Text = "0.00";
            lblOrderDateValue.Text = "-";
            lblOrderIdValue.Text = "-";
            gridSupplierOrderDetails.DataSource = null;

            cmbBook.SelectedIndex = -1;
            lblPriceValue.Text = "0.00";
            numQuantity.Value = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadOrders();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                LoadOrders();
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
