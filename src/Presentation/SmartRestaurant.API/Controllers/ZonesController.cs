using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Zones.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("{id:Guid}/zones/create")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute]Guid id,CreateZoneCommand command)
        {
            if(id!= command.FoodBusinessId)
                return BadRequest();
            var validationResult = await Mediator.Send(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
    }
}