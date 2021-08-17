using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessstaff")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Staff.")]
    public class FoodBusinessEmployeeController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> AddEmployeeInOrganization(AddEmployeeInOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> UpdateEmployeeRoleInOrganization(
            UpdateEmployeeRoleInOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpDelete]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> RemoveEmployeeFromOrganization(RemoveEmployeeFromOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> This endpoint is used to invite staff to join an organization </summary>
        /// <remarks>
        /// This endpoint can invite the following staff to  join an organization:
        /// <br></br>
        /// <b>FoodBusinessManager</b>, <b>Chef</b>, <b>Cashier</b>, <b>Waiter</b>.
        /// </remarks>
        /// <param name="command">This is the Json object used to invite staff</param>
        /// <response code="204">The invitation has been successfully sent.</response>
        /// <response code="400">The payload data sent to the backend-server in order to invite staff, are invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("invite")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator, FoodBusinessManager")]
        public async Task<IActionResult> InviteUserToJoinOrganization(InviteUserToJoinOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}