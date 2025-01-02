using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using SmartRestaurant.Application.GestionStock.Inventaire.Commands;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Menus.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.GestionStock.Inventaire.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/inventaire")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Inventaire")]
    public class InventaireController : ApiController
    {
        /// <summary> GetAllStock() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllInventoryRapportList(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetInventoryValidatedListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
            });
        }


        [HttpGet]
        [Route("lignesFinal")]
        public async Task<IActionResult> GetAllInventoryLignesFinalList(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetInventoryLignesFinalListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
            });
        }


        [HttpGet]
        [Route("check")]
        public async Task<IActionResult> CheckInventoryAlreadyExist()
        {
            return await SendWithErrorsHandlingAsync(new CheckInventaireEquipeQuery
            {

                
            });
        }


        /// <summary> AddNewProduct To Stock() </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new building</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Create([FromForm] CreateInventaireParEquipeCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> Import Data To Stock() </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new building</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        //[HttpPost("import")]
        //public async Task<IActionResult> ImportStocks(IFormFile file)
        //{
        //    if (file == null || file.Length <= 0)
        //    {
        //        return BadRequest("Invalid file");
        //    }

        //    using var memoryStream = new MemoryStream();
        //    await file.CopyToAsync(memoryStream);

        //    var command = new ImportStockFromExcelCommand
        //    {
        //        ExcelFileData = memoryStream.ToArray()
        //    };

        //    return await SendWithErrorsHandlingAsync(command);

        //}
            /// <summary> UpdateBuilding() </summary>
            /// <remarks>
            ///     This endpoint allows SM user to update building.<br></br>
            /// </remarks>
            /// <param name="id">id of the building that would be updated</param>
            /// <param name="command">This is the payload object used to update building</param>
            /// <response code="204">The building has been successfully updated.</response>
            /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
            /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
            /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
            [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> ValiderInventaire([FromForm] ValiderInventaireCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Route("reglerEcarts")]
        public async Task<IActionResult> ReglerEcartsInventaire([FromForm] ReglerEcartsInventaireCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        [HttpPut]
        [Route("resetInvEquipe")]
        public async Task<IActionResult> ResetInventaire([FromBody] ResetInventaireCommand command)
        {
            // No need to convert numeric representation to the enum type here
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteBuilding() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        //[Route("{id:guid}")]
        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    return await SendWithErrorsHandlingAsync(new DeleteProductFromStockCommand { Id = id });
        //}
    }
}