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

namespace BookHaven.Forms.Reports
{
    public partial class Reports : Form
    {
        private Panel parentPanel;
        private readonly IReportService _reportService;
        private int _currentPage = 1;
        private int _totalRecords;
        private const int PageSize = 10;

        public Reports(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;
            _reportService = serviceProvider.GetRequiredService<IReportService>();

            LoadReportTypes();
        }

        private void LoadReportTypes()
        {
            cmbReport.Items.Clear();
            cmbReport.Items.Add("Daily Sales Report");
            cmbReport.Items.Add("Weekly Sales Report");
            cmbReport.Items.Add("Monthly Sales Report");
            cmbReport.Items.Add("Inventory Status Report");
            cmbReport.SelectedIndex = 0;
        }

        private void UpdatePaginationControls()
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);
            lblPageInfo.Text = $"Page {_currentPage} of {totalPages}";

            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
        }

        private void LoadReport()
        {
            if (cmbReport.SelectedItem == null) return;

            string selectedReport = cmbReport.SelectedItem.ToString();
            DateTime from = dtFrom.Value;
            DateTime to = dtTo.Value;

            if (selectedReport == "Daily Sales Report")
                gridReport.DataSource = _reportService.GetDailySalesReport(from, to, _currentPage, PageSize, out _totalRecords);
            else if (selectedReport == "Weekly Sales Report")
                gridReport.DataSource = _reportService.GetWeeklySalesReport(from, to, _currentPage, PageSize, out _totalRecords);
            else if (selectedReport == "Monthly Sales Report")
                gridReport.DataSource = _reportService.GetMonthlySalesReport(from, to, _currentPage, PageSize, out _totalRecords);
            else if (selectedReport == "Inventory Status Report")
                gridReport.DataSource = _reportService.GetInventoryReport(_currentPage, PageSize, out _totalRecords);

            UpdatePaginationControls();
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadReport();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadReport();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                LoadReport();
            }
        }
    }
}
