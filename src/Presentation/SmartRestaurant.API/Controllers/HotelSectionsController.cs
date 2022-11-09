using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Sections.Queries;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.HotelSections.Queries;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    /// <summary> GetSectionMenuItems() </summary>
    /// <remarks>This endpoint allows <b>the api consumer</b> to fetch the list of hotel sections</remarks>
    /// <param name="searchKey">Search keyword is used to filter results by <b>names</b></param>
    /// <param name="currentFilter">hotel sections can be filtred by<b>names</b></param>
    /// <param name="id">id of hotel that we want to fetch its section items.</param>
    /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
    /// <param name="pageSize">The max number of results that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
    /// <response code="200"> Hotel sections has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
    /// <response code="400">The payload data sent to the backend-server in order to fetch hotel sections is invalid.</response>
    /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
    /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

    [Route("api/hotel/sections")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotel Sections")]
    public class HotelSectionsController : ApiController
    {
        // GET: api/<HotelSectionsController>
        [Route("hotel/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin, HotelClient")]
        public async Task<IActionResult> GetSectionsListByHotelId([FromRoute] string id, string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetSectionsListByHotelIdQuery
            {
                HotelId = id,
                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
            });
        }

        // GET api/<HotelSectionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HotelSectionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HotelSectionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HotelSectionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
