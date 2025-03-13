using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Utils
{
    public static class DatabaseHelper
    {
        public static readonly string connectionString = "Data Source=LAPTOP-F4TUI078;Initial Catalog=BookHaven;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
