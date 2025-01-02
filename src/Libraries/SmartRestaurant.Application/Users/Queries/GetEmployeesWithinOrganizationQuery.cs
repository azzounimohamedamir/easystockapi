using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetEmployeesWithinOrganizationQuery : IPagedListQuery<EmployeDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class
        GetEmployeesWithinOrganizationQueryValidator : AbstractValidator<
            GetEmployeesWithinOrganizationQuery>
    {
        public GetEmployeesWithinOrganizationQueryValidator()
        {
            RuleFor(v => v.PageSize).LessThanOrEqualTo(100);
        }
    }
}