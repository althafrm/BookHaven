using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooksPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords);
        Book GetBookById(Guid id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}
