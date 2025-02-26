using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries
{
    public class GetFacturebyIdBlQuery : IRequest<FactureDto>
    {
        public Guid BlId { get; set; }
    }
}