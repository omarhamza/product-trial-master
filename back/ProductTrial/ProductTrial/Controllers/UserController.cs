using Microsoft.AspNetCore.Mvc;
using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;

namespace ProductTrial.Controllers
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
        public async Task<ActionResult<User>> Add(User user)
        {
            var createdUser = await _userService.CreateAsync(user);

            return CreatedAtAction(
                $"UserId_{createdUser.Id}",
                new { id = createdUser.Id },
                createdUser
            );
        }
    }
}
