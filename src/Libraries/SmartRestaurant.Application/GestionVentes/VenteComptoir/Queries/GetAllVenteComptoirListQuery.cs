using FluentValidation;
using MediatR;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetAllVenteComptoirListQuery : IRequest<List<VenteComptoir>>
    {



    }

    public class GetAllVenteComptoirListQueryValidator : AbstractValidator<GetAllVenteComptoirListQuery>
    {
        public GetAllVenteComptoirListQueryValidator()
        {

        }
    }
}