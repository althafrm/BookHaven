using BookHaven.Models;
using BookHaven.Repositories;
using BookHaven.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetUsersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            return _repository.GetUsersPaginated(pageNumber, pageSize, searchQuery, out totalRecords);
        }

        public User GetUserById(Guid id) => _repository.GetUserById(id);
        public void AddUser(User user) => _repository.AddUser(user);
        public void UpdateUser(User user) => _repository.UpdateUser(user);
        public void DeleteUser(Guid id) => _repository.DeleteUser(id);
        public List<UserRole> GetRoles() => _repository.GetRoles();
    }
}
