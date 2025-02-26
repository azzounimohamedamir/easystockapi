using FluentValidation;
using MediatR;
using SmartRestaurant.Domain.Identity.Entities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries
{
    public class GetAllCaissiersListQuery : IRequest<List<ApplicationUser>>
    {


    }

    public class GetAllCaissiersListQueryValidator : AbstractValidator<GetAllCaissiersListQuery>
    {
        public GetAllCaissiersListQueryValidator()
        {

        }
    }
}