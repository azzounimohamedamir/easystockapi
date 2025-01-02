using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries
{
    public class GetBAListQuery : IRequest<PagedListDto<Domain.Entities.BonAchats>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
       
    }

    public class GetBAListQueryValidator : AbstractValidator<GetBAListQuery>
    {
        public GetBAListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}