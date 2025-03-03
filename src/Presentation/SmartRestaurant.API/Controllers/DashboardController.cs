﻿using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Dashboard.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Dashboard")]
    public class DashboardController : ApiController
    {
        /// <summary> GetAllCAmonthlyStats() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        [Route("CAstats")]
        public async Task<IActionResult> GetAllMonthlyStatCA()
        {
            return await SendWithErrorsHandlingAsync(new GetMonthStatsQuery
            {


            });
        }


    }
}