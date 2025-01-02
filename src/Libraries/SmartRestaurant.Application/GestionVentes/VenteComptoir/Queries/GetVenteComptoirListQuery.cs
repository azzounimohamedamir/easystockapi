using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetVenteComptoirListQuery : IRequest<PagedListDto<VenteComptoir>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
        public int Caisse { get; set; }


    }

    public class GetVenteComptoirListQueryValidator : AbstractValidator<GetVenteComptoirListQuery>
    {
        public GetVenteComptoirListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}