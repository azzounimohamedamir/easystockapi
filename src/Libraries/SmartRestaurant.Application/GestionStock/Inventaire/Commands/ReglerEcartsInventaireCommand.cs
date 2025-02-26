using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class ReglerEcartsInventaireCommand : UpdateCommand
    {
        public List<LignesInventaireFinal> Ecarts { get; set; }

    }

    public class ReglerEcartsInventaireCommandValidator : AbstractValidator<ReglerEcartsInventaireCommand>
    {
        public ReglerEcartsInventaireCommandValidator()
        {

        }
    }
}