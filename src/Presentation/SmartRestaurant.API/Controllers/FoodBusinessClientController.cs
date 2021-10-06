using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessClient")]
    [ApiController]
    public class FoodBusinessClientController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateFoodBusinessClientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> This endpoint is used to update a FoodBusinessClient </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Client</b> to update FoodBusinessClient created by him.
        ///     <br></br>
        ///     2- This endpoint allows <b>foodBusinessClientManager</b> to update FoodBusinessClient.
        /// </remarks>
        /// <param name="command">This is Json object user update reservation</param>
        /// <param name="id">Id of foodBusinessClient which we want to Update</param>
        /// <response code="200">The FoodBusinessClient has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a FoodBusinessClient is invalid.</response>
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
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateFoodBusinessClientCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}
