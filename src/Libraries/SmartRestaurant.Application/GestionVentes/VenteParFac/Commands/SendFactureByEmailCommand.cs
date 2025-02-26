using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class SendFactureByEmailCommand : CreateCommand
    {

        public string Email { get; set; }
        public string PdfLink { get; set; }
        public Guid FactureId { get; set; }

    }

    public class SendFactureByEmailCommandValidator : AbstractValidator<SendFactureByEmailCommand>
    {
        public SendFactureByEmailCommandValidator()
        {
            RuleFor(m => m.PdfLink).NotEmpty();

        }
    }
}