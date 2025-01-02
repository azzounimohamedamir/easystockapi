using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries
{
    public class GetInventoryValidatedListQuery : IRequest<PagedListDto<InventaireDto>>
    {
        public string CurrentFilter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetInventoryValidatedListQueryValidator : AbstractValidator<GetInventoryValidatedListQuery>
    {
        public GetInventoryValidatedListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}