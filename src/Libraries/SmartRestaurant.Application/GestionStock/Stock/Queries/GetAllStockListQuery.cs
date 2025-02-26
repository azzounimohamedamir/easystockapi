using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetAllStockListQuery : IRequest<List<StockDto>>
    {

    }

    public class GetAllStockListQueryValidator : AbstractValidator<GetAllStockListQuery>
    {
        public GetAllStockListQueryValidator()
        {

        }
    }
}