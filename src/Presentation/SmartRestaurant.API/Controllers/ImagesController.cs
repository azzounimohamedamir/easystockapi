using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using Swashbuckle.AspNetCore.Annotations;

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


        /// <summary> GetAllImagesByEntityId() </summary>
        /// <remarks>
        ///     This endpoint is used to fetch all images for a pre-specified entity.
        ///     <br></br>
        ///     This is the list of entities names accepted by this endpoint : <b>FoodBusiness</b>, <b>Zone</b>, <b>Table</b>, <b>Menu</b>, <b>SubSection</b>.
        /// </remarks>
        /// <response code="200">
        ///     The list of images has been successfully fetched.
        ///     <br></br>
        ///     <b>images will be the form of Base64String</b>
        /// </response>
        /// <response code="400">The parameters sent to the backend-server in order to fetch the list of images are invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [HttpGet]
        [Route("entity/all-images")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public async Task<IActionResult> GetAllImagesByEntityId( string EntityId, string EntityName)
        {
            var query = new GetImagesByEntityIdQuery { 
                EntityId = EntityId,
                EntityName = EntityName
            };
            return await SendWithErrorsHandlingAsync(query);
        }
    }
}