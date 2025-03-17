using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Utils
{
    public static class SessionManager
    {
        public static string LoggedInUser { get; set; }
        public static string UserRole { get; set; }
        public static Guid UserId { get; set; }

        public static void Logout()
        {
            LoggedInUser = null;
            UserRole = null;
            UserId = Guid.Empty;
        }
    }
}
