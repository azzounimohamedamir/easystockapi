using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

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