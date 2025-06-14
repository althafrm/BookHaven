﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface IAuthRepository
    {
        bool AuthenticateUser(string username, string password, out string role, out Guid userId);
    }
}
