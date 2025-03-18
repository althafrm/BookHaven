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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM Suppliers WHERE is_deleted = 0 ORDER BY created_at ASC", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
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
            return suppliers;
        }

        public List<Supplier> GetSuppliersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            List<Supplier> suppliers = new List<Supplier>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Suppliers " +
                        "WHERE is_deleted = 0 AND (name LIKE @search OR contact_person LIKE @search OR email LIKE @search OR phone LIKE @search)", conn))
                    {
                        countCmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, name, contact_person, email, phone, address, created_at, updated_at FROM Suppliers " +
                        "WHERE is_deleted = 0 AND (name LIKE @search OR contact_person LIKE @search OR email LIKE @search OR phone LIKE @search) " +
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
                                suppliers.Add(new Supplier
                                {
                                    Id = reader.GetGuid(0),
                                    Name = reader.GetString(1),
                                    ContactPerson = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Phone = reader.GetString(4),
                                    Address = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    CreatedAt = reader.GetDateTime(6),
                                    UpdatedAt = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving paginated suppliers: " + ex.Message);
            }

            return suppliers;
        }

        public Supplier GetSupplierById(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, name, contact_person, email, phone, address, created_at, updated_at FROM Suppliers " +
                        "WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Supplier
                                {
                                    Id = reader.GetGuid(0),
                                    Name = reader.GetString(1),
                                    ContactPerson = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Phone = reader.GetString(4),
                                    Address = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    CreatedAt = reader.GetDateTime(6),
                                    UpdatedAt = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supplier: " + ex.Message);
            }
            return null;
        }

        public void AddSupplier(Supplier supplier)
        {
            if (IsEmailOrPhoneDuplicate(supplier.Email, supplier.Phone))
            {
                throw new Exception("A supplier with this email or phone number already exists.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Suppliers (id, name, contact_person, email, phone, address, is_deleted) " +
                        "VALUES (@id, @name, @contact, @email, @phone, @address, 0)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@name", supplier.Name);
                        cmd.Parameters.AddWithValue("@contact", (object)supplier.ContactPerson ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", (object)supplier.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", supplier.Phone);
                        cmd.Parameters.AddWithValue("@address", (object)supplier.Address ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier: " + ex.Message);
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (IsEmailOrPhoneDuplicate(supplier.Email, supplier.Phone, supplier.Id))
            {
                throw new Exception("A supplier with this email or phone number already exists.");
            }

            try
            {
                supplier.UpdatedAt = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Suppliers SET name=@name, contact_person=@contact, email=@email, phone=@phone, address=@address, updated_at=@updatedAt " +
                        "WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", supplier.Id);
                        cmd.Parameters.AddWithValue("@name", supplier.Name);
                        cmd.Parameters.AddWithValue("@contact", (object)supplier.ContactPerson ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", (object)supplier.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", supplier.Phone);
                        cmd.Parameters.AddWithValue("@address", (object)supplier.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@updatedAt", supplier.UpdatedAt);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message);
            }
        }

        public void DeleteSupplier(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Suppliers SET is_deleted = 1, updated_at = @updatedAt WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message);
            }
        }

        public bool IsEmailOrPhoneDuplicate(string email, string phone, Guid? supplierId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Suppliers WHERE (email = @email OR phone = @phone) AND is_deleted = 0";

                    if (supplierId.HasValue)
                    {
                        query += " AND id <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", phone);

                        if (supplierId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", supplierId.Value);
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
