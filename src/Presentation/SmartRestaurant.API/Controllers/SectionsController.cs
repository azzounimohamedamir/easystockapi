using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Sections.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/sections")]
    [ApiController]
    public class SectionsController : ApiController
    {
        [Route("menu/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<PagedListDto<SectionDto>> Get([FromRoute] Guid id, int page, int pageSize)
        {
            return SendAsync(new GetSectionsListQuery {MenuId = id, Page = page, PageSize = pageSize});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create(CreateSectionCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update(UpdateSectionCommand command)
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
            await SendAsync(new DeleteSectionCommand {CmdId = id}).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}