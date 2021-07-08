using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class UpdateSubSectionCommand : SmartRestaurantCommand
    {
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }

    public class UpdateSubSectionCommandValidator : AbstractValidator<UpdateSubSectionCommand>
    {
        public UpdateSubSectionCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.SectionId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}