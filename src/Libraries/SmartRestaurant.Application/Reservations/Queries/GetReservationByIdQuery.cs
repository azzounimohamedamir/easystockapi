using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; set; }
    }
}
