using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Orders.Commands;
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

        /// <summary> GetRoomsByBuildingId() </summary>
        /// <remarks>This endpoint allows us to fetch list of Room of Current Building </remarks>
        /// <response code="200"> Room list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch room list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,HotelReceptionist,HouseKeeping")]
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

        /// <summary> UpdateRoom() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update room.<br></br>
        /// </remarks>
        /// <param name="id">id of the room that would be updated</param>
        /// <param name="command">This is the payload object used to update room</param>
        /// <response code="204">The room has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a room is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Update([FromForm]  UpdateRoomCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> DeleteRoom() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete room.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The room has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a room is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteRoomCommand { Id = id });
        }


        /// <summary> UpdateRoomStatus() </summary>
        /// <remarks>
        ///     This endpoint allows user to update Room Status To Available.<br></br>
        /// </remarks>        
        /// /// <param name="id">id of the room that would be updated</param>
        /// <param name="command">This is payload object used to update room status</param>
        /// <response code="204">The room has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in-order to update room status is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/status")]
        [HttpPatch]
        [Authorize(Roles = "HouseKeeping,HotelReceptionist")]
        public async Task<IActionResult> UpdateRoomStatusToAvailable([FromRoute] string id, UpdateRoomStatusCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}