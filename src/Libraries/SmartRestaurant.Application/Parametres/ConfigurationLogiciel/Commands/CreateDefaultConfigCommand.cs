using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Commands
{
    public class CreateDefaultConfigCommand : CreateCommand
    {
        public string Timbre { get; set; }
        public string Tva { get; set; }
        public string ModeVente { get; set; }
        public Guid Categorie { get; set; }

        public string DeviseParDefault { get; set; }
        public string MargeBenifDetail { get; set; }
        public string SommeFacture { get; set; }
        public string PointsGagner { get; set; }
        public string MargeBenifGros { get; set; }
        public bool AutorisationQteNeg { get; set; }
        public bool PrixAchatMoyPondere { get; set; }

    }

    public class CreateDefaultConfigCommandValidator : AbstractValidator<CreateDefaultConfigCommand>
    {
        public CreateDefaultConfigCommandValidator()
        {           
        }
    }
}