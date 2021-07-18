using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
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
        public async Task<ActionResult> Create(CreateReservationCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult, NoContent());
        }

        [Route("{id:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<ActionResult> Update([FromRoute] Guid id, UpdateReservationCommand command)
        {
            if (id != command.CmdId)
                return BadRequest();

            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult, NoContent());
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var validationResult = await SendAsync(new DeleteReservationCommand {CmdId = id}).ConfigureAwait(false);
            return ApiCustomResponse(validationResult, NoContent());
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<ReservationDto> Get([FromRoute] Guid id)
        {
            return SendAsync(new GetReservationByIdQuery { ReservationId = id });
        }

        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<PagedListDto<ReservationDto>> GetListByReservationDateTimeInterval(Guid foodBusinessId,
            DateTime timeIntervalStart, DateTime timeIntervalEnd, int page, int pageSize)
        {
            var query = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = foodBusinessId,
                TimeIntervalStart = timeIntervalStart,
                TimeIntervalEnd = timeIntervalEnd,
                Page = page,
                PageSize = pageSize
            };
            return SendAsync(query);
        }

        [Route("diners/reservationsDate/expired")]
        [HttpGet]
        [Authorize(Roles = "Diner")]
        public Task<PagedListDto<ReservationClientDto>> GetClientReservationsHistory(Guid dinerUserId, int page, int pageSize)
        {
            var query = new GetClientReservationsHistoryQuery
            {
                UserId = dinerUserId.ToString(),
                Page = page,
                PageSize = pageSize
            };
            return SendAsync(query);
        }      

        [Route("diners/reservationsDate/notExpired")]
        [HttpGet]
        [Authorize(Roles = "Diner")]
        public Task<PagedListDto<ReservationClientDto>> GetClientNonExpiredReservations(Guid dinerUserId, int page, int pageSize)
        {
            var query = new GetClientNonExpiredReservationsQuery
            {
                UserId = dinerUserId.ToString(),
                Page = page,
                PageSize = pageSize
            };
            return SendAsync(query);
        }
    }
}