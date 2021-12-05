using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/zones")]
    [ApiController]
    public class ZonesController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetZonesListQuery {FoodBusinessId = id});
        }
        /// <summary> GetWithTable() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> and <b>Support Agent</b> to fetch zone with tables.</remarks>
        /// <param name="id">id of the Food Buisines that would be used to fetch zone and table</param>
        /// <response code="200"> Zone with tables has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch product details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(IEnumerable<ZoneWithTablesDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("ZoneWithTables/{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
        public async Task<IActionResult> GetWithTable([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetZonesListWithTablesQuery { FoodBusinessId = id });
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new GetZoneByIdQuery {ZoneId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateZoneCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateZoneCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            return (ActionResult) await SendWithErrorsHandlingAsync(new DeleteZoneCommand {Id = id});
        }
    }
}