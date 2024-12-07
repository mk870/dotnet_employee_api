using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.User;
using studentApi.Models;

namespace studentApi.Mappers
{
    public static class UsersMapper
    {
        public static UserResponseDto ToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                GivenName = user.GivenName,
                FamilyName = user.FamilyName,
                Email = user.Email,
                Roles = user.Roles
            };
        }
    }
}