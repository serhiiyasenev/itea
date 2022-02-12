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

            return Created(user.Id.ToString(), user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet]
        public IActionResult GetUserById(Guid guid)
        {
            var user = _users.FirstOrDefault(u => u.Id.Equals(guid));
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var dbUser = _users.FirstOrDefault(u => u.Id.Equals(user.Id));

            if (dbUser != null)
            {
                var index = _users.IndexOf(dbUser);
                _users[index] = user;
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteUserById(Guid guid)
        {
            var user = _users.FirstOrDefault(u => u.Id.Equals(guid));

            if (user != null)
            {
                _users.Remove(user);
                return Ok(user);
            }

            return NotFound();
        }
    }
}
