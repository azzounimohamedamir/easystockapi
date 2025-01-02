using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
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