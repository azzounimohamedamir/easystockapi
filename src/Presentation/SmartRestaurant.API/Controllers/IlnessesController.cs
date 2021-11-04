using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Illness.Commands;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/illness")]
    [ApiController]
    public class IlnessesController :  ApiController
    {
        /// <summary> This endpoint is used to create an Illness </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Mananger</b> to create Illness.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object user create Illness</param>
        /// <response code="204">The Illness has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create an Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "SupportAgent")]
        public async Task<IActionResult> Create(CreateIllnessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> AddIngredientToIllness() </summary>
        /// <remarks> This endpoint is used to add an Ingredient to Illness. </remarks>
        /// <param name="command">This is payload object used to add an Ingredient to Illness</param>
        /// <response code="204">The Ingredient has been successfully added to Illness.</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a new Ingredient to Illness is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("add-ingredient")]
        [HttpPost]
        [Authorize(Roles = "SupportAgent")]
        public async Task<IActionResult> AddIngredientToIllness(AddIngredientToIllnessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}
