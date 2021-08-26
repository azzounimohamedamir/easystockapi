using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.Resources.Queries;
using System.Collections.Generic;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/resources")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Application Resources")]
    public class ResourcesController : ApiController
    {


        /// <summary> GetListOfCountries() </summary>
        /// <remarks> This endpoint allows any user to get a list of countries </remarks>
        /// <response code="200">The list of countries has been successfully fetched.</response>
        [ProducesResponseType(typeof(List<Countries>), 200)]
        [Route("countries")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetListOfCountries()
        {
            return await SendWithErrorsHandlingAsync(new GetListOfCountriesQuery());
        }

       
    }
}