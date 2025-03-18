using BookHaven.Forms.Sales;
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
    public class SupplierOrderRepository : ISupplierOrderRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<SupplierOrder> ListSupplierOrdersPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            List<SupplierOrder> supplierOrders = new List<SupplierOrder>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM SupplierOrders WHERE is_deleted = 0", conn))
                    {
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, supplier_id, total_amount, order_status, order_date " +
                        "FROM SupplierOrders WHERE is_deleted = 0 ORDER BY order_date DESC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", conn))
                    {
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplierOrders.Add(new SupplierOrder
                                {
                                    Id = reader.GetGuid(0),
                                    SupplierId = reader.GetGuid(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    OrderStatus = reader.GetString(3),
                                    OrderDate = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders: " + ex.Message);
            }

            return supplierOrders;
        }

        public SupplierOrder GetSupplierOrderById(Guid supplierOrderId)
        {
            SupplierOrder supplierOrder = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, supplier_id, total_amount, order_status, order_date " +
                        "FROM SupplierOrders WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", supplierOrderId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                supplierOrder = new SupplierOrder
                                {
                                    Id = reader.GetGuid(0),
                                    SupplierId = reader.GetGuid(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    OrderStatus = reader.GetString(3),
                                    OrderDate = reader.GetDateTime(4),
                                    SupplierOrderDetails = new List<SupplierOrderDetail>()
                                };
                            }
                        }
                    }

                    if (supplierOrder != null)
                    {
                        using (SqlCommand detailsCmd = new SqlCommand(
                            "SELECT SOD.id, SOD.supplier_order_id, SOD.book_id, B.title, SOD.quantity, SOD.price " +
                            "FROM SupplierOrderDetails SOD " +
                            "JOIN Books B ON SOD.book_id = B.id " +
                            "WHERE SOD.supplier_order_id = @supplierOrderId AND SOD.is_deleted = 0", conn))
                        {
                            detailsCmd.Parameters.AddWithValue("@supplierOrderId", supplierOrderId);

                            using (SqlDataReader reader = detailsCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    supplierOrder.SupplierOrderDetails.Add(new SupplierOrderDetail
                                    {
                                        Id = reader.GetGuid(0),
                                        SupplierOrderId = reader.GetGuid(1),
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
                throw new Exception("Error retrieving order details: " + ex.Message);
            }

            return supplierOrder;
        }

        public void AddSupplierOrder(SupplierOrder supplierOrder)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO SupplierOrders (id, supplier_id, total_amount, order_status, order_date) " +
                            "VALUES (@id, @supplierId, @totalAmount, @orderStatus, GETDATE())", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", supplierOrder.Id);
                            cmd.Parameters.AddWithValue("@supplierId", supplierOrder.SupplierId);
                            cmd.Parameters.AddWithValue("@totalAmount", supplierOrder.TotalAmount);
                            cmd.Parameters.AddWithValue("@orderStatus", supplierOrder.OrderStatus);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var detail in supplierOrder.SupplierOrderDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO SupplierOrderDetails (id, supplier_order_id, book_id, quantity, price) VALUES (@id, @supplierOrderId, @bookId, " +
                                "@quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@supplierOrderId", supplierOrder.Id);
                                cmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                cmd.Parameters.AddWithValue("@price", detail.Price);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand stockCmd = new SqlCommand(
                                "UPDATE Books SET stock_quantity = stock_quantity + @quantity WHERE id = @bookId", conn, transaction))
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
                        throw new Exception("Error adding order: " + ex.Message);
                    }
                }
            }
        }

        public void UpdateSupplierOrder(SupplierOrder supplierOrder)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        List<SupplierOrderDetail> existingDetails = new List<SupplierOrderDetail>();

                        using (SqlCommand fetchCmd = new SqlCommand("SELECT book_id, quantity FROM SupplierOrderDetails WHERE " +
                            "supplier_order_id = @supplierOrderId", conn, transaction))
                        {
                            fetchCmd.Parameters.AddWithValue("@supplierOrderId", supplierOrder.Id);
                            using (SqlDataReader reader = fetchCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    existingDetails.Add(new SupplierOrderDetail
                                    {
                                        BookId = reader.GetGuid(0),
                                        Quantity = reader.GetInt32(1)
                                    });
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE SupplierOrders SET supplier_id = @supplierId, total_amount = @totalAmount, order_status = @orderStatus, " +
                            "updated_at = GETDATE() WHERE id = @id", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", supplierOrder.Id);
                            cmd.Parameters.AddWithValue("@supplierId", supplierOrder.SupplierId);
                            cmd.Parameters.AddWithValue("@totalAmount", supplierOrder.TotalAmount);
                            cmd.Parameters.AddWithValue("@orderStatus", supplierOrder.OrderStatus);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM SupplierOrderDetails WHERE supplier_order_id = @supplierOrderId", conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@supplierOrderId", supplierOrder.Id);
                            deleteCmd.ExecuteNonQuery();
                        }

                        foreach (var detail in supplierOrder.SupplierOrderDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO SupplierOrderDetails (id, supplier_order_id, book_id, quantity, price) VALUES " +
                                "(@id, @supplierOrderId, @bookId, @quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@supplierOrderId", supplierOrder.Id);
                                cmd.Parameters.AddWithValue("@bookId", detail.BookId);
                                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                cmd.Parameters.AddWithValue("@price", detail.Price);
                                cmd.ExecuteNonQuery();
                            }

                            int previousQuantity = existingDetails.FirstOrDefault(d => d.BookId == detail.BookId)?.Quantity ?? 0;
                            int quantityDifference = detail.Quantity - previousQuantity;

                            using (SqlCommand stockCmd = new SqlCommand(
                                "UPDATE Books SET stock_quantity = stock_quantity + @quantityDifference WHERE id = @bookId", conn, transaction))
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
                        throw new Exception("Error updating order: " + ex.Message);
                    }
                }
            }
        }

        public void DeleteSupplierOrder(Guid supplierOrderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE SupplierOrders SET is_deleted = 1, updated_at = GETDATE() WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", supplierOrderId);
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
