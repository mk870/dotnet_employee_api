using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roles { get; set; } = "User";
    }
}