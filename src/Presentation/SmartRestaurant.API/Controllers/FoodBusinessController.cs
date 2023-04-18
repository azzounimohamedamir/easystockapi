using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusiness")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusinesses")]
    public class FoodBusinessController : ApiController
    {
        /// <summary> GetListOfFoodBusinesses() </summary>
        /// <remarks>This endpoint allows us to fetch list of foodBusinesses.</remarks>
        /// <param name="currentFilter">FoodBusinesses list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">FoodBusinesses list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> FoodBusinesses list has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of foodBusinesses is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<FoodBusinessDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,Diner,Organization,Waiter")]
        public Task<IActionResult> Get(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetFoodBusinessListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }
        /// <summary> GetListOfFoodBusinessesByAdministrator() </summary>
        /// <remarks>This endpoint allows us to fetch list of foodBusinesses.</remarks>
        /// <response code="200"> FoodBusinesses list of Administrator has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of foodBusinesses is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public Task<IActionResult> GetByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListByAdmin());
        }
        /// <summary> GetListOfFoodBusinessesByFoodBusinessManager() </summary>
        /// <remarks>This endpoint allows us to fetch list of foodBusinesses by FoodBusinessManager .</remarks>
        /// <response code="200"> FoodBusinesses list of Manager has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of foodBusinesses is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("byFoodBusinessManager")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,SuperAdmin,Waiter")]
        public Task<IActionResult> GetAllFoodBusinessByFoodBusinessManager()
        {
            return SendWithErrorsHandlingAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());
        }

        /// <summary> GetAllFoodBusinessAcceptDelivery()() </summary>
        /// <remarks>This endpoint allows us to fetch list of foodBusinesses that accept delivery of current Diner  .</remarks>
        /// /// <param name="currentFilter">FoodBusinesses list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">FoodBusinesses list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> FoodBusinesses list of Diner that accept delivery has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of foodBusinesses is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("thatAcceptDelivery")]
        [HttpGet]
        [Authorize(Roles = "Diner")]
        public Task<IActionResult> GetAllFoodBusinessthatAcceptDelivery(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetAllFoodBusinessAccpetsImportationQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }
        /// <summary> GetListOfFoodBusinessByUser() </summary>
        /// <remarks>This endpoint allows us to fetch list of Food Business of Current Administrator </remarks>
        /// <param name="id">Id of connected user</param>
        /// <response code="200"> Food Business list has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch Food Business list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,Diner,Organization,Waiter,HotelClient")]
        public Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessByIdQuery { FoodBusinessId = id });
        }

        /// <summary> CreateNewFoodBusiness() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new FoodBusiness.<br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new FoodBusiness</param>
        /// <response code="204">The FoodBusiness has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new FoodBusiness is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateFoodBusiness() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update Food Business.<br></br>
        /// </remarks>
        /// <param name="id">id of the Food Business that would be updated</param>
        /// <param name="command">This is the payload object used to update FB</param>
        /// <response code="204">The Food Business has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a FB is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateFoodBusinessCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteFoodBusiness() </summary>
        /// <remarks>This endpoint allows <b>Food Business Administrator</b> to delete Food Business.</remarks>
        /// <param name="id">id of the Food business that would be deleted</param>
        /// <response code="204">The Food business has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a Food business is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteFoodBusinessCommand { Id = id });
        }


        /// <summary> UpdateUpdateFourDigitCode() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update FourDigitCode.<br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to update FourDigitCode</param>
        /// <response code="204">The FourDigitCode has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a FourDigitCode is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPatch("updateFourDigitCode")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> UpdateFourDigitCode(UpdateFourDigitCodeCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> GetFourDigitCode() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to get FourDigitCode.<br></br>
        /// </remarks>
        /// <param name="command">This is the payload object used to get FourDigitCode</param>
        /// <response code="204">The FourDigitCode has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to get a FourDigitCode is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet("getFourDigitCode")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> GetFourDigitCode(GetFourDigitCodeFoodBusinessByIdQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> ToggleFoodBusinessFreezingStatus() </summary>
        /// <remarks>This endpoint allows user to toggle FoodBusiness freezing status.</remarks>
        /// <param name="id">id of the FoodBusiness that we would like to toggle its freezing status</param>
        /// <response code="204">FoodBusiness freezing status has been successfully toggled.</response>
        /// <response code="400">The payload data sent to the backend-server in order to toggle FoodBusiness freezing status is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [HttpPatch]
        [Route("{id}/toggle-freezing-status")]
        [Authorize(Roles = "SuperAdmin,SupportAgent,SalesMan")]
        public async Task<IActionResult> ToggleFoodBusinessFreezingStatus([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new ToggleFoodBusinessFreezingStatusCommand { FoodBusinessId = id });
        }

        /// <summary> UpdateRating() </summary>
        /// <remarks>This endpoint allows the diner user to rate the FoodBusiness.</remarks>
        /// <param name="id">id of the FoodBusiness that we would like to rate</param>
        /// <response code="204">FoodBusiness rating status has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to rate the FoodBusiness is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [HttpPut]
        [Route("{id}/update-rating")]
        [Authorize(Roles = "Diner")]
        public async Task<IActionResult> UpdateRating([FromRoute] string id, UpdateFoodBusinessRatingCommand command)
        {
            command.FoodBusinessId = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}