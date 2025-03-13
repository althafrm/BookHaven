using BookHaven.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = DatabaseHelper.connectionString;
    }
}
