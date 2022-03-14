using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Products.Queries
{
    public class GetProductListQuery : IRequest<PagedListDto<ProductDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string ComparisonOperator { get; set; }
        public string FoodBusinessId { get; set; }

    }

    public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
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
