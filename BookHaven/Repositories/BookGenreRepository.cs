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
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<BookGenre> GetAllGenres()
        {
            List<BookGenre> genres = new List<BookGenre>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM BookGenres WHERE is_deleted = 0 ORDER BY created_at ASC", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(new BookGenre
                            {
                                Id = reader.GetGuid(0),
                                GenreName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving genres: " + ex.Message);
            }
            return genres;
        }
    }
}
