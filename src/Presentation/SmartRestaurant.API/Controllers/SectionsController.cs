using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Sections.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness/{id:Guid}/menus")]
    [ApiController]
    public class SectionsController : ApiController
    {
        [Route("{menuId:Guid}/sections/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute] Guid menuId, CreateSectionCommand command)
        {
            if (menuId != command.MenuId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{menuId:Guid}/sections/{sectionId:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute] Guid menuId, [FromRoute] Guid sectionId, UpdateSectionCommand command)
        {
            if (menuId != command.MenuId || sectionId!= command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{menuId:Guid}/sections/{sectionId:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid menuId, [FromRoute] Guid sectionId)
        {
            if (menuId == Guid.Empty || sectionId ==Guid.Empty)
                return BadRequest(); 
            await SendAsync(new DeleteSectionCommand{SectionId = sectionId}).ConfigureAwait(false);
            return Ok("Successful");
        }
    }
}