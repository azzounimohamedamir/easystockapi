using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Menus.Commands
{
    public class UpdateMenuCommand : SmartRestaurantCommand
    {
        public string Name { get; set; }
        public int MenuState { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}