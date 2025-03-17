using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public interface IUserService
    {
        List<User> GetUsersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords);
        User GetUserById(Guid id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
        List<UserRole> GetRoles();
    }
}
