using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.MediaModels;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/zones")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IEnumerable<ZoneDto>> Get([FromRoute] Guid id)
        {
            return SendAsync(new GetZonesListQuery {FoodBusinessId = id});
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<ZoneDto> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Zone id shouldn't be null or empty ");

            return SendAsync(new GetZoneByIdQuery {ZoneId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create(CreateZoneCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update(UpdateZoneCommand command)
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
            await SendAsync(new DeleteZoneCommand {ZoneId = id}).ConfigureAwait(false);
            return Ok("Successful");
        }

        [HttpPost]
        [Route("{id:Guid}/uploadImages")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> UploadImages([FromRoute] Guid id, [FromForm] FIleUploadModel images)
        {
            if (images.EntityId == Guid.Empty)
                throw new InvalidOperationException("Zone id shouldn't be null or empty");
            var zoneDto = await SendAsync(new GetZoneByIdQuery {ZoneId = images.EntityId}).ConfigureAwait(false);
            if (zoneDto == null)
                return BadRequest("Zone wasn't found");
            if (images.Files.Count <= 0)
                return BadRequest("Unsuccessful");
            var imageModels = FileHelper.SaveImagesAsync(images);
            var createImagesCommand = new CreateListImagesCommand();
            createImagesCommand.EntityId = zoneDto.ZoneId;
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