using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.MediaModels;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusiness")]
    [ApiController]
    public class FoodBusinessController : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public Task<PagedListDto<FoodBusinessDto>> Get(int page, int pageSize)
        {
            return SendAsync(new GetFoodBusinessListQuery {Page = page, PageSize = pageSize});
        }
        [Route("{adminId}/foodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public Task<List<FoodBusinessDto>> GetByFoodBusinessAdministratorId([FromRoute] string adminId)
        {
            return SendAsync(new GetFoodBusinessListByAdmin { FoodBusinessAdministratorId = adminId });
        }
        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]

        public Task<FoodBusinessDto> GetById([FromRoute] Guid id)
        {
            return SendAsync(new GetFoodBusinessByIdQuery { FoodBusinessId = id });
        }

        [HttpPost]
        [ActionName("")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> Create(CreateFoodBusinessCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> Update([FromRoute] Guid id, UpdateFoodBusinessCommand command)
        {
            if (id != command.CmdId)
                return BadRequest();

            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);

        }

        [Authorize(Roles = "FoodBusinessAdministrator")]
        [HttpDelete]
        [Route("{id:Guid}")]
        [ActionName("delete")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await SendAsync(new DeleteFoodBusinessCommand { FoodBusinessId = id }).ConfigureAwait(false);
            return NoContent();
        }

        [HttpPost]
        [Route("{id:Guid}/uploadImages")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> UploadImages([FromRoute] Guid id, [FromForm] FIleUploadModel images)
        {
            if (images.EntityId == Guid.Empty)
                throw new InvalidOperationException("FoodBusiness id shouldn't be null or empty");
            if (id != images.EntityId)
                return BadRequest();
            var foodBusiness = await SendAsync(new GetFoodBusinessByIdQuery { FoodBusinessId = images.EntityId }).ConfigureAwait(false);
            if (foodBusiness == null)
                return BadRequest("FoodBusiness wasn't found");
            if (images.Files.Count <= 0)
                return BadRequest("Unsuccessful");
            var imageModels = FileHelper.SaveImagesAsync(images);
            var createImagesCommand = new CreateListImagesCommand
            {
                EntityId = foodBusiness.FoodBusinessId
            };
            foreach (var imageModel in imageModels)
            {
                createImagesCommand.ImageCommands.Add(
                    new CreateImageCommand
                    {
                        ImageTitle = imageModel.ImageTitle,
                        ImageBytes = imageModel.ImageBytes,
                        IsLogo = imageModel.IsLogo
                    });
            }

            await SendAsync(createImagesCommand).ConfigureAwait(false);
            return Ok("Successful");
        }

        [HttpGet]
        [Route("{id:Guid}/allImages")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]

        public async Task<IEnumerable<string>> GetAllImagesByFoodBusinessId([FromRoute] Guid id)
        {
            var query = await SendAsync(new GetImagesByEntityIdQuery { EntityId = id }).ConfigureAwait(false);
            return query.Select(Convert.ToBase64String);
        }
    }
}
