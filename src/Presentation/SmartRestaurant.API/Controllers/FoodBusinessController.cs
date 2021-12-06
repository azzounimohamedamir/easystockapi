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
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
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

        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public Task<IActionResult> GetByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListByAdmin());
        }

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
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateFoodBusinessCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteFoodBusinessCommand {Id = id});
        }    

        [HttpPatch("updateFourDigitCode")]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> UpdateFourDigitCode(UpdateFourDigitCodeCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpGet("getFourDigitCode")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager")]
        public async Task<IActionResult> GetFourDigitCode(GetFourDigitCodeFoodBusinessByIdQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}