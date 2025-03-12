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
        private readonly string connectionString = "Data Source=LAPTOP-F4TUI078;Initial Catalog=BookHaven;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool AuthenticateUser(string username, string password, out string role)
        {
            role = null;
            string hashedPassword = SecurityHelper.HashPassword(password);
            Console.WriteLine(hashedPassword);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT role_name " +
                        "FROM Users U " +
                        "JOIN UserRoles R ON U.role_id = R.id " +
                        "WHERE username = @username AND password_hash = @password AND U.is_deleted = 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            role = result.ToString();
                            return true;
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
