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

namespace BookHaven.Forms.Overview
{
    public partial class Admin : Form
    {
        private readonly IAdminService _adminService;

        public Admin(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _adminService = serviceProvider.GetRequiredService<IAdminService>();
            LoadDashboardMetrics();
        }

        private void LoadDashboardMetrics()
        {
            var metrics = _adminService.GetDashboardMetrics();

            lblTotalSales.Text = $"Total Sales (Last 30 Days): {metrics.TotalSales}";
            lblTotalOrders.Text = $"Total Orders: {metrics.TotalOrders}";
            lblTotalCustomers.Text = $"Total Customers: {metrics.TotalCustomers}";
            lblActiveCustomers.Text = $"Active Customers (Last 30 Days): {metrics.ActiveCustomers}";
            lblLowStockBooks.Text = $"Low Stock Books: {metrics.LowStockBooks}";

            gridStaffPerformance.DataSource = metrics.StaffPerformance.Select(kv => new { Staff = kv.Key, SalesHandled = kv.Value }).ToList();
        }
    }
}
