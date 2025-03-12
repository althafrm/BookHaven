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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string username, string password)
        {
            if (_userRepository.AuthenticateUser(username, password, out string role))
            {
                SessionManager.LoggedInUser = username;
                SessionManager.UserRole = role;
                return true;
            }
            return false;
        }
    }
}
