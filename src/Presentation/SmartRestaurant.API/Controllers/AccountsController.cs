using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Accounts.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on user account.")]
    public class AccountsController : ApiController
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, IEmailSender emailSender) : base(emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded) return Unauthorized();
            var user = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            if (!user.IsActive) return Unauthorized();
            var token = await TokenGenerator.Generate(user, _userManager, _configuration);
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new {token, user.Id, user.UserName, roles});
        }

        [AllowAnonymous]
        [HttpPost("register")]
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
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
                await SendEmailConfirmation(user, token).ConfigureAwait(false);
            }

            return await GrantPublicClientsRole(user, result);
        }

        /// <summary> AuthenticateViaSocialMedia() </summary>
        /// <remarks>
        ///     This endpoint is used to authenticate user via social media accounts. 
        ///     if the user account does not exist; it will create a new account with a Diner role for him then a confirmation email will be sent to the user.
        /// </remarks>
        /// <param name="command">This is a payload object used to authenticate user via social media</param>
        /// <response code="200">The user has been successfully authenticated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to authenticate user is invalid.</response>
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost("authenticateViaSocialMedia")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateViaSocialMedia(AuthenticateViaSocialMediaCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (model.CurrentPassword.Equals(model.ConfirmNewPassword))
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return Ok(HttpResponseHelper.Respond(ResponseType.NotFound));
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded) return Ok(HttpResponseHelper.Respond(ResponseType.OK));
                return Ok(HttpResponseHelper.Respond(ResponseType.InternalServerError));
            }

            return Ok(HttpResponseHelper.Respond(ResponseType.BadRequest));
        }


        /// <summary> ForgetPassword() </summary>
        /// <remarks>
        ///     This endpoint is used to send a request to reset user password. After sending the request to reset user password; 
        ///     the user will receive an email  which contains the link that will be used reset his password.
        /// </remarks>
        /// <param name="command">This is payload object used to create reset password request</param>
        /// <response code="204">Reset password email has been successfully sent.</response>
        /// <response code="400">The payload data sent to the backend-server in order send reset password request is invalid.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost("forgetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> ResetUserPassword() </summary>
        /// <remarks> This endpoint is used to reset user password.</remarks>
        /// <param name="id">This is the user Id.</param>
        /// <param name="command">This is the payload object used to reset user password</param>
        /// <response code="204">Resetting user password has been successfully done.</response>
        /// <response code="400">The payload data sent to the backend-server in order to reset user password is invalid.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/reset-password")]
        [HttpPatch]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromRoute] string id, ResetPasswordCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        private async Task<IActionResult> GrantPublicClientsRole(ApplicationUser user, IdentityResult result)
        {
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Diner.ToString()).ConfigureAwait(false);
                await _userManager.AddToRoleAsync(user, Roles.HotelClient.ToString()).ConfigureAwait(false);

                return Ok(HttpResponseHelper.Respond(ResponseType.OK));
            }

            return Ok(HttpResponseHelper.Respond(ResponseType.BadRequest));
        }

        [Route("/api/accounts/confirmEmail/{userId}")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string userId, string token, string fullName)
        {
            return await SendWithErrorsHandlingAsync(new ConfirmEmailCommad() {UserId= userId,Token=token,FullName=fullName });
        }
    }
}