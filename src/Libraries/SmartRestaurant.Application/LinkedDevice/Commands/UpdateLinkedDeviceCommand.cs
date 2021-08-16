using SmartRestaurant.Application.Common.Commands;
using System;
using FluentValidation;


namespace SmartRestaurant.Application.LinkedDevice.Commands
{
   public class UpdateLinkedDeviceCommand : UpdateCommand
    {
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateLinkedDeviceommandValidator : AbstractValidator<UpdateLinkedDeviceCommand>
    {
        public UpdateLinkedDeviceommandValidator()
        {
            RuleFor(v => v.IdentifierDevice).NotNull().NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }

}


