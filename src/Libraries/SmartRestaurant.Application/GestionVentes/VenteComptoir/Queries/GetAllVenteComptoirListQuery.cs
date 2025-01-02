using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

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