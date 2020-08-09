using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Tables.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness/{id:Guid}/zones")]
    [ApiController]
    public class TablesController : ApiController
    {
        [Route("{zoneId:Guid}/tables/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute]Guid zoneId, CreateTableCommand command)
        {
            if (zoneId != command.ZoneId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{zoneId:Guid}/tables/")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute]Guid zoneId, UpdateTableCommand command)
        {
            if (zoneId != command.ZoneId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
    }
}