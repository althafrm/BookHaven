using BookHaven.Repositories;
using BookHaven.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public bool Login(string username, string password)
        {
            if (_authRepository.AuthenticateUser(username, password, out string role, out Guid userId))
            {
                SessionManager.LoggedInUser = username;
                SessionManager.UserRole = role;
                SessionManager.UserId = userId;
                return true;
            }
            return false;
        }
    }
}
