using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Menus.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenusController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> Get([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetMenusListQuery
                {FoodBusinessId = id, Page = page, PageSize = pageSize});
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetMenuByIdQuery {MenuId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateMenuCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateMenuCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteMenuCommand {CmdId = id});
        }
    }
}