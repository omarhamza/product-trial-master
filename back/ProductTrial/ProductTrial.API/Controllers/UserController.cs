using Microsoft.AspNetCore.Mvc;
using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Models;

namespace ProductTrial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<string> Get(string email, string password)
        {
            return await _userService.AuthAsync(email, password);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUser createUser)
        {
            var user = new User
            {
                Firstname = createUser.FirstName,
                Lastname = createUser.LastName,
                Email = createUser.Email,
                Password = createUser.Password
            };
            await _userService.CreateAsync(user);

            return CreatedAtAction(
                nameof(Get),
                new { email = createUser.Email, password = createUser.Email },
                user
            );
        }
    }
}
