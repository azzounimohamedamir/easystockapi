using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class ReglerEcartsInventaireCommand : UpdateCommand
    {
       public List<LignesInventaireFinal>  Ecarts { get; set; }

    }

    public class ReglerEcartsInventaireCommandValidator : AbstractValidator<ReglerEcartsInventaireCommand>
    {
        public ReglerEcartsInventaireCommandValidator()
        {
           
        }
    }
}