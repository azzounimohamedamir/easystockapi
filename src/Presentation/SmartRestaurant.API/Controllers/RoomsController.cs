using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Application.Rooms.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/rooms")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on rooms")]
    public class RoomsController : ApiController
    {


        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetRoomsByBuildingId([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetAllRoomsByBuildingId { BuildingId = id });
        }

        /// <summary> CreateNewRoom() </summary>
        /// <remarks>This endpoint allows us to create a new room within a Building.</remarks>
        /// <param name="command">This is payload object used to create a new room</param>
        /// <response code="204">The new room has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new room is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create([FromForm] CreateRoomCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Update([FromForm]  UpdateRoomCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteRoomCommand { Id = id });
        }
    }
}