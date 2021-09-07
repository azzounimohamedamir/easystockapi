using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetUsersByRoleQuery : IPagedListQuery<ApplicationUserDto>
    {
        public string Role { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetUsersByRoleQueryValidator : AbstractValidator<GetUsersByRoleQuery>
    {
        public GetUsersByRoleQueryValidator()
        {
            RuleFor(updateUser => updateUser.Role)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("'Role' can not be empty")
                    .Must(ValidatorHelper.ValidateUsersRoles).WithMessage("'Role: {PropertyValue}' is invalide");
        }
    }
}