using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System;

using Microsoft.AspNetCore.Http;
using System.IO;

using SmartRestaurant.Application.GestionAchats.BonsAchat.Queries;
using SmartRestaurant.Application.GestionAchats.BonsAchat.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/ba")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Bon Achat")]
    public class BonAchatController : ApiController
    {
        /// <summary> GetAllBonsAchat() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllBA(string currentFilter, int page, int pageSize)
        {
           return await SendWithErrorsHandlingAsync(new GetBAListQuery
            {

               Page = page,
               PageSize = pageSize,
               CurrentFilter= currentFilter,
            });
        }

       


        /// <summary> AddNewBA </summary>
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
        public async Task<IActionResult> Create(CreateBACommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }



     


        /// <summary> UpdateBA() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update BA.<br></br>
        /// </remarks>
        /// <param name="id">id of the building that would be updated</param>
        /// <param name="command">This is the payload object used to update building</param>
        /// <response code="204">The building has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update( UpdateBACommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteBA() </summary>
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
            return await SendWithErrorsHandlingAsync(new DeleteBACommand { Id = id });
        }




        /// <summary> GetAllRegelements/Acomptes List Of Client by Facture Id() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("reglementAcompteList")]
        public async Task<IActionResult> GetAllregelementsByBAIdAndFournisseur(int page, int pageSize, string fournisseurId, string baId)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfRegAcompteFournisseurByBaIdQuery
            {

                BaId = Guid.Parse(baId),
                FournisseurId = Guid.Parse(fournisseurId),
                Page = page,
                PageSize = pageSize,
            });
        }




        [HttpGet]
        [Route("allreglementsfournisseurs")]
        public async Task<IActionResult> GetAllregelements(int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfRegAcompteFournisseurs
            {
                Page = page,
                PageSize = pageSize,
            });
        }


        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("reglementAcompteFr")]

        // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> AjouterRegOuAcompteSurBA(AjouterRegAcompteBACommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


    }
}