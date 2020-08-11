using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness/{id:Guid}/zones")]
    [ApiController]
    public class TablesController : ApiController
    {
        [Route("{zoneId:Guid}/tables/")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IEnumerable<TableDto>> Get([FromRoute] Guid zoneId)
        {
            if (zoneId == Guid.Empty)
                throw new InvalidOperationException("zone id shouldn't be null or empty");
            return SendAsync(new GetTablesListQuery() { ZoneId = zoneId });
        }
        [Route("{zoneId:Guid}/tables/{tableId:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<TableDto> GetById([FromRoute] Guid zoneId, [FromRoute] Guid tableId)
        {
            if (zoneId == Guid.Empty)
                throw new InvalidOperationException("zone id shouldn't be null or empty");
            if (tableId == Guid.Empty)
                throw new InvalidOperationException("table id shouldn't be null or empty");

            return SendAsync(new GetTableByIdQuery { TableId = tableId });
        }
        [Route("{zoneId:Guid}/tables/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute] Guid zoneId, CreateTableCommand command)
        {
            if (zoneId != command.ZoneId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{zoneId:Guid}/tables/{tableId:guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute] Guid zoneId, [FromRoute] Guid tableId, UpdateTableCommand command)
        {
            if (zoneId != command.ZoneId)
                return BadRequest();
            if (tableId != command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{zoneId:Guid}/tables/{tableId:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid zoneId, [FromRoute] Guid tableId)
        {
            if (zoneId == Guid.Empty)
                return BadRequest();
            if (tableId == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteTableCommand { TableId = tableId }).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}