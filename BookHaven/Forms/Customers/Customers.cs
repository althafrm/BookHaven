using BookHaven.Models;
using BookHaven.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookHaven.Forms.Customers
{
    public partial class Customers : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICustomerService _customerService;

        private Panel parentPanel;

        private Guid selectedCustomerId;
        private List<Customer> customers;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private string searchQuery = "";

        public Customers(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
            _customerService = serviceProvider.GetRequiredService<ICustomerService>();

            LoadCustomers();
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void LoadCustomers()
        {
            customers = _customerService.GetCustomersPaginated(currentPage, pageSize, searchQuery, out totalRecords);
            gridCustomers.DataSource = customers;
            UpdatePaginationControls();

            //if (gridCustomers.Columns.Contains("Id"))
            //{
            //    gridCustomers.Columns["Id"].Visible = false;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name, Email and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = new Customer
            {
                Id = selectedCustomerId == Guid.Empty ? Guid.NewGuid() : selectedCustomerId,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            if (selectedCustomerId == Guid.Empty)
            {
                _customerService.AddCustomer(customer);
            }
            else
            {
                customer.UpdatedAt = DateTime.Now;
                _customerService.UpdateCustomer(customer);
            }

            MessageBox.Show("Customer saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCustomers();
            btnClear_Click(sender, e);
        }

        private void gridCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCustomerId = (Guid)gridCustomers.Rows[e.RowIndex].Cells["Id"].Value;
                lblIdValue.Text = selectedCustomerId.ToString();
                txtName.Text = gridCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtEmail.Text = gridCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPhone.Text = gridCustomers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtAddress.Text = gridCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblIdValue.Text = "-";
            selectedCustomerId = Guid.Empty;
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchQuery = txtSearch.Text.Trim();
            currentPage = 1;
            LoadCustomers();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadCustomers();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadCustomers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == Guid.Empty)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                _customerService.DeleteCustomer(selectedCustomerId);
                MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
                btnClear_Click(sender, e);
            }
        }
    }
}
