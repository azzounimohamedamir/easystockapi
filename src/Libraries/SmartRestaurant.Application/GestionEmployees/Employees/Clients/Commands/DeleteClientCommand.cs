﻿using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.Clients.Commands
{
    public class DeleteClientCommand : DeleteCommand
    {
    }

    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}