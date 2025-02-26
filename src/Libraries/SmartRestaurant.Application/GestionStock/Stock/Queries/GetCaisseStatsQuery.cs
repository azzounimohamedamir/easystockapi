using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetCaisseStatsQuery : IRequest<CaisseDto>

    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public class GetCaisseStatsQueryValidator : AbstractValidator<GetCaisseStatsQuery>
    {
        public GetCaisseStatsQueryValidator()
        {

        }
    }
}