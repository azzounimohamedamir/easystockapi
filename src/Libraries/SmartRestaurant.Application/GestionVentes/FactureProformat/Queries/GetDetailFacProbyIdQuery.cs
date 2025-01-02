using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class GetDetailFacByIdQuery : IRequest<Facture>
    {
        public Guid BlId { get; set; }
    }
}