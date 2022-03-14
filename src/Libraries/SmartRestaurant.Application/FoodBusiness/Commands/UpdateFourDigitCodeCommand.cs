using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class UpdateFourDigitCodeCommand : UpdateCommand
    {
        public int FourDigitCode { get; set; }
    }

    public class UpdateFourDigitCodeCommandValidator : AbstractValidator<UpdateFourDigitCodeCommand>
    {
        public UpdateFourDigitCodeCommandValidator()
        {
            RuleFor(v => v.FourDigitCode).NotEmpty();
        }
    }
}