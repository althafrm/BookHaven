using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<SalesReport> GetDailySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return _reportRepository.GetDailySalesReport(from, to, page, pageSize, out totalRecords);
        }

        public List<SalesReport> GetWeeklySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return _reportRepository.GetWeeklySalesReport(from, to, page, pageSize, out totalRecords);
        }

        public List<SalesReport> GetMonthlySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return _reportRepository.GetMonthlySalesReport(from, to, page, pageSize, out totalRecords);
        }

        public List<InventoryReport> GetInventoryReport(int page, int pageSize, out int totalRecords)
        {
            return _reportRepository.GetInventoryReport(page, pageSize, out totalRecords);
        }
    }
}
