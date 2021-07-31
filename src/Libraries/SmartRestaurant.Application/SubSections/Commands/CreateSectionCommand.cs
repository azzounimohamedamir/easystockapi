using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.SubSections.Commands
{
    public class CreateSubSectionCommand : IRequest<Created>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }

    public class CreateSubSectionCommandValidator : AbstractValidator<CreateSubSectionCommand>
    {
        public CreateSubSectionCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.SectionId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}