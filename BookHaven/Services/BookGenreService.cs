using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IBookGenreRepository _repository;

        public BookGenreService(IBookGenreRepository repository)
        {
            _repository = repository;
        }

        public List<BookGenre> GetGenres() => _repository.GetAllGenres();

        public List<BookGenre> GetGenresPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            return _repository.GetGenresPaginated(pageNumber, pageSize, searchQuery, out totalRecords);
        }

        public BookGenre GetGenreById(Guid id) => _repository.GetGenreById(id);
        public void AddGenre(BookGenre genre) => _repository.AddGenre(genre);
        public void UpdateGenre(BookGenre genre) => _repository.UpdateGenre(genre);
        public void DeleteGenre(Guid id) => _repository.DeleteGenre(id);
    }
}
