using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries
{
    public class GetCaissesListQuery : IRequest<PagedListDto<Domain.Entities.Caisses>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
       
    }

    public class GetCaissesListQueryValidator : AbstractValidator<GetCaissesListQuery>
    {
        public GetCaissesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}