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
    public partial class Orders : Form
    {
        private readonly IOrderService _orderService;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        private List<OrderDetail> _orderDetails;
        private Panel parentPanel;
        private Order _currentOrder;
        private int _currentPage = 1;
        private int _totalRecords;
        private const int _pageSize = 10;

        public Orders(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            parentPanel = panelContainer;
            _orderService = serviceProvider.GetRequiredService<IOrderService>();
            _bookService = serviceProvider.GetRequiredService<IBookService>();
            _customerService = serviceProvider.GetRequiredService<ICustomerService>();
            _orderDetails = new List<OrderDetail>();
            LoadOrders();
            LoadBooks();
            LoadCustomers();
            LoadOrderStatus();
        }

        private void LoadOrders()
        {
            gridOrders.DataSource = _orderService.ListOrdersPaginated(_currentPage, _pageSize, out _totalRecords);
            UpdatePaginationControls();
        }

        private void LoadBooks()
        {
            cmbBook.DataSource = _bookService.GetBooksPaginated(1, 100, "", out _);
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "Id";
        }

        private void LoadCustomers()
        {
            cmbCustomer.DataSource = _customerService.GetCustomers();
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "Id";
        }

        private void LoadOrderStatus()
        {
            cmbOrderStatus.Items.Clear();
            cmbOrderStatus.Items.Add("Pending");
            cmbOrderStatus.Items.Add("Completed");
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
            lblTotalAmountValue.Text = _orderDetails.Sum(d => (d.Price * d.Quantity)).ToString();
        }

        private void UpdateOrderDetails()
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

                var existingDetail = _orderDetails.FirstOrDefault(d => d.BookId == selectedBook.Id);

                if (existingDetail != null)
                {
                    if (quantity == 0)
                    {
                        _orderDetails.Remove(existingDetail);
                    }
                    else
                    {
                        existingDetail.Quantity = quantity;
                        existingDetail.Price = selectedBook.Price;
                    }
                }
                else if (quantity > 0)
                {
                    _orderDetails.Add(new OrderDetail
                    {
                        OrderId = _currentOrder?.Id ?? Guid.NewGuid(),
                        BookId = selectedBook.Id,
                        BookTitle = selectedBook.Title,
                        Quantity = quantity,
                        Price = selectedBook.Price
                    });
                }

                gridOrderDetails.DataSource = null;
                gridOrderDetails.DataSource = _orderDetails;
                UpdateTotalAmount();
            }
        }

        private void gridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid orderId = (Guid)gridOrders.Rows[e.RowIndex].Cells["Id"].Value;
                _currentOrder = _orderService.GetOrderById(orderId);
                cmbCustomer.SelectedValue = _currentOrder.CustomerId;
                cmbOrderStatus.SelectedItem = _currentOrder.OrderStatus;
                txtDeliveryAddress.Text = _currentOrder.DeliveryAddress;
                lblTotalAmountValue.Text = _currentOrder.TotalAmount.ToString();
                lblOrderDateValue.Text = _currentOrder.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

                _orderDetails = _currentOrder.OrderDetails;
                gridOrderDetails.DataSource = _orderDetails;
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateOrderDetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_orderDetails.Count == 0)
            {
                MessageBox.Show("Cannot save an empty order! Add at least one book.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = new Order
            {
                Id = _currentOrder?.Id ?? Guid.NewGuid(),
                CustomerId = (Guid)cmbCustomer.SelectedValue,
                UserId = SessionManager.UserId,
                TotalAmount = _orderDetails.Sum(d => (d.Price * d.Quantity)),
                OrderStatus = cmbOrderStatus.SelectedItem.ToString(),
                DeliveryAddress = txtDeliveryAddress.Text,
                OrderDate = DateTime.Now,
                OrderDetails = _orderDetails
            };

            if (_currentOrder == null)
                _orderService.AddOrder(order);
            else
                _orderService.UpdateOrder(order);

            MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridOrderDetails.DataSource = null;
            LoadOrders();
        }

        private void gridOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedDetail = _orderDetails[e.RowIndex];
                lblOrderIdValue.Text = selectedDetail.OrderId.ToString();
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
                _orderService.DeleteOrder(_currentOrder.Id);
                MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _currentOrder = null;
            _orderDetails.Clear();
            cmbCustomer.SelectedIndex = -1;
            cmbOrderStatus.SelectedIndex = 0;
            txtDeliveryAddress.Clear();
            lblTotalAmountValue.Text = "0.00";
            lblOrderDateValue.Text = "-";
            lblOrderIdValue.Text = "-";
            gridOrderDetails.DataSource = null;

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
