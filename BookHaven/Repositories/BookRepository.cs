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
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;

        public List<Book> GetBooksPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            List<Book> books = new List<Book>();
            totalRecords = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Books B " +
                        "JOIN BookGenres G ON B.genre_id = G.id " +
                        "WHERE B.is_deleted = 0 AND (B.title LIKE @search OR B.author LIKE @search OR B.isbn LIKE @search OR G.genre_name LIKE @search)", conn))
                    {
                        countCmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        totalRecords = (int)countCmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT B.id, B.genre_id, G.genre_name, B.title, B.author, B.isbn, B.price, B.stock_quantity, B.created_at, B.updated_at " +
                        "FROM Books B " +
                        "JOIN BookGenres G ON B.genre_id = G.id " +
                        "WHERE B.is_deleted = 0 AND (B.title LIKE @search OR B.author LIKE @search OR B.isbn LIKE @search OR G.genre_name LIKE @search) " +
                        "ORDER BY B.created_at ASC " +
                        "OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;", conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchQuery}%");
                        cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                books.Add(new Book
                                {
                                    Id = reader.GetGuid(0),
                                    GenreId = reader.GetGuid(1),
                                    GenreName = reader.GetString(2),
                                    Title = reader.GetString(3),
                                    Author = reader.GetString(4),
                                    Isbn = reader.GetString(5),
                                    Price = reader.GetDecimal(6),
                                    StockQuantity = reader.GetInt32(7),
                                    CreatedAt = reader.GetDateTime(8),
                                    UpdatedAt = reader.GetDateTime(9)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving paginated books: " + ex.Message);
            }

            return books;
        }

        public Book GetBookById(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE id = @id AND is_deleted = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Book
                                {
                                    Id = reader.GetGuid(0),
                                    GenreId = reader.GetGuid(1),
                                    Title = reader.GetString(2),
                                    Author = reader.GetString(3),
                                    Isbn = reader.GetString(4),
                                    Price = reader.GetDecimal(5),
                                    StockQuantity = reader.GetInt32(6),
                                    CreatedAt = reader.GetDateTime(7),
                                    UpdatedAt = reader.GetDateTime(8)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving book: " + ex.Message);
            }
            return null;
        }

        public void AddBook(Book book)
        {
            if (IsIsbnDuplicate(book.Isbn))
            {
                throw new Exception("A book with this ISBN already exists.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Books (id, genre_id, title, author, isbn, price, " +
                        "stock_quantity, is_deleted) VALUES (@id, @genreId, @title, @author, @isbn, @price, @stock, 0)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@genreId", book.GenreId);
                        cmd.Parameters.AddWithValue("@title", book.Title);
                        cmd.Parameters.AddWithValue("@author", book.Author);
                        cmd.Parameters.AddWithValue("@isbn", book.Isbn);
                        cmd.Parameters.AddWithValue("@price", book.Price);
                        cmd.Parameters.AddWithValue("@stock", book.StockQuantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book: " + ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            if (IsIsbnDuplicate(book.Isbn, book.Id))
            {
                throw new Exception("A book with this ISBN already exists.");
            }

            try
            {
                book.UpdatedAt = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Books SET genre_id=@genreId, title=@title, author=@author, isbn=@isbn, price=@price, " +
                        "stock_quantity=@stock, updated_at=@updatedAt WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", book.Id);
                        cmd.Parameters.AddWithValue("@genreId", book.GenreId);
                        cmd.Parameters.AddWithValue("@title", book.Title);
                        cmd.Parameters.AddWithValue("@author", book.Author);
                        cmd.Parameters.AddWithValue("@isbn", book.Isbn);
                        cmd.Parameters.AddWithValue("@price", book.Price);
                        cmd.Parameters.AddWithValue("@stock", book.StockQuantity);
                        cmd.Parameters.AddWithValue("@updatedAt", book.UpdatedAt);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book: " + ex.Message);
            }
        }

        public void DeleteBook(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Books SET is_deleted = 1, updated_at = @updatedAt WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book: " + ex.Message);
            }
        }

        public bool IsIsbnDuplicate(string isbn, Guid? bookId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Books WHERE isbn = @isbn AND is_deleted = 0";

                    if (bookId.HasValue)
                    {
                        query += " AND id <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@isbn", isbn);

                        if (bookId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", bookId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking ISBN duplicate: " + ex.Message);
            }
        }
    }
}
