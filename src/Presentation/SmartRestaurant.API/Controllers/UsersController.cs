using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper, IMemoryCache cache,
            IEmailSender emailSender) : base(emailSender)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var result = _userManager.Users.GetPaged(page, pageSize);
            var pagedResult = await GetPagedListOfUsers(result).ConfigureAwait(false);

            return Ok(pagedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByRole(string role, int page, int pageSize)
        {
            var result = await _userManager.GetUsersInRoleAsync(role).ConfigureAwait(false);
            return Ok(result);
        }

        private async Task<PagedListDto<UserWithRolesModel>> GetPagedListOfUsers(
            PagedResultBase<ApplicationUser> result)
        {
            var userModels = new List<UserWithRolesModel>();
            foreach (var user in result.Data)
            {
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                userModels.Add(new UserWithRolesModel(user, roles.ToArray()));
            }

            var pagedResult = new PagedListDto<UserWithRolesModel>(result.CurrentPage, result.PageCount,
                result.PageSize,
                result.RowCount, userModels);
            return pagedResult;
        }

        [Route("/api/users/{foodBusinessId:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        [HttpGet]
        public async Task<IActionResult> GetStaff([FromRoute] Guid foodBusinessId, int page, int pageSize)
        {
            if (foodBusinessId == Guid.Empty)
                return BadRequest("FoodBusiness id shouldn't be null or empty");
            var usersIds = await SendAsync(new GetUsersByFoodBusinessIdQuery
            {
                FoodBusinessId = foodBusinessId
            }).ConfigureAwait(false);
            var result = _userManager.Users.Where(x => usersIds.Any(u => x.Id == u)).GetPaged(page, pageSize);
            var pagedResult = await GetPagedListOfUsers(result).ConfigureAwait(false);
            return Ok(pagedResult);
        }

        [Route("/api/users/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null) return Ok(HttpResponseHelper.Respond(ResponseType.NotFound));

            return Ok(user);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserModel model)
        {
            var user = new ApplicationUser(model.FullName, model.Email, model.UserName);
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
            var user = new ApplicationUser(model.User.FullName, model.User.Email, model.User.UserName);
            if (string.IsNullOrEmpty(model.Password))
                model.Password = RandomPasswordGenerator.GeneratePassword(true, true, true, true, 10);

            var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
            foreach (var role in model.Roles) await _userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
            if (!result.Succeeded) return CheckResultStatus(result);
            _cache.GetOrCreate(user.Email, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(1);
                return new MemoryCachePasswordModel {Email = user.Email, Password = model.Password};
            });
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
            await SendEmailConfirmation(user, token).ConfigureAwait(false);

            return CheckResultStatus(result);
        }

        [HttpPut]
        [Route("{id}")]
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
        public async Task<IActionResult> Disable(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = false;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPut("enable")]
        public async Task<IActionResult> Enable(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = true;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }

        private IActionResult CheckResultStatus(IdentityResult result)
        {
            if (result.Succeeded) return Ok(HttpResponseHelper.Respond(ResponseType.OK));

            return Ok(HttpResponseHelper.Respond(ResponseType.InternalServerError));
        }
    }
}