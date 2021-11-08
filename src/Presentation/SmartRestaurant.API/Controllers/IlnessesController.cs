using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.Illness.Queries;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/illness")]
    [ApiController]
    public class IlnessesController :  ApiController
    {
        /// <summary> This endpoint is used to create an Illness </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Mananger</b> to create Illness.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object user create Illness</param>
        /// <response code="204">The Illness has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create an Illness is invalid.</response>
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
        [Authorize(Roles = "SupportAgent")]
        public async Task<IActionResult> Create(CreateIllnessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to List Illnesses </summary>
        /// <remarks>This endpoint allows us to fetch list of illnesses.</remarks>
        /// <param name="currentFilter">illnesses list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">illnesses list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> illnesses list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch illnesses list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<IllnessDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "SupportAgent")]
        [HttpGet]
        public Task<IActionResult> GetList(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetIllnessesListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }
    }
}
