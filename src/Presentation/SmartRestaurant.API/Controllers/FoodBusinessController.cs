using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.MediaModels;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusiness")]
    [ApiController]
    public class FoodBusinessController : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public Task<IActionResult> Get(int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListQuery {Page = page, PageSize = pageSize});
        }

        [Route("{adminId}/foodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public Task<IActionResult> GetByFoodBusinessAdministratorId([FromRoute] string adminId)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListByAdmin {FoodBusinessAdministratorId = adminId});
        }

        [Route("byFoodBusinessManager")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> GetAllFoodBusinessByFoodBusinessManager()
        {
            return SendWithErrorsHandlingAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessByIdQuery {FoodBusinessId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Create(CreateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Update(UpdateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteFoodBusinessCommand {CmdId = id});
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
            var foodBusiness = await SendAsync(new GetFoodBusinessByIdQuery {FoodBusinessId = images.EntityId});
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
                createImagesCommand.ImageCommands.Add(
                    new CreateImageCommand
                    {
                        ImageTitle = imageModel.ImageTitle,
                        ImageBytes = imageModel.ImageBytes,
                        IsLogo = imageModel.IsLogo
                    });

            await SendAsync(createImagesCommand).ConfigureAwait(false);
            return Ok("Successful");
        }

        [HttpGet]
        [Route("{id:Guid}/allImages")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public async Task<IEnumerable<string>> GetAllImagesByFoodBusinessId([FromRoute] Guid id)
        {
            var query = await SendAsync(new GetImagesByEntityIdQuery {EntityId = id}).ConfigureAwait(false);
            return query.Select(Convert.ToBase64String);
        }
    }
}