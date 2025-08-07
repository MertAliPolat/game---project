using Microsoft.AspNetCore.Mvc;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;

namespace MiddleEarthTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto);

            if (user == null)
                return Unauthorized(new { success = false, message = "Kullanıcı adı veya şifre hatalı." });

            return Ok(new
            {
                success = true,
                message = "Giriş başarılı.",
                id = user.Id,
                username = user.Username 
            });
        }

        [HttpGet("profile/{userId}")]
        public async Task<ActionResult<ProfileDto>> GetProfile(Guid userId)
        {
            var profile = await _userService.GetProfileAsync(userId);
            if (profile == null)
                return NotFound("User not found");

            return Ok(profile);
        }
    }
}
