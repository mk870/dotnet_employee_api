using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.User
{
    public class UserResponseDto : UserDTO
    {
        [Required]
        public int Id { get; set; }
    }
}