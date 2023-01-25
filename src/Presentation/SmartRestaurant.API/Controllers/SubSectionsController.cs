using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.SubSections.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/subSections")]
    [ApiController]
    public class SubSectionsController : ApiController
    {
        [Route("section/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,HotelClient,Diner")]
        public async Task<IActionResult> GetBySectionId([FromRoute] Guid id, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetSubSectionsListQuery
                {SectionId = id, Page = page, PageSize = pageSize});
        }

        [Route("allsubs/{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,HotelClient,Diner,Waiter")]
        public  Task<IActionResult> GetAllSubsectionsByFoodBusinessId([FromRoute] string id)
        {
            var query = new GetAllSubSectionsListQuery
            {
                FoodBusinessId = id
            };
            return SendWithErrorsHandlingAsync(query);
        }


      

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Create(CreateSubSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Update(UpdateSubSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteSubSectionCommand {Id = id});
        }

        /// <summary> GetSubSectionById() </summary>
        /// <remarks> This endpoint is used to get Sub-Sections details by id. </remarks>
        /// <param name="id">id of sub-section that would be fetched.</param>
        /// <response code="200">Sub-Section details has been successfully fetched.</response>
        /// <response code="400">The Sub-Section-Id sent to the backend-server in order to fetch sub-section details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(SubSectionDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetSubSectionByIdQuery { Id = id });
        }


        /// <summary> AddProductToSubSection() </summary>
        /// <remarks> This endpoint is used to add a new product to menu sub-section. </remarks>
        /// <param name="command">This is payload object used to add a new product to menu sub-section</param>
        /// <response code="204">The product has been successfully added to menu sub-section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a new product to menu sub-section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("add-product")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> AddProductToSubSection(AddProductToSubSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> AddDishToSubSection() </summary>
        /// <remarks> This endpoint is used to add a new dish to menu sub-section. </remarks>
        /// <param name="command">This is payload object used to add a new dish to menu sub-section</param>
        /// <response code="204">The dish has been successfully added to menu sub-section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a new dish to menu sub-section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("add-dish")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> AddDishToSubSection(AddDishToSubSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> RemoveProductFromSubSection() </summary>
        /// <remarks> This endpoint is used to remove product from menu sub-section. </remarks>
        /// <param name="id">id of sub-section that product belong to.</param>
        /// <param name="productId">id of product that would be removed from menu sub-section.</param>
        /// <response code="204">The product has been successfully removed from menu sub-section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to remove product from menu sub-section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/product/{productId}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> RemoveProductFromSubSection([FromRoute] string id, [FromRoute] string productId)
        {
            var command = new RemoveProductFromSubSectionCommand
            {
                SubSectionId = id,
                ProductId = productId
            };
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> RemoveDishFromSubSection() </summary>
        /// <remarks> This endpoint is used to remove dish from menu sub-section. </remarks>
        /// <param name="id">id of sub-section that dish belong to.</param>
        /// <param name="dishId">id of dish that would be removed from menu sub-section.</param>
        /// <response code="204">The dish has been successfully removed from menu sub-section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to remove dish from menu sub-section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/dish/{dishId}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        public async Task<IActionResult> RemoveDishFromSubSection([FromRoute] string id, [FromRoute] string dishId)
        {
            var command = new RemoveDishFromSubSectionCommand
            {
                SubSectionId = id,
                DishId = dishId
            };
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> GetSubSectionMenuItems() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to fetch list of menu items linked to sub-section.<br></br><b>Note:</b>Menu items can be either a product or dish</remarks>
        /// <param name="searchKey">Search keyword is used to filter results by <b>name</b></param>
        /// <param name="id">id of sub-section that we want to fetch its menu items.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of results that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> SubSection menu items has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch sub-section menu items is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<MenuItemDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}/menu-items")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,HotelClient,Diner")]
        public async Task<IActionResult> GetSubSectionMenuItems([FromRoute] string id, string searchKey, int page, int pageSize)
        {
            var query = new GetSubSectionMenuItemsQuery
            {
                SearchKey = searchKey,
                Page = page,
                PageSize = pageSize,
                SubSectionId = id
            };
            return await SendWithErrorsHandlingAsync(query);
        }
    }
}