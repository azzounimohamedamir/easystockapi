using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries
{
    public class GetCreancesAssainiesListQuery : IRequest<PagedListDto<CreanceAssainie>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetCreancesAssainiesListQueryValidator : AbstractValidator<GetCreancesAssainiesListQuery>
    {
        public GetCreancesAssainiesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}
