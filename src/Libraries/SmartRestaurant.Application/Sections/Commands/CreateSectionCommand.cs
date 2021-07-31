using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Sections.Commands
{
    public class CreateSectionCommand : IRequest<Created>
    {
        public Guid Id { get; set; }
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