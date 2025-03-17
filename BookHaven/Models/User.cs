using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
