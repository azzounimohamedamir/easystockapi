using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.AdminArea.Commands;
using SmartRestaurant.Application.AdminArea.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/adminarea")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Admin Area")]
    public class AdminAreaController : ApiController
    {
        /// <summary> GetAllCLients() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("clients")]

        public async Task<IActionResult> GetAllAppClientsList(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetClientsAppListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
            });
        }


        [HttpGet]
        [Route("licenses")]

        public async Task<IActionResult> GetAllLicencesClientsList(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetAllLicencesClientsListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
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
        [HttpPost]
        [Authorize(Roles = "SupportAgent")]
        [Route("clients")]
        public async Task<IActionResult> CreateClient([FromForm] CreateClientAppCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }



        [HttpPost]
        [Authorize(Roles = "SupportAgent")]
        [Route("newAdmin")]
        public async Task<IActionResult> CreateNewAdmin([FromForm] CreateClientAppCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        [HttpPost]
        [Authorize(Roles = "SupportAgent")]
        [Route("licence")]
        public async Task<IActionResult> CreateLic([FromForm] CreateLicenceCommand command)
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
        [Route("client/{id:guid}")]
        public async Task<IActionResult> Update([FromForm] UpdateClientAppCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Route("licence/{id:guid}")]

        public async Task<IActionResult> Update([FromForm] UpdateLicenceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }



        /// <summary> AssainirCLient() </summary>
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
        [Route("licence/reset/{id:guid}")]

        public async Task<IActionResult> ResetLicence([FromRoute] ResetLicenceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteClient() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>



    }
}