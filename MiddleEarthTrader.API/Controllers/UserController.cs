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
            var result = await _userService.LoginAsync(loginDto);

            if (!result)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");

            return Ok("Giriş başarılı.");
        }
    }
}
