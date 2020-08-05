using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodBusinessController : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        [ActionName("")]
        public Task<List<FoodBusinessDto>> Get()
        {
            return SendAsync(new GetFoodBusinessListQuery());
        }
        [ActionName("byFoodBusinessAdministratorId")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public Task<List<FoodBusinessDto>> GetByFoodBusinessAdministratorId(string adminId)
        {
            return SendAsync(new GetFoodBusinessListByAdmin { FoodBusinessAdministratorId = adminId });
        }
        [ActionName("byId")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]

        public Task<FoodBusinessDto> GetById(Guid id)
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
        [ActionName("")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> Update(Guid id, UpdateFoodBusinessCommand command)
        {
            if (id != command.CmdId)
                return BadRequest();

            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);

        }


        [ActionName("")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await SendAsync(new DeleteFoodBusinessCommand { FoodBusinessId = id }).ConfigureAwait(false);
            return NoContent();
        }
        [HttpPost]
        [ActionName("uploadImages")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> UploadImages([FromForm] FIleUploadApi images)
        {
            if (images.FoodBusinessId == Guid.Empty)
                throw new InvalidOperationException("FoodBusiness id shouldn't be null or empty");
            var foodBusiness = await SendAsync(new GetFoodBusinessByIdQuery { FoodBusinessId = images.FoodBusinessId }).ConfigureAwait(false);
            if (foodBusiness == null)
                return BadRequest("FoodBusiness wasn't found");
            if (images.Files.Count <= 0)
                return BadRequest("Unsuccessful");
            var imageModels = FileHelper.SaveImagesAsync(images);
            var createImagesCommand = new CreateListFoodBusinessImagesCommand();
            createImagesCommand.FoodBusinessId = foodBusiness.FoodBusinessId;
            foreach (var imageModel in imageModels)
            {
                createImagesCommand.ImageCommands.Add(
                    new CreateFoodBusinessImageCommand
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
        [ActionName("allImagesByFoodBusinessId")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]

        public async Task<IEnumerable<string>> GetAllImagesByFoodBusinessId(Guid id)
        {
            var query = await SendAsync(new GetImagesByFoodBusinessIdQuery() { FoodBusinessId = id }).ConfigureAwait(false);
            return query.Select(Convert.ToBase64String);
        }
    }
}
