using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.OrderDestination.Commands;
using SmartRestaurant.Application.OrderDestination.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/orderDestination")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Order Destination")]
    public class OrderDestinationController : ApiController
    {

        /// <summary> GetListOfOrderDestinationByHotelId() </summary>
        /// <remarks>This endpoint allows us to fetch list of types reclamations.</remarks>
        /// <param name="Id">If the Id is set, we will get  types reclamations list linked to that Id hotel we will get an empty list.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200">  types reclamations list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch  types reclamations list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ListingDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{HotelId:Guid}/list")]
        [Authorize(Roles = "FoodBusinessManager,HotelClient,HotelServiceAdmin")]
        public async Task<IActionResult> GetOrderDestinationList([FromRoute] string HotelId,int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetAllOrderDestinationListByHotelId
            { HotelId=HotelId, Page = page, PageSize = pageSize });
        }



        /// <summary> CreateNewOrderDestination() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new order destination.<br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new order destination</param>
        /// <response code="204">The order destination has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new order destination type is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateOrderDestinationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateOrderDestination() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update OrderDestination.<br></br>
        /// </remarks>
        /// <param name="id">id of the OrderDestination that would be updated</param>
        /// <param name="command">This is the payload object used to update OrderDestination</param>
        /// <response code="204">The OrderDestination  has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a OrderDestination is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update([FromRoute] Guid Id , [FromForm] UpdateOrderDestinationCommand command)
        {
            command.Id = Id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteOrderDestination() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete OrderDestination.</remarks>
        /// <param name="id">id of the OrderDestination that would be deleted</param>
        /// <response code="204">The OrderDestination has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a OrderDestination is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteOrderDestinationCommand { Id = id });
        }

      

     
    }
}