﻿using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class DeleteVenteComptoirCommand : DeleteCommand
    {
    }

    public class DeleteVenteComptoirCommandValidator : AbstractValidator<DeleteVenteComptoirCommand>
    {
        public DeleteVenteComptoirCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}