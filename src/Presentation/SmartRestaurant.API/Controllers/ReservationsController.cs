using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Reservations.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Create(CreateReservationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateReservationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteReservationCommand {CmdId = id}).ConfigureAwait(false);
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetReservationByIdQuery {ReservationId = id});
        }

        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> GetListByReservationDateTimeInterval(Guid foodBusinessId,
            DateTime timeIntervalStart, DateTime timeIntervalEnd, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = foodBusinessId,
                TimeIntervalStart = timeIntervalStart,
                TimeIntervalEnd = timeIntervalEnd,
                Page = page,
                PageSize = pageSize
            });
        }

        [Route("diners/reservationsDate/expired")]
        [HttpGet]
        [Authorize(Roles = "Diner")]
        public async Task<IActionResult> GetClientReservationsHistory(Guid dinerUserId, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetClientReservationsHistoryQuery
            {
                UserId = dinerUserId.ToString(),
                Page = page,
                PageSize = pageSize
            });
        }

        [Route("diners/reservationsDate/notExpired")]
        [HttpGet]
        [Authorize(Roles = "Diner")]
        public async Task<IActionResult> GetClientNonExpiredReservations(Guid dinerUserId, int page, int pageSize)
        {
            return await SendWithErrorsHandlingAsync(new GetClientNonExpiredReservationsQuery
            {
                UserId = dinerUserId.ToString(),
                Page = page,
                PageSize = pageSize
            });
        }
    }
}