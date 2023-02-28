using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
namespace SmartRestaurant.Application.Hotels.Queries
{
    public class GetHotelByIdQuery : IRequest<HotelDto>
    {
        public Guid Id { get; set; }
    }
}