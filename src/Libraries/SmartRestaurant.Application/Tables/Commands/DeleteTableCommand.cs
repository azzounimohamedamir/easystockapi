using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class DeleteTableCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteTableCommandValidator : AbstractValidator<DeleteTableCommand>
    {
        public DeleteTableCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}