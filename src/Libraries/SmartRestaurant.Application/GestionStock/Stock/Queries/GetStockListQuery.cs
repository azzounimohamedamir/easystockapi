using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetStockListQuery : IRequest<PagedListDto<StockDto>>
    {
        public string CurrentFilter { get; set; }
        public string FilterCategory { get; set; }
        public List<AttributesWithTheirValuesDto> FilterCriteriaData { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetStockListQueryValidator : AbstractValidator<GetStockListQuery>
    {
        public GetStockListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}