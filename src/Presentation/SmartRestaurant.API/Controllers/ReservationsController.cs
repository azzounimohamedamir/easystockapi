using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Reservations.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/foodbusiness")]
    [ApiController]
    public class ReservationsController : ApiController
    {
        [Route("{id:Guid}/reservations/")]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Create([FromRoute] Guid id, CreateReservationCommand command)
        {
            if (id != command.FoodBusinessId)
                return BadRequest();
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);
        }
    }
}