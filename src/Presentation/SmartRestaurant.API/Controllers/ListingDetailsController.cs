using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.API.Swagger.Exception;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.ListingDetails.Commands;
using SmartRestaurant.Application.ListingDetails.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/listingDetails")]
    [ApiController]
    public class ListingDetailsController : ApiController
    {
        /// <summary> CreateListingDetail() </summary>
        /// <remarks>This endpoint allows hotel managers to add one listing element to existing listing.</remarks>
        /// <param name="listingId">Is the listing Id where the listing element will be added to .</param>
        /// <param name="command">the data of the listing element that should be added.</param>
        /// <response code="200"> listings element has been successfully created.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a listing element is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("{listingId:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> CreateListingDetail([FromRoute] Guid listingId,[FromForm]CreateListingDetailCommand command)
        {
            command.ListingId = listingId;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UpdateListingDetail() </summary>
        /// <remarks>This endpoint allows hotel managers to update one listing element to existing listing.</remarks>
        /// <param name="Id">Is the listing element Id that should be updated .</param>
        /// <param name="command">the data of the listing element that should be added.</param>
        /// <response code="200"> listings element has been successfully updated.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a listing element is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> UpdateListingDetail([FromRoute] Guid Id, [FromForm] UpdateListingDetailCommand command)
        {
            command.Id = Id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> GetListingDetailById() </summary>
        /// <remarks>This endpoint allows hotel managers to get one listing element to existing listing.</remarks>
        /// <param name="Id">Is the listing element Id that should be updated .</param>
        /// <response code="200"> listings element has been successfully updated.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a listing element is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(ListingDetailDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task<IActionResult> GetListingDetailById([FromRoute] Guid Id)
        {
            return await SendWithErrorsHandlingAsync(new GetListingDetailByIdQuery{Id=Id.ToString()});
        }


        /// <summary> DeleteListingDetail() </summary>
        /// <remarks>This endpoint allows hotel managers to delete one listing element to existing listing.</remarks>
        /// <param name="Id">Is the listing element Id which will be deleted .</param>
        /// <response code="200"> listings element has been successfully deleted.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a listing element is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpDelete]
        [Route("{Id:Guid}")]
        //[Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> DeleteListingDetail([FromRoute] Guid Id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteListingDetailCommand { Id=Id});
        }
    }
}
