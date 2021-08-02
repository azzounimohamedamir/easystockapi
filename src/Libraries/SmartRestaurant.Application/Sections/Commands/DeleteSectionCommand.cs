using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class DeleteSectionCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}