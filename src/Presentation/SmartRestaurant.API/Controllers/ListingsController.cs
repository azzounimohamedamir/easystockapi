using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Zones.Queries;
using System.Threading.Tasks;
using System;
using SmartRestaurant.Application.Listings.Queries;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/listings")]
    [ApiController]
    public class ListingsController : ApiController
    {
        /// <summary> GetListingsByHotelId() </summary>
        /// <remarks>This endpoint allows hotel managers to fetch list of listings.</remarks>
        /// <param name="id">Is the hotel Id we use the it to get listings list linked to the hotel that has the specified Id .</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of listings that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> listings list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch listings list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(PagedListDto<ListingDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{Id:Guid}/list")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task<IActionResult> GetListingsByHotelId([FromRoute]string Id,int page,int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListingsByHotelIdQuery { HotelId=Id,Page=page,PageSize=pageSize});
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
    }
}