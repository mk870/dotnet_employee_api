using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using studentApi.DTOs.User;
using studentApi.Services.Users.Interface;

namespace studentApi.Controller
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService):ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<UserResponseDto>> Users()
        {
            return Ok(await _userService.GetAllUsersService());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdService(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(
            UpdateUserDTO updateUserDTO, int id
        )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _userService.UpdateUserByIdService(updateUserDTO, id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var isUserDeleted = await _userService.DeleteUserByIdService(id);
            if (isUserDeleted == null) return NotFound();
            return NoContent();
        }
    }
}