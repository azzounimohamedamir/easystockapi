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
    [Route("api/hotel/sections")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotel Sections")]
    public class HotelSectionsController : ApiController
    {
        // GET: api/<HotelSectionsController>
        [Route("hotel/{id:Guid}")]
        [HttpGet]
        //[Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
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
