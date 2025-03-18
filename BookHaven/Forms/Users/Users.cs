using BookHaven.Forms.Books;
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

namespace BookHaven.Forms.Users
{
    public partial class Users : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;

        private Panel parentPanel;

        private Guid selectedUserId;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private string searchQuery = "";

        public Users(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
            _userService = serviceProvider.GetRequiredService<IUserService>();

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            LoadUsers();
            LoadRoles();
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void LoadUsers()
        {
            gridUsers.DataSource = _userService.GetUsersPaginated(currentPage, pageSize, searchQuery, out totalRecords);
            UpdatePaginationControls();

            if (gridUsers.Columns.Contains("PasswordHash"))
            {
                gridUsers.Columns["PasswordHash"].Visible = false;
            }
        }

        private void LoadRoles()
        {
            cmbRole.DataSource = _userService.GetRoles();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Username and Role are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = null;

            if (selectedUserId == Guid.Empty)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                passwordHash = SecurityHelper.HashPassword(txtPassword.Text);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    passwordHash = SecurityHelper.HashPassword(txtPassword.Text);
                }
            }

            var user = new User
            {
                Id = selectedUserId == Guid.Empty ? Guid.NewGuid() : selectedUserId,
                RoleId = (Guid)cmbRole.SelectedValue,
                Username = txtUsername.Text,
                PasswordHash = passwordHash
            };

            try
            {
                if (selectedUserId == Guid.Empty)
                {
                    _userService.AddUser(user);
                }
                else
                {
                    user.UpdatedAt = DateTime.Now;
                    _userService.UpdateUser(user);
                }

                MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedUserId = (Guid)gridUsers.Rows[e.RowIndex].Cells["Id"].Value;
                lblIdValue.Text = selectedUserId.ToString();
                txtUsername.Text = gridUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                cmbRole.SelectedValue = gridUsers.Rows[e.RowIndex].Cells["RoleId"].Value;
                txtPassword.Clear();
                txtConfirmPassword.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == Guid.Empty)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                _userService.DeleteUser(selectedUserId);
                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblIdValue.Text = "-";
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cmbRole.SelectedIndex = -1;
            selectedUserId = Guid.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchQuery = txtSearch.Text.Trim();
            currentPage = 1;
            LoadUsers();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadUsers();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadUsers();
            }
        }
    }
}
