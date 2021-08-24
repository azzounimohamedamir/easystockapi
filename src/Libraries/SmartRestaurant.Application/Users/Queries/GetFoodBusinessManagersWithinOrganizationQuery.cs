using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetFoodBusinessManagersWithinOrganizationQuery : IPagedListQuery<FoodBusinessManagersDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class
        GetFoodBusinessManagersWithinOrganizationValidator : AbstractValidator<
            GetFoodBusinessManagersWithinOrganizationQuery>
    {
        public GetFoodBusinessManagersWithinOrganizationValidator()
        {
            RuleFor(v => v.PageSize).LessThanOrEqualTo(100);
        }
    }
}