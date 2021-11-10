using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Orders.Queries;
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
        [HttpPatch]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] string id, UpdateOrderStatusCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> GetOrderDetails() </summary>
        /// <remarks>
        ///     This endpoint allows user to fetch order details..<br></br>
        ///     <b>Note 01:</b> This is the enum used to describe Order Type: <b>  enum OrderTypes { DineIn, Takeout, Delivery } </b><br></br>
        ///     <b>Note 02:</b> This is the enum used to describe Order Status: <b> enum OrderStatuses { InQueue, Serving, Served, Billed, Cancelled } </b><br></br>
        ///     <b>Note 03:</b> This is the enum used to describe Takeout Type: <b>  enum TakeoutType { Instant, Delayed } </b><br></br>
        /// </remarks>
        /// <param name="id">id of the order that would be used to fetch order details</param>
        /// <response code="200"> Order details has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch order details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetOrderByIdQuery { Id = id });
        }


        /// <summary> GetListOfOrders() </summary>
        /// <remarks>This endpoint allows us to fetch list of orders.</remarks>
        /// <param name="currentFilter">Orders list can be filtred by: <b>order number</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">Orders list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="foodBusinessId">We will get dishes list linked to that foodBusinessId.</param>
        /// <param name="dateInterval">We will get results within the selected interval. Default interval is: <b>ToDay</b><br></br>
        ///     <b>Note 01:</b> This is the enum used to set Date Interval: <b>  enum DateFilter { ToDay, Last7Days, Last30Days, All } </b>
        /// </param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> Orders list has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch orders list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<OrderDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,Cashier")]
        [HttpGet]
        public Task<IActionResult> GetList(string currentFilter, string searchKey, string sortOrder, string foodBusinessId, 
            int page, int pageSize,  DateFilter dateInterval)
        {
            var query = new GetOrdersListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
                FoodBusinessId = foodBusinessId,
                DateInterval = dateInterval
            };
            return SendWithErrorsHandlingAsync(query);
        }
    }
}