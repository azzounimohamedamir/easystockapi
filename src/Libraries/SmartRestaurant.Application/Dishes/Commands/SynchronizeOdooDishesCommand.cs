using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class SynchronizeOdooDishesCommand : IRequest<PagedListDto<DishDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string ComparisonOperator { get; set; }
        public string FoodBusinessId { get; set; }

    }

    public class SynchronizeOdooDishesCommandValidator : AbstractValidator<SynchronizeOdooDishesCommand>
    {
        public SynchronizeOdooDishesCommandValidator()
        {
            RuleFor(v => v.PageSize)
               .LessThanOrEqualTo(100);

            RuleFor(dish => dish.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
                .When(dish => dish.FoodBusinessId != null);

        }
    }
}
