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
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands;
using SmartRestaurant.Application.GestionVentes.RetourProduits.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/retourproduits")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Returned products")]
    public class RetourProduitsController : ApiController
    {
        /// <summary> GetAllBonLivraisons() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAllRetourProductsClient(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfRetourProduitsQuery
            {

                Page = page,
                PageSize = pageSize,
            });
        }


     
    }
}