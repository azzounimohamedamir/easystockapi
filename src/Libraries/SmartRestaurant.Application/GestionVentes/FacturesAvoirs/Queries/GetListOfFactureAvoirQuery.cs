using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries
{
    public class GetListOfFactureAvoirQuery : IRequest<PagedListDto<FactureAvoirDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
       
    }

    public class GetListOfFactureAvoirQueryValidator : AbstractValidator<GetListOfFactureAvoirQuery>
    {
        public GetListOfFactureAvoirQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}