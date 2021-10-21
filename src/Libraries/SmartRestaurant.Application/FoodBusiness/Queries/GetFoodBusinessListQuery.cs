using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFoodBusinessListQuery : IRequest<PagedListDto<FoodBusinessDto>>
    {
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetFoodBusinessListQueryValidator : AbstractValidator<GetFoodBusinessListQuery>
    {
        public GetFoodBusinessListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}