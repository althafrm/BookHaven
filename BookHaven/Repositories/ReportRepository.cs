using BookHaven.Models;
using BookHaven.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<SalesReport> GetDailySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return GetSalesReport("FORMAT(s.sale_date, 'yyyy-MM-dd')", from, to, page, pageSize, out totalRecords);
        }

        public List<SalesReport> GetWeeklySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return GetSalesReport("FORMAT(DATEADD(DAY, -DATEPART(WEEKDAY, s.sale_date) + 1, s.sale_date), 'yyyy-MM-dd')", from, to, page, pageSize, out totalRecords);
        }

        public List<SalesReport> GetMonthlySalesReport(DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            return GetSalesReport("FORMAT(s.sale_date, 'yyyy-MM')", from, to, page, pageSize, out totalRecords);
        }

        private List<SalesReport> GetSalesReport(string groupBy, DateTime from, DateTime to, int page, int pageSize, out int totalRecords)
        {
            var reports = new List<SalesReport>();
            totalRecords = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string countQuery = $@"
                    SELECT COUNT(DISTINCT {groupBy})
                    FROM Sales s
                    WHERE s.sale_date BETWEEN @From AND @To AND s.is_deleted = 0";

                using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@From", from);
                    countCmd.Parameters.AddWithValue("@To", to);
                    totalRecords = (int)countCmd.ExecuteScalar();
                }

                string query = $@"
            WITH SalesData AS (
                SELECT 
                    {groupBy} AS ReportDate,
                    b.title AS BookTitle,
                    SUM(sd.quantity) AS QuantitySold,
                    SUM(sd.price) AS TotalRevenue
                FROM Sales s
                JOIN SalesDetails sd ON s.id = sd.sale_id
                JOIN Books b ON sd.book_id = b.id
                WHERE s.sale_date BETWEEN @From AND @To AND s.is_deleted = 0
                GROUP BY {groupBy}, b.title
            )
            SELECT * FROM SalesData
            ORDER BY ReportDate DESC, QuantitySold DESC
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from);
                    cmd.Parameters.AddWithValue("@To", to);
                    cmd.Parameters.AddWithValue("@Offset", (page - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reports.Add(new SalesReport
                            {
                                ReportDate = DateTime.Parse(reader.GetString(0)),
                                BookTitle = reader.GetString(1),
                                QuantitySold = reader.GetInt32(2),
                                TotalRevenue = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            return reports;
        }

        public List<InventoryReport> GetInventoryReport(int page, int pageSize, out int totalRecords)
        {
            try
            {
                var reports = new List<InventoryReport>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string countQuery = "SELECT COUNT(*) FROM Books WHERE is_deleted = 0";
                    using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                    {
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    string query = @"
                SELECT title, stock_quantity
                FROM Books
                WHERE is_deleted = 0
                ORDER BY 
                    CASE 
                        WHEN stock_quantity = 0 THEN 0 
                        ELSE 1 
                    END, 
                    stock_quantity ASC
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Offset", (page - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reports.Add(new InventoryReport
                                {
                                    BookTitle = reader.GetString(0),
                                    StockQuantity = reader.GetInt32(1)
                                });
                            }
                        }
                    }
                }
                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching inventory report.", ex);
            }
        }
    }
}
