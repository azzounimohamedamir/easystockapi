using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class CreateHotelCommand : CreateCommand
    {
        public string FoodBusinessAdministratorId { get; set; }
        public string ImagUrl { get; set; }
        public IFormFile Picture { get; set; }

        public string Name { get; set; }
    }

    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().MinimumLength(5);
            RuleFor(hotel => hotel.ImagUrl)
                .NotEmpty().MinimumLength(10);

           

            RuleFor(hotel => hotel.FoodBusinessAdministratorId)
               .NotNull().MinimumLength(10);
              
        }
    }
}