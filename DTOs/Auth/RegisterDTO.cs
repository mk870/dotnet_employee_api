using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        public string GivenName { get; set; } = string.Empty;
        [Required]
        public string FamilyName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6, ErrorMessage = "password must have atleast 6 characters")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = "User";
    }
}