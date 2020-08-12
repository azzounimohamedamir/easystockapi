using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.MediaModels;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("{id:Guid}/zones/")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        [ActionName("")]
        public Task<IEnumerable<ZoneDto>> Get([FromRoute] Guid id)
        {
            return SendAsync(new GetZonesListQuery { FoodBusinessId = id });
        }
        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        [ActionName("")]
        public Task<ZoneDto> GetById([FromRoute] Guid id, [FromRoute] Guid zoneId)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Food business id shouldn't be null or empty ");
            if (zoneId == Guid.Empty)
                throw new InvalidOperationException("Zone id shouldn't be null or empty ");

            return SendAsync(new GetZoneByIdQuery { ZoneId = zoneId });
        }
        [Route("{id:Guid}/zones/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute] Guid id, CreateZoneCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromRoute] Guid zoneId, UpdateZoneCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            if (zoneId != command.CmdId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }

        [Route("{id:Guid}/zones/{zoneId:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromRoute] Guid zoneId)
        {
            if (id == Guid.Empty)
                return BadRequest();
            if (zoneId == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteZoneCommand { ZoneId = zoneId }).ConfigureAwait(false);
            return Ok("Successful");
        }
        [HttpPost]
        [Route("{id:Guid}/zones/{zoneId:Guid}/uploadImages")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> UploadImages([FromRoute] Guid id, [FromRoute] Guid zoneId, [FromForm] FIleUploadModel images)
        {
            if (images.EntityId == Guid.Empty)
                throw new InvalidOperationException("Zone id shouldn't be null or empty");
            if (zoneId != images.EntityId)
                return BadRequest();
            var zoneDto = await SendAsync(new GetZoneByIdQuery { ZoneId = images.EntityId }).ConfigureAwait(false);
            if (zoneDto == null)
                return BadRequest("Zone wasn't found");
            if (images.Files.Count <= 0)
                return BadRequest("Unsuccessful");
            var imageModels = FileHelper.SaveImagesAsync(images);
            var createImagesCommand = new CreateListImagesCommand();
            createImagesCommand.EntityId = zoneDto.ZoneId;
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
        [Route("{id:Guid}/zones/{zoneId:Guid}/allImages")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]

        public async Task<IEnumerable<string>> GetAllImagesByFoodBusinessId([FromRoute] Guid id, [FromRoute] Guid zoneId)
        {
            var query = await SendAsync(new GetImagesByEntityIdQuery { EntityId = zoneId }).ConfigureAwait(false);
            return query.Select(Convert.ToBase64String);
        }
    }
}