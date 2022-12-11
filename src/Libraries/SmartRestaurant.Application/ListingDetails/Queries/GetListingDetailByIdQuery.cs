using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using System;


namespace SmartRestaurant.Application.ListingDetails.Queries
{
    public class GetListingDetailByIdQuery : IRequest<ListingDetailDto>
    {
        public string Id { get; set; }
    }

    public class GetListingDetailByIdQueryValidator : AbstractValidator<GetListingDetailByIdQuery>
    {
        public GetListingDetailByIdQueryValidator()
        {
            RuleFor(l => l.Id)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .NotEmpty()
         .NotEqual(Guid.Empty.ToString())
         .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
