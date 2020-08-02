using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized();

            var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);

            var token = await TokenGenerator.Generate(appUser, _userManager, _configuration);

            var roles = await _userManager.GetRolesAsync(appUser);

            return Ok(new { token, appUser.UserName, roles });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role.ToString());

                return Ok("Ok");
            }

            return BadRequest("Username already exists");
        }
    }
}
