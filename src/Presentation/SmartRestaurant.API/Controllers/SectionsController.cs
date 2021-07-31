using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get([FromRoute] Guid id, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetSectionsListQuery
                {MenuId = id, Page = page, PageSize = pageSize});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteSectionCommand {Id = id});
        }
    }
}