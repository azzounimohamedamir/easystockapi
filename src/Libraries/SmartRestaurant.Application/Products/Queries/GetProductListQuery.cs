using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

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
    }

    public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(v => v.PageSize)              
                .LessThanOrEqualTo(100);
        }
    }
}
