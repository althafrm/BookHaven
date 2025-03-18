using BookHaven.Models;
using BookHaven.Services;
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

namespace BookHaven.Forms.Suppliers
{
    public partial class Suppliers : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISupplierService _supplierService;

        private Panel parentPanel;

        private Guid selectedSupplierId;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private string searchQuery = "";

        public Suppliers(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
            _supplierService = serviceProvider.GetRequiredService<ISupplierService>();

            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            gridSuppliers.DataSource = _supplierService.GetSuppliersPaginated(currentPage, pageSize, searchQuery, out totalRecords);
            UpdatePaginationControls();
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Supplier Name and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var supplier = new Supplier
            {
                Id = selectedSupplierId == Guid.Empty ? Guid.NewGuid() : selectedSupplierId,
                Name = txtName.Text,
                ContactPerson = txtContact.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            try
            {
                if (selectedSupplierId == Guid.Empty)
                {
                    _supplierService.AddSupplier(supplier);
                }
                else
                {
                    supplier.UpdatedAt = DateTime.Now;
                    _supplierService.UpdateSupplier(supplier);
                }

                MessageBox.Show("Supplier saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuppliers();
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSupplierId = (Guid)gridSuppliers.Rows[e.RowIndex].Cells["Id"].Value;
                lblIdValue.Text = selectedSupplierId.ToString();
                txtName.Text = gridSuppliers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtContact.Text = gridSuppliers.Rows[e.RowIndex].Cells["ContactPerson"].Value?.ToString();
                txtEmail.Text = gridSuppliers.Rows[e.RowIndex].Cells["Email"].Value?.ToString();
                txtPhone.Text = gridSuppliers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtAddress.Text = gridSuppliers.Rows[e.RowIndex].Cells["Address"].Value?.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblIdValue.Text = "-";
            selectedSupplierId = Guid.Empty;
            txtName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchQuery = txtSearch.Text.Trim();
            currentPage = 1;
            LoadSuppliers();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSuppliers();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadSuppliers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == Guid.Empty)
            {
                MessageBox.Show("Please select a supplier to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                _supplierService.DeleteSupplier(selectedSupplierId);
                MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuppliers();
                btnClear_Click(sender, e);
            }
        }
    }
}
