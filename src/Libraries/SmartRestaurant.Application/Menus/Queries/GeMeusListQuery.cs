using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetMenusListQuery : IRequest<PagedListDto<MenuDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string FoodBusinessId { get; set; }
    }

    public class GetMenusListQueryValidator : AbstractValidator<GetMenusListQuery>
    {
        public GetMenusListQueryValidator()
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