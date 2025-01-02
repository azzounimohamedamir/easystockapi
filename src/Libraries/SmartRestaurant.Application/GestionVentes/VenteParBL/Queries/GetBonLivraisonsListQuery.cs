using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries
{
    public class GetBonLivraisonsListQuery : IRequest<PagedListDto<Bl>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
        public int Caisse { get; set; }
       
    }

    public class GetBonLivraisonsListQueryValidator : AbstractValidator<GetBonLivraisonsListQuery>
    {
        public GetBonLivraisonsListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}