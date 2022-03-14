using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.Ingredients.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Ingredients")]
    public class IngredientsController : ApiController
    {
        /// <summary> GetListOfIngredients() </summary>
        /// <remarks>This endpoint allows us to fetch list of ingredients.</remarks>
        /// <param name="currentFilter">Products list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">Ingredients list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> Ingredients list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch ingredients list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<IngredientDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        [HttpGet]
        public Task<IActionResult> GetList(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetIngredientsListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }


        /// <summary> GetIngredientDetails() </summary>
        /// <remarks>This endpoint allows us to fetch Ingredient details.</remarks>
        /// <param name="id">id of the ingredient that would be used to fetch ingredient details</param>
        /// <response code="200"> Ingredient details has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch ingredient details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(IngredientDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin")]
        [HttpGet]
        public Task<IActionResult> Get([FromRoute] string id)
        {
            return SendWithErrorsHandlingAsync(new GetIngredientByIdQuery {Id = id});
        }


        /// <summary> CreateNewIngredient() </summary>
        /// <remarks>
        ///     This endpoint allows <b>Support Agent</b> to create a new ingredient.<br></br>
        ///     <b>Note 01:</b> This is the enum used to set ingredient measurement unit: <b> enum MeasurementUnits { Gramme, KiloGramme, MilliLiter, Liter, Unit }</b><br></br>
        ///     <b>Note 02:</b> Ingredient names must be in the format of Json string. 
        ///     <b>Example:</b> [{"name":"Black pepper","language":"en"},{"name":"الفلفل الاسود","language":"ar"},{"name":"Le poivre noir","language":"fr"}]   
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new ingredient</param>
        /// <response code="204">The ingredient has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new ingredient is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateIngredientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateIngredient() </summary>
        /// <remarks>
        ///     This endpoint allows <b>Support Agent</b> to update ingredient.<br></br>
        ///     <b>Note 01:</b> This is the enum used to set ingredient measurement unit: <b> enum MeasurementUnits { Gramme, KiloGramme, MilliLiter, Liter, Unit }</b><br></br>
        ///     <b>Note 02:</b> Ingredient names must be in the format of Json string. 
        ///     <b>Example:</b> [{"name":"Black pepper","language":"en"},{"name":"الفلفل الاسود","language":"ar"},{"name":"Le poivre noir","language":"fr"}]   
        /// </remarks>
        /// <param name="id">id of the Ingredient that would be updated</param>
        /// <param name="command">This is the payload object used to update ingredient</param>
        /// <response code="204">The ingredient has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update ingredient is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateIngredientCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> DeleteIngredient() </summary>
        /// <remarks>This endpoint allows <b>Support Agent</b> to delete ingredient.</remarks>
        /// <param name="id">id of the ingredient that would be deleted</param>
        /// <response code="204">The ingredient has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete ingredient is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteIngredientCommand {Id = id});
        }
    }
}