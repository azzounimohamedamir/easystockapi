using MediatR;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetDetailVenteComptoirbyIdQuery : IRequest<VenteComptoir>
    {
        public Guid VenteComptoirId { get; set; }
    }
}