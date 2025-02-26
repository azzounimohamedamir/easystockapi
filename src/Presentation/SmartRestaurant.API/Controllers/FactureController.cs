using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Commands;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Commands;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/fac")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Bill")]
    public class FactureController : ApiController
    {
        /// <summary> GetAllFactures() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedListDto<Facture>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> GetAllFactures(string currentFilter, int page, int pageSize, int caisse)
        {
            return await SendWithErrorsHandlingAsync(new GetFacturesListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
                Caisse = caisse
            });
        }


        /// <summary> GetAllRegelements/Acomptes List Of Client by Facture Id() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("reglementAcompteList")]
        public async Task<IActionResult> GetAllregelementsByFactureIdAndClient(int page, int pageSize, string clientId, string factureId)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfRegAcompteClientByFactureIdQuery
            {

                FactureId = Guid.Parse(factureId),
                ClientId = Guid.Parse(clientId),
                Page = page,
                PageSize = pageSize,
            });
        }




        [HttpGet]
        [Route("allreglementsclients")]
        public async Task<IActionResult> GetAllregelements(int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfRegAcompteClients
            {
                Page = page,
                PageSize = pageSize,
            });
        }


        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("reglementAcompte")]

        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> AjouterRegOuAcompteSurFacture(AjouterRegAcompteFactureCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }




        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("sendEmail")]
        public async Task<IActionResult> sendfacture([FromForm] SendFactureByEmailCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]


        /// <summary> AddNewFacture </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new BL</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Create(CreateFactureCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }





        /// <summary> GroupBL() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update BL.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPatch]
        [Route("groupFacts")]
        public async Task<IActionResult> GroupFacts(RegroupFactureCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> UpdateFac() </summary>
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
        public async Task<IActionResult> Update(UpdateFactureCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteFac() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("delete/{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> Cancel([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteFactureCommand { Id = id });
        }
    }
}