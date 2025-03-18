using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public interface IReportService
    {
        List<SalesReport> GetDailySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords);
        List<SalesReport> GetWeeklySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords);
        List<SalesReport> GetMonthlySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords);
        List<InventoryReport> GetInventoryReport(int page, int pageSize, out int totalRecords);
    }
}
