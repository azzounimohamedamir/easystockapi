using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetHotelEmployeesQuery : IPagedListQuery<HotelEmployeesDtos>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class GetHotelEmployeesValidator : AbstractValidator<GetHotelEmployeesQuery>
    {
        public GetHotelEmployeesValidator()
        {
            RuleFor(v => v.HotelId).NotEmpty().NotEqual(Guid.Empty.ToString()).Must(ValidateGuid);
            RuleFor(v => v.PageSize).LessThanOrEqualTo(100);
        }

        private bool ValidateGuid(string input)
        {
            return Guid.TryParse(input, out var newGuid);
        }
    }
}