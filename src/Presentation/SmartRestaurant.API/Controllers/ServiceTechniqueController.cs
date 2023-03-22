using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.ServiceTechniqueDestination.Commands;
using SmartRestaurant.Application.ServiceTechniqueDestination.Queries;
using SmartRestaurant.Application.TypeReclamation.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/serviceTechnique")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Service Technique")]
    public class ServiceTechniqueController : ApiController
    {

        /// <summary> GetListOfServiceTechniques() </summary>
        /// <remarks>This endpoint allows us to fetch list ServiceTechnique.</remarks>
        /// <param name="Id">If the Id is set, we will get ServiceTechnique list linked to that Id hotel we will get an empty list.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200">  types reclamations list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch  types reclamations list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ListingDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{HotelId:Guid}/list")]
        [Authorize(Roles = "FoodBusinessManager,HotelClient,HotelServiceAdmin,HotelServiceTechnique,FoodBusinessAdministrator")]
        public async Task<IActionResult> GetServiceTechniqueList([FromRoute] string HotelId, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetAllServiceTechniquesDestinationByHotelIdQuery
            { HotelId = HotelId, Page = page, PageSize = pageSize });
        }



        /// <summary> CreateNewServiceTechnique() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new Service Technique.<br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new reclamation type</param>
        /// <response code="204">The reclamation type has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new ServiceTechnique is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateServiceTechniqueCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateServiceTechnique() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update ServiceTechnique.<br></br>
        /// </remarks>
        /// <param name="id">id of ServiceTechnique that would be updated</param>
        /// <param name="command">This is the payload object used to update reclamation type</param>
        /// <response code="204">The reclamation type  has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a reclamationtype is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateServiceTechniqueCommand command)
        {
            command.Id = Id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteServiceTechnique() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete ServiceTechnique.</remarks>
        /// <param name="id">id of the ServiceTechnique that would be deleted</param>
        /// <response code="204">The ServiceTechnique  has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a reclamation type is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteServiceTechniqueCommand { Id = id });
        }




    }
}