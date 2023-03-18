using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Products.Commands
{
    public class SynchronizeOdooProductsCommand : IRequest<PagedListDto<ProductDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string ComparisonOperator { get; set; }
        public string FoodBusinessId { get; set; }

    }

    public class SynchronizeOdooProductsCommandValidator : AbstractValidator<SynchronizeOdooProductsCommand>
    {
        public SynchronizeOdooProductsCommandValidator()
        {
            RuleFor(v => v.PageSize)
               .LessThanOrEqualTo(100);

            RuleFor(product => product.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
                .When(product => product.FoodBusinessId != null);

        }
    }
}
