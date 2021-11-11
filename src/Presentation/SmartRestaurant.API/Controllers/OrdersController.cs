using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Orders.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Orders")]
    public class OrdersController : ApiController
    {
        /// <summary> CreateNewOrder() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new Order.<br></br>
        ///     <b>Note 01:</b> This is the enum used to set Order Type: <b>  enum OrderTypes { DineIn, Takeout, Delivery } </b><br></br>
        ///     <b>Note 02:</b> This is the enum used to set Takeout Type: <b>  enum TakeoutType { Instant, Delayed } </b><br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new Order</param>
        /// <response code="204">The order has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new order is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UpdateOrder() </summary>
        /// <remarks>
        ///     This endpoint allows user to update an Order.<br></br>
        ///     <b>Note 01:</b> This is the enum used to set Order Type: <b>  enum OrderTypes { DineIn, Takeout, Delivery } </b><br></br>
        ///     <b>Note 02:</b> This is the enum used to set Takeout Type: <b>  enum TakeoutType { Instant, Delayed } </b><br></br>
        /// </remarks>        
        /// /// <param name="id">id of the order that would be updated</param>
        /// <param name="command">This is payload object used to update an order</param>
        /// <response code="204">The order has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in-order to update an order is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateOrderCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UpdateOrderStatus() </summary>
        /// <remarks>
        ///     This endpoint allows user to update Order Status.<br></br>
        ///     <b>Note 01:</b> This is the enum used to set Order Status: <b> enum OrderStatuses { InQueue, Serving, Served, Billed, Cancelled } </b><br></br>
        /// </remarks>        
        /// /// <param name="id">id of the order that would be updated</param>
        /// <param name="command">This is payload object used to update order status</param>
        /// <response code="204">The order has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in-order to update order status is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/status")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] string id, UpdateOrderStatusCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}