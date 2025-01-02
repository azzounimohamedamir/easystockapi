using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Commands
{
    public class UpdateCaisseCommand : UpdateCommand
    {
        public int? Numero { get; set; }
        public bool? Status { get; set; }
        public string Vendeur { get; set; }
        public decimal? SoldeJ { get; set; }
        public decimal? SoldeM { get; set; }

    }

    public class UpdateCaisseCommandValidator : AbstractValidator<UpdateCaisseCommand>
    {
        public UpdateCaisseCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           
        }
    }
}