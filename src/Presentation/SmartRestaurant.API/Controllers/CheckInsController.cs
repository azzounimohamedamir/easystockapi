using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Checkins.Queries;
using SmartRestaurant.Application.Checkins.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/checkins")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on rooms")]
    public class CheckInsController : ApiController
    {

        /// <summary> GetCheckInsByHotelId() </summary>
        /// <remarks>This endpoint allows us to fetch list of checkins of Current hotel </remarks>
        /// <response code="200"> checkins list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch checkins list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,HotelReceptionist")]
        public async Task<IActionResult> GetCheckInsByHotelId([FromRoute] Guid id , int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetCheckinsListQuery {
                hotelId = id,
                Page = page,
                PageSize = pageSize
            });
        }

        /// <summary> GetCheckInsListOfClient() </summary>
        /// <remarks>This endpoint allows us to fetch list of checkins of Current client </remarks>
        /// <response code="200"> checkins list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch checkins list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("clientCheckins")]
        [HttpGet]
        [Authorize(Roles = "HotelClient")]
        public async Task<IActionResult> GetCheckInsListOfClient()
        {
            return await SendWithErrorsHandlingAsync(new GetCheckinsListOfClientQuery ());
        }

        /// <summary> CreateCheckinDraft() </summary>
        /// <remarks>This endpoint allows us to create a new checkin draft.</remarks>
        /// <param name="command">This is payload object used to create a new checkin</param>
        /// <response code="204">The new checkin has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new checkin is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "HotelReceptionist")]
        public async Task<IActionResult> Create([FromForm] CreateCheckInCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> AssignRoomToClient() </summary>
        /// <remarks>This endpoint allows us to assign a room to Client.</remarks>
        /// <param name="command">This is payload object used to assign a room to Client</param>
        /// <response code="204">The room has been successfully assigned.</response>
        /// <response code="400">The payload data sent to the backend-server in order to assign a room to Client is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("assignRoom")]
        [HttpPut]
        [Authorize(Roles = "HotelReceptionist")]
        public async Task<IActionResult> AssignRoomUpdate([FromForm] UpdateCheckInAssignRoomCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> ActivateClientChecking() </summary>
        /// <remarks>This endpoint allows us to activate a checking to Client.</remarks>
        /// <param name="command">This is payload object used to activate a checking to Client</param>
        /// <response code="204">The room has been successfully activated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to activate checkin is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("activateCheckin")]
        [HttpPut]
        [Authorize(Roles = "HotelClient")]
        public async Task<IActionResult> ActivateCheckin([FromForm] ActivateCheckinCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


    }
}