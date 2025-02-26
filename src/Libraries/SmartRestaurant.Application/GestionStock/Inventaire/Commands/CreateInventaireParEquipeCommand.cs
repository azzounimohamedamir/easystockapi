using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class CreateInventaireParEquipeCommand : CreateCommand
    {
        public DateTime DateCreationInv { get; set; }

        public Equipe Equipe { get; set; }
        public List<LignesInventaireEquipe> Lignes { get; set; }
    }

    public class CreateInventaireParEquipeCommandValidator : AbstractValidator<CreateInventaireParEquipeCommand>
    {
        public CreateInventaireParEquipeCommandValidator()
        {


        }
    }
}