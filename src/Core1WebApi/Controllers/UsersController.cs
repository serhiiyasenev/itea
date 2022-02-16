using CoreBAL.Models;
using CoreBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
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
        public IActionResult AddUser(User user)
        {
            if (user != null)
            {
                var createdGuid = _userService.AddUser(user);
                return Created(createdGuid.ToString(), user);
            }

            return BadRequest();

        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService);
        }

        //[HttpGet("{guid:Guid}")]
        //public IActionResult GetUserById(Guid guid)
        //{
        //    var user = _users.FirstOrDefault(u => u.Id.Equals(guid));
        //    return user != null ? Ok(user) : NotFound($"NotFound by id: '{guid}'");
        //}

        //[HttpPut("{guid:Guid}")]
        //public IActionResult UpdateUser(Guid guid, User user)
        //{
        //    var dbUser = _userService.FirstOrDefault(u => u.Id == guid);

        //    if (dbUser != null)
        //    {
        //        user.Id = guid;
        //        var index = _users.IndexOf(dbUser);
        //        _users[index] = user;
        //        return Ok(user);
        //    }

        //    return NotFound($"NotFound by id: '{guid}'");
        //}

        //[HttpDelete("{guid:Guid}")]
        //public IActionResult DeleteUser(Guid guid)
        //{
        //    var user = _userService.FirstOrDefault(u => u.Id == guid);

        //    if (user != null)
        //    {
        //        _users.Remove(user);
        //        _logger.LogInformation($"Delete user with id '{user.Id}'");
        //        return Ok(user);
        //    }

        //    return NotFound($"NotFound by id: '{guid}'");
        //}
    }
}
