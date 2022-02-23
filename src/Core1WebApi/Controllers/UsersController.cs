using CoreBL;
using CoreBL.Models;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Add user endpoint
        /// </summary>
        /// <remarks>
        /// The endpoint returns newly created user with Guid
        /// </remarks>
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

        /// <summary>
        /// Get all users endpoint
        /// </summary>
        /// <remarks>
        /// The endpoint returns all users from a storage
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        /// <summary>
        /// Get user by id endpoint
        /// </summary>
        /// <remarks>
        /// The endpoint returns pointed user from a storage
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound($"NotFound by id: '{id}'");
        }

        /// <summary>
        /// Update user by id endpoint
        /// </summary>
        /// <remarks>
        /// The endpoint returns newly updated user
        /// </remarks>
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

        /// <summary>
        /// Delete user by id endpoint
        /// </summary>
        /// <remarks>
        /// The endpoint returns pointed Guid
        /// </remarks>
        [Authorize (Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.RemoveUserById(id);

            if (result > 0)
            {
                return Ok($"User with id '{id}' was deleted");
            }

            return NotFound($"NotFound by id: '{id}'");
        }
    }
}
