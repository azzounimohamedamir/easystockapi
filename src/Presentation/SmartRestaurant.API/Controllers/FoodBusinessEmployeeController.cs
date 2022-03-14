using System.Collections.Generic;
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
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> AddEmployeeInOrganization(AddEmployeeInOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to update employee  role of a FoodBusiness</summary>
        /// <remarks>
        ///     This endpoint can be used to update role only for the employees listed bellow:
        ///     <br></br>
        ///     <b>Chef</b>, <b>Cashier</b>, <b>Waiter</b>.
        /// </remarks>
        /// <param name="id">id of the employee </param>
        /// <param name="command">This is the Json object used to update employee role</param>
        /// <response code="204">The employee role has been successfully updated</response>
        /// <response code="400">
        ///     The parameters sent to the backend-server in order to update employee role are
        ///     invalid.
        /// </response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager, SuperAdmin, SupportAgent")]
        public async Task<IActionResult> UpdateEmployeeRoleInOrganization([FromRoute] string id,
            UpdateEmployeeRoleInOrganizationCommand command)
        {
            command.UserId = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> This endpoint is used to remove staff frome organization</summary>
        /// <remarks>
        ///     This endpoint is used to remove staff frome organization.
        /// </remarks>
        /// <param name="id">id of the employee</param>
        /// <param name="foodBusinessesIds">
        ///     foodBusinessesIds is the list of [foodBusinesses] ids where employee should be removed
        ///     from.
        /// </param>
        /// <response code="400">
        ///     The parameters sent to the backend-server in order to remove employee from organization are
        ///     invalid.
        /// </response>
        /// <response code="204">The employee has been successfully removed from organization..</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> RemoveEmployeeFromOrganization([FromRoute] string id,
            [FromQuery] List<string> foodBusinessesIds)
        {
            var command = new RemoveEmployeeFromOrganizationCommand
            {
                UserId = id,
                FoodBusinessesIds = foodBusinessesIds
            };
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> This endpoint is used to invite staff to join an organization </summary>
        /// <remarks>
        ///     This endpoint can invite the following staff to  join an organization:
        ///     <br></br>
        ///     <b>FoodBusinessManager</b>, <b>Chef</b>, <b>Cashier</b>, <b>Waiter</b>.
        /// </remarks>
        /// <param name="command">This is the Json object used to invite staff</param>
        /// <response code="204">The invitation has been successfully sent.</response>
        /// <response code="400">The payload data sent to the backend-server in order to invite staff, are invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("invite")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator, FoodBusinessManager ,SuperAdmin, SupportAgent")]
        public async Task<IActionResult> InviteUserToJoinOrganization(InviteUserToJoinOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used by staff to accept joining to an organization </summary>
        /// <remarks>
        ///     This endpoint is used by the new <b>staff</b> to join the organisation that invited them.
        ///     <br></br>
        ///     The new <b>staff</b> will have to the fill their personal information and password to complete the process of
        ///     joining the organisation.
        /// </remarks>
        /// <param name="id">This is the user Id of the new employee</param>
        /// <param name="command">This is the Json object used to complete employee subscription</param>
        /// <response code="204">The new employee has been successfully joined the organisation</response>
        /// <response code="400">The payload data sent to the backend-server in order to add the new employee, are invalid.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/accept-invitation")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UserAcceptsInvitationToJoinOrganization([FromRoute] string id,
            UserAcceptsInvitationToJoinOrganizationCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}