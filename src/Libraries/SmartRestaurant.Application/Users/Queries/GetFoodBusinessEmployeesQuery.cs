using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using FluentValidation;
using System;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetFoodBusinessEmployeesQuery : IPagedListQuery<FoodBusinessEmployeesDtos>
    {
        public string FoodBusinessId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class GetFoodBusinessEmployeesValidator : AbstractValidator<GetFoodBusinessEmployeesQuery>
    {

        private bool ValidateGuid(string input)
        {
            return Guid.TryParse(input, out var newGuid);
        }

        public GetFoodBusinessEmployeesValidator()
        {
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty.ToString()).Must(ValidateGuid);
            RuleFor(v => v.PageSize).LessThanOrEqualTo(100);


        }
    }
}