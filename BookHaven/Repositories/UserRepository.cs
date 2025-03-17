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
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<User> GetUsersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            List<User> users = new List<User>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE is_deleted = 0 AND username LIKE @search", conn))
                    {
                        countCmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT U.id, U.role_id, R.role_name, U.username, U.created_at, U.updated_at " +
                        "FROM Users U JOIN UserRoles R ON U.role_id = R.id " +
                        "WHERE U.is_deleted = 0 AND U.username LIKE @search " +
                        "ORDER BY U.created_at ASC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;", conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    Id = reader.GetGuid(0),
                                    RoleId = reader.GetGuid(1),
                                    RoleName = reader.GetString(2),
                                    Username = reader.GetString(3),
                                    CreatedAt = reader.GetDateTime(4),
                                    UpdatedAt = reader.GetDateTime(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving paginated users: " + ex.Message);
            }

            return users;
        }

        public User GetUserById(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT U.id, U.role_id, R.role_name, U.username, U.created_at, U.updated_at " +
                        "FROM Users U JOIN UserRoles R ON U.role_id = R.id " +
                        "WHERE U.id = @id AND U.is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = reader.GetGuid(0),
                                    RoleId = reader.GetGuid(1),
                                    RoleName = reader.GetString(2),
                                    Username = reader.GetString(3),
                                    CreatedAt = reader.GetDateTime(4),
                                    UpdatedAt = reader.GetDateTime(5)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user: " + ex.Message);
            }
            return null;
        }

        public void AddUser(User user)
        {
            if (IsUsernameDuplicate(user.Username))
            {
                throw new Exception("A user with this username already exists.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Users (id, role_id, username, password_hash, is_deleted, created_at, updated_at) " +
                        "VALUES (@id, @roleId, @username, @passwordHash, 0, GETDATE(), GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        cmd.Parameters.AddWithValue("@roleId", user.RoleId);
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user: " + ex.Message);
            }
        }

        public void UpdateUser(User user)
        {
            if (IsUsernameDuplicate(user.Username, user.Id))
            {
                throw new Exception("A user with this username already exists.");
            }

            try
            {
                user.UpdatedAt = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string updateQuery = "UPDATE Users SET role_id=@roleId, username=@username, updated_at=@updatedAt";

                    if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                    {
                        updateQuery += ", password_hash=@passwordHash";
                    }

                    updateQuery += " WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        cmd.Parameters.AddWithValue("@roleId", user.RoleId);
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@updatedAt", user.UpdatedAt);

                        if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                        {
                            cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Users SET is_deleted = 1, updated_at = @updatedAt WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }

        public List<UserRole> GetRoles()
        {
            List<UserRole> roles = new List<UserRole>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id, role_name FROM UserRoles", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new UserRole
                            {
                                Id = reader.GetGuid(0),
                                RoleName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving roles: " + ex.Message);
            }
            return roles;
        }

        private bool IsUsernameDuplicate(string username, Guid? userId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND is_deleted = 0";
                    if (userId.HasValue)
                    {
                        query += " AND id <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        if (userId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", userId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking username duplicate: " + ex.Message);
            }
        }
    }
}
