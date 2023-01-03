using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Listings.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Listings.Queries
{
    public class GetListingsByHotelIdQuery:IPagedListQuery<ListingDto>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

public class GetListingsListByHotelIdQueryValidator : AbstractValidator<GetListingsByHotelIdQuery>
{
    public void GetListingsByHotelIdQueryValidator()
    {
        RuleFor(v => v.PageSize)
            .LessThanOrEqualTo(100);

        RuleFor(listing => listing.HotelId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEqual(Guid.Empty.ToString())
            .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
            .When(listing => listing.HotelId != null);
    }
}