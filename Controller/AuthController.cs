using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using studentApi.DTOs.Auth;
using studentApi.Models;
using studentApi.Services.Auth;
using studentApi.Services.Users.Interface;

namespace studentApi.Controller
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController(IUserService userService, ILoginService loginService) : ControllerBase
    {
        private IUserService _userService = userService;
        private ILoginService _loginService = loginService;

        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.CreateUserService(registerDTO);
            if (result == null)
            {
                return StatusCode(500, "this user already exists");
            }
            return result;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Register(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _loginService.LoginAsync(loginDTO);
            if (result == null) return StatusCode(401, "Wrong credentials");
            return result;
        }
    }
}