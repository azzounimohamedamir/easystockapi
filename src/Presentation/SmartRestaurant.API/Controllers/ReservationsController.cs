using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Examples.Reservations;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Reservations.Queries;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on FoodBusiness Reservations")]
    public class ReservationsController : ApiController
    {
        /// <summary> This endpoint is used to creates a new Reservation </summary>
        /// <remarks>
        /// 1- This endpoint allows <b>customer</b> to create a new reservation.
        /// <br></br>
        /// 2- This endpoint allows <b>foodBusinessManager</b> to create a reservation for a customer based on his request.
        /// </remarks>
        /// <param name="command">This is Json object user create a new reservation</param>
        /// <response code="204">The Reservation has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new reservation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [SwaggerRequestExample(typeof(CreateReservationCommandForSwaggerExamples), typeof(CreateReservationCommandExamples))]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Create(CreateReservationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to update a Reservation </summary>
        /// <remarks>
        /// 1- This endpoint allows <b>customer</b> to update reservation created by him. 
        /// <br></br>
        /// 2- This endpoint allows <b>foodBusinessManager</b> to update customer reservation.
        /// </remarks>
        /// <param name="command">This is Json object user update reservation</param>
        /// <response code="204">The Reservation has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a reservation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id:Guid}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateReservationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to delete a Reservation </summary>
        /// <remarks>
        /// 1- This endpoint allows <b>customer</b> to delete reservation created by him. 
        /// <br></br>
        /// 2- This endpoint allows <b>foodBusinessManager</b> to delete reservation.
        /// </remarks>
        /// <param name="id">id of reservation that would be deleted</param>
        /// <response code="204">The Reservation has been successfully deleted.</response>
        /// <response code="400">The Reservation-Id sent to the backend-server in order to deleted reservation is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id:Guid}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteReservationCommand {Id = id}).ConfigureAwait(false);
        }

        /// <summary> This endpoint is used to get a Reservation details </summary>
        /// <remarks> This endpoint allows <b>foodBusinessManager</b> to get Reservation details. </remarks>
        /// <param name="id">id of reservation that would be fetched.</param>
        /// <response code="200">The Reservation details has been successfully fetched.</response>
        /// <response code="400">The Reservation-Id sent to the backend-server in order to fetch reservation details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ReservationDto), 200)]
        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetReservationByIdQuery {ReservationId = id});
        }

        /// <summary> This endpoint is used to get a Reservations list By ReservationDateTimeInterval and FoodBusinessId </summary>
        /// <remarks> This endpoint allows <b>foodBusinessManager</b> to get a list of Reservations that have been booked at a particular <b>FoodBusiness</b> and the results will be filtred based on <b>ReservationDateTimeInterval</b>. </remarks>
        /// <param name="foodBusinessId">Id of foodBusiness which we want to get its reservations list.</param>
        /// <param name="timeIntervalStart"></param>
        /// <param name="timeIntervalEnd"></param>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of Reservations that should be returned</param>
        /// <response code="200">The list of FoodBusiness Reservations has been successfully fetched.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ReservationDto>), 200)]
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

        /// <summary> This endpoint is used to get a customer expired Reservations</summary>
        /// <remarks> This endpoint allows <b>customer</b> to get his list of expired Reservations using his <b>id</b>. </remarks>
        /// <param name="dinerUserId">id of user which would be used to get the list of expired Reservations.</param>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of Reservations that should be returned</param>
        /// <response code="200">The list of expired Reservations has been successfully fetched.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ReservationClientDto>), 200)]
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

        /// <summary> This endpoint is used to get a customer non expired Reservations</summary>
        /// <remarks> This endpoint allows <b>customer</b> to get his list of non expired Reservations using his <b>id</b>. </remarks>
        /// <param name="dinerUserId">id of user which would be used to get the list of non expired Reservations.</param>
        /// <param name="page">The start position of read pointer in a request results</param>
        /// <param name="pageSize">The max number of Reservations that should be returned</param>
        /// <response code="200">The list of non expired Reservations has been successfully fetched.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403">The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ReservationClientDto>), 200)]
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