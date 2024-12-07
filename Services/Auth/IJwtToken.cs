using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.Models;

namespace studentApi.Services.Auth
{
    public interface IJwtToken
    {
        public string CreateJwtToken(User user);
    }
}