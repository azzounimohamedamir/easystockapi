using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

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