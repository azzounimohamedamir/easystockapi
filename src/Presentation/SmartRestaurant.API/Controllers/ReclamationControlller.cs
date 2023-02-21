using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Reclamation.Queries;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Application.Reclamation.Queries;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.Orders.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels/reclamations")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Reclamation")]
    public class ReclamationController : ApiController
    {


        /// <summary> GetListOfReclamationsForManagerAndHotelServiceAdmin() </summary>
        /// <remarks>This endpoint allows us to fetch list of reclamations for manager by hotel.</remarks>
        /// <param name="currentFilter">hotels list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">reclamation list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="Id"> we will get reclamation list linked to that Id else we will get an empty list.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> hotels list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch reclamation list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>


        [ProducesResponseType(typeof(PagedListDto<ReclamationDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{HotelId:Guid}/list")]
        [Authorize(Roles = "FoodBusinessManager , FoodBusinessAdministrator , HotelServiceAdmin")]
        public async Task<IActionResult> GetReclamationList([FromRoute] string HotelId, int page, int pageSize, string searchKey, string currentFilter, string sortOrder)
        {
            return await SendWithErrorsHandlingAsync(new GetAllReclamationListQuery
            { HotelId = HotelId,
              Page = page, 
              PageSize = pageSize,  
              CurrentFilter= currentFilter,
              SortOrder = sortOrder,
              SearchKey = searchKey
            });
        }


        /// <summary> GetListOfReclamationsForClientHotel() </summary>
        /// <remarks>This endpoint allows us to fetch list of reclamations for client.</remarks>
        /// <param name="currentFilter">hotels list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">reclamation list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="Id"> we will get reclamation list linked to that Id else we will get an empty list.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> hotels list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch reclamation list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(PagedListDto<ReclamationDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("reclamationsOfClient")]
        [Authorize(Roles = "HotelClient")]
        public async Task<IActionResult> GetReclamationOfClientList( int page, int pageSize,string searchKey , string currentFilter, string sortOrder)
        {
            return await SendWithErrorsHandlingAsync(new GetAllReclamationOfClientQuery
            { 
                Page = page,
                PageSize = pageSize ,
                SearchKey=searchKey,
                SortOrder=sortOrder,
                CurrentFilter=currentFilter 
            });
        }
        /// <summary> CreateNewReclamation() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new reclamation.<br></br>
        ///     <b>Note 01:</b> Picture should be encoded in Base64
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new reclamation</param>
        /// <response code="204">The reclamation has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new reclamation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "HotelClient,Diner")]
        public async Task<IActionResult> Create([FromForm] CreateReclamationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UpdateReclamation() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update reclamation.<br></br>
        ///     <b>Note 01:</b> Picture should be encoded in Base64
        /// </remarks>
        /// <param name="id">id of the reclamation that would be updated</param>
        /// <param name="command">This is the payload object used to update reclamation</param>
        /// <response code="204">The reclamation  has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a reclamation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(NoContent), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "HotelClient")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateReclamationCommand command)
        {
            command.Id = Id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> UpdateReclamationStatus() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update reclamation status.<br></br>
        ///     <b>Note 01:</b> Picture should be encoded in Base64
        /// </remarks>
        /// <param name="id">id of the reclamation that would be updated</param>
        /// <param name="command">This is the payload object used to update reclamation status</param>
        /// <response code="204"> reclamation status has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a reclamation status is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/status")]
        [HttpPatch]
        [Authorize(Roles = "FoodBusinessManager,HotelClient")]
        public async Task<IActionResult> UpdateReclamationStatus([FromRoute] string id, UpdateReclamationStatusCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> DeleteReclamation() </summary>
        /// <remarks>This endpoint allows <b>Food Business Administrator</b> to delete reclamation.</remarks>
        /// <param name="id">id of the reclamation that would be deleted</param>
        /// <response code="204">The reclamation has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a reclamation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "HotelClient")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteReclamationCommand { Id = id });
        }




    }
}