using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.Models;

namespace studentApi.Repository.UserRepo.Interface
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsersRepo();
        Task<User> CreateUserRepo(User User);
        Task<User?> GetUserByIdRepo(int id);
        Task<User?> GetUserByEmail(string email);
        Task<bool?> DeleteUserByIdRepo(int id);
        Task<User> UpdateUserByIdRepo(User user, int id);
    }
}