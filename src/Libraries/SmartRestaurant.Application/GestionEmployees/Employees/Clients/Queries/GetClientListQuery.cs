using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries
{
    public class GetClientListQuery : IRequest<PagedListDto<Client>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetClientListQueryValidator : AbstractValidator<GetClientListQuery>
    {
        public GetClientListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}