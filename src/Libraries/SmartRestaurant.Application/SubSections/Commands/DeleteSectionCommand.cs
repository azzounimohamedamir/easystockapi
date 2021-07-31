using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.SubSections.Commands
{
    public class DeleteSubSectionCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteSubSectionCommandValidator : AbstractValidator<DeleteSubSectionCommand>
    {
        public DeleteSubSectionCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}