using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class ValiderInventaireCommand : UpdateCommand
    {
       public Domain.Entities.Inventaire Inventaire { get; set; }

    }

    public class ValiderInventaireCommandValidator : AbstractValidator<ValiderInventaireCommand>
    {
        public ValiderInventaireCommandValidator()
        {
           
        }
    }
}