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
    public class SalesRepository : ISalesRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<Sale> ListSalesPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            List<Sale> sales = new List<Sale>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM Sales WHERE is_deleted = 0", conn))
                    {
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, user_id, total_amount, discount, sale_date " +
                        "FROM Sales WHERE is_deleted = 0 ORDER BY sale_date DESC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", conn))
                    {
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sales.Add(new Sale
                                {
                                    Id = reader.GetGuid(0),
                                    UserId = reader.GetGuid(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    Discount = reader.GetDecimal(3),
                                    SaleDate = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sales: " + ex.Message);
            }

            return sales;
        }

        public Sale GetSaleById(Guid saleId)
        {
            Sale sale = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, user_id, total_amount, discount, sale_date FROM Sales WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", saleId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sale = new Sale
                                {
                                    Id = reader.GetGuid(0),
                                    UserId = reader.GetGuid(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    Discount = reader.GetDecimal(3),
                                    SaleDate = reader.GetDateTime(4),
                                    SaleDetails = new List<SaleDetail>()
                                };
                            }
                        }
                    }

                    if (sale != null)
                    {
                        using (SqlCommand detailsCmd = new SqlCommand(
                            "SELECT SD.id, SD.sale_id, SD.book_id, B.title, SD.quantity, SD.price " +
                            "FROM SalesDetails SD " +
                            "JOIN Books B ON SD.book_id = B.id " +
                            "WHERE SD.sale_id = @saleId AND SD.is_deleted = 0", conn))
                        {
                            detailsCmd.Parameters.AddWithValue("@saleId", saleId);

                            using (SqlDataReader reader = detailsCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    sale.SaleDetails.Add(new SaleDetail
                                    {
                                        Id = reader.GetGuid(0),
                                        SaleId = reader.GetGuid(1),
                                        BookId = reader.GetGuid(2),
                                        BookTitle = reader.GetString(3),
                                        Quantity = reader.GetInt32(4),
                                        Price = reader.GetDecimal(5)
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sale details: " + ex.Message);
            }

            return sale;
        }

        public void AddSale(Sale sale)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Sales (id, user_id, total_amount, discount, sale_date) VALUES (@id, @userId, @totalAmount, @discount, GETDATE())", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", sale.Id);
                            cmd.Parameters.AddWithValue("@userId", sale.UserId);
                            cmd.Parameters.AddWithValue("@totalAmount", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@discount", sale.Discount);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var detail in sale.SaleDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO SalesDetails (id, sale_id, book_id, quantity, price) VALUES (@id, @saleId, @bookId, @quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@saleId", sale.Id);
                                cmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                cmd.Parameters.AddWithValue("@price", detail.Price);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand stockCmd = new SqlCommand(
                                "UPDATE Books SET stock_quantity = stock_quantity - @quantity WHERE id = @bookId", conn, transaction))
                            {
                                stockCmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                stockCmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                stockCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error adding sale: " + ex.Message);
                    }
                }
            }
        }

        public void UpdateSale(Sale sale)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        List<SaleDetail> existingDetails = new List<SaleDetail>();

                        using (SqlCommand fetchCmd = new SqlCommand("SELECT book_id, quantity FROM SalesDetails WHERE sale_id = @saleId", conn, transaction))
                        {
                            fetchCmd.Parameters.AddWithValue("@saleId", sale.Id);
                            using (SqlDataReader reader = fetchCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    existingDetails.Add(new SaleDetail
                                    {
                                        BookId = reader.GetGuid(0),
                                        Quantity = reader.GetInt32(1)
                                    });
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Sales SET total_amount = @totalAmount, discount = @discount, updated_at = GETDATE() WHERE id = @id", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", sale.Id);
                            cmd.Parameters.AddWithValue("@totalAmount", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@discount", sale.Discount);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM SalesDetails WHERE sale_id = @saleId", conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@saleId", sale.Id);
                            deleteCmd.ExecuteNonQuery();
                        }

                        foreach (var detail in sale.SaleDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO SalesDetails (id, sale_id, book_id, quantity, price) VALUES (@id, @saleId, @bookId, @quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@saleId", sale.Id);
                                cmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                cmd.Parameters.AddWithValue("@price", detail.Price);
                                cmd.ExecuteNonQuery();
                            }

                            int previousQuantity = existingDetails.FirstOrDefault(d => d.BookId == detail.BookId)?.Quantity ?? 0;
                            int quantityDifference = detail.Quantity - previousQuantity;

                            using (SqlCommand stockCmd = new SqlCommand(
                                "UPDATE Books SET stock_quantity = stock_quantity - @quantityDifference WHERE id = @bookId", conn, transaction))
                            {
                                stockCmd.Parameters.AddWithValue("@quantityDifference", quantityDifference);
                                stockCmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                stockCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error updating sale: " + ex.Message);
                    }
                }
            }
        }

        public void DeleteSale(Guid saleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Sales SET is_deleted = 1, updated_at = GETDATE() WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", saleId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting sale: " + ex.Message);
            }
        }
    }
}
