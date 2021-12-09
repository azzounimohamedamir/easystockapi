using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Bills.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Orders.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/bills")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Order Bill")]
    public class BillController : ApiController
    {
        /// <summary> UpdateBillDiscount() </summary>
        /// <remarks>This endpoint allows user to update Bill Discount. </remarks>        
        /// <param name="id">id of the order that will used to update its bill biscount </param>
        /// <param name="command">This is payload object used to update bill discount</param>
        /// <response code="204">Bill discount has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in-order to update bill discount is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateBillCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        
    }
}