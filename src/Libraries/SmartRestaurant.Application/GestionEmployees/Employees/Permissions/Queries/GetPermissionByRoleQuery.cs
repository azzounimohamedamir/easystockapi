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
    public class GetPermissionByRoleQuery : IRequest<Domain.Identity.Entities.Permissions>
    {
        public string Role { get; set; }
      

    }

    public class GetPermissionByRoleQueryValidator : AbstractValidator<GetPermissionByRoleQuery>
    {
        public GetPermissionByRoleQueryValidator()
        {
            RuleFor(v => v.Role)
                .NotEmpty();
        }
    }
}