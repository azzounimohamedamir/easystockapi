using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrdersListByDinnerOrClientQuery : IRequest<PagedListDto<OrderDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public DateFilter DateInterval { get; set; }
    }

    public class GetOrdersListByDinnerOrClientQueryValidator : AbstractValidator<GetOrdersListByDinnerOrClientQuery>
    {
        public GetOrdersListByDinnerOrClientQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);

          
        }
    }
}