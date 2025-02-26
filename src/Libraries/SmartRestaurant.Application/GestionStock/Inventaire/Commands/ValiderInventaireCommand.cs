using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

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