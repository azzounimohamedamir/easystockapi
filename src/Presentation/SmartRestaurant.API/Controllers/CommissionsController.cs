using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.commisiones.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/commissions")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Commissions")]
    public class CommissionsController : ApiController
    {
        /// <summary> SetFoodBusinessCommission() </summary>
        /// <remarks>This endpoint allows user to set FoodBusiness Commission. </remarks>        
        /// <param name="id">id of the FoodBusiness that we will set its Commission </param>
        /// <param name="command">This is payload object used to set FoodBusiness Commission</param>
        /// <response code="204">FoodBusiness Commission has been successfully set.</response>
        /// <response code="400">The payload data sent to the backend-server in-order to set FoodBusiness Commission is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "SuperAdmin,SupportAgent,SalesMan")]
        public async Task<IActionResult> SetFoodBusinessCommission([FromRoute] string id, SetFoodBusinessCommissionCommand command)
        {
            command.FoodBusinessId = id;
            return await SendWithErrorsHandlingAsync(command);
        }     
    }
}