using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/tables")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Tables")]
    public class TablesController : ApiController
    {
        [Route("zone/{zoneId:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,HotelClient,Waiter")]
        public async Task<IActionResult> Get([FromRoute] Guid zoneId)
        {
            return await SendWithErrorsHandlingAsync(new GetTablesListQuery {ZoneId = zoneId});
        }

        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,HotelClient,Waiter")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetTableByIdQuery {TableId = id});
        }

        /// <summary> CreateNewTable() </summary>
        /// <remarks>This endpoint allows us to create a new table within a FoodBusiness zone.</remarks>
        /// <param name="command">This is payload object used to create a new table</param>
        /// <response code="204">The new table has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new table is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Create(CreateTableCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Update(UpdateTableCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteTableCommand {Id = id});
        }
    }
}