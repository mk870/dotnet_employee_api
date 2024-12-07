using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using studentApi.DTOs.Auth;
using studentApi.DTOs.User;
using studentApi.Mappers;
using studentApi.Models;
using studentApi.Repository.UserRepo.Interface;
using studentApi.Services.Auth;
using studentApi.Services.Users.Interface;

namespace studentApi.Services.Users.Implemantetion
{
    public class UserService(IUserRepo userRepo, IJwtToken jwtToken) : IUserService
    {
        private IUserRepo _userRepo = userRepo;
        private IJwtToken _jwtToken = jwtToken;
        public async Task<string?> CreateUserService(RegisterDTO registerDTO)
        {
            var user = _userRepo.GetUserByEmail(registerDTO.Email);
            if (user != null)
            {
                return null;
            }
            var userModel = new User
            {
                GivenName = registerDTO.GivenName,
                FamilyName = registerDTO.FamilyName,
                Email = registerDTO.Email,
                Roles = registerDTO.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
            };
            var jwt = _jwtToken.CreateJwtToken(userModel);
            _ = await _userRepo.CreateUserRepo(userModel);
            return jwt;
        }

        public async Task<bool?> DeleteUserByIdService(int id)
        {
            var isUserDeleted = await _userRepo.DeleteUserByIdRepo(id);
            if (isUserDeleted == null) return null;
            return isUserDeleted;
        }

        public async Task<List<UserResponseDto>> GetAllUsersService()
        {
            var users = await _userRepo.GetAllUsersRepo();
            var convertedList = users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                GivenName = user.GivenName,
                FamilyName = user.FamilyName,
                Email = user.Email,
                Roles = user.Roles
            }).ToList();

            return convertedList;
        }

        public async Task<UserResponseDto?> GetUserByIdService(int id)
        {
            var user = await _userRepo.GetUserByIdRepo(id);
            if (user == null) return null;
            return user.ToUserResponseDto();
        }

        public async Task<UserResponseDto?> UpdateUserByIdService(UpdateUserDTO updateUser, int id)
        {
            var user = await _userRepo.GetUserByIdRepo(id);
            if (user == null) return null;
            var updatedUser = await _userRepo.UpdateUserByIdRepo(
            new User
            {
                Id = updateUser.Id,
                GivenName = updateUser.GivenName,
                FamilyName = updateUser.FamilyName,
                Password = user.Password,
            }, id
            );
            return updatedUser.ToUserResponseDto();
        }
    }
}