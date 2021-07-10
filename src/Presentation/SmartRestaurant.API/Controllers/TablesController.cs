using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : ApiController
    {
        [Route("zone/{zoneId:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IEnumerable<TableDto>> Get([FromRoute] Guid zoneId)
        {
            if (zoneId == Guid.Empty)
                throw new InvalidOperationException("zone id shouldn't be null or empty");
            return SendAsync(new GetTablesListQuery {ZoneId = zoneId});
        }

        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<TableDto> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("table id shouldn't be null or empty");

            return SendAsync(new GetTableByIdQuery {TableId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create(CreateTableCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update(UpdateTableCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteTableCommand {CmdId = id}).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}