using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class GetListOfRegAcompteClientByFactureIdQuery : IRequest<PagedListDto<Reglement_Acompte_Facture_Client>>
    {
        public Guid ClientId { get; set; }
        public Guid FactureId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class GetListOfRegAcompteClientByFactureIdQueryValidator : AbstractValidator<GetListOfRegAcompteClientByFactureIdQuery>
    {
        public GetListOfRegAcompteClientByFactureIdQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}