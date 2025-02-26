using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/favoir")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Facture avoir")]
    public class FactureAvoirController : ApiController
    {
        /// <summary> GetAllBonLivraisons() </summary>
        /// <remarks>This endpoint allows us to fetch list of Bls </remarks>
        /// <response code="200"> BLs list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllFacturesAvoir(string currentFilter, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetListOfFactureAvoirQuery
            {

                Page = page,
                PageSize = pageSize,
            });
        }



    }
}