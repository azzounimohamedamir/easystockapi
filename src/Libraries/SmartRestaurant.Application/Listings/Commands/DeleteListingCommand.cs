using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Listings.Commands
{
    public class DeleteListingCommand : DeleteCommand
    {
    }

    public class DeleteListingCommandValidator : AbstractValidator<DeleteListingCommand>
    {
        public DeleteListingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    }