using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Dashboard.Queries
{
    public class GetMonthStatsQuery : IRequest<MonthStatsDto>
    {


    }

    public class GetMonthStatsQueryValidator : AbstractValidator<GetMonthStatsQuery>
    {
        public GetMonthStatsQueryValidator()
        {

        }
    }
}