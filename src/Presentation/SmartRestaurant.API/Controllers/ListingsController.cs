using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Zones.Queries;
using System.Threading.Tasks;
using System;
using SmartRestaurant.Application.Listings.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    [Route("api/listings")]
    [ApiController]
    public class ListingsController : ApiController
    {
        // GET: api/<ListingsController>
        [HttpGet]
        [Route("hotel/{id:Guid}")]
        //[Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> GetListingsByHotelId([FromRoute]string id,int page,int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListingsByHotelIdQuery { HotelId=id,Page=page,PageSize=pageSize});
        }
    }
}