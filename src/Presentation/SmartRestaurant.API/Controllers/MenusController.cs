using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Menus.Commands;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness")]
    [ApiController]
    public class MenusController : ApiController
    {
        [Route("{id:Guid}/menus/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute] Guid id, CreateMenuCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{id:Guid}/menus/{tableId:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromRoute] Guid tableId, UpdateMenuCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            if (tableId != command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
    }
}