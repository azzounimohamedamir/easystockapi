using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries
{
    public class GetPermissionsListQuery : IRequest<PagedListDto<Domain.Identity.Entities.Permissions>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetPermissionsListQueryValidator : AbstractValidator<GetPermissionsListQuery>
    {
        public GetPermissionsListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}