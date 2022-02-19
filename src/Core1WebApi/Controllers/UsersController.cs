using CoreBL;
using CoreBL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Core1WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserService _userService;

        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user != null)
            {
                var createdUser = await _userService.AddUser(user);
                _logger.LogInformation($"User was created with id: '{createdUser.Id}'");
                return Created(createdUser.Id.ToString(), createdUser);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound($"NotFound by id: '{id}'");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(Guid id, User user)
        {
            var updatedUser = await _userService.UpdateUserById(id, user);

            if (updatedUser != null)
            {
                return Ok(updatedUser);
            }

            return NotFound($"NotFound by id: '{id}'");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.RemoveUserById(id);

            if (result > 0)
            {
                return Ok(id);
            }

            return NotFound($"NotFound by id: '{id}'");
        }
    }
}
