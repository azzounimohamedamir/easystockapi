using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Commands
{
    public class CreateCaisseCommand : CreateCommand
    {
        public decimal Numero { get; set; }
        public bool Status { get; set; }
        public string Vendeur { get; set; }
        public string UserId { get; set; }


    }

    public class CreateCaisseCommandValidator : AbstractValidator<CreateCaisseCommand>
    {
        public CreateCaisseCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           

        }
    }
}