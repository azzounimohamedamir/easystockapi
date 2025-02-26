using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries
{
    public class GetListOfRetourProduitsQuery : IRequest<PagedListDto<RetourProduitClient>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class GetListOfRetourProduitsQueryValidator : AbstractValidator<GetListOfRetourProduitsQuery>
    {
        public GetListOfRetourProduitsQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}