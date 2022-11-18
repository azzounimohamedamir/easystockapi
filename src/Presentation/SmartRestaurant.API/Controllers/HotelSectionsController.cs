using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.HotelSections.Queries;
using SmartRestaurant.Application.HotelSections.Commands;
using System.Threading.Tasks;
using SmartRestaurant.API.Swagger.Exception;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/sections")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotel Sections")]
    public class HotelSectionsController : ApiController
    {
        /// <summary> This endpoint is used to list hotel sections </summary>
        /// <remarks>This endpoint allows <b>the api consumer</b> to fetch the list of hotel sections</remarks>
        /// <param name="searchKey">Search keyword is used to filter results by <b>names</b></param>
        /// <param name="currentFilter">hotel sections can be filtred by<b>names</b></param>
        /// <param name="language">The language in which the search will be conducted. Default value is:<b>en</b></param>
        /// <param name="id">id of hotel that we want to fetch its section items.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of results that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> Hotel sections has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotel sections is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("hotel/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin, HotelClient")]
        public async Task<IActionResult> GetSectionsListByHotelId([FromRoute] string id, string currentFilter, string searchKey, string language, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetSectionsListByHotelIdQuery
            {
                HotelId = id,
                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                language = language,
            });
        }

        /// <summary> This endpoint is used to add a hotel section </summary>
        /// <remarks>This endpoint allows hotel managers to create a new section.</remarks>
        /// <param name="section">section object which will be added to the database.</param>
        /// <response code="200"> section has been successfully created.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        //[Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task<IActionResult> CreateListing(CreateHotelSectionCommand section)
        {
            return await SendWithErrorsHandlingAsync(section);
        }
    }
}
