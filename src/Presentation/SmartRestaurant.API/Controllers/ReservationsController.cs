using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Sections.Queries;

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

        [Route("reservations")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Update(UpdateReservationCommand command)
        {
            var validationResult = await SendAsync(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult, NoContent());
        }

        [Route("{id:Guid}/reservations/")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            await SendAsync(new DeleteReservationCommand {ReservationId = id}).ConfigureAwait(false);
            return Ok("Successful");
        }

        [Route("{id:Guid}/reservations/")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<PagedListDto<ReservationDto>> GetListByReservationDateTimeInterval([FromRoute] Guid id,
            DateTime timeIntervalStart, DateTime timeIntervalEnd, int page, int pageSize)
        {
            var query = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = id,
                TimeIntervalStart = timeIntervalStart,
                TimeIntervalEnd = timeIntervalEnd,
                Page = page,
                PageSize = pageSize
            };
            return SendAsync(query);
        }
    }
}