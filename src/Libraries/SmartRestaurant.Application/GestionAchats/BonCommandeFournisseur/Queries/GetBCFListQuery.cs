using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries
{
    public class GetBCFListQuery : IRequest<PagedListDto<Domain.Entities.BonCommandeFournisseur>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
       
    }

    public class GetBCFListQueryValidator : AbstractValidator<GetBCFListQuery>
    {
        public GetBCFListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}