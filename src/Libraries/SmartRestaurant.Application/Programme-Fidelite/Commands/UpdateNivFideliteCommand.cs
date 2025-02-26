using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.ProgrammeFidelite.Commands
{
    public class UpdateNivFideliteCommand : UpdateCommand
    {
        public string Nom { get; set; }
        public int MinPointsRequis { get; set; } // Nombre de points requis pour atteindre ce niveau de fidélité
        public int MaxPointsRequis { get; set; } // Nombre de points requis pour atteindre ce niveau de fidélité
        public decimal Remise { get; set; } // Remise applicable pour ce niveau de fidélité (en pourcentage)

    }

    public class UpdateNivFideliteCommandValidator : AbstractValidator<UpdateNivFideliteCommand>
    {
        public UpdateNivFideliteCommandValidator()
        {

            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}