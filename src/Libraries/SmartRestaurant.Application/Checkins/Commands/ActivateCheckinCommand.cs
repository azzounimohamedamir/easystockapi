using System;
using System.Runtime.InteropServices;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Checkins.Commands
{
    public class ActivateCheckinCommand : UpdateCommand
    {
       

    }

    public class ActivateCheckinCommandValidator : AbstractValidator<ActivateCheckinCommand>
    {
        ActivateCheckinCommandValidator()
        {
            RuleFor(c => c.Id)
                 .NotEmpty();
        }
    }
}