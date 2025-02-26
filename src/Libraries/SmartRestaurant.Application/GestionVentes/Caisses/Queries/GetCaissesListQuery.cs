using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries
{
    public class GetCaissesListQuery : IRequest<PagedListDto<Domain.Entities.Caisses>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetCaissesListQueryValidator : AbstractValidator<GetCaissesListQuery>
    {
        public GetCaissesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}