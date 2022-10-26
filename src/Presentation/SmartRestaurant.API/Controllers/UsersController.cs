using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Identity.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Application users.")]
    public class UsersController : ApiController
    {
        private readonly IIdentityContext _identityContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager, IEmailSender emailSender,
            IIdentityContext identityContext) :
            base(emailSender)
        {
            _userManager = userManager;
            _identityContext = identityContext;
        }

        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var result = _userManager.Users.GetPaged(page, pageSize);
            var pagedResult = await GetPagedListOfUsers(result).ConfigureAwait(false);

            return Ok(pagedResult);
        }


        /// <summary> Get users by role </summary>
        /// <remarks> This endpoint will return a list of users based on their role. </remarks>
        /// <param name="role"> Users list will be filtered based on role value.</param>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of users that should be returned</param>
        /// <response code="200">The list of staff has been successfully fetched.</response>
        /// <response code="400">The parameters sent to the backend-server in order to get the list of staff are invalid.</response>
        /// <response code="401"> The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request. </response>
        [ProducesResponseType(typeof(PagedListDto<ApplicationUserDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("role/{role}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetAllByRole([FromRoute] string role, int page, int pageSize)
        {                   
            var query = new GetUsersByRoleQuery
            {
                Role = role,
                Page = page,
                PageSize = pageSize
            };
            return await SendWithErrorsHandlingAsync(query);
        }

        [Route("{userId}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(user), userId);
            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            return Ok(new UserWithRolesModel(user, roles == null ? new string[0] : roles.ToArray()));
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

        /// <summary> This endpoint is used to get the staff list in a particular FoodBusiness </summary>
        /// <remarks>
        ///     This endpoint will return different results based on the role of the logged in user:
        ///     <br></br>
        ///     1- if the logged in user is a <b>FoodBusinessAdministrator</b>; the endpoint will return the list of users with
        ///     role = <b>FoodBusinessManagers</b> in the the selected <b>FoodBusiness</b>.
        ///     <br></br>
        ///     2- if the logged in user is a <b>FoodBusinessManager</b>; the endpoint will return the list of users with roles =
        ///     <b>Chef - Cashier - Waiter</b>  in the the selected <b>FoodBusiness</b>.
        /// </remarks>
        /// <param name="foodBusinessId">Id of foodBusiness which we want to get its staff list.</param>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of Reservations that should be returned</param>
        /// <response code="400">The parameters sent to the backend-server in order to get the list of staff are invalid.</response>
        /// <response code="200">The list of staff has been successfully fetched.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(PagedListDto<FoodBusinessEmployeesDtos>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("foodBusiness/staff")]
        [Authorize(Roles = "FoodBusinessAdministrator, FoodBusinessManager ,SuperAdmin, SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetStaff(string foodBusinessId, int page, int pageSize)
        {
            var query = new GetFoodBusinessEmployeesQuery
            {
                FoodBusinessId = foodBusinessId,
                Page = page,
                PageSize = pageSize
            };
            return await SendWithErrorsHandlingAsync(query);
        }





        [ProducesResponseType(typeof(PagedListDto<FoodBusinessEmployeesDtos>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("hotel/staff")]
        [Authorize(Roles = "FoodBusinessAdministrator, FoodBusinessManager ,SuperAdmin, SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetHotelStaff(string hotelId, int page, int pageSize)
        {
            var query = new GetHotelEmployeesQuery
            {
                HotelId = hotelId,
                Page = page,
                PageSize = pageSize
            };
            return await SendWithErrorsHandlingAsync(query);
        }

       
            [ProducesResponseType(typeof(PagedListDto<FoodBusinessManagersDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("organization/foodBusinessManagers")]
        [Authorize(Roles = "FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetFoodBusinessManagersWithinOrganization(int page, int pageSize)
        {
            var query = new GetFoodBusinessManagersWithinOrganizationQuery
            {
                Page = page,
                PageSize = pageSize
            };
            return await SendWithErrorsHandlingAsync(query);
        }







        [ProducesResponseType(typeof(PagedListDto<HotelsManagersDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("organization/hotelsManagers")]
        [Authorize(Roles = "FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        [HttpGet]
        public async Task<IActionResult> GetHotelsManagersWithinOrganization(int page, int pageSize)
        {
            var query = new GetHotelsManagersWithinOrganizationQuery
            {
                Page = page,
                PageSize = pageSize
            };
            return await SendWithErrorsHandlingAsync(query);
        }






        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserModel model)
        {
            if (SuperAdminCheck(model.Roles)) return BadRequest();
            var user = new ApplicationUser(model.FullName, model.Email, model.Email);
            user.EmailConfirmed = true;
            user.PhoneNumber = model.PhoneNumber;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                        await CreateUser(model, user).ConfigureAwait(false);
                        await AssignRolesToUser(model, user).ConfigureAwait(false);
                        transaction.Complete();                                
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().IsSubclassOf(typeof(BaseException)))
                    if (ex is BaseException result)
                        return StatusCode(result.StatusCode, new
                        {
                            result.Message,
                            result.Errors
                        });
                if (ex .GetType() == typeof(InvalidOperationException))
                        return StatusCode(400, new
                        {
                            Message = "Errors related to user manager",
                            Errors = new List<string> { ex.Message }
                        });

                return StatusCode(500, new
                {
                    Message = "Internal Server Error",
                    Errors = new List<string> { ex.Message}
                });
            }
            return Ok();
        }

        private async Task AssignRolesToUser(ApplicationUserModel model, ApplicationUser user)
        {
                foreach (var role in model.Roles)
                {
                    var AddRolesToUserResult = await _userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
                    if (!AddRolesToUserResult.Succeeded)
                        throw new UserManagerException(AddRolesToUserResult.Errors);
                }   
        }

        private async Task CreateUser(ApplicationUserModel model, ApplicationUser user)
        {
            var userCreationResult = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
            if (!userCreationResult.Succeeded)
                throw new UserManagerException(userCreationResult.Errors);
        }

        /// <summary> Update User Account  </summary>
        /// <remarks> This endpoint is used to update user account.</remarks>
        /// <param name="id">This is the user id.</param>
        /// <param name="command"> This is the payload object used to update user account</param>
        /// <response code="204">User account has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update user account is invalid.</response>
        /// <response code="401"> The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request. </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [Authorize(Roles = "SuperAdmin,SupportAgent")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateUserCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
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
        [HttpPatch("disable")]
        public async Task<IActionResult> Disable(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = false;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPatch("enable")]
        public async Task<IActionResult> Enable(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = true;
            var result = await _userManager.UpdateAsync(user);
            return CheckResultStatus(result);
        }
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPatch("{id}/forceEmailConfirmed")]
        public async Task<IActionResult> ForceEmailConfirmed([FromRoute]string id, [FromQuery] bool stateEmailConfirmed)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.EmailConfirmed = stateEmailConfirmed;
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

        /// <summary> SetNewPasswordForFoodBusinessAdministrator() </summary>
        /// <remarks> This endpoint is used to set a new password for the account of FoodBusinessAdministrator </remarks>
        /// <param name="id">This is the id of FoodBusinessAdministrator account.</param>
        /// <param name="command"> This is payload object used to set a new password for the account of FoodBusinessAdministrator</param>
        /// <response code="204"> The new password has been successfully set.</response>
        /// <response code="400"> The payload sent to the backend-server in order to set a new password is invalid. </response>
        /// <response code="401"> The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request. </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("foodBusinessAdministrator/{id}/set-new-password")]
        [Authorize(Roles = "SuperAdmin, SupportAgent")]
        [HttpPatch]
        public async Task<IActionResult> SetNewPasswordForFoodBusinessAdministrator([FromRoute] string id, SetNewPasswordForFoodBusinessAdministratorCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}