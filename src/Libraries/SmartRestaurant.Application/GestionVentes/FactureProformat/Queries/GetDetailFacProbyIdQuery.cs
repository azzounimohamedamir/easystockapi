using MediatR;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class GetDetailFacByIdQuery : IRequest<Facture>
    {
        public Guid BlId { get; set; }
    }
}