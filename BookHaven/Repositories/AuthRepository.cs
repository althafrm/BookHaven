using BookHaven.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public bool AuthenticateUser(string username, string password, out string role, out Guid userId)
        {
            role = null;
            userId = Guid.Empty;
            string hashedPassword = SecurityHelper.HashPassword(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT U.id, R.role_name " +
                                   "FROM Users U " +
                                   "JOIN UserRoles R ON U.role_id = R.id " +
                                   "WHERE U.username = @username AND U.password_hash = @password AND U.is_deleted = 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetGuid(0);
                                role = reader.GetString(1);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return false;
        }
    }
}
