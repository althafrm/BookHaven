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
    }
}
