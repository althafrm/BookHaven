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
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public DashboardMetrics GetDashboardMetrics()
        {
            var metrics = new DashboardMetrics { StaffPerformance = new Dictionary<string, int>() };

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        (SELECT COALESCE(SUM(total_amount), 0) FROM Sales WHERE is_deleted = 0) + 
                        (SELECT COALESCE(SUM(total_amount), 0) FROM Orders WHERE order_status = 'Completed' AND is_deleted = 0) AS TotalSales,
                        (SELECT COUNT(*) FROM Sales WHERE is_deleted = 0) + 
                        (SELECT COUNT(*) FROM Orders WHERE order_status = 'Completed' AND is_deleted = 0) AS TotalOrders,
                        (SELECT COUNT(*) FROM Customers WHERE is_deleted = 0) AS TotalCustomers,
                        (SELECT COUNT(DISTINCT customer_id) FROM Orders WHERE order_date >= DATEADD(DAY, -30, GETDATE()) AND is_deleted = 0) AS ActiveCustomers,
                        (SELECT COUNT(*) FROM Books WHERE stock_quantity < 5 AND is_deleted = 0) AS LowStockBooks";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        metrics.TotalSales = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        metrics.TotalOrders = reader.GetInt32(1);
                        metrics.TotalCustomers = reader.GetInt32(2);
                        metrics.ActiveCustomers = reader.GetInt32(3);
                        metrics.LowStockBooks = reader.GetInt32(4);
                    }
                }

                string staffQuery = @"
                    SELECT u.username, 
                           COALESCE(sales_count, 0) + COALESCE(order_count, 0) AS SalesHandled
                    FROM Users u
                    LEFT JOIN (
                        SELECT user_id, COUNT(id) AS sales_count
                        FROM Sales
                        WHERE is_deleted = 0
                        GROUP BY user_id
                    ) s ON u.id = s.user_id
                    LEFT JOIN (
                        SELECT user_id, COUNT(id) AS order_count
                        FROM Orders
                        WHERE order_status = 'Completed' AND is_deleted = 0
                        GROUP BY user_id
                    ) o ON u.id = o.user_id
                    ORDER BY SalesHandled DESC";

                using (SqlCommand cmd = new SqlCommand(staffQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        metrics.StaffPerformance[reader.GetString(0)] = reader.GetInt32(1);
                    }
                }
            }

            return metrics;
        }
    }
}
