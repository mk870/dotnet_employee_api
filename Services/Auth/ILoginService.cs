using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Auth;

namespace studentApi.Services.Auth
{
    public interface ILoginService
    {
        public Task<string?> LoginAsync(LoginDTO loginData);
    }
}