using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Zones.Queries;
using System.Threading.Tasks;
using System;
using SmartRestaurant.Application.Listings.Queries;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRestaurant.Application.Listings.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using SmartRestaurant.Application.Common.WebResults;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/listings")]
    [ApiController]
    public class ListingsController : ApiController
    {
        /// <summary> GetListingsByHotelId() </summary>
        /// <remarks>This endpoint allows hotel managers to fetch list of listings.</remarks>
        /// <param name="HotelId">Is the hotel Id we use the it to get listings list linked to the hotel that has the specified Id .</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of listings that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> listings list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch listings list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(PagedListDto<ListingDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{HotelId:Guid}/list")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task<IActionResult> GetListingsByHotelId([FromRoute]string HotelId,int page,int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListingsByHotelIdQuery { HotelId=HotelId,Page=page,PageSize=pageSize});
        }

        /// <summary> GetListingById() </summary>
        /// <remarks>This endpoint allows hotel managers to fetch one listing.</remarks>
        /// <param name="id">listing Id we use the it to get listing with the specified Id .</param>
        /// <response code="200"> listings has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch listing is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(ListingDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task <IActionResult> GetListingById([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetListingByIdQuery { Id=id });
        }

        /// <summary> CreateListing() </summary>
        /// <remarks>This endpoint allows hotel managers to add one listing.</remarks>
        /// <param name="hotelId">Is the hotel Id we use the it to get listings list linked to the hotel that has the specified Id .</param>
        /// <param name="command">the data of the listing that should be added.</param>
        /// <response code="200"> listings has been successfully created.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a listing is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("{hotelId:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> CreateListing([FromRoute] Guid hotelId,CreateListingCommand command )
        {
            command.HotelId = hotelId;
            return await SendWithErrorsHandlingAsync( command);
        }

        /// <summary> UpdateListing() </summary>
        /// <remarks>This endpoint allows hotel managers to edit one listing.</remarks>
        /// <param name="command">the new data of the listing that should be edited.</param>
        /// <param name="id">listing Id we use the it to edit listing with the specified Id .</param>
        /// <response code="200"> listings has been successfully edited.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to edit a listing is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> UpdateListing([FromRoute]Guid id,  UpdateListingCommand command)
        {
            command.ListingId = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteListing() </summary>
        /// <remarks>This endpoint allows hotel managers to delete one listing.</remarks>
        /// <param name="id">listing Id we use the it to delete listing with the specified Id .</param>
        /// <response code="200"> listings has been successfully deleted.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a listing is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> DeleteListing([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteListingCommand { Id=id});
        }
    }
}