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
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<Order> ListOrdersPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            List<Order> orders = new List<Order>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM Orders WHERE is_deleted = 0", conn))
                    {
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, customer_id, user_id, total_amount, order_status, delivery_address, order_date " +
                        "FROM Orders WHERE is_deleted = 0 ORDER BY order_date DESC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", conn))
                    {
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orders.Add(new Order
                                {
                                    Id = reader.GetGuid(0),
                                    CustomerId = reader.GetGuid(1),
                                    UserId = reader.GetGuid(2),
                                    TotalAmount = reader.GetDecimal(3),
                                    OrderStatus = reader.GetString(4),
                                    DeliveryAddress = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    OrderDate = reader.GetDateTime(6)
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

            return orders;
        }

        public Order GetOrderById(Guid orderId)
        {
            Order order = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, customer_id, user_id, total_amount, order_status, delivery_address, order_date " +
                        "FROM Orders WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                {
                                    Id = reader.GetGuid(0),
                                    CustomerId = reader.GetGuid(1),
                                    UserId = reader.GetGuid(2),
                                    TotalAmount = reader.GetDecimal(3),
                                    OrderStatus = reader.GetString(4),
                                    DeliveryAddress = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    OrderDate = reader.GetDateTime(6),
                                    OrderDetails = new List<OrderDetail>()
                                };
                            }
                        }
                    }

                    if (order != null)
                    {
                        using (SqlCommand detailsCmd = new SqlCommand(
                            "SELECT OD.id, OD.order_id, OD.book_id, B.title, OD.quantity, OD.price " +
                            "FROM OrderDetails OD " +
                            "JOIN Books B ON OD.book_id = B.id " +
                            "WHERE OD.order_id = @orderId AND OD.is_deleted = 0", conn))
                        {
                            detailsCmd.Parameters.AddWithValue("@orderId", orderId);

                            using (SqlDataReader reader = detailsCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    order.OrderDetails.Add(new OrderDetail
                                    {
                                        Id = reader.GetGuid(0),
                                        OrderId = reader.GetGuid(1),
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

            return order;
        }

        public void AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Orders (id, customer_id, user_id, total_amount, order_status, delivery_address, order_date) " +
                            "VALUES (@id, @customerId, @userId, @totalAmount, @orderStatus, @deliveryAddress, GETDATE())", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", order.Id);
                            cmd.Parameters.AddWithValue("@customerId", order.CustomerId);
                            cmd.Parameters.AddWithValue("@userId", order.UserId);
                            cmd.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
                            cmd.Parameters.AddWithValue("@orderStatus", order.OrderStatus);
                            cmd.Parameters.AddWithValue("@deliveryAddress", (object)order.DeliveryAddress ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var detail in order.OrderDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO OrderDetails (id, order_id, book_id, quantity, price) VALUES (@id, @orderId, @bookId, @quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@orderId", order.Id);
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
                        throw new Exception("Error adding order: " + ex.Message);
                    }
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        List<OrderDetail> existingDetails = new List<OrderDetail>();

                        using (SqlCommand fetchCmd = new SqlCommand("SELECT book_id, quantity FROM OrderDetails WHERE order_id = @orderId", conn, transaction))
                        {
                            fetchCmd.Parameters.AddWithValue("@orderId", order.Id);
                            using (SqlDataReader reader = fetchCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    existingDetails.Add(new OrderDetail
                                    {
                                        BookId = reader.GetGuid(0),
                                        Quantity = reader.GetInt32(1)
                                    });
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Orders SET customer_id = @customerId, total_amount = @totalAmount, order_status = @orderStatus, " +
                            "delivery_address = @deliveryAddress, updated_at = GETDATE() WHERE id = @id", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", order.Id);
                            cmd.Parameters.AddWithValue("@customerId", order.CustomerId);
                            cmd.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
                            cmd.Parameters.AddWithValue("@orderStatus", order.OrderStatus);
                            cmd.Parameters.AddWithValue("@deliveryAddress", (object)order.DeliveryAddress ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM OrderDetails WHERE order_id = @orderId", conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@orderId", order.Id);
                            deleteCmd.ExecuteNonQuery();
                        }

                        foreach (var detail in order.OrderDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO OrderDetails (id, order_id, book_id, quantity, price) VALUES (@id, @orderId, @bookId, @quantity, @price)", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@orderId", order.Id);
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
                        throw new Exception("Error updating order: " + ex.Message);
                    }
                }
            }
        }

        public void DeleteOrder(Guid orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Orders SET is_deleted = 1, updated_at = GETDATE() WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
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
