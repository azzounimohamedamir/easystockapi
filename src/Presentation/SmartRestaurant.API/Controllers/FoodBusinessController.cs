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
        [ActionName("getByAdministratorId")]
        [HttpGet]
        public Task<List<FoodBusinessDto>> GetByAdministratorId(string adminId)
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
            await Mediator.Send(new DeletefoodBusinessCommand { FoodBusinessId = id }).ConfigureAwait(false);
            return NoContent();
        }
        [HttpPost]
        [ActionName("uploadImages")]
        public async Task<string> UploadImages([FromForm] FIleUploadAPI images)
        {
            if (images.RestaurantId == Guid.Empty)
                throw new InvalidOperationException("Restaurant id shouldn't be empty or  null");
            var restaurant = await Mediator.Send(new GetFoodBusinessByIdQuery { FoodBusinessId = images.RestaurantId }).ConfigureAwait(false);
            if (restaurant == null)
                return "Restaurant wasn't found";
            if (images.Files.Count <= 0)
                return "Unsuccessful";
            try
            {
                await FileHelper.SaveImagesAsync(images, images.Logo).ConfigureAwait(false);
                return $"{FileHelper.RestaurantImagesPath}{images.RestaurantId}\\";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        
    }
}
