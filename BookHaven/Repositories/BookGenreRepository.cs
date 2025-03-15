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

        public List<BookGenre> GetGenresPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            List<BookGenre> genres = new List<BookGenre>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM BookGenres " +
                        "WHERE is_deleted = 0 AND genre_name LIKE @search", conn))
                    {
                        countCmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, genre_name, created_at, updated_at FROM BookGenres " +
                        "WHERE is_deleted = 0 AND genre_name LIKE @search " +
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
                                genres.Add(new BookGenre
                                {
                                    Id = reader.GetGuid(0),
                                    GenreName = reader.GetString(1),
                                    CreatedAt = reader.GetDateTime(2),
                                    //UpdatedAt = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                                    UpdatedAt = reader.GetDateTime(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving paginated book genres: " + ex.Message);
            }

            return genres;
        }

        public BookGenre GetGenreById(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT id, genre_name, created_at, updated_at FROM BookGenres " +
                        "WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new BookGenre
                                {
                                    Id = reader.GetGuid(0),
                                    GenreName = reader.GetString(1),
                                    CreatedAt = reader.GetDateTime(2),
                                    //UpdatedAt = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                                    UpdatedAt = reader.GetDateTime(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving book genre: " + ex.Message);
            }
            return null;
        }

        public void AddGenre(BookGenre genre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO BookGenres (id, genre_name, is_deleted) VALUES (@id, @genreName, 0)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@genreName", genre.GenreName);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book genre: " + ex.Message);
            }
        }

        public void UpdateGenre(BookGenre genre)
        {
            try
            {
                genre.UpdatedAt = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE BookGenres SET genre_name=@genreName, updated_at=@updatedAt WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", genre.Id);
                        cmd.Parameters.AddWithValue("@genreName", genre.GenreName);
                        cmd.Parameters.AddWithValue("@updatedAt", genre.UpdatedAt);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book genre: " + ex.Message);
            }
        }

        public void DeleteGenre(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE BookGenres SET is_deleted = 1, updated_at = @updatedAt WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book genre: " + ex.Message);
            }
        }
    }
}
