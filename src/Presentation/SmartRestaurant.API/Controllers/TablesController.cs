using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get([FromRoute] Guid zoneId)
        {
            return await SendWithErrorsHandlingAsync(new GetTablesListQuery {ZoneId = zoneId});
        }

        [Route("{id:guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetTableByIdQuery {TableId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateTableCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateTableCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteTableCommand {Id = id});
        }
    }
}