using FluentValidation;
using MediatR;

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