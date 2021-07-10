using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
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
        public Task<PagedListDto<MenuDto>> Get([FromRoute] Guid id, int page, int pageSize)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("FoodBusiness id shouldn't be null or empty");

            return SendAsync(new GetMenusListQuery {FoodBusinessId = id, Page = page, PageSize = pageSize});
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<MenuDto> Get([FromRoute] Guid id)
        {
            return SendAsync(new GetMenuByIdQuery {MenuId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create(CreateMenuCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update(UpdateMenuCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteMenuCommand {CmdId = id}).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}