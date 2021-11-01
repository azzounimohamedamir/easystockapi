using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Menus.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Menus")]
    public class MenusController : ApiController
    {

        /// <summary> GetListOfMenus() </summary>
        /// <remarks>This endpoint allows us to fetch list of menus.</remarks>
        /// <param name="currentFilter">Menus list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">Menus list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="foodBusinessId">foodBusinessId is the id of the foodBusiness we want to fetch its list of menus.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> Menus list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch menus list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<MenuDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> GetList(string foodBusinessId, string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetMenusListQuery
            { 
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                FoodBusinessId = foodBusinessId, 
                Page = page, 
                PageSize = pageSize 
            };
            return SendWithErrorsHandlingAsync(query);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetMenuByIdQuery {MenuId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateMenuCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateMenuCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteMenuCommand {Id = id});
        }
    }
}