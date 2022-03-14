using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; set; }
    }
}