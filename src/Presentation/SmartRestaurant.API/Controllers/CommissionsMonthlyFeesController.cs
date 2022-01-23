using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.CommissionsMonthlyFees.Commands;
using SmartRestaurant.Application.CommissionsMonthlyFees.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/commissions")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Monthly Commissions")]
    public class CommissionsMonthlyFeesController : ApiController
    {      
        /// <summary> GetMonthlyCommissionListByFoodBusinessUser() </summary>
        /// <remarks>This endpoint allows FoodBusiness User to fetch list of monthly commission for the selected FoodBusiness.</remarks>
        /// <param name="foodBusinessId">id of foodBusiness that we would like to get its list of monthly commission.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> List of monthly commission has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of monthly commission is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<CommissionConfigsDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator")]
        [Route("monthly-commissions-by-foodbusiness-user")]
        [HttpGet]
        public Task<IActionResult> GetMonthlyCommissionListByFoodBusinessUser(string foodBusinessId, int page, int pageSize)
        {
            var query = new GetMonthlyCommissionListByFoodBusinessUserQuery
            {
                FoodBusinessId = foodBusinessId,
                Page = page,
                PageSize = pageSize
            };
            return SendWithErrorsHandlingAsync(query);
        }


        /// <summary> GetMonthlyCommissionListBySmartRestaurantUser() </summary>
        /// <remarks>This endpoint allows SmartRestaurant User to fetch list of monthly commissions for the selected FoodBusiness.</remarks>
        /// <param name="currentFilter">List of monthly commission can be filtred by: <b>foodbusinessname</b> | <b>foodbusinessadmin</b>. Default value is: <b>foodbusinessname</b></param>
        /// <param name="searchKey">Search keyword</param>        
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> List of monthly commission has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch list of monthly commission is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<CommissionConfigsDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "SuperAdmin,SupportAgent,SalesMan")]
        [Route("monthly-commissions-by-smartrestaurant-user")]
        [HttpGet]
        public Task<IActionResult> GetMonthlyCommissionListBySmartRestaurantUser(string searchKey, string currentFilter, int page, int pageSize)
        {
            var query = new GetMonthlyCommissionListBySmartRestaurantUserQuery
            {
                SearchKey = searchKey,
                CurrentFilter = currentFilter,
                Page = page,
                PageSize = pageSize
            };
            return SendWithErrorsHandlingAsync(query);
        }


        /// <summary> CalculateLastMonthCommissionFees() </summary>
        /// <remarks>This endpoint allows user to manually Calculate Last Month Commission Fees for all foodbusinesses in database. </remarks>        
        /// <response code="204">Calculation last month commission fees has been successfully done.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("calculate-last-month-fees")]
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,SupportAgent,SalesMan")]
        public async Task<IActionResult> CalculateLastMonthCommissionFees()
        {
            return await SendWithErrorsHandlingAsync(new CalculateLastMonthCommissionFeesCommand());
        }


        /// <summary> FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFees() </summary>
        /// <remarks>This endpoint allows user to manually freeze all FoodBusiness activities that has not paid commission fees.</remarks>        
        /// <response code="204">Freezing FoodBusiness activities that has not paid its commission fees has been successfully done.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("freeze-foodBusiness-activities")]
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,SupportAgent,SalesMan")]
        public async Task<IActionResult> FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFeesCommand()
        {
            return await SendWithErrorsHandlingAsync(new FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFeesCommand());
        }
    }
}