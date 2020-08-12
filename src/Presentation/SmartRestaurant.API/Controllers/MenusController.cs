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
        [Route("{id:Guid}/menus/{menuId:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromRoute] Guid menuId, UpdateMenuCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            if (menuId != command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{id:Guid}/menus/{menuId:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromRoute] Guid menuId)
        {
            if (id == Guid.Empty)
                return BadRequest();
            if (menuId == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteMenuCommand() { MenuId = menuId }).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}