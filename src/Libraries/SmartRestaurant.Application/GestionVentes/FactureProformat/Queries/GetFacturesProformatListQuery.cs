using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries
{
    public class GetFacturesProListQuery : IRequest<PagedListDto<FactureProformatDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetFacturesProListQueryValidator : AbstractValidator<GetFacturesProListQuery>
    {
        public GetFacturesProListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}