using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetHotelsManagersWithinOrganizationQuery : IPagedListQuery<HotelsManagersDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class
        GetHotelsManagersWithinOrganizationValidator : AbstractValidator<
            GetHotelsManagersWithinOrganizationQuery>
    {
        public GetHotelsManagersWithinOrganizationValidator()
        {
            RuleFor(v => v.PageSize).LessThanOrEqualTo(100);
        }
    }
}