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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM Customers WHERE is_deleted = 0 ORDER BY created_at ASC", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers: " + ex.Message);
            }
            return customers;
        }

        public List<Customer> GetCustomersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            List<Customer> customers = new List<Customer>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Get total record count
                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Customers " +
                        "WHERE is_deleted = 0 AND (name LIKE @search OR email LIKE @search OR phone LIKE @search)", conn))
                    {
                        countCmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    // Fetch paginated customer records
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, name, email, phone, address, created_at, updated_at FROM Customers " +
                        "WHERE is_deleted = 0 AND (name LIKE @search OR email LIKE @search OR phone LIKE @search) " +
                        "ORDER BY created_at ASC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;", conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    Id = reader.GetGuid(0),
                                    Name = reader.GetString(1),
                                    Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Phone = reader.GetString(3),
                                    Address = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    UpdatedAt = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving paginated customers: " + ex.Message);
            }

            return customers;
        }

        public Customer GetCustomerById(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, name, email, phone, address, created_at, updated_at FROM Customers " +
                        "WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Customer
                                {
                                    Id = reader.GetGuid(0),
                                    Name = reader.GetString(1),
                                    Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Phone = reader.GetString(3),
                                    Address = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    UpdatedAt = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer: " + ex.Message);
            }
            return null;
        }

        public void AddCustomer(Customer customer)
        {
            if (IsEmailOrPhoneDuplicate(customer.Email, customer.Phone))
            {
                throw new Exception("A customer with this email or phone number already exists.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Customers (id, name, email, phone, address, is_deleted) " +
                        "VALUES (@id, @name, @email, @phone, @address, 0)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@name", customer.Name);
                        cmd.Parameters.AddWithValue("@email", (object)customer.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@address", (object)customer.Address ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer: " + ex.Message);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (IsEmailOrPhoneDuplicate(customer.Email, customer.Phone, customer.Id))
            {
                throw new Exception("A customer with this email or phone number already exists.");
            }

            try
            {
                customer.UpdatedAt = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Customers SET name=@name, email=@email, phone=@phone, address=@address, updated_at=@updatedAt " +
                        "WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customer.Id);
                        cmd.Parameters.AddWithValue("@name", customer.Name);
                        cmd.Parameters.AddWithValue("@email", (object)customer.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@address", (object)customer.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@updatedAt", customer.UpdatedAt);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer: " + ex.Message);
            }
        }

        public void DeleteCustomer(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Customers SET is_deleted = 1, updated_at = @updatedAt WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message);
            }
        }

        public bool IsEmailOrPhoneDuplicate(string email, string phone, Guid? customerId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Customers WHERE (email = @email OR phone = @phone) AND is_deleted = 0";

                    if (customerId.HasValue)
                    {
                        query += " AND id <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", phone);

                        if (customerId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", customerId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking email or phone duplicate: " + ex.Message);
            }
        }

    }
}
