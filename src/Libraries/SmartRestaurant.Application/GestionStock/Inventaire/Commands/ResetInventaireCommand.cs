using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class ResetInventaireCommand : UpdateCommand
    {
        public Equipe Equipe { get; set; }

    }

    public class ResetInventaireCommandValidator : AbstractValidator<ResetInventaireCommand>
    {
        public ResetInventaireCommandValidator()
        {

        }
    }
}