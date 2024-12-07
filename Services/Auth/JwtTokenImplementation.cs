using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using studentApi.Models;

namespace studentApi.Services.Auth
{
    public class JwtTokenImplementation(IConfiguration configuration) : IJwtToken
    {
        private readonly IConfiguration _configuration = configuration;

        public string CreateJwtToken(User user)
        {
            List<Claim> claims =
        [
            new (type:"Sub",value:user.Id.ToString()),
            new(ClaimTypes.Name, user.GivenName!),
            new(ClaimTypes.Role, user.Roles),
        ];
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value!)
            );
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }

}