﻿using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Commands
{
    public class UpdateDefaultConfigCommand : UpdateCommand
    {
#pragma warning disable CS0108 // 'UpdateDefaultConfigCommand.Id' masque le membre hérité 'UpdateCommand.Id'. Utilisez le mot clé new si le masquage est intentionnel.
        public Guid Id { get; set; }
#pragma warning restore CS0108 // 'UpdateDefaultConfigCommand.Id' masque le membre hérité 'UpdateCommand.Id'. Utilisez le mot clé new si le masquage est intentionnel.

        public string Timbre { get; set; }
        public string Tva { get; set; }
        public decimal SommeFacture { get; set; }
        public decimal PointsGagner { get; set; }
        public string ModeVente { get; set; }
        public Guid Categorie { get; set; }
        public decimal Recompense { get; set; }

        public string DeviseParDefault { get; set; }
        public string MargeBenifDetail { get; set; }
        public string MargeBenifGros { get; set; }
        public bool AutorisationQteNeg { get; set; }
        public bool PrixAchatMoyPondere { get; set; }
        public decimal MinimumPointsToWithdraw { get; set; }

    }

    public class UpdateDefaultConfigCommandValidator : AbstractValidator<UpdateDefaultConfigCommand>
    {
        public UpdateDefaultConfigCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}