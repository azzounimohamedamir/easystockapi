using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

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