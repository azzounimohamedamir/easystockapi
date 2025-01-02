using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

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