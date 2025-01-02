using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetDetailVenteComptoirbyIdQuery : IRequest<VenteComptoir>
    {
        public Guid VenteComptoirId { get; set; }
    }
}