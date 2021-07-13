using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager, IEmailSender emailSender) :
            base(emailSender)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var result = _userManager.Users.GetPaged(page, pageSize);
            var pagedResult = await GetPagedListOfUsers(result).ConfigureAwait(false);

            return Ok(pagedResult);
        }

        [Route("role/{role}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetAllByRole([FromRoute] string role, int page, int pageSize)
        {
            var result = await _userManager.GetUsersInRoleAsync(role).ConfigureAwait(false);
            return Ok(result);
        }

        [Route("{userId}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            return user == null ? Ok(HttpResponseHelper.Respond(ResponseType.NotFound)) : Ok(user);
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
        [Authorize(Roles = "SuperAdmin,FoodBusinessManager")]
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


        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserModel model)
        {
            if (SuperAdminCheck(model.Roles)) return BadRequest();
            var user = new ApplicationUser(model.FullName, model.Email, model.UserName);
            var result = await _userManager.CreateAsync(user).ConfigureAwait(false);
            if (!result.Succeeded) return CheckResultStatus(result);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
            await SendEmailConfirmation(user, token).ConfigureAwait(false);
            if (model.Password.Length <= 0) return CheckResultStatus(result);
            foreach (var role in model.Roles) await _userManager.AddToRoleAsync(user, role).ConfigureAwait(false);

            return CheckResultStatus(result);
        }

        [Route("{id}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] string id, ApplicationUserModel model)
        {
            if (SuperAdminCheck(model.Roles)) return BadRequest();
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
            var roles = await _userManager.GetRolesAsync(user);
            if (SuperAdminCheck(roles)) return BadRequest();
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

        private static bool SuperAdminCheck(IEnumerable<string> roles)
        {
            return roles.Contains("SuperAdmin", StringComparer.OrdinalIgnoreCase);
        }

        private IActionResult CheckResultStatus(IdentityResult result)
        {
            return Ok(result.Succeeded
                ? HttpResponseHelper.Respond(ResponseType.OK)
                : HttpResponseHelper.Respond(ResponseType.InternalServerError));
        }
    }
}