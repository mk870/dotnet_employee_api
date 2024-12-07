using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.User
{
    public class UserDTO
    {
        
        [Required]
        [MinLength(3, ErrorMessage ="Given name should be 3 characters or more")]
        public string GivenName { get; set; } = string.Empty;
        
        [Required]
        [MinLength(3, ErrorMessage ="Family name should be 3 characters or more")]
        public string FamilyName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Roles { get; set; } = "User";
    }
}