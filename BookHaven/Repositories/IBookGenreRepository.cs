using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface IBookGenreRepository
    {
        List<BookGenre> GetAllGenres();
        List<BookGenre> GetGenresPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords);
        BookGenre GetGenreById(Guid id);
        void AddGenre(BookGenre genre);
        void UpdateGenre(BookGenre genre);
        void DeleteGenre(Guid id);
    }
}
