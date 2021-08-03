using SmartRestaurant.Application.Common.Commands;
using System;
using FluentValidation;


namespace SmartRestaurant.Application.DeviceID.Commands
{
   public class CreateDeviceIDCommand : SmartRestaurantCommand
    {
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateDeviceIDCommandValidator : AbstractValidator<CreateDeviceIDCommand>
    {
        public CreateDeviceIDCommandValidator()
        {
            RuleFor(v => v.IdentifierDevice).NotNull().NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
