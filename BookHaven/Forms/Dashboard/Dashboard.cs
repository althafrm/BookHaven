using BookHaven.Forms.Authentication;
using BookHaven.Forms.Books;
using BookHaven.Services;
using BookHaven.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms.Dashboard
{
    public partial class Dashboard : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Dashboard(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            this.StartPosition = FormStartPosition.CenterScreen;
            ApplyRoleRestrictions();
            this.FormClosing += Dashboard_FormClosing;

            btnHome.TabIndex = 0;
            btnManageBooks.TabIndex = 1;

            lblGreeting.Text = $"Hi, {SessionManager.LoggedInUser}!";

            if (SessionManager.UserRole == "Admin")
            {
                FormLoader.LoadFormIntoPanel(
                    panelContainer,
                    new BookHaven.Forms.Overview.Admin(panelContainer, _serviceProvider)
                );
            }
            else if (SessionManager.UserRole == "Sales Clerk")
            {
                FormLoader.LoadFormIntoPanel(
                    panelContainer,
                    new BookHaven.Forms.Overview.SalesClerk(panelContainer, _serviceProvider)
                );
            }
        }

        private void ApplyRoleRestrictions()
        {
            if (SessionManager.UserRole == "Sales Clerk")
            {
                btnManageBooks.Visible = false;
                btnSuppliers.Visible = false;
                //btnAdminSettings.Visible = false;
                //btnReports.Visible = false;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (SessionManager.UserRole == "Admin")
            {
                FormLoader.LoadFormIntoPanel(
                    panelContainer,
                    new BookHaven.Forms.Overview.Admin(panelContainer, _serviceProvider)
                );
            }
            else if (SessionManager.UserRole == "Sales Clerk")
            {
                FormLoader.LoadFormIntoPanel(
                    panelContainer,
                    new BookHaven.Forms.Overview.SalesClerk(panelContainer, _serviceProvider)
                );
            }
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Books.Books(panelContainer, _serviceProvider)
            );
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmLogout = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmLogout == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Hide();
                new Login(_serviceProvider).Show();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Customers.Customers(panelContainer, _serviceProvider)
            );
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Books.BookGenres(panelContainer, _serviceProvider)
            );
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Suppliers.Suppliers(panelContainer, _serviceProvider)
            );
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Sales.Sales(panelContainer, _serviceProvider)
            );
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Orders.Orders(panelContainer, _serviceProvider)
            );
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(
                panelContainer,
                new BookHaven.Forms.Users.Users(panelContainer, _serviceProvider)
            );
        }
    }
}
