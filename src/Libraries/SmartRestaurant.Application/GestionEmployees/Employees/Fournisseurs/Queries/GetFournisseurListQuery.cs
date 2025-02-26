using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries
{
    public class GetFournisseurListQuery : IRequest<PagedListDto<Fournisseur>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetFournisseurListQueryValidator : AbstractValidator<GetFournisseurListQuery>
    {
        public GetFournisseurListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}