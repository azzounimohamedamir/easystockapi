using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("{id:Guid}/zones/")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        [ActionName("")]
        public Task<IEnumerable<ZoneDto>> Get([FromRoute]Guid id)
        {
            return SendAsync(new GetZonesListQuery {FoodBusinessId = id});
        }
        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        [ActionName("")]
        public Task<ZoneDto> GetById([FromRoute]Guid id, [FromRoute]Guid zoneId)
        {
            if(id == Guid.Empty)
                throw new InvalidOperationException("Food business id shouldn't be null or empty ");
            if (zoneId == Guid.Empty)
                throw new InvalidOperationException("Zone id shouldn't be null or empty ");

            return SendAsync(new GetZoneByIdQuery { ZoneId = zoneId });
        }
        [Route("{id:Guid}/zones/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute]Guid id,CreateZoneCommand command)
        {
            if(id!= command.FoodBusinessId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute]Guid id, [FromRoute]Guid zoneId, UpdateZoneCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            if(zoneId!= command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromRoute] Guid zoneId)
        {
            if (id  == Guid.Empty)
                return BadRequest();
            if (zoneId == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteZoneCommand {ZoneId = zoneId}).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}