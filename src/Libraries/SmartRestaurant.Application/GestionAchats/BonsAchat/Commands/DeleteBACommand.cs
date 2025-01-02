using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Commands
{
    public class DeleteBACommand : DeleteCommand
    {
    }

    public class DeleteBACommandValidator : AbstractValidator<DeleteBACommand>
    {
        public DeleteBACommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}