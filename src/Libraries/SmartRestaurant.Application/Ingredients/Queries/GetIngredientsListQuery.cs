using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class GetIngredientsListQuery : IRequest<PagedListDto<IngredientDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }

    public class GetIngredientsListQueryValidator : AbstractValidator<GetIngredientsListQuery>
    {
        public GetIngredientsListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}