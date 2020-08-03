using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodBusinessController : ApiController
    {
        [HttpGet]
        [ActionName("get")]
        public Task<List<FoodBusinessDto>> Get()
        {
            return Mediator.Send(new GetFoodBusinessListQuery());
        }
        [ActionName("getByFoodBusinessAdministratorId")]
        [HttpGet]
        public Task<List<FoodBusinessDto>> GetByFoodBusinessAdministratorId(string adminId)
        {
            return Mediator.Send(new GetFoodBusinessListByAdmin {FoodBusinessAdministratorId = adminId });
        }
        [ActionName("getById")]
        [HttpGet]
        public Task<FoodBusinessDto> GetById(Guid id)
        {
            return Mediator.Send(new GetFoodBusinessByIdQuery { FoodBusinessId = id });
        }

        [HttpPost]
        [ActionName("create")]
        public async Task<ActionResult> Create(CreateFoodBusinessCommand command)
        {
            var validationResult =  await Mediator.Send(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [ActionName("update")]
        public async Task<ActionResult> Update(Guid id, UpdateFoodBusinessCommand command)
        {
            if (id != command.CmdId)
                return BadRequest();

            var validationResult = await Mediator.Send(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteFoodBusinessCommand { FoodBusinessId = id }).ConfigureAwait(false);
            return NoContent();
        }
        [HttpPost]
        [ActionName("uploadImages")]
        public async Task<ActionResult> UploadImages([FromForm] FIleUploadApi images)
        {
            if (images.FoodBusinessId == Guid.Empty)
                throw new InvalidOperationException("FoodBusiness id shouldn't be null or empty");
            var foodBusiness = await Mediator.Send(new GetFoodBusinessByIdQuery { FoodBusinessId = images.FoodBusinessId }).ConfigureAwait(false);
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

            await Mediator.Send(createImagesCommand).ConfigureAwait(false);
            return Ok("Successful");
        }
        

    }
}
