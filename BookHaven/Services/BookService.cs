using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetBooksPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            return _repository.GetBooksPaginated(pageNumber, pageSize, searchQuery, out totalRecords);
        }

        public Book GetBookById(Guid id) => _repository.GetBookById(id);
        public void AddBook(Book book) => _repository.AddBook(book);
        public void UpdateBook(Book book) => _repository.UpdateBook(book);
        public void DeleteBook(Guid id) => _repository.DeleteBook(id);
    }
}
