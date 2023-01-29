using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.HotelServices.Queries;
using SmartRestaurant.Application.HotelServices.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/hotelServices")]
    [ApiController]
    public class HotelServiceController:ApiController
    {
        /// <summary> GetAllHotelServicesBySectionId() </summary>
        /// <remarks>This endpoint allows users to fetch list of hotel services.</remarks>
        /// <param name="sectionId">Is the hotel section Id we use the it to get hotel services list linked to that section .</param>
        /// <response code="200"> hotel services list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotel services list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(List<HotelServiceDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{sectionId:Guid}/list")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]
    
        public async Task<IActionResult> GetAllHotelServicesBySectionId([FromRoute] string sectionId)
        {
            return await SendWithErrorsHandlingAsync(new GetAllHotelServicesBySectionIdQuery { HotelSectionId = sectionId });
        }

        /// <summary> GetHotelServicesById() </summary>
        /// <remarks>This endpoint allows users to fetch one hotel service.</remarks>
        /// <param name="Id">Is the hotel service Id we use it to get the hotel service  .</param>
        /// <response code="200"> hotel service has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotel service is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(List<HotelServiceDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,HotelClient")]

        public async Task<IActionResult> GetHotelServicesById([FromRoute] string Id)
        {
            return await SendWithErrorsHandlingAsync(new GetHotelServiceByIdQuery { Id = Id });
        }


        /// <summary> UpdateHotelService() </summary>
        /// <remarks>This endpoint allows users to update one hotel services.</remarks>
        /// <param name="command">Is the hotel service informations we use it to update the hotel service  .</param>
        /// <param name="Id">Is the hotel service Id we use it to update the hotel service  .</param>
        /// <response code="200"> hotel service has been successfully updated.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to update hotel service is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]

        public async Task<IActionResult> UpdateHotelService([FromRoute] Guid Id,UpdateHotelServiceCommand command)
        {
            command.Id = Id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> CreateHotelService() </summary>
        /// <remarks>This endpoint allows users to create one hotel services.</remarks>
        /// <param name="command">Is the hotel service informations we use it to create the hotel service  .</param>
        /// <response code="200"> hotel service has been successfully created.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to create hotel service is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(List<Created>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]

        public async Task<IActionResult> CreateHotelService(CreateHotelServiceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteHotelService() </summary>
        /// <remarks>This endpoint allows hotel managers to delete one one hotel service.</remarks>
        /// <param name="Id">hotel service Id we use the it to delete hotel service with the specified Id .</param>
        /// <response code="200">hotel service has been successfully deleted.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete one hotel service is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>


        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpDelete]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> DeleteHotelService([FromRoute] Guid Id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteHotelServiceCommand { Id=Id});
        }
    }
}
