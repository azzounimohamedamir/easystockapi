using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries
{
    public class GetInventoryLignesFinalListQuery : IRequest<PagedListDto<LignesInventaireFinalDto>>
    {
        public string CurrentFilter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetInventoryLignesFinalListQueryValidator : AbstractValidator<GetInventoryLignesFinalListQuery>
    {
        public GetInventoryLignesFinalListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}