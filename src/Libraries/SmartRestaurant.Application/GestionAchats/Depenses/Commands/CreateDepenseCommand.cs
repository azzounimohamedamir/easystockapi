using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Depenses.Commands
{
    public class CreateDepenseCommand : CreateCommand
    {
        public TypeDepense Type { get; set; }
        public decimal Somme { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Observations { get; set; }
    }

    public class CreateDepenseCommandValidator : AbstractValidator<CreateDepenseCommand>
    {
        public CreateDepenseCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           
        }
    }
}