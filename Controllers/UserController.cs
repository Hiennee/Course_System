using Course_System.DTOs;
using Course_System.Models;
using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetUsersByName([FromQuery] string name)
        {
            var users = await _userService.GetUsersByName(name);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}/role")]
        public async Task<IActionResult> GetUserRole(string id)
        {
            var role = await _userService.GetUserRole(id);
            if (string.IsNullOrEmpty(role))
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _userService.AddUser(user);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{idToUpdate}")]
        public async Task<IActionResult> UpdateUser(string idToUpdate, [FromBody] User user)
        {
            var result = await _userService.UpdateUser(idToUpdate, user);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
