using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System;
using SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Commands;
using SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Permissions")]
    public class PermissionsController : ApiController
    {
        /// <summary> GetAllMarks() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllPermList(string currentFilter, int page, int pageSize)
        {
           return await SendWithErrorsHandlingAsync(new GetPermissionsListQuery
            {

               Page = page,
               PageSize = pageSize,
               CurrentFilter= currentFilter,
            });
        }


        /// <summary> Add Mark </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new mark</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Create([FromForm] AjouterPermRoleCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        [ProducesResponseType(typeof(Domain.Identity.Entities.Permissions), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{role:string}")]
        
        public Task<IActionResult> Get([FromRoute] string role)
        {
            return SendWithErrorsHandlingAsync(new GetPermissionByRoleQuery { Role = role });
        }

        /// <summary> UpdateMark() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update mark.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> Update([FromForm] UpdatePermRoleCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteMark() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        //[Route("{id:guid}")]
        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    return await SendWithErrorsHandlingAsync(new deletep { Id = id });
        //}
    }
}