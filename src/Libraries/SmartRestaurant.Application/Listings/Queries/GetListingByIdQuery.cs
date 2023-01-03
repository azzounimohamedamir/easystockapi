using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using MediatR;
using System;


namespace SmartRestaurant.Application.Listings.Queries
{
    public class GetListingByIdQuery: IRequest<ListingDto>
    {
        public string Id { get; set; }
    }
    public class GetListingByIdQueryValidator : AbstractValidator<GetListingByIdQuery>
    {
        public GetListingByIdQueryValidator()
        {
            RuleFor(listing => listing.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
