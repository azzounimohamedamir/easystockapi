using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Menus.Commands
{
    public class CreateMenuCommand : IRequest<Created>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MenuState { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.FoodBusinessId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}