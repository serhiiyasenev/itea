using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private static List<User> _users;

        static UsersController()
        {
            _users = new List<User>();
        }

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            _logger.LogInformation($"Create user with id '{user.Id}'");
            return Created(user.Id.ToString(), user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{guid:Guid}")]
        public IActionResult GetUserById(Guid guid)
        {
            var user = _users.FirstOrDefault(u => u.Id.Equals(guid));
            return user != null ? Ok(user) : NotFound($"NotFound by id: '{guid}'");
        }

        [HttpPut("{guid:Guid}")]
        public IActionResult UpdateUser(Guid guid, User user)
        {
            var dbUser = _users.FirstOrDefault(u => u.Id == guid);

            if (dbUser != null)
            {
                user.Id = guid;
                var index = _users.IndexOf(dbUser);
                _users[index] = user;
                return Ok(user);
            }

            return NotFound($"NotFound by id: '{guid}'");
        }

        [HttpDelete("{guid:Guid}")]
        public IActionResult DeleteUserById(Guid guid)
        {
            var user = _users.FirstOrDefault(u => u.Id == guid);

            if (user != null)
            {
                _users.Remove(user);
                _logger.LogInformation($"Delete user with id '{user.Id}'");
                return Ok(user);
            }

            return NotFound($"NotFound by id: '{guid}'");
        }
    }
}
