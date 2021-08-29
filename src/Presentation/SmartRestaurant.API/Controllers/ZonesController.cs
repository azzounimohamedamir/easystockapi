using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.MediaModels;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/zones")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetZonesListQuery {FoodBusinessId = id});
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetZoneByIdQuery {ZoneId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateZoneCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateZoneCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            return (ActionResult) await SendWithErrorsHandlingAsync(new DeleteZoneCommand {Id = id});
        }


        [HttpGet]
        [Route("{id:Guid}/allImages")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public async Task<IEnumerable<string>> GetAllImagesByFoodBusinessId([FromRoute] Guid id)
        {
            var query = await SendAsync(new GetImagesByEntityIdQuery {EntityId = id}).ConfigureAwait(false);
            return query.Select(Convert.ToBase64String);
        }
    }
}