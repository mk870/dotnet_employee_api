using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Auth;
using studentApi.Repository.UserRepo.Implementation;
using studentApi.Repository.UserRepo.Interface;

namespace studentApi.Services.Auth
{
    public class LoginService(IUserRepo userRepo, IJwtToken jwtToken) : ILoginService
    {
        private IUserRepo _userRepo = userRepo;
        private IJwtToken _jwtToken = jwtToken;

        public async Task<string?> LoginAsync(LoginDTO loginData)
        {
            var user = await _userRepo.GetUserByEmail(loginData.Email);
            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
            {
                return null;
            }
            var jwt = _jwtToken.CreateJwtToken(user);
            return jwt;
        }
    }
}