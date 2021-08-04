using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class UpdateSectionCommand : UpdateCommand
    {
        public string Name { get; set; }
        public Guid MenuId { get; set; }
    }

    public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.MenuId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}