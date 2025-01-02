using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Rapports.MvtStock.Queries
{
    public class GetMvtStockListQuery : IRequest<PagedListDto<Domain.Entities.MouvementStock>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Type { get; set; }
        public string CurrentFilter { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

    }

    public class GetMvtStockListQueryValidator : AbstractValidator<GetMvtStockListQuery>
    {
        public GetMvtStockListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}