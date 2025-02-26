using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Commands;
using SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Queries;
using SmartRestaurant.Application.Parametres.SocieteInfo.Commands;
using SmartRestaurant.Application.Parametres.SocieteInfo.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/societe")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Parametres")]
    public class ParametresController : ApiController
    {
        /// <summary> GetAllCLients() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("societeInfo")]
        public async Task<IActionResult> GetInfoSociete()
        {
            return await SendWithErrorsHandlingAsync(new GetSocieteInfoQuery
            {


            });
        }





        /// <summary> Add Client </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new mark</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost("societeInfo")]
        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Create([FromForm] CreateSocieteInfoCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateCLient() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update mark.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Route("societeInfo/{id:guid}")]
        public async Task<IActionResult> Update([FromForm] UpdateSocieteInfoCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }































        /// <summary> GetAllCLients() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("config")]
        public async Task<IActionResult> GetConfigDeafult()
        {
            return await SendWithErrorsHandlingAsync(new GetDefaultConfigQuery
            {


            });
        }





        /// <summary> Add Client </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new mark</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost("config")]
        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> CreateConfig([FromForm] CreateDefaultConfigCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateCLient() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update mark.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Route("config/{id:guid}")]
        public async Task<IActionResult> UpdateConfig([FromForm] UpdateDefaultConfigCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }





    }
}