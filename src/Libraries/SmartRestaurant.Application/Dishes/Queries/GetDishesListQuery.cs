using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishesListQuery : IRequest<PagedListDto<DishDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string FoodBusinessId { get; set; }
    }

    public class GetDishesListQueryValidator : AbstractValidator<GetDishesListQuery>
    {
        public GetDishesListQueryValidator()
        {
            RuleFor(v => v.PageSize)              
                .LessThanOrEqualTo(100);

            RuleFor(dish => dish.FoodBusinessId)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .NotEqual(Guid.Empty.ToString())
                 .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
