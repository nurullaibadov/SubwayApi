using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SubwayApp.Domain.Entities;
using System.Threading.Tasks;

namespace SubwayApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;

        public AuthController(UserManager userManager, SignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterDto model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) return Ok("Kayit basarili");
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized("Kullanici bulunamadi");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
                return Ok(new { Token = "JWT_TOKEN_BURAYA_GELECEK", User = user.FullName });

            return Unauthorized("Sifre hatali");
        }
    }

    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
