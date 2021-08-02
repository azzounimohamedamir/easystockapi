using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class UpdateSubSectionCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }

    public class UpdateSubSectionCommandValidator : AbstractValidator<UpdateSubSectionCommand>
    {
        public UpdateSubSectionCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}