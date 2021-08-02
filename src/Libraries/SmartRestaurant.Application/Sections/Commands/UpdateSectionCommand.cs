using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class UpdateSectionCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
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