using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class GetFacturesListQuery : IPagedListQuery<FactureDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
        public int Caisse { get; set; }

    }
   

    public class GetFacturesListQueryValidator : AbstractValidator<GetFacturesListQuery>
    {
        public GetFacturesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}