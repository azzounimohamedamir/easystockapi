using FluentValidation;
using MediatR;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Commands
{
    public class RegroupBlCommand : IRequest<Bl>
    {
        public DateTime Dated { get; set; }
        public DateTime Datef { get; set; }
        public Client Client { get; set; }

    }

    public class RegroupBlCommandValidator : AbstractValidator<RegroupBlCommand>
    {
        public RegroupBlCommandValidator()
        {


        }
    }
}