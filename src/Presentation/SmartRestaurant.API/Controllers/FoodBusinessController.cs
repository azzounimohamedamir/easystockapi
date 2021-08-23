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

        /// <summary> This endpoint is used to get list of FoodBusinesses by FoodBusinessAdministrator </summary>
        /// <remarks> This endpoint is used to get list of FoodBusinesses by FoodBusinessAdministrator </remarks>
        /// <response code="200">The list of FoodBusinesses has been successfully fetched.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public Task<IActionResult> GetByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListByAdmin());
        }

        /// <summary> This endpoint is used to get list of FoodBusinesses by FoodBusinessManager </summary>
        /// <remarks> This endpoint is used to get list of FoodBusinesses by FoodBusinessManager </remarks>
        /// <response code="200">The list of FoodBusinesses has been successfully fetched.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
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
            return await SendWithErrorsHandlingAsync(new DeleteFoodBusinessCommand {Id = id});
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


        [HttpPatch]
        [Authorize(Roles ="FoodBusinessManager")]
        public async Task<IActionResult> UpdateFourDigitCode(UpdateFourDigitCodeCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        [Route("{IdentifierDevice}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager")]
        public async Task<IActionResult> GetFourDigitCode(GetFourDigitCodeFoodBusinessByIdQuery command)
        {
            return await SendWithErrorsHandlingAsync(new GetFourDigitCodeFoodBusinessByIdQuery { FoodBusinessId = command.FoodBusinessId });
        }



    }
}