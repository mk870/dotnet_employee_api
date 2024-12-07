using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Auth;
using studentApi.DTOs.User;

namespace studentApi.Services.Users.Interface
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersService();
        Task<string?> CreateUserService(RegisterDTO registerDTO);
        Task<UserResponseDto?> GetUserByIdService(int id);
        Task<bool?> DeleteUserByIdService(int id);
        Task<UserResponseDto?> UpdateUserByIdService(UpdateUserDTO updateUser, int id);
    }
}