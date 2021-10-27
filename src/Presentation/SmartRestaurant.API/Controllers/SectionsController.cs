using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Sections.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/sections")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Menu Sections")]
    public class SectionsController : ApiController
    {
        [Route("menu/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetByMenuId([FromRoute] Guid id, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetSectionsListQuery
                {MenuId = id, Page = page, PageSize = pageSize});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteSectionCommand {Id = id});
        }

        /// <summary> GetSectionById() </summary>
        /// <remarks> This endpoint is used to get Sections details by id. </remarks>
        /// <param name="id">id of section that would be fetched.</param>
        /// <response code="200">Section details has been successfully fetched.</response>
        /// <response code="400">The Section-Id sent to the backend-server in order to fetch section details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(SectionDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetSectionByIdQuery { Id = id });
        }

        /// <summary> AddProductToSection() </summary>
        /// <remarks> This endpoint is used to add a new product to menu section. </remarks>
        /// <param name="command">This is payload object used to add a new product to menu section</param>
        /// <response code="204">The product has been successfully added to menu section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a new product to menu section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("add-product")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> AddProductToSection(AddProductToSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> AddDishToSection() </summary>
        /// <remarks> This endpoint is used to add a new dish to menu section. </remarks>
        /// <param name="command">This is payload object used to add a new dish to menu section</param>
        /// <response code="204">The dish has been successfully added to menu section.</response>
        /// <response code="400">The payload data sent to the backend-server in order to add a new dish to menu section is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("add-dish")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> AddDishToSection(AddDishToSectionCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
      
    }
}