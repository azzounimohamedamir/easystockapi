using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class CreateSectionCommand : CreateCommand
    {
        public string Name { get; set; }
        public Guid MenuId { get; set; }
    }

    public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
    {
        public CreateSectionCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.MenuId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}