using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Menus.Commands
{
    public class UpdateMenuCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MenuState { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}