using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.HotelSections.Queries
{
    public class GetSectionsListByHotelIdQuery : IPagedListQuery<HotelSectionDto>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }

    public class GetSectionsListByHotelIdQueryValidator : AbstractValidator<GetSectionsListByHotelIdQuery>
    {
        public GetSectionsListByHotelIdQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);

            RuleFor(hotelSection => hotelSection.HotelId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
                .When(hotelSection => hotelSection.HotelId != null);
        }
    }
}
