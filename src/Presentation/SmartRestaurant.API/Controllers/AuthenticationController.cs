using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Domain.Exceptions;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.ViewModels;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUserCommand command)
        {
            var user = await Mediator.Send(command);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            string tokenString = TokenGenerator.Generate(user, _appSettings.Secret);

            UserModel userModel = _mapper.Map<UserModel>(user);
            userModel.Token = tokenString;

            return Ok(userModel);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            try
            {
                await Mediator.Send(command);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}