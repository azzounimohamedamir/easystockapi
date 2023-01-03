using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.ListingDetails.Commands
{
    public class DeleteListingDetailCommand : DeleteCommand
    {

    }
    public class DeleteListingDetailCommandValidator : AbstractValidator<DeleteListingDetailCommand>
    {
         public DeleteListingDetailCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
        } 
    }
}
