using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.HotelDetailsSections.Queries;
using SmartRestaurant.Application.HotelDetailsSections.Commands;
using System.Threading.Tasks;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/detailsSection")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotel Sections")]
    public class HotelDetailsSectionController : ApiController
    {

        /// <summary> this endpoint is used to get a section details</summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to fetch section details.</remarks>
        /// <param name="id">id of the section that would be used to fetch section details</param>
        /// <response code="200"> Section details has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch seciton details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetHotelDetailsSectionByIdQuery { Id = id });
        }


        /// <summary> This endpoint is used to add a hotel section </summary>
        /// <remarks>This endpoint allows hotel managers to create a new section.</remarks>
        /// <param name="section">section object which will be added to the database.</param>
        /// <response code="200"> section has been successfully created.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
        public async Task<IActionResult> Create([FromForm] CreateHotelDetailsSectionCommand section)
        {
            return await SendWithErrorsHandlingAsync(section);  
        }

        /// <summary> This endpoint is used to update a hotel section </summary>
        /// <remarks>This endpoint allows hotel managers to update a section.</remarks>
        /// <param name="id">section object which will be updated in the database.</param>
        /// <param name="command">This is payload object used to update a section</param>
        /// <response code="200"> section has been successfully updated.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateHotelDetailsSectionCommand command)
        {
            command.hotelSetionId = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to delet a hotel section </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to delete a section.</remarks>
        /// <param name="id">id of the section that would be deleted</param>
        /// <response code="204">The section has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteHotelDetailsSectionCommand { Id = id });
        }
    }
}
