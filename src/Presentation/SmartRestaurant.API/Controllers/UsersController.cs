using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        
        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper, IEmailSender emailSender) : base(emailSender)
        {
            _userManager = userManager;
            _mapper = mapper;
           
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var users = _userManager.Users.GetPaged(page,pageSize);
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetById(string username)
        {
            var user = await _userManager.FindByNameAsync(username).ConfigureAwait(false);
            if (user == null)
            {
                return Ok(HttpResponseHelper.Respond(ResponseType.NotFound));
            }

            return Ok(user);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserModel model)
        {
            ApplicationUser user = new ApplicationUser(model.FullName, model.Email, model.UserName);
            var result = await _userManager.CreateAsync(user).ConfigureAwait(false);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
                await SendEmailConfirmation(user, token).ConfigureAwait(false);
            }
            return CheckResultStatus(result);
        }


        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost("createUserWithRoles")]
        public async Task<IActionResult> CreateUserWithRoles(CreateUserWithRolesModel model)
        {
            IdentityResult result;
            ApplicationUser user = new ApplicationUser(model.User.FullName, model.User.Email, model.User.UserName);
            if (string.IsNullOrEmpty(model.Password))
                result = await _userManager.CreateAsync(user).ConfigureAwait(false);
            else
                result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

            foreach (var role in model.Roles) await _userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
                await SendEmailConfirmation(user, token).ConfigureAwait(false);
            }
            return CheckResultStatus(result);
        }

        [HttpPut]
        [Route("users/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, ApplicationUserModel model)
        {
            var user = await _userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(user), id);
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            var result = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            return ApiCustomResponse(result);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return CheckResultStatus(result);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPut("disable")]
        public async Task<IActionResult> Disable(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            user.IsActive = false;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPut("enable")]
        public async Task<IActionResult> Enable(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            user.IsActive = true;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }

        private IActionResult CheckResultStatus(IdentityResult result)
        {
            if (result.Succeeded)
            {
                return Ok(HttpResponseHelper.Respond(ResponseType.OK));
            }

            return Ok(HttpResponseHelper.Respond(ResponseType.InternalServerError));
        }

        
       

    }
}