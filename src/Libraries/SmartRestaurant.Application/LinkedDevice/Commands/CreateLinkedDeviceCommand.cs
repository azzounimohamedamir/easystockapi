using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.LinkedDevice.Commands
{
    public class CreateLinkedDeviceCommand : CreateCommand
    {
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateLinkedDeviceCommandValidator : AbstractValidator<CreateLinkedDeviceCommand>
    {
        public CreateLinkedDeviceCommandValidator()
        {
            RuleFor(v => v.IdentifierDevice).NotNull().NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}