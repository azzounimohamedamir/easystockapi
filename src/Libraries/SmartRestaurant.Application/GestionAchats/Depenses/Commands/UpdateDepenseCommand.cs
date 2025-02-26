using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Application.Depenses.Commands
{
    public class UpdateDepenseCommand : UpdateCommand
    {
        public TypeDepense Type { get; set; }
        public decimal Somme { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Observations { get; set; }
    }

    public class UpdateDepenseCommandValidator : AbstractValidator<UpdateDepenseCommand>
    {
        public UpdateDepenseCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}