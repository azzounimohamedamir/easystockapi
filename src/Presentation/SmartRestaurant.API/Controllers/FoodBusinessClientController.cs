using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Queries;


namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessClient")]
    [ApiController]
    public class FoodBusinessClientController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateFoodBusinessClientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> This endpoint is used to update a FoodBusinessClient </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Client</b> to update FoodBusinessClient created by him.
        ///     <br></br>
        ///     2- This endpoint allows <b>foodBusinessClientManager</b> to update FoodBusinessClient.
        /// </remarks>
        /// <param name="command">This is Json object user update reservation</param>
        /// <param name="id">Id of foodBusinessClient which we want to Update</param>
        /// <response code="200">The FoodBusinessClient has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a FoodBusinessClient is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateFoodBusinessClientCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> This endpoint is used to get a FoodBusinessClient list </summary>
        /// <remarks>
        ///     This endpoint allows <b>foodBusinessManager</b> to get a list of FoodBusinessClients 
        /// </remarks>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of FoodBusinessClients that should be returned</param>
        /// <response code="200">The list of FoodBusinessClient has been successfully fetched.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(FoodBusinessClientDto), 200)]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public Task<IActionResult> GetFoodBusinesClientList(int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinesClientListQuery { Page = page, PageSize = pageSize });
        }

        /// <summary> This endpoint is used to get a FoodBusinessClient details </summary>
        /// <remarks> This endpoint allows <b>FoodBusinessClient Manager</b> to get FoodBusinessClient details. </remarks>
        /// <param name="id">id of FoodBusinessClient that would be fetched.</param>
        /// <response code="200">The FoodBusinessClient details has been successfully fetched.</response>
        /// <response code="400">The FoodBusinessClient-Id sent to the backend-server in order to fetch FoodBusinessClient details is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(FoodBusinessClientDto), 200)]
        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessClientByIdQuery { FoodBusinessClientId = id });
        }
        /// <summary> This endpoint is used to get a FoodBusinessClient By ManagerId </summary>
        /// <remarks>
        ///     This endpoint allows <b>foodBusinessClient Manager</b> to get  his FoodBusinessClient
        /// </remarks>
        /// <param name="id">id of FoodBusinessClient Manager that would be fetched.</param>
        /// <response code="200">The FoodBusinessClient has been successfully fetched.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public Task<IActionResult> GetFoodBusinessClientListByManagerIdQuery([FromRoute] string id)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessClientByManagerIdQuery());
        }

        /// <summary> This endpoint is used to get a FoodBusinessClient By Email </summary>
        /// <remarks>
        ///     This endpoint allows <b>foodBusinessClient Manager</b> to get his FoodBusinessClient
        /// </remarks>
        /// <param name="Email"> FoodBusinessClient email that would be fetched.</param>
        /// <response code="200">The FoodBusinessClient has been successfully fetched.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [Route("{Email}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public Task<IActionResult> GetFoodBusinessClientListByEmailQuery([FromRoute] string Email)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessClientByEmailQuery());
        }
    }
}
