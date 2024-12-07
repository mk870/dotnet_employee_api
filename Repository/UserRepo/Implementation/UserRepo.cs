using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using studentApi.DB;
using studentApi.Models;
using studentApi.Repository.UserRepo.Interface;

namespace studentApi.Repository.UserRepo.Implementation
{
    public class UserRepo(ApplicationDBContext dBContext) : IUserRepo
    {
        private ApplicationDBContext _dbContext = dBContext;
        public async Task<User> CreateUserRepo(User User)
        {
            await _dbContext.Set<User>().AddAsync(User);
            await _dbContext.SaveChangesAsync();
            return User;
        }

        public async Task<bool?> DeleteUserByIdRepo(int id)
        {
            var entity = await _dbContext.Set<User>().FindAsync(id);
            if (entity == null) return null;
            else
            {
                _dbContext.Set<User>().Attach(entity);
                _dbContext.Set<User>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public async Task<List<User>> GetAllUsersRepo()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;
            return user;
        }

        public async Task<User?> GetUserByIdRepo(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;
            else return user;
        }

        public async Task<User> UpdateUserByIdRepo(User user, int id)
        {
            var item = await _dbContext.Set<User>().FindAsync(id);
            _dbContext.Entry(item).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}