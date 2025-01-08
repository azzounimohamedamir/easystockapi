using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System;

using Microsoft.AspNetCore.Http;
using System.IO;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Commands;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Application.Stock.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/categ")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Categories")]
    public class CategController : ApiController
    {



        /// <summary> AddNewBL </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new BL</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]

        public async Task<IActionResult> Create([FromForm] AddCategoryCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }







        /// <summary> UpdateBL() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update BL.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update( UpdateBlCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteBL() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteBlCommand { Id = id });
        }


        [Route("getCat")]
        [HttpGet]
        public async Task<IActionResult> GetCateg()
        {
            return await SendWithErrorsHandlingAsync(new GetCategorieQuery {  });
        }
    }
}