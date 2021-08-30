using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Examples.Reservation;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Reservations.Queries;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/images")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on application images")]
    public class ImagesController : ApiController
    {
        /// <summary> UploadEntityImages() </summary>
        /// <remarks>
        ///     This endpoint is used to upload images for a pre-specified entity.
        ///     <br></br>
        ///     This is the list of entities names accepted by this endpoint : <b>FoodBusiness</b>, <b>Zone</b>, <b>Table</b>, <b>Menu</b>, <b>SubSection</b>.
        ///     <br></br><br></br>
        ///     Request body is the payload object used to upload images.
        ///     <br></br>
        ///     <b>EntityId</b> is the id of the entity we want to upload images for it.
        ///     <br></br>
        ///     <b>EntityName</b> is the name of the entity we want to upload images for it. 
        ///     We can only pick one of the following values for EntityName  <b>FoodBusiness</b>, <b>Zone</b>, <b>Table</b>, <b>Menu</b>, <b>SubSection</b>.
        ///     <br></br>
        ///     <b>Images</b> is the list of images to upload.
        /// </remarks>
        /// <response code="204">The images has been successfully uploaded.</response>
        /// <response code="400">The payload sent to the backend-server in order to upload images is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("entity/upload-images")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> UploadEntityImages([FromForm] UploadListOfImagesCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UploadEntityLogo() </summary>
        /// <remarks>
        ///     This endpoint is used to upload the logo for a pre-specified entity.
        ///     <br></br>
        ///     This is the list of entities names accepted by this endpoint : <b>FoodBusiness</b>, <b>Zone</b>, <b>Table</b>, <b>Menu</b>, <b>SubSection</b>.
        ///     <br></br><br></br>
        ///     Request body is the payload object used to upload logo.
        ///     <br></br>
        ///     <b>EntityId</b> is the id of the entity we want to upload the logo for it.
        ///     <br></br>
        ///     <b>EntityName</b> is the name of the entity we want to upload the logo for it. 
        ///     We can only pick one of the following values for EntityName  <b>FoodBusiness</b>, <b>Zone</b>, <b>Table</b>, <b>Menu</b>, <b>SubSection</b>.
        ///     <br></br>
        ///     <b>Image</b> is the logo image.
        /// </remarks>
        /// <response code="204">The logo has been successfully uploaded.</response>
        /// <response code="400">The payload sent to the backend-server in order to upload the logo is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("entity/upload-logo")]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> UploadEntityLogo([FromForm] UploadLogoCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}